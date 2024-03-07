using SmsService.Models;

namespace SmsService.Services
{
    public class ContextService
    {
        private readonly MessageContext _context;
        public ContextService(MessageContext context)
        {
            _context = context;
        }

       
    }
}
