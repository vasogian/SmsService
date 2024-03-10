using SmsService.Infrastructure;
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

        public async Task<SmsMessage> PersistMessageToDb(SmsMessage message)
        {
            if (message != null)
            {
                _context.Messages.Add(message); //persists entry to db
                await _context.SaveChangesAsync();

            }
            return new SmsMessage();
        }

        public async Task<List<SmsMessage>> PersistMessageToDbForCypriotMessages(List<SmsMessage> messages)
        {
            if (messages != null)
            {
                _context.Messages.AddRange(messages); //persists entries for multiple cypriot messages to db
                await _context.SaveChangesAsync();

            }
            return new List<SmsMessage>();
        }

    }
}
