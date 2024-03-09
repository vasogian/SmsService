using System.ComponentModel.DataAnnotations;

namespace SmsService.ViewModels
{
    public class SmsMessageRequestViewModel
    {
        [MaxLength(Constants.Constants.maxSmsMessageLength)]
        public string Message { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
    }
}