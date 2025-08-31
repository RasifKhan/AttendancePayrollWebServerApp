namespace AttendancePayrollWebServerApp.Models
{
    public class DashboardSummary
    {
        public DateTime MaxAttendanceDate { get; set; }
        public int EmployeeTotal { get; set; }
        public int AbsentTotal { get; set; }
        public int PresentTotal { get; set; }
        public int LeaveTotal { get; set; }

        public int LateTotal { get; set; }
    }
}
