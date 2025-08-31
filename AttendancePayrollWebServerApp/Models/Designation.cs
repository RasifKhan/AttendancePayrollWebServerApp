using System.ComponentModel.DataAnnotations;
namespace AttendancePayrollWebServerApp.Models
{
    public class Designation
    {
        [Key]
        public int DesignationId { get; set; }

        [Required(ErrorMessage = "Provide Designation Name")]
        [RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "Write a valid name")]
        public string DesignationName { get; set; }


        [Required(ErrorMessage = "Provide Designation Name Bangla")]
        [Display(Name = "Designation Name Ban")]
        public string DesignationNameBan { get; set; }

        [Required(ErrorMessage = "Provide Rank")]
        [Range(1, int.MaxValue, ErrorMessage = "Provide Rank")]
        [Display(Name = "Rank Category Item Id")]
        public int RankCategoryItemId { get; set; }

        [Required(ErrorMessage = "Provide Grade")]
        [Range(1, int.MaxValue, ErrorMessage = "Provide Grade")]
        [Display(Name = "Grade Category Item Id")]
        public int GradeCategoryItemId { get; set; }

        [Required(ErrorMessage = "Provide Attendance Bonus")]
        [Range(0, int.MaxValue, ErrorMessage = "Enter a valid Bonus")]
        public decimal AttendanceBonus { get; set; }


        [Required(ErrorMessage = "Provide Night Allowance")]
        [Range(0, int.MaxValue, ErrorMessage = "Enter a valid Allowance")]
        public decimal NightAllowance { get; set; }


        [Required(ErrorMessage = "Provide Holiday Allowance")]
        [Range(0, int.MaxValue, ErrorMessage = "Enter a valid Allowance")]
        public decimal HolidayAllowance { get; set; }




        [Required(ErrorMessage = "Provide  Work Type")]
        public string WorkType { get; set; }
        //[Required(ErrorMessage = "Provide Work Type")]
        //[Range(1, int.MaxValue, ErrorMessage = "Provide Work Type")]
        //public int WorkTypeCategoryItemId { get; set; }

    }
}
