using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using SmsService.API.Common;
using SmsService.Services.Commands;
using SmsService.Services.Queries.Abstract;

namespace SmsService.API.Controllers
{
    [ApiController]
    public class SMSController : ControllerBase
    {
        readonly IMediator mediator;
        readonly ISMSQueries SMSQuieries;
        public SMSController(IMediator mediator, ISMSQueries SMSQueries)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.SMSQuieries = SMSQueries ?? throw new ArgumentException(nameof(SMSQueries));
        }

        [HttpGet("sms/send.{format}"), FormatFilter]
        async public Task<IActionResult> Get(string from, string to, string text)
        {
            var sendSmsCommand = new SendSMSCommand()
            {
                From = from,
                To = to,
                Text = text
            };
            var result = await mediator.Send(sendSmsCommand);

            return Ok(Enum.GetName(typeof(RequestResult), result));
        }

        [HttpGet("sms/sent.{format}"), FormatFilter]
        async public Task<IActionResult> Get(DateTime dateTimeFrom, DateTime dateTimeTo, int skip, int take)
        { 
            var result = await SMSQuieries.GetSentSMSAsync(dateTimeFrom, dateTimeTo, skip, take);
            return Ok(result);
        }
    }
}
