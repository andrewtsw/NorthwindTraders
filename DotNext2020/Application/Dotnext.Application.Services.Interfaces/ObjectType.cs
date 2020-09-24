using System;

namespace Dotnext.Application.Services.Interfaces
{
    [Flags]
    public enum ObjectType
    {
        Product = 1,
        Order = 2,
        // ...
    }
}
