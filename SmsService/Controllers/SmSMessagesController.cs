using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmsService.Interfaces;
using SmsService.Models;
using SmsService.Services;
using System.Linq;
using System.Text.RegularExpressions;
using SmsService.ViewModels;
using AutoMapper;

namespace SmsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmSMessagesController : ControllerBase
    {
        private readonly IEnumerable<IProvider> _provider;
        private readonly IMapper _mapper;
        public SmSMessagesController(IMapper mapper, IEnumerable<IProvider> provider)
        {
            _mapper = mapper;
            _provider = provider;

        }

        [HttpPost]
        public async Task<IActionResult> SendSms(SmsMessageRequestViewModel message)
        {
            var messageToPersist = _mapper.Map<SmsMessage>(message);

            SmsMessageSucccessResponseViewModel mappedResponse = null;

            foreach (var provider in _provider)
            {
                await provider.Send(messageToPersist);
                
                 mappedResponse = _mapper.Map<SmsMessageSucccessResponseViewModel>(messageToPersist);

                if(mappedResponse != null)
                {
                    break;
                }
            }
            return CreatedAtRoute("", mappedResponse);

            // char[] letters = new char[] { 'Α', 'Β', 'Γ', 'Δ', 'Ε', 'Ζ', 'Η', 'Θ', 'Ι', 'Κ', 'Λ', 'Μ', 'Ν', 'Ξ', 'Ο', 'Π', 'Ρ', 'Σ', 'Τ', 'Υ', 'Φ', 'Χ', 'Ψ', 'Ω' };      

            //string greekFromat = @"^\+30[2-9][0-9]{9}$";

            //string cypriot = @"^\+357[2-9][0-9]{6,7}$";

            //string restPhoneNumbers = @"^([\+]?123[-]?|[0])?[1-9][0-9]{8}$";

            //bool isGreek = Regex.IsMatch(phoneNumber, greekFromat);

            //bool isCypriot = Regex.IsMatch(phoneNumber, cypriot);

            //bool isOther = Regex.IsMatch(phoneNumber, restPhoneNumbers);

            //    if (isGreek)
            //    {

            //        var mappedMessageRequest = _mapper.Map<SmsMessage>(message);
            //    await this._greekVendor.SendMessage(mappedMessageRequest);

            //    var mappedResponse = _mapper.Map<SmsMessageSucccessResponseViewModel>(mappedMessageRequest);
            //    return CreatedAtRoute("", new { Id = mappedResponse.Id }, mappedResponse);

            //}

            //    else if (isCypriot)
            //    {
            //        var mappedMessageRequest = _mapper.Map<SmsMessage>(message);

            //        await this._cypriotVendor.SendMessage(mappedMessageRequest);

            //        var mappedResponse = _mapper.Map<SmsMessageSucccessResponseViewModel>(mappedMessageRequest);

            //        return CreatedAtRoute("", new { Id = mappedResponse.Id }, mappedResponse);
            //    }
            //    else if (isOther)
            //    {
            //        var mappedMessageRequest = _mapper.Map<SmsMessage>(message);
            //        await this._restVendor.SendMessage(mappedMessageRequest);
            //        var mappedResponse = _mapper.Map<SmsMessageSucccessResponseViewModel>(mappedMessageRequest);
            //        return CreatedAtRoute("", new { Id = mappedResponse.Id }, mappedResponse);
            //    }

            //    return BadRequest();
        }
    }
}
