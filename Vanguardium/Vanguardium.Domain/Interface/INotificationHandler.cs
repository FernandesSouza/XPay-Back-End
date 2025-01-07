using Vanguardium.Domain.Handlers.NotificationHandler;

namespace Vanguardium.Domain.Interface;

public interface INotificationHandler
{ 
    List<DomainNotification> GetNotifications();
    bool HasNotification();
    void CreateNotifications(IEnumerable<DomainNotification> notifications);
    void CreateNotification(DomainNotification notification);
    bool CreateNotification(string key, string value);
    void DeleteNotification(DomainNotification notification);
    
}