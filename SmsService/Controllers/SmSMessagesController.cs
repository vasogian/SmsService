using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmsService.Interfaces;
using SmsService.Models;
using SmsService.Services;
using System.Linq;
using SmsService.Validation;
using System.Text.RegularExpressions;
using SmsService.ViewModels;
using AutoMapper;

namespace SmsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmSMessagesController : ControllerBase
    {
        private readonly SMSVendorGR _greekVendor;
        private readonly SMSVendorCY _cypriotVendor;
        private readonly SMSVendorRest _restVendor;
        private readonly IMapper _mapper;
        public SmSMessagesController(SMSVendorGR greekVendor, SMSVendorCY cypriotVendor, SMSVendorRest restVendor, IMapper mapper)
        {
            _mapper = mapper;
            _greekVendor = greekVendor;
            _cypriotVendor = cypriotVendor;
            _restVendor = restVendor;
        }
        
        [HttpPost]
        public async Task<IActionResult> SendSms(SmsMessageRequestViewModel message)
        {
            var phoneNumber = message.PhoneNumber;

            string greekFromat = @"^\+30[2-9][0-9]{9}$";

            string cypriot = @"^\+357[2-9][0-9]{6,7}$"; 

            string restPhoneNumbers = @"^([\+]?123[-]?|[0])?[1-9][0-9]{8}$";

            bool isGreek = Regex.IsMatch(phoneNumber, greekFromat);

            bool isCypriot = Regex.IsMatch(phoneNumber, cypriot);

            bool isOther = Regex.IsMatch(phoneNumber, restPhoneNumbers);

            if (phoneNumber == null)
            {
                return BadRequest();
            }
            if (isGreek)
            {
                var mappedMessage = _mapper.Map<SmsMessage>(message);
                await this._greekVendor.SendMessage(message);
                return CreatedAtRoute("", new { Id = message.Id }, message);

            }

            else if (isCypriot)
            {
                await this._cypriotVendor.SendMessage(message);
                return CreatedAtRoute("", new { Id = message.Id }, message);
            }
            else if (isOther)
            {
                await this._restVendor.SendMessage(message);
                return CreatedAtRoute("", new { Id = message.Id }, message);
            }

            return BadRequest();
        }
    }
}
