using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SmsService.Model.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace SmsService.Model
{
    public class SMSContext : DbContext
    {
        public SMSContext(DbContextOptions<SMSContext> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CountryCodes>().HasData(
                new CountryCodes("Germany", 262, "49", new decimal(0.055)),
                new CountryCodes("Austria", 232, "43", new decimal(0.053)),
                new CountryCodes("Poland", 260, "48", new decimal(0.032))
                );
        }


        public DbSet<SMSMessage> SMSMessages { get; private set; }
        public DbSet<CountryCodes> CountryCodes { get; private set; }


    }
}
