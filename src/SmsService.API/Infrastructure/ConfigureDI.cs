using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using SmsService.Model;
using SmsService.Services.Integrations;
using SmsService.Services.Queries;
using SmsService.Services.Queries.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmsService.API.Infrastructure
{
    static class ConfigureDI
    {
        internal static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<ISMSRepository, SMSRepository>();
            services.AddTransient<ISMSBroker, SMSBroker>();
            services.AddTransient<ICountriesQueries, CountriesQueries>();
            services.AddTransient<ISMSQueries, SMSQueries>();
            services.AddTransient<IStatisticsQueries, StatisticsQueries>();

            return services;
        }
    }
}
