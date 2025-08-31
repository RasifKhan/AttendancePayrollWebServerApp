using System.ComponentModel.DataAnnotations;
namespace AttendancePayrollWebServerApp.Models.View
{
    public class AttendanceSummaryView
    {
        [Required(ErrorMessage = "Provide Id")]
        [Display(Name = "Id")]
        public decimal Id { get; set; }

        [Required(ErrorMessage = "Provide Employee Id")]
        [Display(Name = "Employee Id")]
        public string EmployeeId { get; set; }

        [Required(ErrorMessage = "Provide Employee Name")]
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Provide Section Name")]
        [Display(Name = "Section Name")]
        public string SectionName { get; set; }

        [Required(ErrorMessage = "Provide Department Name")]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "Provide Designation Name")]
        [Display(Name = "Designation Name")]
        public string DesignationName { get; set; }

        [Required(ErrorMessage = "Provide worktype")]
        [Display(Name = "worktype")]
        public string worktype { get; set; }

        [Required(ErrorMessage = "Provide M Att Str")]
        [Display(Name = "M Att Str")]
        public string MAttStr { get; set; }

        [Required(ErrorMessage = "Provide From Date")]
        [Display(Name = "From Date")]
        public DateTime FromDate { get; set; }

        public DateTime JoinDate { get; set; }

        [Required(ErrorMessage = "Provide To Date")]
        [Display(Name = "To Date")]
        public DateTime ToDate { get; set; }

        [Required(ErrorMessage = "Provide Month Days")]
        [Display(Name = "Month Days")]
        public decimal MonthDays { get; set; }

        [Required(ErrorMessage = "Provide W H D")]
        [Display(Name = "W H D")]
        public decimal WHD { get; set; }

        [Required(ErrorMessage = "Provide H D")]
        [Display(Name = "H D")]
        public decimal HD { get; set; }

        [Required(ErrorMessage = "Provide W D")]
        [Display(Name = "W D")]
        public decimal WD { get; set; }

        [Required(ErrorMessage = "Provide P")]
        [Display(Name = "P")]
        public decimal P { get; set; }

        [Required(ErrorMessage = "Provide A")]
        [Display(Name = "A")]
        public decimal A { get; set; }

        [Required(ErrorMessage = "Provide L")]
        [Display(Name = "L")]
        public decimal L { get; set; }

        [Required(ErrorMessage = "Provide W H D P L")]
        [Display(Name = "W H D P L")]
        public decimal WHDPL { get; set; }

        [Required(ErrorMessage = "Provide H D P L")]
        [Display(Name = "H D P L")]
        public decimal HDPL { get; set; }

        [Required(ErrorMessage = "Provide Total Present")]
        [Display(Name = "Total Present")]
        public decimal TotalPresent { get; set; }

        [Required(ErrorMessage = "Provide C L")]
        [Display(Name = "C L")]
        public decimal CL { get; set; }

        [Required(ErrorMessage = "Provide S L")]
        [Display(Name = "S L")]
        public decimal SL { get; set; }

        [Required(ErrorMessage = "Provide E L")]
        [Display(Name = "E L")]
        public decimal EL { get; set; }

        [Required(ErrorMessage = "Provide M L")]
        [Display(Name = "M L")]
        public decimal ML { get; set; }

        [Required(ErrorMessage = "Provide L W P")]
        [Display(Name = "L W P")]
        public decimal LWP { get; set; }

        [Required(ErrorMessage = "Provide O L")]
        [Display(Name = "O L")]
        public decimal OL { get; set; }

        [Required(ErrorMessage = "Provide Total Leave")]
        [Display(Name = "Total Leave")]
        public decimal TotalLeave { get; set; }

        [Required(ErrorMessage = "Provide Leave Str")]
        [Display(Name = "Leave Str")]
        public string LeaveStr { get; set; }

        [Required(ErrorMessage = "Provide Pay D")]
        [Display(Name = "Pay D")]
        public decimal PayD { get; set; }

        [Required(ErrorMessage = "Provide L Hr")]
        [Display(Name = "L Hr")]
        public decimal LHr { get; set; }

        [Required(ErrorMessage = "Provide L Str")]
        [Display(Name = "L Str")]
        public string LStr { get; set; }

        [Required(ErrorMessage = "Provide O T")]
        [Display(Name = "O T")]
        public decimal OT { get; set; }

        [Required(ErrorMessage = "Provide Ext O T")]
        [Display(Name = "Ext O T")]
        public decimal ExtOT { get; set; }

        [Required(ErrorMessage = "Provide Ded O T")]
        [Display(Name = "Ded O T")]
        public decimal DedOT { get; set; }

        [Required(ErrorMessage = "Provide Total O T")]
        [Display(Name = "Total O T")]
        public decimal TotalOT { get; set; }

        [Required(ErrorMessage = "Provide Remarks")]
        [Display(Name = "Remarks")]
        public string Remarks { get; set; }

        public decimal SN { get; set; }
    }
}
