using System.ComponentModel.DataAnnotations;

namespace AttendancePayrollWebServerApp.Models.View
{
    public class JobCardView
    {

        [Required(ErrorMessage = "Provide Company Name")]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Provide S N")]
        [Display(Name = "S N")]
        public decimal SN { get; set; }

        [Required(ErrorMessage = "Provide Department Name")]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "Provide Designation Name")]
        [Display(Name = "Designation Name")]
        public string DesignationName { get; set; }

        [Required(ErrorMessage = "Provide Employee Name")]
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Provide Shift Name")]
        [Display(Name = "Shift Name")]
        public string ShiftName { get; set; }

        [Required(ErrorMessage = "Provide Shift Type")]
        [Display(Name = "Shift Type")]
        public string ShiftType { get; set; }

        [Required(ErrorMessage = "Provide Section Name")]
        [Display(Name = "Section Name")]
        public string SectionName { get; set; }

        [Required(ErrorMessage = "Provide Salary Section Name")]
        [Display(Name = "Salary Section Name")]
        public string SalarySectionName { get; set; }

        [Required(ErrorMessage = "Provide Attendance Id")]
        [Display(Name = "Attendance Id")]
        public int AttendanceId { get; set; }

        [Required(ErrorMessage = "Provide Employee Id")]
        [Display(Name = "Employee Id")]
        public string EmployeeId { get; set; }

        [Required(ErrorMessage = "Provide Card Id")]
        [Display(Name = "Card Id")]
        public string CardId { get; set; }

        [Required(ErrorMessage = "Provide Department Id")]
        [Display(Name = "Department Id")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Provide Section Id")]
        [Display(Name = "Section Id")]
        public int SectionId { get; set; }

        [Required(ErrorMessage = "Provide Expr6")]
        [Display(Name = "Expr6")]
        public int Expr6 { get; set; }

        [Required(ErrorMessage = "Provide Designation Id")]
        [Display(Name = "Designation Id")]
        public int DesignationId { get; set; }

        [Required(ErrorMessage = "Provide Company Id")]
        [Display(Name = "Company Id")]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "Provide Attendance Date")]
        [Display(Name = "Attendance Date")]
        public DateTime AttendanceDate { get; set; }

        [Required(ErrorMessage = "Provide Time In")]
        [Display(Name = "Time In")]
        public DateTime TimeIn { get; set; }

        [Required(ErrorMessage = "Provide Time Out")]
        [Display(Name = "Time Out")]
        public DateTime TimeOut { get; set; }

        [Required(ErrorMessage = "Provide Shift Detail Id")]
        [Display(Name = "Shift Detail Id")]
        public int ShiftDetailId { get; set; }

        [Required(ErrorMessage = "Provide Late")]
        [Display(Name = "Late")]
        public DateTime Late { get; set; }

        [Required(ErrorMessage = "Provide Shift In")]
        [Display(Name = "Shift In")]
        public DateTime ShiftIn { get; set; }

        [Required(ErrorMessage = "Provide Shift Out")]
        [Display(Name = "Shift Out")]
        public DateTime ShiftOut { get; set; }

        [Required(ErrorMessage = "Provide Shift Late")]
        [Display(Name = "Shift Late")]
        public DateTime ShiftLate { get; set; }

        [Required(ErrorMessage = "Provide Shift Lunch In")]
        [Display(Name = "Shift Lunch In")]
        public DateTime ShiftLunchIn { get; set; }

        [Required(ErrorMessage = "Provide Shift Lunch Out")]
        [Display(Name = "Shift Lunch Out")]
        public DateTime ShiftLunchOut { get; set; }

        [Required(ErrorMessage = "Provide Shift Lunch Late")]
        [Display(Name = "Shift Lunch Late")]
        public DateTime ShiftLunchLate { get; set; }

        [Required(ErrorMessage = "Provide Shift Lunch Hr")]
        [Display(Name = "Shift Lunch Hr")]
        public DateTime ShiftLunchHr { get; set; }

        [Required(ErrorMessage = "Provide Duty Hr")]
        [Display(Name = "Duty Hr")]
        public DateTime DutyHr { get; set; }

        [Required(ErrorMessage = "Provide Work Hr")]
        [Display(Name = "Work Hr")]
        public decimal WorkHr { get; set; }

        [Required(ErrorMessage = "Provide Late Hr")]
        [Display(Name = "Late Hr")]
        public decimal LateHr { get; set; }

        [Required(ErrorMessage = "Provide O T")]
        [Display(Name = "O T")]
        public DateTime OT { get; set; }

        [Required(ErrorMessage = "Provide O T Hr")]
        [Display(Name = "O T Hr")]
        public decimal OTHr { get; set; }

        [Required(ErrorMessage = "Provide O T Min")]
        [Display(Name = "O T Min")]
        public decimal OTMin { get; set; }

        [Required(ErrorMessage = "Provide Status")]
        [Display(Name = "Status")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Provide P Cnt")]
        [Display(Name = "P Cnt")]
        public decimal PCnt { get; set; }

        [Required(ErrorMessage = "Provide Remark")]
        [Display(Name = "Remark")]
        public string Remark { get; set; }

        [Required(ErrorMessage = "Provide Sft Emp")]
        [Display(Name = "Sft Emp")]
        public string SftEmp { get; set; }

        [Required(ErrorMessage = "Provide Act In")]
        [Display(Name = "Act In")]
        public DateTime ActIn { get; set; }

        [Required(ErrorMessage = "Provide Act Out")]
        [Display(Name = "Act Out")]
        public DateTime ActOut { get; set; }

        [Required(ErrorMessage = "Provide Ln Out")]
        [Display(Name = "Ln Out")]
        public DateTime LnOut { get; set; }

        [Required(ErrorMessage = "Provide Ln Bk")]
        [Display(Name = "Ln Bk")]
        public DateTime LnBk { get; set; }

        [Required(ErrorMessage = "Provide Ln Lt Hr")]
        [Display(Name = "Ln Lt Hr")]
        public decimal LnLtHr { get; set; }

        [Required(ErrorMessage = "Provide E Out")]
        [Display(Name = "E Out")]
        public DateTime EOut { get; set; }

        [Required(ErrorMessage = "Provide E O Hr")]
        [Display(Name = "E O Hr")]
        public decimal EOHr { get; set; }

        [Required(ErrorMessage = "Provide Act O T")]
        [Display(Name = "Act O T")]
        public decimal ActOT { get; set; }

        [Required(ErrorMessage = "Provide Ext O T")]
        [Display(Name = "Ext O T")]
        public decimal ExtOT { get; set; }

        [Required(ErrorMessage = "Provide Ded O T")]
        [Display(Name = "Ded O T")]
        public decimal DedOT { get; set; }

        [Required(ErrorMessage = "Provide O T Rem")]
        [Display(Name = "O T Rem")]
        public string OTRem { get; set; }

        [Required(ErrorMessage = "Provide Pnc")]
        [Display(Name = "Pnc")]
        public decimal Pnc { get; set; }

        [Required(ErrorMessage = "Provide F I D")]
        [Display(Name = "F I D")]
        public string FID { get; set; }

        [Required(ErrorMessage = "Provide N1")]
        [Display(Name = "N1")]
        public decimal N1 { get; set; }

        [Required(ErrorMessage = "Provide N2")]
        [Display(Name = "N2")]
        public decimal N2 { get; set; }

        [Required(ErrorMessage = "Provide S1")]
        [Display(Name = "S1")]
        public string S1 { get; set; }

        [Required(ErrorMessage = "Provide S2")]
        [Display(Name = "S2")]
        public string S2 { get; set; }

        [Required(ErrorMessage = "Provide D1")]
        [Display(Name = "D1")]
        public DateTime D1 { get; set; }

        [Required(ErrorMessage = "Provide D2")]
        [Display(Name = "D2")]
        public DateTime D2 { get; set; }

        [Required(ErrorMessage = "Provide Sex")]
        [Display(Name = "Sex")]
        public string Sex { get; set; }

        [Required(ErrorMessage = "Provide Comp Name Ban")]
        [Display(Name = "Comp Name Ban")]
        public string CompNameBan { get; set; }

        [Required(ErrorMessage = "Provide From Date")]
        [Display(Name = "From Date")]
        public DateTime FromDate { get; set; }

        [Required(ErrorMessage = "Provide To Date")]
        [Display(Name = "To Date")]
        public DateTime ToDate { get; set; }

        [Required(ErrorMessage = "Provide P")]
        [Display(Name = "P")]
        public decimal P { get; set; }

        [Required(ErrorMessage = "Provide A")]
        [Display(Name = "A")]
        public decimal A { get; set; }

        [Required(ErrorMessage = "Provide L")]
        [Display(Name = "L")]
        public decimal L { get; set; }

        [Required(ErrorMessage = "Provide H D")]
        [Display(Name = "H D")]
        public decimal HD { get; set; }

        [Required(ErrorMessage = "Provide W H D")]
        [Display(Name = "W H D")]
        public decimal WHD { get; set; }

        [Required(ErrorMessage = "Provide C L")]
        [Display(Name = "C L")]
        public decimal CL { get; set; }

        [Required(ErrorMessage = "Provide S L")]
        [Display(Name = "S L")]
        public decimal SL { get; set; }

        [Required(ErrorMessage = "Provide E L")]
        [Display(Name = "E L")]
        public decimal EL { get; set; }

        [Required(ErrorMessage = "Provide Expr1")]
        [Display(Name = "Expr1")]
        public decimal Expr1 { get; set; }

        [Required(ErrorMessage = "Provide M D")]
        [Display(Name = "M D")]
        public decimal MD { get; set; }

        [Required(ErrorMessage = "Provide W D")]
        [Display(Name = "W D")]
        public decimal WD { get; set; }

        [Required(ErrorMessage = "Provide Total Leave")]
        [Display(Name = "Total Leave")]
        public decimal TotalLeave { get; set; }





    }
}
