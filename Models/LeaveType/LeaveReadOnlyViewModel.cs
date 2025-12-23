
using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Web.Models.LeaveType
{
    public class LeaveReadOnlyViewModel
    {
        public int Id { get; set; }

    
        public string Name { get; set; }

        [Display(Name = "Maximum Number of Days")]
        public int NumberOfDays { get; set; }
    }

    public class LeaveTypeCreateVM
    {
        [Required, Length(3, 50, ErrorMessage ="minimum length 1 required")]
       
       public string Name { get; set; }

        [Required, Range(1,30)]
        [Display(Name= "Maximum Number of Days")]
        public int NumberOfDays { get; set; }

    }


    public class LeaveTypeEditVM
    {
        public int Id { get; set; }

        [Required, Length(3, 50, ErrorMessage = "minimum length 1 required")]
        public string Name { get; set; }

        [Required, Range(1, 30)]
        [Display(Name = "Maximum Number of Days")]
        public int NumberOfDays { get; set; }
    }
}
