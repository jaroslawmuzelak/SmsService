using System;
using System.Collections.Generic;
using System.Text;

namespace SmsService.Services.Queries.DTOs
{
    class StatisticsDTO
    {
        public string day { get; set; }
        public string mcc { get; set; }
        public decimal pricePerSms { get; set; }
        public int count { get; set; }
        public decimal totalPrice { get; set; }
    }
}
