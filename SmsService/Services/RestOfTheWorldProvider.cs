using Microsoft.AspNetCore.Mvc;
using SmsService.Interfaces;
using SmsService.Models;

namespace SmsService.Services
{
    public class RestOfTheWorldProvider :IProvider
    {
        private readonly ContextService _contextService;
        public RestOfTheWorldProvider(ContextService contextService)
        {
            _contextService = contextService;

        }

        public async Task<List<SmsMessage>> Send(SmsMessage message)
        {
            var messagesForRestList = new List<SmsMessage>();
            message.Country = ConstValues.Constants.entryforOther;
            await _contextService.PersistMessageToDb(message);

            messagesForRestList.Add(message);

            return messagesForRestList;
        }
    }
}
