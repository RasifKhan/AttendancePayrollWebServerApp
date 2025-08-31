
using AspNetCore.Reporting;
using AttendancePayrollWebServerApp.Gateway;
using AttendancePayrollWebServerApp.Gateway.View;
using AttendancePayrollWebServerApp.Models;
using AttendancePayrollWebServerApp.Models.View;
using DevExpress.Data.ODataLinq;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net.NetworkInformation;
using System.Text;
namespace AttendancePayrollWebServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportssController : ControllerBase
    {
        private readonly AttendanceViewGateway _attendanceViewGateway;
        private readonly SalaryViewGateway _salaryViewGateway;
        private readonly JobCardViewGateway _jobCardViewGateway; 
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly AttendanceSummaryViewGateway _attendanceSumGateway;
        private List<AttendanceView> attendanceView { get; set; } = new List<AttendanceView>();
        private List<SalaryView> salaryView { get; set; } = new List<SalaryView>();
        // private List<AttendanceSum> AttendanceSumList { get; set; } = new List<AttendanceSum>();

        public ReportssController(IWebHostEnvironment webHostEnvironment, AttendanceViewGateway attendanceViewGateway, SalaryViewGateway salaryViewGateway, AttendanceSummaryViewGateway attendanceSumGateway, JobCardViewGateway jobCardViewGateway)
        {
            _attendanceViewGateway = attendanceViewGateway;
            _salaryViewGateway = salaryViewGateway;
            _webHostEnvironment = webHostEnvironment;
            _attendanceSumGateway = attendanceSumGateway;
            _jobCardViewGateway = jobCardViewGateway;
            System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        //[HttpGet]
        //[Route("GetEmpReport")]
        //public async Task<IActionResult> GetEmpReport(int reportType, string? empId)
        //{
        //    try
        //    {
        //        var dt = await _attendanceViewGateway.GetEmpReport(empId);
        //        if (dt == null || !dt.Any())
        //        {
        //            return BadRequest("No data available for the report.");
        //        }


        //        string mimeType = "";
        //        int extension = 1;
        //        var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\Report1.rdlc";
        //        Dictionary<string, string> parameters = new Dictionary<string, string>();
        //        parameters.Add("param", empId);
        //        LocalReport localReport = new LocalReport(path);
        //        localReport.AddDataSource("DataSet1", dt);

        //        if (reportType == 1)
        //        {
        //            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimeType);
        //            return File(result.MainStream, "application/pdf");
        //        }
        //        else
        //        {
        //            var result = localReport.Execute(RenderType.Excel, extension, parameters, mimeType);
        //            return File(result.MainStream, "application/msexcel", "report.xls");
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        Console.Error.WriteLine($"An error occurred: {ex.Message}");
        //        return StatusCode(500, "An error occurred while generating the report.");
        //    }
        //}


        [HttpGet]
        [Route("GetAttendanceReport")]
        public async Task<IActionResult> GetAttendanceReport(int reportType, DateTime? attendanceDate, string about)
        {
            try
            {
                var dt = attendanceView;
                if (about == "Present")      //Present Employee Report
                {
                    dt = await _attendanceViewGateway.GetDailyAttendanceReport(attendanceDate, "Present");

                    if (dt == null || !dt.Any())
                    {
                        return BadRequest("No data available for the report.");
                    }
                }

                if (about == "AllEmployee")
                {
                    dt = await _attendanceViewGateway.GetDailyAttendanceReport(attendanceDate, "AllEmployee");

                    if (dt == null || !dt.Any())
                    {
                        return BadRequest("No data available for the report.");
                    }
                }


                if (about == "Absent")
                {
                    dt = await _attendanceViewGateway.GetDailyAttendanceReport(attendanceDate, "Absent");

                    if (dt == null || !dt.Any())
                    {
                        return BadRequest("No data available for the report.");
                    }
                }


                if (about == "Leave")
                {
                    dt = await _attendanceViewGateway.GetDailyAttendanceReport(attendanceDate, "Leave");

                    if (dt == null || !dt.Any())
                    {
                        return BadRequest("No data available for the report.");
                    }
                }


                if (about == "Late")
                {
                    dt = await _attendanceViewGateway.GetDailyAttendanceReport(attendanceDate, "Late");

                    if (dt == null || !dt.Any())
                    {
                        return BadRequest("No data available for the report.");
                    }
                }


                if (about == "Male")
                {
                    dt = await _attendanceViewGateway.GetDailyAttendanceReport(attendanceDate, "Male");

                    if (dt == null || !dt.Any())
                    {
                        return BadRequest("No data available for the report.");
                    }
                }


                if (about == "Female")
                {
                    dt = await _attendanceViewGateway.GetDailyAttendanceReport(attendanceDate, "Female");

                    if (dt == null || !dt.Any())
                    {
                        return BadRequest("No data available for the report.");
                    }
                }


                string mimeType = "";
                int extension = 1;
                var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\DailyAttendance.rdlc";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("param", attendanceDate?.ToString("yyyy-MM-dd") ?? string.Empty);
                LocalReport localReport = new LocalReport(path);
                localReport.AddDataSource("DataSet1", dt);
                if (reportType == 1)
                {
                    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimeType);
                    return File(result.MainStream, "application/pdf");
                }
                else
                {
                    var result = localReport.Execute(RenderType.Excel, extension, parameters, mimeType);
                    return File(result.MainStream, "application/msexcel", "report.xls");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "An error occurred while generating the report.");
            }
        }

        //------ Salary report 
        // -------------------------------------------------

        [HttpGet]
        [Route("GetSalaryReport")]
        public async Task<IActionResult> GetSalaryReport(int reportType, string salStr)
        {
            try
            {
                var dt = await _salaryViewGateway.GetSalaryViewList(salStr);

                if (dt == null || !dt.Any())
                {
                    return BadRequest("No data available for the report.");
                }


                string mimeType = "";
                int extension = 1;
                var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\SalaryReport.rdlc";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("param", salStr);
                LocalReport localReport = new LocalReport(path);
                localReport.AddDataSource("SalaryDataSet", dt);


                if (reportType == 1)
                {
                    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimeType);
                    return File(result.MainStream, "application/pdf");
                }
                else
                {
                    var result = localReport.Execute(RenderType.Excel, extension, parameters, mimeType);
                    return File(result.MainStream, "application/msexcel", "report.xls");
                }
            }

            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "An error occurred while generating the report.");
            }
        }

        //--------------------------------------------------
        // -------------------------------------------------

        //-------------- Attendance Summary Report --------------------------//

        [HttpGet]
        [Route("GetAttendanceSumReport")]
        public async Task<IActionResult> GetAttendanceSumReport(int reportType, DateTime? fromDate, DateTime? toDate)
        {
            try
            {

                var dt = await _attendanceSumGateway.GetAttSumViewListByDateByDept(fromDate, toDate);


                if (dt == null || !dt.Any())
                {
                    return BadRequest("No data available for the report.");
                }

                string mimeType = "";
                int extension = 1;
                var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\AttendanceSummary\\AttendanceSummary.rdlc";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("fromDate", fromDate?.ToString("yyyy-MM-dd") ?? string.Empty);
                  parameters.Add("toDate", toDate?.ToString("yyyy-MM-dd") ?? string.Empty);
               // parameters.Add("toDate", toDate?.ToString("mm-yyyy") ?? string.Empty);
                LocalReport localReport = new LocalReport(path);
                localReport.AddDataSource("AttendanceSumDS", dt);

                if (reportType == 1)
                {
                    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimeType);
                    return File(result.MainStream, "application/pdf");
                }
                else
                {
                    var result = localReport.Execute(RenderType.Excel, extension, parameters, mimeType);
                    return File(result.MainStream, "application/msexcel", "report.xls");
                }
            }

            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "An error occurred while generating the report.");
            }
        }






        //-------------- Attendance Summary new Report --------------------------//
        //-------------- Attendance Summary  new Report --------------------------//

        [HttpGet]
        [Route("GetAttendanceSummaryReport")]
        public async Task<IActionResult> GetAttendanceSummaryReport(int reportType, DateTime? fromDate, DateTime? toDate)
        {
            try
            {
                var dt = await _attendanceSumGateway.GetAttSumViewListByDateByDept(fromDate, toDate);
                if (dt == null || !dt.Any())
                {
                    return BadRequest("No data available for the report.");
                }
                string mimeType = "";
                int extension = 1;
                var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\AttendanceSummary\\AttendanceSummary.rdlc";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("fromDate", fromDate?.ToString("yyyy-MM-dd") ?? string.Empty);
                parameters.Add("toDate", toDate?.ToString("yyyy-MM-dd") ?? string.Empty);
                LocalReport localReport = new LocalReport(path);
                localReport.AddDataSource("AttendanceSumDS", dt);

                if (reportType == 1)
                {
                    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimeType);
                    return File(result.MainStream, "application/pdf");
                }
                else
                {
                    var result = localReport.Execute(RenderType.Excel, extension, parameters, mimeType);
                    return File(result.MainStream, "application/msexcel", "report.xls");
                }
            }

            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "An error occurred while generating the report.");
            }
        }


        ///------------------------- job Card  ///-------------------------
        /// ///------------------------- job Card  ///-------------------------
        ///  <summary>
        /// ------------------------- job Card  ///-------------------------
        /// 
        
        [HttpGet]
        [Route("GetJobCardReport")]
        public async Task<IActionResult> GetJobCardReport(int reportType, DateTime? fromDate, DateTime? toDate,string? employeeId)
        {
            try
            {
                var dt = await _jobCardViewGateway.GetEmpReport(fromDate, toDate);
                if (dt == null || !dt.Any())
                {
                    return BadRequest("No data available for the report.");
                }
                string mimeType = "";
                int extension = 1;
                var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\JobCard\\JobCard.rdlc";
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("fromDate", fromDate?.ToString("yyyy-MM-dd") ?? string.Empty);
                parameters.Add("toDate", toDate?.ToString("yyyy-MM-dd") ?? string.Empty);
               
                LocalReport localReport = new LocalReport(path);
                localReport.AddDataSource("JobCardDS", dt);

                if (reportType == 1)
                {
                    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimeType);
                    return File(result.MainStream, "application/pdf");
                }
                else
                {
                    var result = localReport.Execute(RenderType.Excel, extension, parameters, mimeType);
                    return File(result.MainStream, "application/msexcel", "report.xls");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "An error occurred while generating the report.");
            }
        }


        ///------------------------- job Card  ///-------------------------
        /// ///------------------------- job Card  ///-------------------------
    }
}




