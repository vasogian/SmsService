using Microsoft.AspNetCore.Mvc;
using SmsService.Models;

namespace SmsService.Interfaces
{
    public interface IProvider
    {     
        public Task<SmsMessage?> Send(SmsMessage message);
    }
}
