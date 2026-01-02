using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagementSystem.Web.Data.Configurations
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
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

        }
    }


}
