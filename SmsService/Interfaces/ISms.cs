using Microsoft.AspNetCore.Mvc;
using SmsService.Models;

namespace SmsService.Interfaces
{
    public interface ISms
    {
        public string Message { get; set; }
        public string PhoneNumber { get; set; }
        public ActionResult<SmsMessage> SendMessage(SmsMessage message);
    }
}
