using System.ComponentModel.DataAnnotations;
namespace AttendancePayrollWebServerApp.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Provide Department Name")]
        [RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "Write a valid name")]
        public string? DepartmentName { get; set; }

        [Required(ErrorMessage = "Provide Department Name Ban")]
        [Display(Name = "Department Name Ban")]
        public string? DepartmentNameBan { get; set; }
    }
}
