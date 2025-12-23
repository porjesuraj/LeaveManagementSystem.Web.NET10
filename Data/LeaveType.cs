using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.Web.Data
{
    public class LeaveType
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName ="nvarchar(150)")]
        public string Name { get; set; }

        [DisplayName("Number Of Days")]
        public int NumberOfDays { get; set; }


    }
}
