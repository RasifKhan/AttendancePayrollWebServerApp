using Microsoft.SqlServer.Server;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AttendancePayrollWebServerApp.Models
{
    public class Leave
    {

        [Key]
        public int LeaveId { get; set; }

        [Required(ErrorMessage = "Provide Employee Id")]
        [Display(Name = "Employee Id")]



        public string EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee? VirtualEmployee { get; set; }






        [Required(ErrorMessage = "Provide Leave Apply Date")]
        [Range(typeof(DateTime), "1900-01-01", "2099-12-31", ErrorMessage = "Apply Date must be after 01-Jan-1900")]
        public DateTime? LeaveApplyDate { get; set; }





        [Required(ErrorMessage = "Provide Apply From Date")]
        [Range(typeof(DateTime), "1900-01-01", "2099-12-31", ErrorMessage = "From Date must be after 01-Jan-1900")]
        public DateTime? ApplyFromDate { get; set; }



        [Required(ErrorMessage = "Provide Apply Days")]
        public int ApplyDays { get; set; }


        [Required(ErrorMessage = "Provide Apply To Date")]
        public DateTime? ApplyToDate { get; set; }

       




        [Required(ErrorMessage = "Provide Leave Type")]
        public string LeaveType { get; set; }

        [Required(ErrorMessage = "Provide Reason")]
        [Display(Name = "Reason")]
        public string Reason { get; set; }

        [Required(ErrorMessage = "Provide Issued From Date")]
        public DateTime? IssuedFromDate { get; set; }

        [Required(ErrorMessage = "Provide Issued To Date")]
     
        public DateTime? IssuedToDate { get; set; }

        [Required(ErrorMessage = "Provide Issued Days")]
        [Display(Name = "Issued Days")]
        public int IssuedDays { get; set; }


        public string IssuedRemarks { get; set; }


        [Required(ErrorMessage = "Provide C L Total")]
        [Display(Name = "C L Total")]
        public decimal? CLTotal { get; set; } = 0;

        [Required(ErrorMessage = "Provide S L Total")]
        [Display(Name = "S L Total")]
        public decimal? SLTotal { get; set; } = 0;

        [Required(ErrorMessage = "Provide E L Total")]
        [Display(Name = "E L Total")]
        public decimal? ELTotal { get; set; } = 0;

        [Required(ErrorMessage = "Provide M L Total")]
        [Display(Name = "M L Total")]
        public decimal? MLTotal { get; set; } = 0;

        [Required(ErrorMessage = "Provide C L Balance")]
        [Display(Name = "C L Balance")]
        public decimal? CLBalance { get; set; } = 0;

        [Required(ErrorMessage = "Provide S L Balance")]
        [Display(Name = "S L Balance")]
        public decimal? SLBalance { get; set; } = 0;

        [Required(ErrorMessage = "Provide E L Balance")]
        [Display(Name = "E L Balance")]
        public decimal? ELBalance { get; set; } = 0;

        [Required(ErrorMessage = "Provide M L Balance")]
        [Display(Name = "M L Balance")]
        public decimal? MLBalance { get; set; } = 0;


        [Required(ErrorMessage = "Provide Leave Issued Date")]
        public DateTime? LeaveIssuedDate { get; set; } 

        [Required(ErrorMessage = "Provide Added By")]
        [Display(Name = "Added By")]
        public int AddedBy { get; set; }

        [Required(ErrorMessage = "Provide Added Date")]
        [Display(Name = "Added Date")]
        public DateTime AddedDate { get; set; }

        [Required(ErrorMessage = "Provide Edit By")]
        [Display(Name = "Edit By")]
        public int EditBy { get; set; }

        [Required(ErrorMessage = "Provide Edited By")]
        [Display(Name = "Edited By")]
        public DateTime EditedDate { get; set; }




        //*****************************************************
        //*****************************************************





        //***************************************************
        //***************************************************
    }
}
