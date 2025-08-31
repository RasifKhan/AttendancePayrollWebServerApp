using System.ComponentModel.DataAnnotations;
namespace AttendancePayrollWebServerApp.Models
{
    public class SalarySection
    {
        [Key]
        public int SalarySectionId { get; set; }

        [Required(ErrorMessage = "Provide Salary Section Name")]
        [RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "Write a valid name")]
        public string SalarySectionName { get; set; }

        [Required(ErrorMessage = "Provide Salary Section Bangla")]
        [Display(Name = "Salary Section Ban")]
        public string SalarySectionBan { get; set; }


    }
}
