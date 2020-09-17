using Dotnext.Common;
using System.Threading.Tasks;

namespace Dotnext.Infrastructure.Interfaces
{
    public interface IUserManager
    {
        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);
    }
}
