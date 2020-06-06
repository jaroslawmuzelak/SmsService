using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmsService.Services.Commands
{
    public class SendSMSCommand : IRequest<bool>
    {
        public string Text { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        
    }
}
