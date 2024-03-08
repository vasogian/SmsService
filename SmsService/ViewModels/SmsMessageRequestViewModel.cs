using System.ComponentModel.DataAnnotations;

namespace SmsService.ViewModels
{
    public class SmsMessageRequestViewModel
    {
        public int Id { get; set; }
        public string Message { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
    }
}