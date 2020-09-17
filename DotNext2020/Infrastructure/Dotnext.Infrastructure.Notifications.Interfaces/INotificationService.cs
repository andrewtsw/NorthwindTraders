using System.Threading.Tasks;

namespace Dotnext.Infrastructure.Notifications.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(MessageDto message);
    }
}
