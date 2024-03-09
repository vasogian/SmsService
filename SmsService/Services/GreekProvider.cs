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

        public async Task<SmsMessage?> Send(SmsMessage message)
        {
            bool isGreekFormatForNum = Regex.IsMatch(message.PhoneNumber, @"^\+30[2-9][0-9]{9}$");

            bool isGreekFormatForText = Regex.IsMatch(message.Message, @"^[α-ωΑ-Ω\s]*$");

            if(isGreekFormatForNum && isGreekFormatForText)
            {
                message.Country = ConstValues.Constants.entryforGreece;
                await _contextService.PersistMessageToDb(message);

                return message;
            }
            return null;         
        }
    }
}
