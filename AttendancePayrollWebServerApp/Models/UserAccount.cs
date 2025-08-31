using System.ComponentModel.DataAnnotations;

namespace AttendancePayrollWebServerApp.Models
{
    public class UserAccount
    {
        [Key]
        [Required]
        //[RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "Write a valid name")]
        [RegularExpression(@"^[a-zA-Z0-9 \-@,_.]+$", ErrorMessage = "Write a user Id")]
        public string? UserAccountId { get; set; }

        [Required(ErrorMessage = "Provide Emp Ioyee Name")]
        [RegularExpression(@"^[a-zA-Z0-9 \-@,_.]+$", ErrorMessage = "Write a valid name")]
        public string? UserName { get; set; }


        //[RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "Write a valid name")]
        public string? Password { get; set; }



        [Required]
        [RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "Select type")]
        public int RoleId { get; set; }


        [Required]
        [RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "Select access")]
        public string? Access { get; set; }

        [Required]
        [RegularExpression("^[0-9 ]+$", ErrorMessage = "Write a valid Number")]
        public string? MobileNumber { get; set; }


        [Required]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Enter a valid email address")]
        public string? EMail { get; set; }


        [Required]
        [RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "Select status")]
        public string? Status { get; set; }



    }
}
