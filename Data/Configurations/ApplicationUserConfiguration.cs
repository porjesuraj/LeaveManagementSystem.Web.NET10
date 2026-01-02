using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagementSystem.Web.Data.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                new ApplicationUser
                {
                    Id = "a1b2c3d4-e5f6-4789-9012-3456789abcde",
                    Email = "test@gmail.com",
                    NormalizedEmail = "TEST@GMAIL.COM",
                    NormalizedUserName = "TEST@GMAIL.COM",
                    UserName = "test@gmail.com",
                    PasswordHash = hasher.HashPassword(null, "Porje_12345"),
                    EmailConfirmed = true,
                    FirstName = "Default",
                    LastName = "Admin",
                    DateOfBirth = new DateOnly(1994, 1, 1)
                });
        }
    }
}
