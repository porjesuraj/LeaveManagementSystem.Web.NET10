namespace LeaveManagementSystem.Web.Models
{
    public class EmployeeAllocationVM: EmployeeListVM
    {
        public List<LeaveAllocationVM> LeaveAllocations { get; set; }

        public bool IsCompletedAllocation { get; set; }
    }

    public class EmployeeListVM
    {
        public string Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Display(Name = "Date Of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateOnly DateOfBirth { get; set; }

        [Display(Name = "Email Address")]
        public string Email { get; set; }
    }
}
