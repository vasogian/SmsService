using Microsoft.AspNetCore.Mvc;
using SmsService.Interfaces;
using SmsService.Models;

namespace SmsService.Services
{
    public class ProviderRest :IProvider
    {
        private readonly ContextService _contextService;
        public ProviderRest(ContextService contextService)
        {
            _contextService = contextService;

        }

        public async Task<SmsMessage?> Send(SmsMessage message)
        {
            message.Country = ConstValues.Constants.entryforOther;
            await _contextService.PersistMessageToDb(message);

            return message;
        }
    }
}
