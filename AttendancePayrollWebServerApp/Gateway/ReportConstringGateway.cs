namespace AttendancePayrollWebServerApp.Gateway
{
    public class ReportConstringGateway : Gateway
    {
        public string x;
        public string y;
        public ReportConstringGateway()
        {
            // Assign the conString from the base Gateway class to x
            x = ConnectionString;
        }

        public string GetConstring()
        {
            y = x; // Assign the value of x to the class field y
            return y; // Return the value of y
        }


    }
}
