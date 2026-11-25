using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UFP.Modules.Identity.Contracts.Authentication
{
    public sealed record ChangePasswordRequest
    (
        string CurrentPassword,
        string NewPassword
    
    );
        
    
}