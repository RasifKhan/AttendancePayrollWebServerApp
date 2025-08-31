using AttendancePayrollWebServerApp.Models;
using AttendancePayrollWebServerApp.Models.View;
using AttendancePayrollWebServerApp.UtilityClass;
using System.Data;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.Net;


namespace AttendancePayrollWebServerApp.Gateway
{
    public class FixAttendanceBackupGateway : Gateway
    {

        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }


        public async Task<Alert> InsertFixAttendanceBackUp(DateTime? attendanceDate, string? employeeId)   //, FixAttendance fixAttendance
        {
            try
            {
                string pc = Dns.GetHostName();
                string ip = Dns.GetHostEntry(pc).AddressList[0].ToString();
                //string localIP = GetLocalIPAddress();
                //string userName = Environment.UserName;
                Query = $"insert into FixAttendanceBackup ( FixAttendanceId,EmployeeId, AttendanceDate,TimeIn,TimeOut, ActualTimeIn, ActualTimeOut,ActualStatus, ActualOT,ActualLate, OT,Status,Remarks, FixDate, " +
                    $"UserID,PC,IP, ProcessedYN,PC2,IP2 )  " +
                    $"select  FixAttendanceId,EmployeeId,AttendanceDate,TimeIn,TimeOut,ActualTimeIn,ActualTimeOut,ActualStatus, ActualOT,ActualLate, OT,Status, Remarks,FixDate," +
                    $"UserID,PC,IP,ProcessedYN,@pC2," +
                    $"@iP2 from FixAttendance " +
                    $"where AttendanceDate='{attendanceDate}' and EmployeeId ='{employeeId}' ";

                Command = new SqlCommand(Query, Connection);
         
                Command.Parameters.AddWithValue("@iP2", ip);
                Command.Parameters.AddWithValue("@pC2", pc);
                ConnectionOpen();
                int rowAffected = await Command.ExecuteNonQueryAsync();
                ConnectionClose();

                if (rowAffected > 0)
                {
                    return new Alert("success", "Company updated successfully.");
                }

                return new Alert("warning", "Update failed. Company not found.");
            }
            catch (Exception ex)
            {
                return new Alert("danger", "Failed to update company\n" + ex.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }




    }
}
