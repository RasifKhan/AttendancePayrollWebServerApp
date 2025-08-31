using System.ComponentModel.DataAnnotations;

namespace AttendancePayrollWebServerApp.Models
{
    public class UserModule
    {
        [Key]
        public int ModuleId { get; set; }


        [Required(ErrorMessage = "Provide name")]
        [RegularExpression(@"^[a-zA-Z0-9 \-@,_.]+$", ErrorMessage = "Write a valid name")]
        public string? ModuleName { get; set; }


        [Required(ErrorMessage = "Provide name")]
        [RegularExpression(@"^[a-zA-Z0-9 \-@,_.]+$", ErrorMessage = "Write a valid name")]
        public string? ModulePageName { get; set; }

    }
}
