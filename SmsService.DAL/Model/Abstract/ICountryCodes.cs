using System;
using System.Collections.Generic;
using System.Text;

namespace SmsService.Model.Model
{
    public interface ICountryCodes
    {
        public string Country { get; }
        public short MCC { get; }
        public string CountryCode { get; }
        public decimal Price { get; }
    }
}
