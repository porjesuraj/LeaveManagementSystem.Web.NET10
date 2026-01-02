namespace LeaveManagementSystem.Web.Models.LeaveRequest
{
    public class ReviewLeaveRequestVM : LeaveRequestListVM
    {
        public EmployeeListVM Employee { get; set; } = new EmployeeListVM();

        [Display(Name ="Additonal Information")]
        public string RequestComments { get; set; }
    }
}