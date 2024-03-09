using System.ComponentModel.DataAnnotations;
using SmsService.ConstValues;

namespace SmsService.Models
{
    public class SmsMessage
    {
        [Key]
        public int Id { get; set; }      
        public string Message { get; set; } 
        [Phone]
        public string PhoneNumber { get; set; }
        [MaxLength(ConstValues.Constants.maxSmsMessageLength)]
        public string? Country { get; set; }
    }
}
