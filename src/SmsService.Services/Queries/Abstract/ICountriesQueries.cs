using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmsService.Services.Queries.Abstract
{
    public interface ICountriesQueries
    {
        Task<dynamic> GetCountriesAsync();
    }
}
