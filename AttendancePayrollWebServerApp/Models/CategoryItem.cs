using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AttendancePayrollWebServerApp.Models
{
    public class CategoryItem
    {
        [Key]
        public int CategoryItemId { get; set; }

        [Required(ErrorMessage = "Provide Category Item Name")]
        [RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "Write a valid name")]
        public string CategoryItemName { get; set; }



        [Required(ErrorMessage = "Provide Category Name")]
        [Range(1, int.MaxValue, ErrorMessage = "Provide Category Name")]
        public int CategoryId { get; set; }
  

        public string? CategoryItemNameBan { get; set; } = "";
    }
}
