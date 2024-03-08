using Microsoft.AspNetCore.Mvc;
using SmsService.Interfaces;
using SmsService.Models;

namespace SmsService.Services
{
    public class SMSVendorCY //: ISms
    {
        //public string Message { get; set; }
        //public string PhoneNumber { get; set; }
        private readonly ContextService _contextService;
        public SMSVendorCY(ContextService contextService)
        {
            _contextService = contextService;

        }
        public async Task<SmsMessage> SendMessage(SmsMessage message)
        {
            if (message == null)
            {
                return new SmsMessage();

            }
            await _contextService.AddMessageToDbFromCY(message);

            return message;
        }
    }
}
