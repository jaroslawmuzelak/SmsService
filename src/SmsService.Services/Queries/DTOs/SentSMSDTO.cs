using System;
using System.Collections.Generic;
using System.Text;

namespace SmsService.Services.Queries.DTOs
{
    class SentSMSDTO
    {
        public string dateTime { get; set; }
        public string mcc { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public decimal price { get; set; }
        public string state { get; set; }

    }
}
