using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmsService.Services.Queries.Abstract
{
    public interface IStatisticsQueries
    {
        Task<dynamic> GetStatisticsAsync(DateTime dtFrom, DateTime dtTo, IList<string> mmcList);
    }
}
