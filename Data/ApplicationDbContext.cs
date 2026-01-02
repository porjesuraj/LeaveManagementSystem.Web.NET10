using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LeaveManagementSystem.Web.Models;
using LeaveManagementSystem.Web.Data.Configurations;
using System.Reflection;
using LeaveManagementSystem.Web.Models.LeaveRequest;

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

            builder.ApplyConfiguration(new IdentityRoleConfiguration());


            builder.ApplyConfiguration(new ApplicationUserConfiguration());

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "e8f1d839-62bb-470d-a1a7-3067e9c5ba0b",
                    UserId = "a1b2c3d4-e5f6-4789-9012-3456789abcde"
                });

            builder.ApplyConfiguration(new LeaveRequestStatusConfiguration());


           // builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
                
                


        public DbSet<LeaveType> LeaveTypes { get; set; }

        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }

        public DbSet<Period> Periods { get; set; }
        
        public DbSet<LeaveRequestStatus> LeaveRequestStatuses { get; set; }

        public DbSet<LeaveRequest> LeaveRequests { get; set; }






    }
}
