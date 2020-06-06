using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmsService.Services.Queries.Abstract
{
    public interface ISMSQueries
    {
        Task<dynamic> GetSentSMSAsync(DateTime dtFrom, DateTime dtTo, int skip, int take);
    }
}
