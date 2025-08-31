using System.ComponentModel.DataAnnotations;

namespace AttendancePayrollWebServerApp.Models
{
    public class UserAccountPolicy
    {
        [Key]
        public int PolicyId { get; set; }

        public string? UserAccountId { get; set; }

        public string? UserPolicy { get; set; }

        public bool IsEnabled { get; set; }

        public string? Module { get; set; }

    }
}
