namespace AttendancePayrollWebServerApp.Models.View
{
    public class FixAttendanceView
    {
        public DateTime AttendanceDate { get; set; }
        public int AttendanceId { get; set; }
        public string Status { get; set; }
        public DateTime OT { get; set; }
        public DateTime Late { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string DepartmentName { get; set; }
        public string SectionName { get; set; }
        public string DesignationName { get; set; }
        public DateTime ActualTimeIn { get; set; }
        public DateTime FixedTimein { get; set; }
        public DateTime ActualTimeOut { get; set; }
        public DateTime FixedTimeOut { get; set; }
        public string Remarks { get; set; }
        public DateTime JoinDate { get; set; }
        public decimal SN { get; set; }
        public FixAttendanceView Clone()
        {
            return (FixAttendanceView)MemberwiseClone();
        }


    }
}
