using System.ComponentModel.DataAnnotations;
namespace AttendancePayrollWebServerApp.Models
{
    public class Employee
    {

      
        [Required(ErrorMessage = "Provide Emp Ioyee Id")]
        [RegularExpression(@"^[a-zA-Z0-9 \-@,_.]+$", ErrorMessage = "Write a valid name")]
        //[RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "Write a valid name")]
        public string EmployeeId { get; set; }


        [Required(ErrorMessage = "Provide Emp Ioyee Name")]
        [RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "Write a valid name")]
        public string EmployeeName { get; set; }



        [Required(ErrorMessage = "Provide Designation Id")]
        [Range(1, int.MaxValue, ErrorMessage = "Select")]
        public int DesignationId { get; set; }




        [Required(ErrorMessage = "Provide Company Id")]
        [Range(1, int.MaxValue, ErrorMessage = "Select")]
        public int CompanyId { get; set; }



        [Required(ErrorMessage = "Provide Department Id")]
        [Range(1, int.MaxValue, ErrorMessage = "Select")]
        public int DepartmentId { get; set; }



        [Required(ErrorMessage = "Provide Section Id")]
        [Range(1, int.MaxValue, ErrorMessage = "Select")]
        public int SectionId { get; set; }



        [Required(ErrorMessage = "Provide Salary Section Id")]
        [Range(1, int.MaxValue, ErrorMessage = "Select")]
        public int SalarySectionId { get; set; }



        [Required(ErrorMessage = "Provide Floor Cat Item Id")]
        [Range(1, int.MaxValue, ErrorMessage = "Select")]
        public int FloorCatItemId { get; set; }




        [Required(ErrorMessage = "Provide Line Cat Item Id")]
        [Range(1, int.MaxValue, ErrorMessage = "Select")]
        public int LineCatItemId { get; set; }




        [Required(ErrorMessage = "Provide Shift Id")]
        [Range(1, int.MaxValue, ErrorMessage = "Select")]
        public int ShiftId { get; set; }



        [Required(ErrorMessage = "Provide Sex")]
        public string Sex { get; set; }



       [Required(ErrorMessage = "Provide Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }



        [Required(ErrorMessage = "Provide Religion")]
        public string Religion { get; set; }




         [Required(ErrorMessage = "Provide Blood")]
        public string? Blood { get; set; }




        [Required(ErrorMessage = "Provide Mobile No")]
        public string MobileNo { get; set; }




     //   [Required(ErrorMessage = "Provide Emergency Contact")]
        public string  EmergencyContact { get; set; }




         [Required(ErrorMessage = "Provide Mail")]
        //[EmailAddress(ErrorMessage = "Invalid email address format.")]
        //public string? Mail { get; set; } = "";
        //[EmailAddress(ErrorMessage = "Invalid email address format.")]

        public string? Mail { get; set; } 



        [Required(ErrorMessage = "Provide Employee Name Ban")]
        public string EmployeeNameBan { get; set; }




        [Required(ErrorMessage = "Provide Father Name")]
        public string FatherName { get; set; }



        [Required(ErrorMessage = "Provide Mother Name")]
        public string MotherName { get; set; }



          [Required(ErrorMessage = "Provide Spouse Name")]
        public string? SpouseName { get; set; }




       [Required(ErrorMessage = "Provide Father Name Ban")]
        public string? FatherNameBan { get; set; }




         [Required(ErrorMessage = "Provide Mother Name Ban")]
        public string? MotherNameBan { get; set; }





           [Required(ErrorMessage = "Provide Spouse Name Ban")]
        public string? SpouseNameBan { get; set; }





        [Required(ErrorMessage = "Provide Permanent Address")]
        public string PermanentAddress { get; set; }




         [Required(ErrorMessage = "Provide Permanent Address Ban")]
        public string? PermanentAddressBan { get; set; } 




        [Required(ErrorMessage = "Provide Present Address")]
        public string PresentAddress { get; set; }




       [Required(ErrorMessage = "Provide Present Address Ban")]
        public string? PresentAddressBan { get; set; } 





         [Required(ErrorMessage = "Provide Marital Status")]
        public string? MaritalStatus { get; set; } 




        [Required(ErrorMessage = "Provide N I D")]
        public string NID { get; set; }



        [Required(ErrorMessage = "Provide Birth Certificate No")]
        public string BirthCertificateNo { get; set; }





           [Required(ErrorMessage = "Provide Passport No")]
        public string? PassportNo { get; set; } 



           [Required(ErrorMessage = "Provide Driving License No")]
        public string? DrivingLicenseNo { get; set; }




           [Required(ErrorMessage = "Provide Body Sign")]
        public string? BodySign { get; set; }





     
       [Required(ErrorMessage = "Provide Join Date")]
        public DateTime? JoinDate { get; set; } //= DateTime.Today;




      //  [Required(ErrorMessage = "Provide Release Y N")]
        public string ReleaseYN { get; set; }




     //   [Required(ErrorMessage = "Provide Release Date")]
        public DateTime? ReleaseDate { get; set; }





        [Required(ErrorMessage = "Provide Salary")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number")]
        public decimal Salary { get; set; }




        [Required(ErrorMessage = "Provide Basic Salary")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number")]
        public decimal BasicSalary { get; set; }



        [Required(ErrorMessage = "Provide Over Time Y N")]
        public string OverTimeYN { get; set; }



        [Required(ErrorMessage = "Provide Lunch Y N")]
        public string LunchYN { get; set; }



     //   [Required(ErrorMessage = "Provide Confirm Y N")]
        public string ConfirmYN { get; set; }



     //   [Required(ErrorMessage = "Provide Confirm Date")]
        public DateTime? ConfirmDate { get; set; } 


        [Required(ErrorMessage = "Provide Transport Y N")]
        public string TransportYN { get; set; }



        [Required(ErrorMessage = "Provide Pay Source")]
        public string PaySource { get; set; }



     //   [Required(ErrorMessage = "Provide Active Y N")]
        public string ActiveYN { get; set; }



       [Required(ErrorMessage = "Provide Card I D")]
        public string CardID { get; set; }



        //[Required(ErrorMessage = "Provide Grade Cat Item Id")]
        //public int GradeCatItemId { get; set; }



       //[Required(ErrorMessage = "Provide S N")]
        public decimal SN { get; set; }



        [Required(ErrorMessage = "Provide Employee Type")]
        [Range(1, int.MaxValue, ErrorMessage = "Select")]
        public int? EmployeeTypeCatItemId { get; set; }



        [Required(ErrorMessage = "Provide Appointment Type")]
        public string AppointmentType { get; set; }



        [Required(ErrorMessage = "Provide Heist Education Cat Item Id")]
        public int HeistEducationCatItemId { get; set; }



        [Required(ErrorMessage = "Provide Provident Fund Y N")]
        public string ProvidentFundYN { get; set; }



       


            [Required(ErrorMessage = "Provide TIN No")]
        public string? TinNo { get; set; } 


        [Required(ErrorMessage = "Provide Rgistration No")]
        public string? RegistrationNo { get; set; }



[Required(ErrorMessage = "Provide Salary Bangla")]
        public decimal? SalaryBuyer { get; set; }



        [Required(ErrorMessage = "Provide Joining Date Ban")]
        public DateTime JoiningDateBuyer { get; set; }




        [Required(ErrorMessage = "Provide Buyer Show")]
        public string BuyerShow { get; set; }




        // [Required(ErrorMessage = "Provide Bank Name")]
        public string? BankName { get; set; } 



        //  [Required(ErrorMessage = "Provide Bank Acc No")]
        public string? BankAccNo { get; set; }




        [Required(ErrorMessage = "Provide B G M E A I D")]
        public string? BGMEAID { get; set; }




        public string? PhysicalStrength { get; set; } 
        public string? Experience { get; set; }

    }
}







