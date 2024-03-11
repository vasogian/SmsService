using Microsoft.AspNetCore.Mvc;
using SmsService.Interfaces;
using SmsService.Models;
using System.Text.RegularExpressions;

namespace SmsService.Services
{
    public class GreekProvider : IProvider
    {
        private readonly IContextService _contextService;
        public GreekProvider(IContextService contextService)
        {
            _contextService = contextService;
        }

        public async Task<List<SmsMessage>> Send(SmsMessage message)
        {
            if (message.PhoneNumber == null ||
               message.Message == null)
            {
                return new List<SmsMessage>();
            }

            var greekMessagesList = new List<SmsMessage>();

            bool isGreekFormatForNum = Regex.IsMatch(message.PhoneNumber, @"^\+30[2-9][0-9]{9}$");

            bool isGreekFormatForText = Regex.IsMatch(message.Message, @"^[α-ωΑ-Ω\s]*$");

            if (isGreekFormatForNum && isGreekFormatForText)
            {
                message.Country = ConstValues.Constants.entryforGreece;
                var messagedAdded = await _contextService.PersistMessageToDb(message);

                greekMessagesList.Add(messagedAdded);

                return greekMessagesList;
            }

            return new List<SmsMessage>();
        }
    }
}
