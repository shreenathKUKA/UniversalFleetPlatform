using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UFP.Modules.Identity.Contracts.Authentication
{
    public sealed record CurrentUserResponse
    (
        Guid UserId,
        string Email,
        string DisplayName,
        string[] Roles,
        bool MustChangePassword

    );
}