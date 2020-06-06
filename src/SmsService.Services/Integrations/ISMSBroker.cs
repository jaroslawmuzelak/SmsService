using SmsService.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmsService.Services.Integrations
{
    public interface ISMSBroker
    {
        Task<bool> SendSMSMessage(SMSMessage message);
    }
}
