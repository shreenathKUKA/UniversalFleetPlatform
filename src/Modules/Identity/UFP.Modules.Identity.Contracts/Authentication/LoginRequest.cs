using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UFP.Modules.Identity.Contracts.Authentication
{
    public sealed record LoginRequest
    (
        string Email,
        string Password,
        bool RememberMe = false
    );
}