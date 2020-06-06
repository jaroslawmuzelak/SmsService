using Microsoft.Extensions.Logging;
using SmsService.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmsService.Services.Integrations
{
    public class SMSBroker : ISMSBroker
    {
        readonly ILogger<SMSBroker> logger;
        public SMSBroker(ILogger<SMSBroker> Logger)
        {
            logger = Logger;
        }
        public Task<bool> SendSMSMessage(SMSMessage message)
        {

            var rand = new Random().NextDouble() > 0.1; //simulate ~10% failed sent sms
            if (rand)
            {
                logger.LogInformation($"[SENT] {message}");
            }
            else
            {
                logger.LogInformation($"[FAILED] {message}");
            }

            return Task.FromResult(rand); 
        }
    }
}
