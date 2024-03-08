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

        public async Task<SmsMessage> AddMessageToDbFromGr(SmsMessage message)
        {
            if (message != null)
            {
                var entryToAdd = new SmsMessage
                {
                    Id = message.Id,
                    Message = message.Message,
                    PhoneNumber = message.PhoneNumber,
                    Country = Constants.Constants.entryforGreece
                };
                _context.Messages.Add(entryToAdd);
                await _context.SaveChangesAsync();

            }
            return new SmsMessage();
        }

        public async Task<SmsMessage> AddMessageToDbFromCY(SmsMessage message)
        {
            if (message != null)
            {
                var entryToAdd = new SmsMessage
                {
                    Id = message.Id,
                    Message = message.Message,
                    PhoneNumber = message.PhoneNumber,
                    Country = Constants.Constants.entryforCyprus
                };
                _context.Messages.Add(entryToAdd);
                await _context.SaveChangesAsync();

            }
            return new SmsMessage();
        }

        public async Task<SmsMessage> AddMessageToDbFromRest(SmsMessage message)
        {
            if (message != null)
            {
                var entryToAdd = new SmsMessage
                {
                    Id = message.Id,
                    Message = message.Message,
                    PhoneNumber = message.PhoneNumber,
                    Country = Constants.Constants.entryforOther
                };
                 _context.Messages.Add(entryToAdd);
                await _context.SaveChangesAsync();

            }
            return new SmsMessage();
        }
    }
}
