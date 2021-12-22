namespace Weelo.Application.Ports;

public interface IMessaging
{
    Task SendMessageAsync(object o, string queue);
}