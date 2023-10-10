using Authentication.Service.DTOs.Notifications;

namespace Authentication.Service.Interfaces.Notifications;

public interface IEmailSmsSender
{
    public Task<bool> SendAsync(SmsMessage message);
}
