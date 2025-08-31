using System.ComponentModel.DataAnnotations;
namespace AttendancePayrollWebServerApp.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }


        [Required(ErrorMessage = "Provide Company Name")]
        [RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "Write a valid name")]
        public string CompanyName { get; set; }


        [Required(ErrorMessage = "Provide Comp Name Ban")]
        public string CompNameBan { get; set; }


        [Required(ErrorMessage = "Provide Description")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Provide Description Ban")]
        public string DescriptionBan { get; set; }


        [Required(ErrorMessage = "Provide Contact")]
        public string Contact { get; set; }


        [Required(ErrorMessage = "Provide Hot Line")]
        public string HotLine { get; set; }


        [Required(ErrorMessage = "Provide Comp Reg")]
        public string CompReg { get; set; }


        public Company Clone()
        {
            return (Company)MemberwiseClone();
        }
    }
}
