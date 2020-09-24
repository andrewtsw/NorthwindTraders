namespace Dotnext.Application.Services.Interfaces
{
    public interface IPermissionsManager
    {
        ObjectAccessLevel[] GetCurrentUserPermissions();

        ObjectAccessLevel[] GetUserPermissions(string userId, ObjectType type);
    }
}
