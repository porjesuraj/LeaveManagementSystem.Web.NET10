using LeaveManagementSystem.Web.Models.LeaveType;

namespace LeaveManagementSystem.Web.Models
{
    public class LeaveAllocationVM
    {

        public int Id { get; set; }

        [Display(Name = "Number Of Days")]
        public int NumberOfDays { get; set; }


        [Display(Name = "Allocation Period")]
        public PeriodVM Period { get; set; } = new PeriodVM();


        public LeaveReadOnlyViewModel LeaveType { get; set; } = new LeaveReadOnlyViewModel();

    }
}