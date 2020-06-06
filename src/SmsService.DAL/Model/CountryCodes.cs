using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmsService.Model.Model
{
    public class CountryCodes : ICountryCodes
    {
        [Key]
        public short MCC { get; private set; }
        [Required, MaxLength(10)]
        public string CountryCode { get; private set; }
        [Required, MaxLength(100)]
        public string Country { get; private set; }
        [Required, Column(TypeName="decimal(5,3)")]
        public decimal Price { get; private set; }

        private CountryCodes()
        {

        }
        public CountryCodes(string country, short mmc, string countryCode, decimal price)
        {
            Country = country;
            MCC = mmc;
            CountryCode = countryCode;
            Price = price;
        }

    }
}
