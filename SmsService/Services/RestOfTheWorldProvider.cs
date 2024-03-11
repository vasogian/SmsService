using SmsService.Interfaces;
using SmsService.Models;

namespace SmsService.Services
{
    public class RestOfTheWorldProvider : IProvider
    {
        private readonly IContextService _contextService;
        public RestOfTheWorldProvider(IContextService contextService)
        {
            _contextService = contextService;

        }
        public async Task<List<SmsMessage>> Send(SmsMessage message)
        {
            if (message.PhoneNumber.StartsWith("+30") ||
                message.PhoneNumber.StartsWith("+357"))
            {
                return new List<SmsMessage>();
            }

            var messagesForRestList = new List<SmsMessage>();
            message.Country = ConstValues.Constants.entryforOther;
            var messagedAdded = await _contextService.PersistMessageToDb(message);

            messagesForRestList.Add(messagedAdded);

            return messagesForRestList;
        }
    }
}
