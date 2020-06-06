using Dapper;
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
    public class StatisticsQueries : IStatisticsQueries
    {
        readonly IConfiguration configuration;
        public StatisticsQueries(IConfiguration Configuration)
        {
            configuration = Configuration;
        }
        async public Task<dynamic> GetStatisticsAsync(DateTime dtFrom, DateTime dtTo, IList<string> mmcList)
        {
            using var connection = new MySqlConnection(configuration["ConnectionString"]);
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@dateFrom", dtFrom, DbType.Date);
            dynamicParameters.Add("@dateTo", dtTo, DbType.Date);
            string inMCCList = "";
            if (mmcList.Count > 0)
            {
                dynamicParameters.Add("@mccs", mmcList);
                inMCCList = "AND s.MCC IN @mccs";
            }

            var sqlQuery = "SELECT date(s.CreatedDateTime) AS day1, s.MCC AS mcc, cc.Price AS pricePerSMS," +
                "COUNT(*) AS count1, SUM(s.Price) AS totalPrice " +
                "FROM SMSMessages s " +
                "JOIN CountryCodes cc ON s.MCC = cc.MCC " +
                $"WHERE s.IsSent AND (date(s.CreatedDateTime) BETWEEN date(@dateFrom) AND date(@dateTo)) {inMCCList} " +
                "GROUP BY date(s.CreatedDateTime), s.MCC";

            var _result = await connection.QueryAsync(sqlQuery, dynamicParameters);

            return _result.Select(x =>
            {
                var row = (IDictionary<string, object>)x;
                return new StatisticsDTO
                {
                    day = Convert.ToDateTime(row["day1"]).ToString("yyyy-MM-dd"),
                    count = Convert.ToInt32(row["count1"]),
                    mcc = row["mcc"].ToString(),
                    pricePerSms = Convert.ToDecimal(row["pricePerSMS"]),
                    totalPrice = Convert.ToDecimal(row["totalPrice"])
                };
            });
        }
    }
}
