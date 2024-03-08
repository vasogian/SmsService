using Microsoft.EntityFrameworkCore;

namespace SmsService.Models
{
    public class MessageContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public MessageContext(DbContextOptions<MessageContext> options)
           : base(options)
        {
        }
        public DbSet<SmsMessage>? Messages { get; set; }
      
    }
}
