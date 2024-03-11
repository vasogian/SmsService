using Microsoft.AspNetCore.Mvc;
using SmsService.Models;

namespace SmsService.Interfaces
{
    public interface IProvider
    {     
        public Task<List<SmsMessage>> Send(SmsMessage message);
    }
}
