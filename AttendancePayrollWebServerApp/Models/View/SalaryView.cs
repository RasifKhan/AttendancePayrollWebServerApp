using System.ComponentModel.DataAnnotations;

namespace AttendancePayrollWebServerApp.Models.View
{
    public class SalaryView
    {
        [Required(ErrorMessage = "Provide Salary Id")]
        [Display(Name = "Salary Id")]
        public int SalaryId { get; set; }

        [Required(ErrorMessage = "Provide Sn")]
        [Display(Name = "Sn")]
        public decimal Sn { get; set; }

        [Required(ErrorMessage = "Provide Sal Str")]
        [Display(Name = "Sal Str")]
        public string SalStr { get; set; }

      //  [Required(ErrorMessage = "Provide Sal Str")]
      //  [Display(Name = "Sal Str")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Provide From Date")]
        [Display(Name = "From Date")]
        public DateTime FromDate { get; set; }

        [Required(ErrorMessage = "Provide To Date")]
        [Display(Name = "To Date")]
        public DateTime ToDate { get; set; }

        [Required(ErrorMessage = "Provide Pay Date")]
        [Display(Name = "Pay Date")]
        public DateTime PayDate { get; set; }

        [Required(ErrorMessage = "Provide Employee Id")]
        [Display(Name = "Employee Id")]
        public string EmployeeId { get; set; }

        [Required(ErrorMessage = "Provide Department Id")]
        [Display(Name = "Department Id")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Provide Department Name")]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "Provide Section Id")]
        [Display(Name = "Section Id")]
        public int SectionId { get; set; }

        [Required(ErrorMessage = "Provide Section Name")]
        [Display(Name = "Section Name")]
        public string SectionName { get; set; }

        [Required(ErrorMessage = "Provide Floor Cat Item Id")]
        [Display(Name = "Floor Cat Item Id")]
        public int FloorCatItemId { get; set; }

        [Required(ErrorMessage = "Provide Floor")]
        [Display(Name = "Floor")]
        public string Floor { get; set; }

        [Required(ErrorMessage = "Provide Line Cat Item Id")]
        [Display(Name = "Line Cat Item Id")]
        public int LineCatItemId { get; set; }

        [Required(ErrorMessage = "Provide Line")]
        [Display(Name = "Line")]
        public string Line { get; set; }

        [Required(ErrorMessage = "Provide Salary Section Id")]
        [Display(Name = "Salary Section Id")]
        public int SalarySectionId { get; set; }

        [Required(ErrorMessage = "Provide Salary Section")]
        [Display(Name = "Salary Section")]
        public string SalarySection { get; set; }

        [Required(ErrorMessage = "Provide Designation Id")]
        [Display(Name = "Designation Id")]
        public int DesignationId { get; set; }

        [Required(ErrorMessage = "Provide Designation")]
        [Display(Name = "Designation")]
        public string Designation { get; set; }

        [Required(ErrorMessage = "Provide Grade Cat Item Id")]
        [Display(Name = "Grade Cat Item Id")]
        public int GradeCatItemId { get; set; }

        [Required(ErrorMessage = "Provide Grade")]
        [Display(Name = "Grade")]
        public string Grade { get; set; }

        [Required(ErrorMessage = "Provide Employee Type Cat Item Id")]
        [Display(Name = "Employee Type Cat Item Id")]
        public int EmployeeTypeCatItemId { get; set; }

        [Required(ErrorMessage = "Provide Type")]
        [Display(Name = "Type")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Provide Pay Source")]
        [Display(Name = "Pay Source")]
        public string PaySource { get; set; }

        [Required(ErrorMessage = "Provide Active Y N")]
        [Display(Name = "Active Y N")]
        public string ActiveYN { get; set; }

        [Required(ErrorMessage = "Provide Bank Info Id")]
        [Display(Name = "Bank Info Id")]
        public int BankInfoId { get; set; }

        [Required(ErrorMessage = "Provide Acc No")]
        [Display(Name = "Acc No")]
        public string AccNo { get; set; }

        [Required(ErrorMessage = "Provide Holiday")]
        [Display(Name = "Holiday")]
        public decimal Holiday { get; set; }

        [Required(ErrorMessage = "Provide Working Day")]
        [Display(Name = "Working Day")]
        public decimal WorkingDay { get; set; }

        [Required(ErrorMessage = "Provide Weekly Holiday Max")]
        [Display(Name = "Weekly Holiday Max")]
        public decimal WeeklyHolidayMax { get; set; }

        [Required(ErrorMessage = "Provide Holiday Max")]
        [Display(Name = "Holiday Max")]
        public decimal HolidayMax { get; set; }

        [Required(ErrorMessage = "Provide Present")]
        [Display(Name = "Present")]
        public decimal Present { get; set; }

        [Required(ErrorMessage = "Provide Absent")]
        [Display(Name = "Absent")]
        public decimal Absent { get; set; }

        [Required(ErrorMessage = "Provide Absent Str")]
        [Display(Name = "Absent Str")]
        public string AbsentStr { get; set; }

        [Required(ErrorMessage = "Provide Absent New Join")]
        [Display(Name = "Absent New Join")]
        public decimal AbsentNewJoin { get; set; }

        [Required(ErrorMessage = "Provide Absent New Join Str")]
        [Display(Name = "Absent New Join Str")]
        public string AbsentNewJoinStr { get; set; }

        [Required(ErrorMessage = "Provide Absent Release")]
        [Display(Name = "Absent Release")]
        public decimal AbsentRelease { get; set; }

        [Required(ErrorMessage = "Provide Absent Release Str")]
        [Display(Name = "Absent Release Str")]
        public string AbsentReleaseStr { get; set; }

        [Required(ErrorMessage = "Provide Absent Total")]
        [Display(Name = "Absent Total")]
        public decimal AbsentTotal { get; set; }

        [Required(ErrorMessage = "Provide Absent Total Str")]
        [Display(Name = "Absent Total Str")]
        public string AbsentTotalStr { get; set; }

        [Required(ErrorMessage = "Provide Late")]
        [Display(Name = "Late")]
        public decimal Late { get; set; }

        [Required(ErrorMessage = "Provide Late Hour")]
        [Display(Name = "Late Hour")]
        public decimal LateHour { get; set; }

        [Required(ErrorMessage = "Provide Late Str")]
        [Display(Name = "Late Str")]
        public string LateStr { get; set; }

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

        [Required(ErrorMessage = "Provide Leave Without Pay")]
        [Display(Name = "Leave Without Pay")]
        public decimal LeaveWithoutPay { get; set; }

        [Required(ErrorMessage = "Provide O L")]
        [Display(Name = "O L")]
        public decimal OL { get; set; }

        [Required(ErrorMessage = "Provide Total Leave")]
        [Display(Name = "Total Leave")]
        public decimal TotalLeave { get; set; }

        [Required(ErrorMessage = "Provide Leave Str")]
        [Display(Name = "Leave Str")]
        public string LeaveStr { get; set; }

        [Required(ErrorMessage = "Provide Grand Total Present")]
        [Display(Name = "Grand Total Present")]
        public decimal GrandTotalPresent { get; set; }

        [Required(ErrorMessage = "Provide Pay Days")]
        [Display(Name = "Pay Days")]
        public decimal PayDays { get; set; }

        [Required(ErrorMessage = "Provide Pay Salary")]
        [Display(Name = "Pay Salary")]
        public decimal PaySalary { get; set; }

        [Required(ErrorMessage = "Provide Over Time")]
        [Display(Name = "Over Time")]
        public decimal OverTime { get; set; }

        [Required(ErrorMessage = "Provide Over Time Amount")]
        [Display(Name = "Over Time Amount")]
        public decimal OverTimeAmount { get; set; }

        [Required(ErrorMessage = "Provide Extra O T")]
        [Display(Name = "Extra O T")]
        public decimal ExtraOT { get; set; }

        [Required(ErrorMessage = "Provide Extra O T Amount")]
        [Display(Name = "Extra O T Amount")]
        public decimal ExtraOTAmount { get; set; }

        [Required(ErrorMessage = "Provide Extra O T Str")]
        [Display(Name = "Extra O T Str")]
        public string ExtraOTStr { get; set; }

        [Required(ErrorMessage = "Provide Additional Over Time")]
        [Display(Name = "Additional Over Time")]
        public decimal AdditionalOverTime { get; set; }

        [Required(ErrorMessage = "Provide Additional O T Str")]
        [Display(Name = "Additional O T Str")]
        public string AdditionalOTStr { get; set; }

        [Required(ErrorMessage = "Provide Deduct O T")]
        [Display(Name = "Deduct O T")]
        public decimal DeductOT { get; set; }

        [Required(ErrorMessage = "Provide Deduct O T Str")]
        [Display(Name = "Deduct O T Str")]
        public string DeductOTStr { get; set; }

        [Required(ErrorMessage = "Provide Total O T")]
        [Display(Name = "Total O T")]
        public decimal TotalOT { get; set; }

        [Required(ErrorMessage = "Provide O T Rate")]
        [Display(Name = "O T Rate")]
        public decimal OTRate { get; set; }

        [Required(ErrorMessage = "Provide O T Amount")]
        [Display(Name = "O T Amount")]
        public decimal OTAmount { get; set; }

        [Required(ErrorMessage = "Provide O T Str")]
        [Display(Name = "O T Str")]
        public string OTStr { get; set; }

        [Required(ErrorMessage = "Provide Total Night")]
        [Display(Name = "Total Night")]
        public decimal TotalNight { get; set; }

        [Required(ErrorMessage = "Provide Night Rate")]
        [Display(Name = "Night Rate")]
        public decimal NightRate { get; set; }

        [Required(ErrorMessage = "Provide Night Allowance")]
        [Display(Name = "Night Allowance")]
        public decimal NightAllowance { get; set; }

        [Required(ErrorMessage = "Provide Attendance Bonus")]
        [Display(Name = "Attendance Bonus")]
        public decimal AttendanceBonus { get; set; }

        [Required(ErrorMessage = "Provide Production Bonus")]
        [Display(Name = "Production Bonus")]
        public decimal ProductionBonus { get; set; }

        [Required(ErrorMessage = "Provide Holiday Allowance")]
        [Display(Name = "Holiday Allowance")]
        public decimal HolidayAllowance { get; set; }

        [Required(ErrorMessage = "Provide Holiday Allowance Str")]
        [Display(Name = "Holiday Allowance Str")]
        public string HolidayAllowanceStr { get; set; }

        [Required(ErrorMessage = "Provide Mobile Allowance")]
        [Display(Name = "Mobile Allowance")]
        public decimal MobileAllowance { get; set; }

        [Required(ErrorMessage = "Provide Trans Allowance Pay")]
        [Display(Name = "Trans Allowance Pay")]
        public decimal TransAllowancePay { get; set; }

        [Required(ErrorMessage = "Provide Trans Allowance Pay Str")]
        [Display(Name = "Trans Allowance Pay Str")]
        public string TransAllowancePayStr { get; set; }

        [Required(ErrorMessage = "Provide Other Allowance")]
        [Display(Name = "Other Allowance")]
        public decimal OtherAllowance { get; set; }

        [Required(ErrorMessage = "Provide Other Allowance Str")]
        [Display(Name = "Other Allowance Str")]
        public string OtherAllowanceStr { get; set; }

        [Required(ErrorMessage = "Provide Arear")]
        [Display(Name = "Arear")]
        public decimal Arear { get; set; }

        [Required(ErrorMessage = "Provide Arear Str")]
        [Display(Name = "Arear Str")]
        public string ArearStr { get; set; }

        [Required(ErrorMessage = "Provide Maternity Leave")]
        [Display(Name = "Maternity Leave")]
        public decimal MaternityLeave { get; set; }

        [Required(ErrorMessage = "Provide Maternity Leave Str")]
        [Display(Name = "Maternity Leave Str")]
        public string MaternityLeaveStr { get; set; }

        [Required(ErrorMessage = "Provide Total Amount")]
        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }

        [Required(ErrorMessage = "Provide Pay Total")]
        [Display(Name = "Pay Total")]
        public decimal PayTotal { get; set; }

        [Required(ErrorMessage = "Provide Absent Deduct")]
        [Display(Name = "Absent Deduct")]
        public decimal AbsentDeduct { get; set; }

        [Required(ErrorMessage = "Provide Absent Deduct New Join")]
        [Display(Name = "Absent Deduct New Join")]
        public decimal AbsentDeductNewJoin { get; set; }

        [Required(ErrorMessage = "Provide Absent Deduct Release")]
        [Display(Name = "Absent Deduct Release")]
        public decimal AbsentDeductRelease { get; set; }

        [Required(ErrorMessage = "Provide Absent Deduct Total")]
        [Display(Name = "Absent Deduct Total")]
        public decimal AbsentDeductTotal { get; set; }

        [Required(ErrorMessage = "Provide Late Deduct")]
        [Display(Name = "Late Deduct")]
        public decimal LateDeduct { get; set; }

        [Required(ErrorMessage = "Provide Late Deduct Str")]
        [Display(Name = "Late Deduct Str")]
        public string LateDeductStr { get; set; }

        [Required(ErrorMessage = "Provide Leave Deduct")]
        [Display(Name = "Leave Deduct")]
        public decimal LeaveDeduct { get; set; }

        [Required(ErrorMessage = "Provide Leave Deduct Str")]
        [Display(Name = "Leave Deduct Str")]
        public string LeaveDeductStr { get; set; }

        [Required(ErrorMessage = "Provide Transport Deduct")]
        [Display(Name = "Transport Deduct")]
        public decimal TransportDeduct { get; set; }

        [Required(ErrorMessage = "Provide Transport Deduct Str")]
        [Display(Name = "Transport Deduct Str")]
        public string TransportDeductStr { get; set; }

        [Required(ErrorMessage = "Provide Other Deduct")]
        [Display(Name = "Other Deduct")]
        public decimal OtherDeduct { get; set; }

        [Required(ErrorMessage = "Provide Other Deduct Str")]
        [Display(Name = "Other Deduct Str")]
        public string OtherDeductStr { get; set; }

        [Required(ErrorMessage = "Provide Tax")]
        [Display(Name = "Tax")]
        public decimal Tax { get; set; }

        [Required(ErrorMessage = "Provide Tax Str")]
        [Display(Name = "Tax Str")]
        public string TaxStr { get; set; }

        [Required(ErrorMessage = "Provide Provident Fund")]
        [Display(Name = "Provident Fund")]
        public decimal ProvidentFund { get; set; }

        [Required(ErrorMessage = "Provide Provident Fund Str")]
        [Display(Name = "Provident Fund Str")]
        public string ProvidentFundStr { get; set; }

        [Required(ErrorMessage = "Provide Lunch")]
        [Display(Name = "Lunch")]
        public decimal Lunch { get; set; }

        [Required(ErrorMessage = "Provide Lunch Str")]
        [Display(Name = "Lunch Str")]
        public string LunchStr { get; set; }

        [Required(ErrorMessage = "Provide Advance")]
        [Display(Name = "Advance")]
        public decimal Advance { get; set; }

        [Required(ErrorMessage = "Provide Advance Str")]
        [Display(Name = "Advance Str")]
        public string AdvanceStr { get; set; }

        [Required(ErrorMessage = "Provide Loan")]
        [Display(Name = "Loan")]
        public decimal Loan { get; set; }

        [Required(ErrorMessage = "Provide Loan Str")]
        [Display(Name = "Loan Str")]
        public string LoanStr { get; set; }

        [Required(ErrorMessage = "Provide Mobbile Deduct")]
        [Display(Name = "Mobbile Deduct")]
        public decimal MobbileDeduct { get; set; }

        [Required(ErrorMessage = "Provide Mobbile Deduct Str")]
        [Display(Name = "Mobbile Deduct Str")]
        public string MobbileDeductStr { get; set; }

        [Required(ErrorMessage = "Provide Security Deduct")]
        [Display(Name = "Security Deduct")]
        public decimal SecurityDeduct { get; set; }

        [Required(ErrorMessage = "Provide Security Deduct Str")]
        [Display(Name = "Security Deduct Str")]
        public string SecurityDeductStr { get; set; }

        [Required(ErrorMessage = "Provide Stamp")]
        [Display(Name = "Stamp")]
        public decimal Stamp { get; set; }

        [Required(ErrorMessage = "Provide Total Deduct")]
        [Display(Name = "Total Deduct")]
        public decimal TotalDeduct { get; set; }

        [Required(ErrorMessage = "Provide Net Pay")]
        [Display(Name = "Net Pay")]
        public decimal NetPay { get; set; }

        [Required(ErrorMessage = "Provide Net Pay Str")]
        [Display(Name = "Net Pay Str")]
        public string NetPayStr { get; set; }

        [Required(ErrorMessage = "Provide Cash")]
        [Display(Name = "Cash")]
        public decimal Cash { get; set; }

        [Required(ErrorMessage = "Provide Bank")]
        [Display(Name = "Bank")]
        public decimal Bank { get; set; }

        [Required(ErrorMessage = "Provide Paid")]
        [Display(Name = "Paid")]
        public decimal Paid { get; set; }

        [Required(ErrorMessage = "Provide Due")]
        [Display(Name = "Due")]
        public decimal Due { get; set; }

        [Required(ErrorMessage = "Provide Remarks")]
        [Display(Name = "Remarks")]
        public string Remarks { get; set; }

        [Required(ErrorMessage = "Provide Payment Status")]
        [Display(Name = "Payment Status")]
        public string PaymentStatus { get; set; }

        [Required(ErrorMessage = "Provide E L Days")]
        [Display(Name = "E L Days")]
        public decimal ELDays { get; set; }

        [Required(ErrorMessage = "Provide E L Amount")]
        [Display(Name = "E L Amount")]
        public decimal ELAmount { get; set; }

        [Required(ErrorMessage = "Provide Lunch Addition")]
        [Display(Name = "Lunch Addition")]
        public decimal LunchAddition { get; set; }

        [Required(ErrorMessage = "Provide Lunch Deduction")]
        [Display(Name = "Lunch Deduction")]
        public decimal LunchDeduction { get; set; }

        [Required(ErrorMessage = "Provide Service Duration")]
        [Display(Name = "Service Duration")]
        public decimal ServiceDuration { get; set; }

        [Required(ErrorMessage = "Provide Routing Number")]
        [Display(Name = "Routing Number")]
        public decimal RoutingNumber { get; set; }

        [Required(ErrorMessage = "Provide Bank Acc Type")]
        [Display(Name = "Bank Acc Type")]
        public string BankAccType { get; set; }

        [Required(ErrorMessage = "Provide Tk1000")]
        [Display(Name = "Tk1000")]
        public decimal Tk1000 { get; set; }

        [Required(ErrorMessage = "Provide Tk500")]
        [Display(Name = "Tk500")]
        public decimal Tk500 { get; set; }

        [Required(ErrorMessage = "Provide Tk100")]
        [Display(Name = "Tk100")]
        public decimal Tk100 { get; set; }

        [Required(ErrorMessage = "Provide Tk50")]
        [Display(Name = "Tk50")]
        public decimal Tk50 { get; set; }

        [Required(ErrorMessage = "Provide Tk20")]
        [Display(Name = "Tk20")]
        public decimal Tk20 { get; set; }

        [Required(ErrorMessage = "Provide Tk10")]
        [Display(Name = "Tk10")]
        public decimal Tk10 { get; set; }

        [Required(ErrorMessage = "Provide Tk5")]
        [Display(Name = "Tk5")]
        public decimal Tk5 { get; set; }

        [Required(ErrorMessage = "Provide Tk2")]
        [Display(Name = "Tk2")]
        public decimal Tk2 { get; set; }

        [Required(ErrorMessage = "Provide Tk1")]
        [Display(Name = "Tk1")]
        public decimal Tk1 { get; set; }

        [Required(ErrorMessage = "Provide Devider")]
        [Display(Name = "Devider")]
        public decimal Devider { get; set; }

        [Required(ErrorMessage = "Provide Reminder")]
        [Display(Name = "Reminder")]
        public decimal Reminder { get; set; }

        [Required(ErrorMessage = "Provide In Word")]
        [Display(Name = "In Word")]
        public string InWord { get; set; }

        [Required(ErrorMessage = "Provide In Word Bangla")]
        [Display(Name = "In Word Bangla")]
        public string InWordBangla { get; set; }

        [Required(ErrorMessage = "Provide W H D P L")]
        [Display(Name = "W H D P L")]
        public decimal WHDPL { get; set; }

        [Required(ErrorMessage = "Provide H D P L")]
        [Display(Name = "H D P L")]
        public decimal HDPL { get; set; }

        [Required(ErrorMessage = "Provide Over Time Y N")]
        [Display(Name = "Over Time Y N")]
        public string OverTimeYN { get; set; }

        [Required(ErrorMessage = "Provide Gross Salary")]
        [Display(Name = "Gross Salary")]
        public decimal GrossSalary { get; set; }

        [Required(ErrorMessage = "Provide Basic Salary")]
        [Display(Name = "Basic Salary")]
        public decimal BasicSalary { get; set; }

        [Required(ErrorMessage = "Provide House Rent")]
        [Display(Name = "House Rent")]
        public decimal HouseRent { get; set; }

        [Required(ErrorMessage = "Provide Food Allowance")]
        [Display(Name = "Food Allowance")]
        public decimal FoodAllowance { get; set; }

        [Required(ErrorMessage = "Provide Transport Allowance")]
        [Display(Name = "Transport Allowance")]
        public decimal TransportAllowance { get; set; }

        [Required(ErrorMessage = "Provide Medical Allowance")]
        [Display(Name = "Medical Allowance")]
        public decimal MedicalAllowance { get; set; }

        [Required(ErrorMessage = "Provide Exchange Rate")]
        [Display(Name = "Exchange Rate")]
        public decimal ExchangeRate { get; set; }

        [Required(ErrorMessage = "Provide Gross Salary Usd")]
        [Display(Name = "Gross Salary Usd")]
        public decimal GrossSalaryUsd { get; set; }

        [Required(ErrorMessage = "Provide Salary Per Day")]
        [Display(Name = "Salary Per Day")]
        public decimal SalaryPerDay { get; set; }

        [Required(ErrorMessage = "Provide Increment")]
        [Display(Name = "Increment")]
        public decimal Increment { get; set; }

        [Required(ErrorMessage = "Provide Increment Str")]
        [Display(Name = "Increment Str")]
        public string IncrementStr { get; set; }

        [Required(ErrorMessage = "Provide Month Days")]
        [Display(Name = "Month Days")]
        public decimal MonthDays { get; set; }

        [Required(ErrorMessage = "Provide Weekly Holiday")]
        [Display(Name = "Weekly Holiday")]
        public decimal WeeklyHoliday { get; set; }



    }
}
