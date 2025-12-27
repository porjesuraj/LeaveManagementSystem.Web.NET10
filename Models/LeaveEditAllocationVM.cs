namespace LeaveManagementSystem.Web.Models
{
    public class LeaveEditAllocationVM : LeaveAllocationVM
    {

        public EmployeeListVM Employee { get; set; } = new EmployeeListVM();
    }
}