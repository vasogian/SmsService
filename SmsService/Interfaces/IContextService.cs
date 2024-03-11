namespace SmsService.Interfaces
{
    using SmsService.Models;
    public interface IContextService
    {
        Task<SmsMessage> PersistMessageToDb(SmsMessage? message);
        Task<int> PersistMessageToDbForCypriotMessages(List<SmsMessage> messages);
    }
}
