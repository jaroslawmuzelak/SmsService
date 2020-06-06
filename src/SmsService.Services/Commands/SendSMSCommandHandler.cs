using MediatR;
using SmsService.Model;
using SmsService.Model.Model;
using SmsService.Services.Integrations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmsService.Services.Commands
{
    public class SendSMSCommandHandler : IRequestHandler<SendSMSCommand, bool>
    {
        readonly ISMSBroker SMSBroker;
        private readonly ISMSRepository SMSRepository;

        public SendSMSCommandHandler(ISMSBroker smsBroker, ISMSRepository smsRepository)
        {
            SMSBroker = smsBroker;
            SMSRepository = smsRepository;
        }

        public async Task<bool> Handle(SendSMSCommand request, CancellationToken cancellationToken)
        {
            var country = await SMSRepository.GetCountryByCountryCodeAsync(request.To.Substring(1, 2))
                ?? throw new DomainExceptions.CountryCodeNotSupportedException($"Missing country code for {request.To} destination");

            var message = new SMSMessage(request.From, request.To, request.Text, country.MCC);
            if (await SMSBroker.SendSMSMessage(message))
            {
                message.MarkAsSent(country.Price);
            }

            SMSRepository.AddSMSMessage(message);

            return message.IsSent;
        }
    }
}
