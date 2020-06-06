using SmsService.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmsService.Model
{
    public interface ISMSRepository
    {
        public void AddSMSMessage(SMSMessage SMS);
        public Task<ICountryCodes> GetCountryByCountryCodeAsync(string countryCode);

    }
}
