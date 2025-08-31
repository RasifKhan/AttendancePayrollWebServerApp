//using System.ComponentModel.DataAnnotations;
//namespace AttendancePayrollWebServerApp.Models;

//public class FixAttendanceInstant
//{
//    [Required(ErrorMessage = "Provide Fix Inst Id")]
//    [Display(Name = "Fix Inst Id")]
//    public int FixInstId { get; set; }

//    [Required(ErrorMessage = "Provide Attendance Id")]
//    [Display(Name = "Attendance Id")]
//    public int AttendanceId { get; set; }

//    [Required(ErrorMessage = "Provide Employee Id")]
//    [Display(Name = "Employee Id")]
//    public string EmployeeId { get; set; }

//    [Required(ErrorMessage = "Provide Attendance Date")]
//    [Display(Name = "Attendance Date")]
//    public DateTime AttendanceDate { get; set; }

//    [Required(ErrorMessage = "Provide Fix Type")]
//    [Display(Name = "Fix Type")]
//    public string FixType { get; set; }

//    [Required(ErrorMessage = "Provide Time In")]
//    [Display(Name = "Time In")]
//    public DateTime TimeIn { get; set; }

//    [Required(ErrorMessage = "Provide Time Out")]
//    [Display(Name = "Time Out")]
//    public DateTime TimeOut { get; set; }

//    [Required(ErrorMessage = "Provide O T")]
//    [Display(Name = "O T")]
//    public DateTime OT { get; set; }

//    [Required(ErrorMessage = "Provide Shift Detail Id")]
//    [Display(Name = "Shift Detail Id")]
//    public int ShiftDetailId { get; set; }

//    [Required(ErrorMessage = "Provide Actual Shift Detail Id")]
//    [Display(Name = "Actual Shift Detail Id")]
//    public int ActualShiftDetailId { get; set; }

//    [Required(ErrorMessage = "Provide Status")]
//    [Display(Name = "Status")]
//    public string Status { get; set; }

//    [Required(ErrorMessage = "Provide Remarks")]
//    [Display(Name = "Remarks")]
//    public string Remarks { get; set; }

//    [Required(ErrorMessage = "Provide Actual Time In")]
//    [Display(Name = "Actual Time In")]
//    public DateTime ActualTimeIn { get; set; }

//    [Required(ErrorMessage = "Provide Actual Time Out")]
//    [Display(Name = "Actual Time Out")]
//    public DateTime ActualTimeOut { get; set; }

//    [Required(ErrorMessage = "Provide Actual O T")]
//    [Display(Name = "Actual O T")]
//    public DateTime ActualOT { get; set; }

//    [Required(ErrorMessage = "Provide Actual Status")]
//    [Display(Name = "Actual Status")]
//    public string ActualStatus { get; set; }

//    [Required(ErrorMessage = "Provide A Remarks")]
//    [Display(Name = "A Remarks")]
//    public string ARemarks { get; set; }

//    [Required(ErrorMessage = "Provide U Id")]
//    [Display(Name = "U Id")]
//    public string UId { get; set; }

//    [Required(ErrorMessage = "Provide U Name")]
//    [Display(Name = "U Name")]
//    public string UName { get; set; }

//    [Required(ErrorMessage = "Provide P C Name")]
//    [Display(Name = "P C Name")]
//    public string PCName { get; set; }

//    [Required(ErrorMessage = "Provide Fix Date")]
//    [Display(Name = "Fix Date")]
//    public DateTime FixDate { get; set; }





//}









using System.ComponentModel.DataAnnotations;
namespace AttendancePayrollWebServerApp.Models
{
    public class FixAttendanceInstant
    {



        [Key]
        public int FixInstId { get; set; }

        [Required(ErrorMessage = "Provide Attendance Id")]
        [Display(Name = "Attendance Id")]
        public int AttendanceId { get; set; }

        [Required(ErrorMessage = "Provide Employee Id")]
        [Display(Name = "Employee Id")]
        public string EmployeeId { get; set; }

        [Required(ErrorMessage = "Provide Attendance Date")]
        [Display(Name = "Attendance Date")]
        public DateTime AttendanceDate { get; set; }

        [Required(ErrorMessage = "Provide Fix Type")]
        [Display(Name = "Fix Type")]
        public string FixType { get; set; }

        [Required(ErrorMessage = "Provide Time In")]
        [Display(Name = "Time In")]
        public DateTime TimeIn { get; set; }

        [Required(ErrorMessage = "Provide Time Out")]
        [Display(Name = "Time Out")]
        public DateTime TimeOut { get; set; }

        [Required(ErrorMessage = "Provide O T")]
        [Display(Name = "O T")]
        public DateTime OT { get; set; }

        [Required(ErrorMessage = "Provide Shift Detail Id")]
        [Display(Name = "Shift Detail Id")]
        public int ShiftDetailId { get; set; }

        [Required(ErrorMessage = "Provide Actual Shift Detail Id")]
        [Display(Name = "Actual Shift Detail Id")]
        public int ActualShiftDetailId { get; set; }

        [Required(ErrorMessage = "Provide Status")]
        [Display(Name = "Status")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Provide Remarks")]
        [Display(Name = "Remarks")]
        public string Remarks { get; set; }

        [Required(ErrorMessage = "Provide Actual Time In")]
        [Display(Name = "Actual Time In")]
        public DateTime ActualTimeIn { get; set; }

        [Required(ErrorMessage = "Provide Actual Time Out")]
        [Display(Name = "Actual Time Out")]
        public DateTime ActualTimeOut { get; set; }

        [Required(ErrorMessage = "Provide Actual O T")]
        [Display(Name = "Actual O T")]
        public DateTime ActualOT { get; set; }

        [Required(ErrorMessage = "Provide Actual Status")]
        [Display(Name = "Actual Status")]
        public string ActualStatus { get; set; }

        [Required(ErrorMessage = "Provide A Remarks")]
        [Display(Name = "A Remarks")]
        public string ARemarks { get; set; }

        [Required(ErrorMessage = "Provide U Id")]
        [Display(Name = "U Id")]
        public string UId { get; set; }

        [Required(ErrorMessage = "Provide U Name")]
        [Display(Name = "U Name")]
        public string UName { get; set; }

        [Required(ErrorMessage = "Provide P C Name")]
        [Display(Name = "P C Name")]
        public string PCName { get; set; }

        [Required(ErrorMessage = "Provide Fix Date")]
        [Display(Name = "Fix Date")]
        public DateTime FixDate { get; set; }







    }
}
