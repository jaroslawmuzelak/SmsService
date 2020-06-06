using Dapper;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using SmsService.Services.Queries.Abstract;
using SmsService.Services.Queries.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsService.Services.Queries
{
    public class SMSQueries : ISMSQueries
    {
        readonly IConfiguration configuration;
        public SMSQueries(IConfiguration Configuration)
        {
            configuration = Configuration;
        }

        async public Task<dynamic> GetSentSMSAsync(DateTime dtFrom, DateTime dtTo, int skip, int take)
        {
            using var connection = new MySqlConnection(configuration["ConnectionString"]);
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@dateFrom", dtFrom,DbType.DateTime);
            dynamicParameters.Add("@dateTo", dtTo, DbType.DateTime);
            dynamicParameters.Add("@skip", skip, DbType.Int16);
            dynamicParameters.Add("@take", take, DbType.Int16);
            var _items = await connection.QueryAsync($"SELECT s.Price as price, s.CreatedDateTime AS dateTime, s.MCC AS mcc, s.Sender AS from1, s.Receiver AS to1, IF(s.IsSent = 1, 'Success', 'Failed') AS state1 FROM SMSMessages s " +
                $"WHERE s.CreatedDateTime BETWEEN @dateFrom AND @dateTo LIMIT @skip,@take", dynamicParameters);

            return new
            {
                totalCount = _items.Count(),
                items = _items.Select(x =>
                {

                    var row = (IDictionary<string, object>)x;
                    return new SentSMSDTO
                    {
                        dateTime = Convert.ToDateTime(row["dateTime"]).ToString("yyyy-MMddTHH:mm:ss"),
                        from = row["from1"].ToString(),
                        to = row["to1"].ToString(),
                        mcc = row["mcc"].ToString(),
                        price = Convert.ToDecimal(row["price"]),
                        state = row["state1"].ToString()
                    };
                }),
            };
        }
    }
}
