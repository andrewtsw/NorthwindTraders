using Dotnext.Infrastructure.Notifications.Interfaces;
using System.Threading.Tasks;

namespace Dotnext.Infrastructure.Notifications.Implementation
{
    internal class NotificationService : INotificationService
    {
        public Task SendAsync(MessageDto message)
        {
            // TODO: Use SendGrid SDK
            return Task.CompletedTask;
        }
    }
}
