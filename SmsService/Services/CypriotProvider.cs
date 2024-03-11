using Microsoft.AspNetCore.Mvc;
using SmsService.Interfaces;
using SmsService.Models;
using System.Text.RegularExpressions;
using SmsService.ConstValues;

namespace SmsService.Services
{
    public class CypriotProvider : IProvider
    {
        private readonly IContextService _contextService;
        public CypriotProvider(IContextService contextService)
        {
            _contextService = contextService;
        }

        public async Task<List<SmsMessage>> Send(SmsMessage message)
        {
            var messagesToReturn = new List<SmsMessage>();

            bool isCypriotNum = Regex.IsMatch(message.PhoneNumber, @"^\+357[2-9][0-9]{6,7}$");

            if (!isCypriotNum)
            {
                return messagesToReturn;
            }

            int messageLength = message.Message.Length;

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

                    messagesToReturn.Add(chainedMessage);
                }
                var messagesPersistedToDb = await _contextService.PersistMessageToDbForCypriotMessages(messagesToReturn);

                if(messagesPersistedToDb > 0)
                {
                    return messagesToReturn;
                }

                return new List<SmsMessage>();
            }

            message.Country = Constants.entryforCyprus;

            var messageAdded = await _contextService.PersistMessageToDb(message);

            messagesToReturn.Add(messageAdded);

            return messagesToReturn;
        }

        /// <summary>
        /// Works only when the text length is 160,320 or 480 chars
        /// </summary>
        /// <param name="text"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        static IEnumerable<string> SplitText(string text, int length)
        {
            return Enumerable.Range(0, text.Length / length)
                .Select(i => text.Substring(i * length, length));
        }

    }
}
