using System.ComponentModel.DataAnnotations;
namespace AttendancePayrollWebServerApp.Models
{
    public class ShiftDetail
    {

        //[Required(ErrorMessage = "Provide Shift Id")]
        //[Display(Name = "Shift Id")]
        [Key]
        public int ShiftDetailId { get; set; }


        [Required(ErrorMessage = "Provide Shift Type")]
        [Range(1, int.MaxValue, ErrorMessage = "Select")]
        public int ShiftTypeMasterId { get; set; }




        [Required(ErrorMessage = "Provide Shift Name")]
        [RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "Write a valid name")]
        public string ShiftName { get; set; }

        //[Required(ErrorMessage = "Provide Shift Type")]
        //[Display(Name = "Shift Type")]
        //public string ShiftType { get; set; }

        [Required(ErrorMessage = "Provide Shift In")]
        [Display(Name = "Shift In")]
        public DateTime ShiftIn { get; set; }

        [Required(ErrorMessage = "Provide Shift Out")]
        [Display(Name = "Shift Out")]
        public DateTime ShiftOut { get; set; }

        [Required(ErrorMessage = "Provide Shift Late")]
        [Display(Name = "Shift Late")]
        public DateTime ShiftLate { get; set; }

        [Required(ErrorMessage = "Provide Shift Hr")]
        [Display(Name = "Shift Hr")]
        public DateTime ShiftHr { get; set; }

        [Required(ErrorMessage = "Provide Lunch In")]
        [Display(Name = "Lunch In")]
        public DateTime LunchIn { get; set; }

        [Required(ErrorMessage = "Provide Lunch Out")]
        [Display(Name = "Lunch Out")]
        public DateTime LunchOut { get; set; }

        [Required(ErrorMessage = "Provide Lunch Late")]
        [Display(Name = "Lunch Late")]
        public DateTime LunchLate { get; set; }

        [Required(ErrorMessage = "Provide Lunch Hr")]
        [Display(Name = "Lunch Hr")]
        public DateTime LunchHr { get; set; }
    }
}
