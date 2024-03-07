using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmsService.Interfaces;
using SmsService.Models;
using SmsService.Services;
using System.Linq;
using SmsService.Validation;
using System.Text.RegularExpressions;

namespace SmsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmSMessagesController : ControllerBase
    {
        //private readonly SMSVendorGR _greekVendor;
        //private readonly SMSVendorCY _cypriotVendor;
        //private readonly SMSVendorRest _restVendor;
        private readonly IEnumerable<ISms> _messageSenders;
        public SmSMessagesController(IEnumerable<ISms> messageSenders)
        {

           _messageSenders = messageSenders;
        }

        [HttpPost]
        public async Task<ActionResult> SendSms(SmsMessage message)
        {

            //foreach(var sender in _messageSenders)
            //{
            //    sender.SendMessage(message);
            //}    
            var phoneNumber = message.PhoneNumber;

            string greekFromat = @"^([\+]?30[-]?|[0])?[1-9][0-9]{8}$";

            string cypriot = @"^([\+]?3579[-]?|[0])?[1-9][0-9]{8}$";

            string restPhoneNumbers = @"^([\+]?33[-]?|[0])?[1-9][0-9]{8}$";

            bool isGreek = Regex.IsMatch(phoneNumber, greekFromat);

            bool isCypriot = Regex.IsMatch(phoneNumber, cypriot);

            bool isOther = Regex.IsMatch(phoneNumber, restPhoneNumbers);

            if (phoneNumber == null)
            {
                return BadRequest();
            }
            if (isGreek)
            {
                var response = _greekVendor.SendMessage(message);
                return Ok(response);
            }

            else if (isCypriot)
            {
                var response = _cypriotVendor.SendMessage(message);
                return Ok(response);
            }
            else if (isOther)
            {
                var response = _restVendor.SendMessage(message);
                return Ok(response);
            }

            return BadRequest(); 
        }
    }
}
