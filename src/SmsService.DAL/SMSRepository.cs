using Microsoft.EntityFrameworkCore;
using SmsService.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsService.Model
{
    public class SMSRepository : ISMSRepository
    {
        private readonly SMSContext context;
        public SMSRepository(SMSContext Context)
        {
            this.context = Context;
        }

        public void AddSMSMessage(SMSMessage SMS)
        {
            context.SMSMessages.Add(SMS);
            context.SaveChanges();
        }

       async public Task<ICountryCodes> GetCountryByCountryCodeAsync(string countryCode)
        {
            return await context.CountryCodes.SingleOrDefaultAsync(x => x.CountryCode == countryCode);
        }
    }
}
