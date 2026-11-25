using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;



namespace UFP.Modules.Identity.Infrastructure.Identity
{
    public sealed class ApplicationUser : IdentityUser<Guid>
    {
        public required string DisplayName { get; set;}

        public bool IsActive {get; set;} = true;

        public bool MustChangePassword {get; set;} = true;

        public DateTimeOffset CreatedAtUtc {get; set;} = DateTimeOffset.UtcNow;
    

        public DateTimeOffset? LastLoginAtUtc {get; set;}

        public Guid? CreatedByUserId {get; set;}
        public Guid? UpdatedByUserId {get; set;}
        public DateTimeOffset UpdatedAtUtc {get; set;} 









        
    }
}


// Explain
// here we all first Half get from MS.Identity And 
// second half is my addictional requirement

// AspNetUsers
// │
// ├── Id
// ├── UserName
// ├── NormalizedUserName
// ├── Email
// ├── NormalizedEmail
// ├── PasswordHash
// ├── SecurityStamp
// ├── PhoneNumber
// ├── EmailConfirmed
// ├── AccessFailedCount
// │-------------------------------------my fields----------------------------
// ├── DisplayName
// ├── IsActive
// ├── MustChangePassword
// ├── CreatedAtUtc
// └── LastLoginAtUtc