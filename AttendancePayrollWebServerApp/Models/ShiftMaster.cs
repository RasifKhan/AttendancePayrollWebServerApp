using System.ComponentModel.DataAnnotations;
namespace AttendancePayrollWebServerApp.Models
{
    public class ShiftMaster
    {



        [Required(ErrorMessage = "Provide Shift Type Mt Id")]
        [Display(Name = "Shift Type Mt Id")]
        public int ShiftTypeMasterId { get; set; }

        [Required(ErrorMessage = "Provide Shift Type")]
        [Display(Name = "Shift Type")]
        public string ShiftType { get; set; }



    }
}
