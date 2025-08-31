using System.ComponentModel.DataAnnotations;
namespace AttendancePayrollWebServerApp.Models
{
    public class Holiday
    {
        [Key]
        public int HolidayId { get; set; }

        [Required(ErrorMessage = "Provide From Date")]
        [Display(Name = "From Date")]
        [Range(typeof(DateTime), "1900-01-01", "2099-12-31", ErrorMessage = "From Date must be after 01-Jan-1900")]
        public DateTime FromDate { get; set; }

        //[Required(ErrorMessage = "Provide To Date")]
        //[Display(Name = "To Date")]
        //public DateTime ToDate { get; set; }

        [Required(ErrorMessage = "Provide To Date")]
        [Display(Name = "To Date")]
        [Range(typeof(DateTime), "1900-01-01", "2099-12-31", ErrorMessage = "To Date must be after 01-Jan-1900")]
        public DateTime ToDate { get; set; }



        [Required(ErrorMessage = "Provide Holy Day")]
        [Display(Name = "Holy Day")]
        public string HoliDay { get; set; }

        [Required(ErrorMessage = "Provide Remarks")]
        [Display(Name = "Remarks")]
        public string Remarks { get; set; }

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
