using System.ComponentModel.DataAnnotations;

namespace SmsService.Models
{
    public class SmsMessage
    {
        [Key]
        public int Id { get; set; }

        public string Message { get; set; }

        public string PhoneNumber { get; set; }
    }
}
