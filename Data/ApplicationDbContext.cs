using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LeaveManagementSystem.Web.Models;

namespace LeaveManagementSystem.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "e8f1d839-62bb-470d-a1a7-3067e9c5ba0b",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole
                {
                    Id = "59441cdd-e751-49fa-8459-385a0f9a7167",
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                },
                new IdentityRole
                {
                    Id = "8ca30d05-5dc6-4a0c-95ed-537048384a1e",
                    Name = "Supervisor",
                    NormalizedName = "SUPERVISOR"
                }
            );

            var hasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "a1b2c3d4-e5f6-4789-9012-3456789abcde",
                    Email = "test@gmail.com",
                    NormalizedEmail = "TEST@GMAIL.COM",
                    NormalizedUserName = "TEST@GMAIL.COM",
                    UserName = "test@gmail.com",
                    PasswordHash = hasher.HashPassword(null, "Porje_12345"),
                    EmailConfirmed = true,
                    FirstName ="Default",
                    LastName ="Admin",
                    DateOfBirth = new DateOnly(1994, 1, 1)
                });

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "e8f1d839-62bb-470d-a1a7-3067e9c5ba0b",
                    UserId = "a1b2c3d4-e5f6-4789-9012-3456789abcde"
                });
        }
                
                


        public DbSet<LeaveType> LeaveTypes { get; set; }

        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }

        public DbSet<Period> Periods { get; set; }
        public DbSet<LeaveManagementSystem.Web.Models.EmployeeAllocationVM> EmployeeAllocationVM { get; set; } = default!;
        public DbSet<LeaveManagementSystem.Web.Models.EmployeeListVM> EmployeeListVM { get; set; } = default!;



    }
}
