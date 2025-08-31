using AttendancePayrollWebServerApp.Models;
using System.ComponentModel.DataAnnotations;

namespace AttendancePayrollWebServerApp.Helper
{
    public class BankAccountValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        { 
            var employeeBankAccInfo = (EmployeeBankAccInfo)validationContext.ObjectInstance;
            // Only validate if Bank 26 is selected

            
                if (employeeBankAccInfo.BankCatItemId == 26) //Rocket
                  {
                        var accNo = value as string;
                        if (string.IsNullOrEmpty(accNo) || accNo.Length != 12)
                        {
                            return new ValidationResult("Account number must be exactly 12 characters for this bank.");
                        }
                  }

            if (employeeBankAccInfo.BankCatItemId == 27)   //Upay
            {
                var accNo = value as string;
                if (string.IsNullOrEmpty(accNo) || accNo.Length != 11)
                {
                    return new ValidationResult("Account number must be exactly 11 characters for this bank.");
                }
            }

            if (employeeBankAccInfo.BankCatItemId == 28)   //Bikash
            {
                var accNo = value as string;
                if (string.IsNullOrEmpty(accNo) || accNo.Length != 11)
                {
                    return new ValidationResult("Account number must be exactly 11 characters for this bank.");
                }
            }


            if (employeeBankAccInfo.BankCatItemId == 31)   //Nagad
            {
                var accNo = value as string;
                if (string.IsNullOrEmpty(accNo) || accNo.Length != 11)
                {
                    return new ValidationResult("Account number must be exactly 11 characters for this bank.");
                }
            }




            return ValidationResult.Success;
        }

    }
}
