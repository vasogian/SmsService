using Microsoft.AspNetCore.Mvc;
using SmsService.Interfaces;
using SmsService.Models;
using System.Text.RegularExpressions;

namespace SmsService.Services
{
    public class GreekProvider :IProvider
    {
        private readonly ContextService _contextService;
        public GreekProvider(ContextService contextService)
        {
            _contextService = contextService;
        }

        public async Task<List<SmsMessage>> Send(SmsMessage message)
        {
            var greekMessagesList = new List<SmsMessage>();
            bool isGreekFormatForNum = Regex.IsMatch(message.PhoneNumber, @"^\+30[2-9][0-9]{9}$");

            bool isGreekFormatForText = Regex.IsMatch(message.Message, @"^[α-ωΑ-Ω\s]*$");

            if(isGreekFormatForNum && isGreekFormatForText)
            {
                message.Country = ConstValues.Constants.entryforGreece;
                await _contextService.PersistMessageToDb(message);

                greekMessagesList.Add(message);

               return greekMessagesList;
            }
            return null;         
        }
    }
}
