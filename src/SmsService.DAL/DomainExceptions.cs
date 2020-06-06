using System;
using System.Collections.Generic;
using System.Text;

namespace SmsService.Model
{
    public static class DomainExceptions
    {
        public class CountryCodeNotSupportedException : Exception
        {
            public CountryCodeNotSupportedException(string message) : base(message) { }
        }
    }
}
