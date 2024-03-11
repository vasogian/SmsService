using Microsoft.EntityFrameworkCore;
using SmsService.Models;

namespace SmsService.Infrastructure
{
    public class MessageContext : DbContext
    {
        public MessageContext(DbContextOptions<MessageContext> options)
           : base(options)
        {
        }
        public DbSet<SmsMessage> Messages { get; set; }

    }
}
