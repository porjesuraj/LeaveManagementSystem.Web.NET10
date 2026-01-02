using LeaveManagementSystem.Web.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Data
{
    //[EntityTypeConfiguration(typeof(LeaveRequestStatusConfiguration))]
    public class LeaveRequest : BaseEntity
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        public int LeaveTypeId { get; set; }

        public LeaveType? LeaveType { get; set; }

        public  int  LeaveRequestStatusId { get; set; }

        public LeaveRequestStatus? LeaveRequestStatus { get; set; }


        public ApplicationUser? Employee { get; set; }

        public string EmployeeId { get; set; } = default!;

        public string? RequestComments { get; set; }


        public ApplicationUser? Reviewer { get; set; }

        public string? ReviewerId { get; set; }
    }
}