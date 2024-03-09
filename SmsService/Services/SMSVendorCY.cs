﻿using Microsoft.AspNetCore.Mvc;
using SmsService.Interfaces;
using SmsService.Models;

namespace SmsService.Services
{
    public class SMSVendorCY :IProvider
    {
        private readonly ContextService _contextService;
        public SMSVendorCY(ContextService contextService)
        {
            _contextService = contextService;
        }

        public async Task<SmsMessage> Send(SmsMessage message)
        {
            return null;
        }
    }
}
