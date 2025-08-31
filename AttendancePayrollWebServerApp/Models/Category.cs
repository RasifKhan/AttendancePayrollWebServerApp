using System.ComponentModel.DataAnnotations;
namespace AttendancePayrollWebServerApp.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Provide Category Name")]
        [RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "Write a valid name")]
        public string CategoryName { get; set; }

        
    }
}
