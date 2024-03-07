using Microsoft.AspNetCore.Mvc;
using SmsService.Interfaces;
using SmsService.Models;

namespace SmsService.Services
{
    public class SMSVendorGR : ISms
    {
        public string Message { get; set; }
        public string PhoneNumber { get; set; }

        public ActionResult<SmsMessage> SendMessage(SmsMessage message)
        {
            if (message == null)
            {
                return new SmsMessage();
            }
            return message;

        }

    }
}
