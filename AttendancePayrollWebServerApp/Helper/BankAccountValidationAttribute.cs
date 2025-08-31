using AttendancePayrollWebServerApp.Models;
using System.ComponentModel.DataAnnotations;

namespace AttendancePayrollWebServerApp.Helper
{
    public class BankAccountValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult("Value cannot be null");

            try
            {
                long x = Convert.ToInt64(value);
            }

            catch (FormatException)
            {
                return new ValidationResult("Please input in correct format");
            }


            catch (OverflowException)
            {
                return new ValidationResult("Number is too large or too small to be converted to integer");
            }



            var employeeBankAccInfo = (EmployeeBankAccInfo)validationContext.ObjectInstance;
            // Only validate if Bank 26 is selected
                if (employeeBankAccInfo.BankCatItemId == 26) //Rocket
                  {
                        var accNo = value as string;
                        if (string.IsNullOrEmpty(accNo) || accNo.Length != 12)
                        {
                         return new ValidationResult("The field Account No is invalid.");// return new ValidationResult("Account number must be exactly 12 characters for this bank.");
                         }
                  }

            if (employeeBankAccInfo.BankCatItemId == 27)   //Upay
            {
                var accNo = value as string;
                if (string.IsNullOrEmpty(accNo) || accNo.Length != 11)
                {
                    return new ValidationResult("The field Account No is invalid.");
                }
            }


            if (employeeBankAccInfo.BankCatItemId == 28)   //Bikash
            {
                var accNo = value as string;
                if (string.IsNullOrEmpty(accNo) || accNo.Length != 11)
                {
                    return new ValidationResult("The field Account No is invalid.");
                }
            }

            if (employeeBankAccInfo.BankCatItemId == 31)   //Nagad
            {
                var accNo = value as string;
                if (string.IsNullOrEmpty(accNo) || accNo.Length != 11)
                {
                    return new ValidationResult("The field Account No is invalid.");
                }
            }
            return ValidationResult.Success;
        }

    }
}


