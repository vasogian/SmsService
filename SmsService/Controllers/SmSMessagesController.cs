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
                var result = await  provider.Send(messageToPersist);

                if (result != null)
                {
                    mappedResponse = _mapper.Map<SmsMessageSucccessResponseViewModel>(messageToPersist);
                    break;
                }
            }
            return CreatedAtRoute("", mappedResponse);
        }
    }
}
