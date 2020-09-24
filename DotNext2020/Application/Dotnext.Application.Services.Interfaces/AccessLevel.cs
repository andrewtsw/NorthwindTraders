using System;

namespace Dotnext.Application.Services.Interfaces
{
    [Flags]
	public enum AccessLevel
    {
		PartialView = 1,
		View = 2,
		Edit = 8,
		Administration = 16
    }
}
