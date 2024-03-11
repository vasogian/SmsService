namespace SmsService.Interfaces
{
    using SmsService.Models;
    public interface IContextService
    {
        Task<SmsMessage> PersistMessageToDb(SmsMessage? message);
        Task<List<SmsMessage>> PersistMessageToDbForCypriotMessages(List<SmsMessage> messages);
    }
}
