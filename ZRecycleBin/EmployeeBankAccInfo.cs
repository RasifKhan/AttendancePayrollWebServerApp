using System.ComponentModel.DataAnnotations;
namespace AttendancePayrollWebServerApp.Models
{
    public class EmployeeBankAccInfo
    {
        [Key]
        public int InfoId { get; set; }

        [Required(ErrorMessage = "Provide Employee Id")]
        public string EmployeeId { get; set; }


        [Required(ErrorMessage = "Provide Bank Cat Item Id")]
        public int BankCatItemId { get; set; }


        public int BranchCatItemId { get; set; }


        [Required(ErrorMessage = "Provide Acc No")]
        public string AccNo { get; set; }


        [Required(ErrorMessage = "Provide From Date")]
        public DateTime FromDate { get; set; }


        [Required(ErrorMessage = "Provide To Date")]
        public DateTime ToDate { get; set; }


        [Required(ErrorMessage = "Provide Remarks")]
        public string Remarks { get; set; }
    }
}
