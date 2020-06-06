using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using SmsService.Services.Queries.Abstract;
using SmsService.Services.Queries.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace SmsService.Services.Queries
{
    public class CountriesQueries : ICountriesQueries
    {
        readonly IConfiguration configuration;
        public CountriesQueries(IConfiguration Configuration)
        {
            configuration = Configuration;
        }
        async public Task<dynamic> GetCountriesAsync()
        {
            using var connection = new MySqlConnection(configuration["ConnectionString"]);

            return await connection.QueryAsync<CountryDTO>("SELECT MCC as mcc, CountryCode as cc, Country as name, Price as pricePerSMS FROM CountryCodes");
        }
    }
}
