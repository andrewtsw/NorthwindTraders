using System.Threading.Tasks;

namespace Dotnext.Infrastructure.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(MessageDto message);
    }
}
