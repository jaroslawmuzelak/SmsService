using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Text;

namespace SmsService.Model.Model
{
    public class SMSMessage : ISMSMessage
    {
        public long Id { get; private set; }
        [Required, MaxLength(500)]
        public string Content { get; private set; }
        [Required]
        public DateTime SendDateTime { get; private set; }
        [Required]
        public DateTime CreatedDateTime { get; private set; } = DateTime.UtcNow;
        [Required]
        public bool IsSent { get; private set; } = false;
        public int MCC { get; private set; }
        [Required, MaxLength(100)]
        public string Sender { get; private set; }
        [Required, MaxLength(20)]
        public string Receiver { get; private set; }
        [Required, Column(TypeName = "decimal(5,3)")]
        public decimal Price { get; private set; } = 0;

        private SMSMessage()
        {

        }
        public SMSMessage(string from, string to, string content, int mmc)
        {
            this.Sender = from;
            this.Receiver = to;
            this.Content = content;
            this.MCC = mmc;
        }

        public void MarkAsSent(decimal price)
        {
            this.Price = price;
            this.IsSent = true;
            this.SendDateTime = DateTime.UtcNow;
        }

        public override string ToString()
        {
            return $"Message from {this.Sender} to {this.Receiver} [MMC: {this.MCC}]";
        }

    }
}
