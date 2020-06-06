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
    [Route("[controller]/")]
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

        [HttpGet("/send.{format}"), FormatFilter]
        async public Task<IActionResult> SendSMS(string from, string to, string text)
        {
            var sendSmsCommand = new SendSMSCommand()
            {
                From = from,
                To = to,
                Text = text
            };
            var result = await mediator.Send(sendSmsCommand);

            //state: enum (Success, Failed)
            return Ok(Enum.GetName(typeof(RequestResult), result));
        }

        [HttpGet("/sent.{format}"), FormatFilter]
        async public Task<IActionResult> GetSentSMS(DateTime dateTimeFrom, DateTime dateTimeTo, int skip, int take)
        {
            //totalCount: int[the total count of all items matching the filter]
            //-items: array of SMS o dateTime: dateTime[the date and time the SMS was sent, format:
            //“yyyy - MMddTHH:mm: ss, UTC]
            // -> mcc: string[the mobile country code of the country
            //where the receiver of the SMS belongs to]
            // -> from: string[the sender of the SMS] -> to: string[the
            //receiver of the SMS]
            // ->  price: decimal [the price of the SMS in EUR, e.g. 0.06] 
            // -> state: enum (Success, Failed) 
            var result = await SMSQuieries.GetSentSMSAsync(dateTimeFrom, dateTimeTo, skip, take);
            return Ok(result);
        }
    }
}
