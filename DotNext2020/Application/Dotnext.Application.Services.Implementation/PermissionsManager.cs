using Dotnext.Application.Services.Interfaces;
using Dotnext.Infrastructure.Persistence.Interfaces;
using System;

namespace Dotnext.Application.Services.Implementation
{
    internal class PermissionsManager : IPermissionsManager
    {
        private readonly INorthwindDbContext _context;

        public PermissionsManager(INorthwindDbContext context)
        {
            _context = context;
        }

        public ObjectAccessLevel[] GetCurrentUserPermissions()
        {
            // TODO: load permissions from DB/Cache
            throw new NotImplementedException();
        }

        public ObjectAccessLevel[] GetUserPermissions(string userId, ObjectType type)
        {
            // TODO: load permissions from DB/Cache
            throw new NotImplementedException();
        }
    }
}
