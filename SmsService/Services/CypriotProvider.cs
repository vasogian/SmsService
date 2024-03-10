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

        public async Task<List<SmsMessage>> Send(SmsMessage message)
        {
            int messageLength = message.Message.Length;

            var listForMultipleMessages = new List<SmsMessage>();//in case text exceeds 160 chars

            var listForASingleMessage = new List<SmsMessage>();

            bool isCypriotNum = Regex.IsMatch(message.PhoneNumber, @"^\+357[2-9][0-9]{6,7}$");

            if (isCypriotNum)
            {
                if (messageLength > ConstValues.Constants.maxCypriotSmsMessageLength)
                {
                    string messageString = message.Message;
                    var messages = SplitText(messageString, ConstValues.Constants.maxCypriotSmsMessageLength);

                    foreach (var item in messages)
                    {

                        SmsMessage chainedMessage = new SmsMessage
                        {
                            PhoneNumber = message.PhoneNumber,
                            Message = item,
                            Country = ConstValues.Constants.entryforCyprus
                        };

                        listForMultipleMessages.Add(chainedMessage);
                    }
                    await _contextService.PersistMessageToDbForCypriotMessages(listForMultipleMessages);

                    return listForMultipleMessages;

                }
                message.Country = Constants.entryforCyprus;

                await _contextService.PersistMessageToDb(message);

                listForASingleMessage.Add(message);

                return listForASingleMessage;

            }
            return null;
        }

        static IEnumerable<string> SplitText(string text, int length)
        {
            return Enumerable.Range(0, text.Length / length)
                .Select(i => text.Substring(i * length, length));
        }

    }
}
