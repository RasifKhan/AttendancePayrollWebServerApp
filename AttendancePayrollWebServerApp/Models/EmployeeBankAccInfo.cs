using AttendancePayrollWebServerApp.Helper;
using System.ComponentModel;
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



        public int? BranchCatItemId { get; set; }


        [Required(ErrorMessage = "Provide Acc No")]


        [BankAccountValidation]
        
        public string AccNo { get; set; }


        [Required]
        public string Status { get; set; }
        


        [Required(ErrorMessage = "Provide Remarks")]
        public string Remarks { get; set; }






    }
}
