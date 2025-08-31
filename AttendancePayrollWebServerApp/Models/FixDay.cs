using System.ComponentModel.DataAnnotations;
namespace AttendancePayrollWebServerApp.Models
{
    public class FixDay
    {
        [Key]

        public int FixDayId { get; set; }

        [Required(ErrorMessage = "Provide From Date")]
        [Range(typeof(DateTime), "1900-01-01", "2099-12-31", ErrorMessage = "From Date must be after 01-Jan-1900")]
        public DateTime FixDateFrom { get; set; }




        [Required(ErrorMessage = "Provide From Date")]
        [Range(typeof(DateTime), "1900-01-01", "2099-12-31", ErrorMessage = "From Date must be after 01-Jan-1900")]
        public DateTime FixDateTo { get; set; }



        [Required(ErrorMessage = "Provide Type")]
        [Display(Name = "Fix Type")]
        public string FixType { get; set; }

        [Required(ErrorMessage = "Provide Remarks")]
        public string FixRemarks { get; set; }

        [Required(ErrorMessage = "Provide Addedby")]
        [Display(Name = "Addedby")]
        public int Addedby { get; set; }

        [Required(ErrorMessage = "Provide Added Date")]
        [Display(Name = "Added Date")]
        public DateTime AddedDate { get; set; }

        [Required(ErrorMessage = "Provide Edited By")]
        [Display(Name = "Edited By")]
        public int EditedBy { get; set; }

        [Required(ErrorMessage = "Provide Edited Date")]
        [Display(Name = "Edited Date")]
        public DateTime EditedDate { get; set; }





    }
}
