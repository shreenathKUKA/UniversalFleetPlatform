using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace UFP.Modules.Identity.Infrastructure.Identity
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        
    }
}


//Explain
//IdentityUser<Guid>
// Microsoft already provides:


// Id
// Name
// NormalizedName
// ConcurrencyStamp