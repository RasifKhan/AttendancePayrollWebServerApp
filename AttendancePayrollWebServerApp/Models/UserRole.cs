using System.ComponentModel.DataAnnotations;

namespace AttendancePayrollWebServerApp.Models
{
    public class UserRole
    {
        [Key]
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
    }
}
