using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmsService.Services.Queries.Abstract;

namespace SmsService.API.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IStatisticsQueries statisticsQueries;
        private readonly ICountriesQueries countriesQueries;

        public HomeController(IStatisticsQueries StatisticsQueries, ICountriesQueries CountriesQueries)
        {
            statisticsQueries = StatisticsQueries ?? throw new ArgumentNullException(nameof(StatisticsQueries));
            countriesQueries = CountriesQueries ?? throw new ArgumentNullException(nameof(CountriesQueries));
        }


        [HttpGet("/countries.{format}"), FormatFilter]
        async public Task<IActionResult> GetCountries()
        {
            var result = await countriesQueries.GetCountriesAsync();
            return Ok(result);
        }

        [HttpGet("/statistics.{format}"), FormatFilter]
        async public Task<IActionResult> GetStatistics(DateTime dateFrom, DateTime dateTo,[FromQuery] IList<string> mccList)
        {
            var result = await statisticsQueries.GetStatisticsAsync(dateFrom, dateTo, mccList);
            return Ok(result);
        }

    }
}
