using System.ComponentModel.DataAnnotations;

namespace AttendancePayrollWebServerApp.Models
{
    public class FixAttendance
    {
        [Key]
        public int FixAttendanceId { get; set; }

        //public int NoneJoinedAttId { get; set; }
        
        [Required(ErrorMessage = "Provide Employee Id")]
        [Display(Name = "Employee Id")]
        public string EmployeeId { get; set; }

        [Required(ErrorMessage = "Provide Date")]
        [Display(Name = "Date")]
        public DateTime AttendanceDate { get; set; }

        [Required(ErrorMessage = "Provide Time In")]
        [Display(Name = "Time In")]
        public DateTime TimeIn { get; set; }

        [Required(ErrorMessage = "Provide Time Out")]
        [Display(Name = "Time Out")]
        public DateTime TimeOut { get; set; }

        [Required(ErrorMessage = "Provide Actual Time In")]
        [Display(Name = "Actual Time In")]
        public DateTime ActualTimeIn { get; set; }

        [Required(ErrorMessage = "Provide Actual Time Out")]
        [Display(Name = "Actual Time Out")]
        public DateTime ActualTimeOut { get; set; }

        [Required(ErrorMessage = "Provide Actual Status")]
        [Display(Name = "Actual Status")]
        public string ActualStatus { get; set; }

        [Required(ErrorMessage = "Provide Actual O T")]
        [Display(Name = "Actual O T")]
        public DateTime ActualOT { get; set; }

        [Required(ErrorMessage = "Provide Actual Late")]
        [Display(Name = "Actual Late")]
        public DateTime ActualLate { get; set; }

        [Required(ErrorMessage = "Provide O T")]
        [Display(Name = "O T")]
        public DateTime OT { get; set; }

        [Required(ErrorMessage = "Provide Status")]
        [Display(Name = "Status")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Provide Remark")]
        [Display(Name = "Remarks")]
        public string Remarks { get; set; }

        [Required(ErrorMessage = "Provide Fix Date")]
        [Display(Name = "Fix Date")]
        public DateTime FixDate { get; set; }

        [Required(ErrorMessage = "Provide User I D")]
        [Display(Name = "User I D")]
        public string UserID { get; set; }

        [Required(ErrorMessage = "Provide P C")]
        [Display(Name = "P C")]
        public string PC { get; set; }

        [Required(ErrorMessage = "Provide I P")]
        [Display(Name = "I P")]
        public string IP { get; set; }
        public string? ProcessedYN { get; set; }

        Employee? Employee { get; set; }

    }
}
