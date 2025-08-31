using System.ComponentModel.DataAnnotations;
namespace AttendancePayrollWebServerApp.Models
{
    public class Section
    {
        [Key]
        public int SectionId { get; set; }



        [Required(ErrorMessage = "Provide Section Name")]
        [RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "Write a valid name")]
        public string SectionName { get; set; }

        [Required(ErrorMessage = "Provide Section Name Bangla")]
       
        public string SectionNameBan { get; set; }

    }
}
