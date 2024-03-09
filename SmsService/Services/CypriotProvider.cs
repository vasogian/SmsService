using Microsoft.AspNetCore.Mvc;
using SmsService.Interfaces;
using SmsService.Models;
using System.Text.RegularExpressions;
using SmsService.ConstValues;

namespace SmsService.Services
{
    public class CypriotProvider : IProvider
    {
        private readonly ContextService _contextService;
        public CypriotProvider(ContextService contextService)
        {
            _contextService = contextService;
        }

        public async Task<SmsMessage?> Send(SmsMessage message)
        {
            int messageLength = message.Message.Length;
            bool isCypriotNum = Regex.IsMatch(message.PhoneNumber, @"^\+357[2-9][0-9]{6,7}$");

            if (isCypriotNum)
            {
                if (messageLength > ConstValues.Constants.maxCypriotSmsMessageLength)
                {
                    //var length = messageLength / ConstValues.Constants.maxCypriotSmsMessageLength;
                    SmsMessage message2 = new SmsMessage();
                    message2.PhoneNumber = message.PhoneNumber;
                    message2.Message = message.Message.Substring(Constants.maxCypriotSmsMessageLength);
                    message2.Country = message.Country = Constants.entryforCyprus;

                    await _contextService.PersistMessageToDb(message2);
                    return message;

                }
                message.Country = Constants.entryforCyprus;

                await _contextService.PersistMessageToDb(message);

                return message;
            }
            return null;
        }
    }
}
