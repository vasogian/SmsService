using SmsService.Infrastructure;
using SmsService.Models;
using SmsService.Interfaces;

namespace SmsService.Services
{


    public class ContextService : IContextService
    {
        private readonly MessageContext _context;
        public ContextService(MessageContext context)
        {
            _context = context;
        }

        public async Task<SmsMessage> PersistMessageToDb(SmsMessage? message)
        {
            if (message != null)
            {
                var entityToAdd = _context.Messages.Add(message); //persists entry to db
                await _context.SaveChangesAsync();
                return entityToAdd.Entity;
            }

            return new SmsMessage();
        }

        public async Task<int> PersistMessageToDbForCypriotMessages(List<SmsMessage> messages)
        {
            if (messages.Count > 0)
            {
                _context.Messages.AddRange(messages); //persists entries for multiple cypriot messages to db
                int rowsAffected = await _context.SaveChangesAsync();

                return rowsAffected;
            }

            return default;
        }

    }
}
