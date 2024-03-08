namespace SmsService.ViewModels
{
    public class SmsMessageSucccessResponseViewModel
    {
        public int Id { get; set; }
        public string Response { get; } = Constants.Constants.responseSuccess;
    }
}
