namespace SmsService.Profiles
{
    using AutoMapper;
    public class MessageProfile: Profile
    {
        public MessageProfile()
        {
            CreateMap<ViewModels.SmsMessageRequestViewModel, Models.SmsMessage>();
            CreateMap<Models.SmsMessage, ViewModels.SmsMessageRequestViewModel>();
            CreateMap<Models.SmsMessage, ViewModels.SmsMessageSucccessResponseViewModel>();
        }
        
    }
}
