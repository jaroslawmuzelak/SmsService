using System;
using System.Collections.Generic;
using System.Text;

namespace SmsService.Model.Model
{
    public interface ISMSMessage
    {
        public string Content { get; }
        public DateTime SendDateTime { get; }
        public DateTime CreatedDateTime { get; }
        public bool IsSent { get; }
        public int MCC { get; }
        public string Sender { get; }
        public string Receiver { get; }
        public decimal Price { get; }
    }
}
