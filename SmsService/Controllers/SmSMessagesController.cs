using Microsoft.AspNetCore.Mvc;
using SmsService.Interfaces;
using SmsService.Models;
using SmsService.ViewModels;
using AutoMapper;

namespace SmsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmSMessagesController : ControllerBase
    {
        private readonly IEnumerable<IProvider> _providers;
        private readonly IMapper _mapper;
        public SmSMessagesController(IMapper mapper, IEnumerable<IProvider> provider)
        {
            _mapper = mapper;
            _providers = provider;
        }


        [HttpPost]
        [ProducesResponseType(typeof(SmsMessageSuccessResponseViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SendSms(SmsMessageRequestViewModel message)
        {
            SmsMessage messageToPersist = _mapper.Map<SmsMessage>(message);

            SmsMessageSuccessResponseViewModel mappedResponse = new SmsMessageSuccessResponseViewModel()
            {
                Response = "Message not sent! Try again!",
                PhoneNumber = null
            };

            foreach (var provider in _providers)
            {
                List<SmsMessage> result = await provider.Send(messageToPersist);

                if (result.Count > 0)
                {
                    mappedResponse = _mapper.Map<SmsMessageSuccessResponseViewModel>(messageToPersist);
                    break;
                }
            }
            return CreatedAtRoute("", mappedResponse);
        }
    }
}
