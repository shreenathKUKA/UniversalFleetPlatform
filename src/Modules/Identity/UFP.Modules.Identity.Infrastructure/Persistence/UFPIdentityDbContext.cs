
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using UFP.Modules.Identity.Infrastructure.Identity;







namespace UFP.Modules.Identity.Infrastructure.Persistence
{
    public sealed class UFPIdentityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public UFPIdentityDbContext(DbContextOptions<UFPIdentityDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        builder.HasDefaultSchema("identity");

        builder.Entity<ApplicationUser>()
            .ToTable("users");

        builder.Entity<ApplicationRole>()
            .ToTable("roles");

        builder.Entity<IdentityUserRole<Guid>>()
            .ToTable("user_roles");

        builder.Entity<IdentityUserClaim<Guid>>()
            .ToTable("user_claims");

        builder.Entity<IdentityRoleClaim<Guid>>()
            .ToTable("role_claims");

        builder.Entity<IdentityUserToken<Guid>>()
            .ToTable("user_tokens");

        builder.Entity<IdentityUserLogin<Guid>>()
            .ToTable("user_logins");

        builder.Entity<ApplicationUser>(entity =>
        {
            entity.Property(x => x.DisplayName)
                .HasMaxLength(200)
                .IsRequired();

            entity.HasIndex(x => x.NormalizedEmail)
                .IsUnique();

            entity.HasIndex(x => x.IsActive)
                .IsUnique();

            entity.HasIndex(x => x.CreatedAtUtc)
                .IsUnique();

                
        });
        }
        
    }
}