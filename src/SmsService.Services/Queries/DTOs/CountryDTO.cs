using System;
using System.Collections.Generic;
using System.Text;

namespace SmsService.Services.Queries.DTOs
{
    class CountryDTO
    {
        public string mcc { get; set; }
        public string cc { get; set; }
        public string name { get; set; }
        public decimal pricePerSMS { get; set; }
    }
}
