namespace SmsService.ViewModels
{
    public class SmsMessageSuccessResponseViewModel
    {
        public string Response { get; set; } = ConstValues.Constants.responseSuccess;
        public string? PhoneNumber { get; set; }
    }
}
