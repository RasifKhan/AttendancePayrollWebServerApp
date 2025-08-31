using System.ComponentModel.DataAnnotations;

namespace AttendancePayrollWebServerApp.Models
{
    public class SalaryBreakdownSetup
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Provide Emp Type Cat Item Id")]
        public int EmpTypeCatItemId { get; set; }

        [Required(ErrorMessage = "Provide Break Dwon Type")]
        public string BreakDwonType { get; set; }


        public string? BreakDownBasedON { get; set; } = "N/A";

        [Required(ErrorMessage = "Provide T A")]
        public decimal TA { get; set; }

        [Required(ErrorMessage = "Provide M A")]
        public decimal MA { get; set; }

        [Required(ErrorMessage = "Provide F A")]
        public decimal FA { get; set; }

        [Required(ErrorMessage = "Provide H R")]
        public decimal HR { get; set; }

        [Required(ErrorMessage = "Provide B S")]
        public decimal BS { get; set; }

    }
}
