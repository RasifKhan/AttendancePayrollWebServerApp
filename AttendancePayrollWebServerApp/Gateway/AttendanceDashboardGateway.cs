using AttendancePayrollWebServerApp.Models;
using AttendancePayrollWebServerApp.Pages.Department;
using AttendancePayrollWebServerApp.Pages.ShiftDetail;
using AttendancePayrollWebServerApp.UtilityClass;
using DevExpress.Xpo.DB.Helpers;
using System.Data.SqlClient;

namespace AttendancePayrollWebServerApp.Gateway
{
    public class AttendanceDashboardGateway : Gateway
    {
        public async Task<DashboardSummary> GetDashboardSummary()
        {
            try
            {

                //                Query = @"
                //                        SELECT 
                //    MAX(AttendanceDate) as MaxAttDate,
                //    (SELECT COUNT(a.EmployeeId) 
                //	from AttendanceView a 
                //	where a.AttendanceDate=(SELECT MAX(AttendanceDate) FROM AttendanceView))  as EmployeeTotal,
                //    (SELECT COUNT(a.EmployeeId)
                //     FROM AttendanceView a
                //     WHERE a.Status = 'A'
                //     AND a.AttendanceDate = (SELECT MAX(AttendanceDate) FROM AttendanceView)) as AbsentTotal,
                //    (SELECT COUNT(a.EmployeeId)
                //     FROM AttendanceView a
                //     WHERE a.Status = 'P'
                //     AND a.AttendanceDate = (SELECT MAX(AttendanceDate) FROM AttendanceView)) as PresentTotal,
                //    (SELECT COUNT(a.EmployeeId)
                //     FROM AttendanceView a
                //     WHERE a.Status in ('SL','ML','EL','CL')
                //     AND a.AttendanceDate = (SELECT MAX(AttendanceDate) FROM AttendanceView)) as LeaveTotal
                //FROM AttendanceView";



                Query = @"
                            SELECT 
                            MAX(AttendanceDate) as MaxAttDate,
                            (SELECT COUNT(a.EmployeeId) 
                	        from AttendanceView a 
                	        where a.AttendanceDate=(SELECT MAX(AttendanceDate) FROM AttendanceView))  as EmployeeTotal,
                            (SELECT COUNT(a.EmployeeId)
                             FROM AttendanceView a
                             WHERE a.Status = 'A'
                             AND a.AttendanceDate = (SELECT MAX(AttendanceDate) FROM AttendanceView)) as AbsentTotal,
                            (SELECT COUNT(a.EmployeeId)
                             FROM AttendanceView a
                             WHERE a.Status = 'P'
                             AND a.AttendanceDate = (SELECT MAX(AttendanceDate) FROM AttendanceView)) as PresentTotal,
                            (SELECT COUNT(a.EmployeeId)
                             FROM AttendanceView a
                             WHERE a.Status in ('SL','ML','EL','CL')
                             AND a.AttendanceDate = (SELECT MAX(AttendanceDate) FROM AttendanceView)) as LeaveTotal,
                            (SELECT COUNT(a.EmployeeId)
                             FROM AttendanceView a
                             WHERE a.Status = 'L'
                             AND a.AttendanceDate = (SELECT MAX(AttendanceDate) FROM AttendanceView)) as LateTotal
                        FROM AttendanceView";

                Command = new SqlCommand(Query, Connection);
                ConnectionOpen();

                Reader = await Command.ExecuteReaderAsync();
                var summary = new DashboardSummary();

                if (await Reader.ReadAsync())
                {
                    summary = new DashboardSummary
                    {
                        MaxAttendanceDate = Reader.GetDateTime(0),
                        EmployeeTotal = Reader.GetInt32(1),
                        AbsentTotal = Reader.GetInt32(2),
                        PresentTotal = Reader.GetInt32(3),
                        LeaveTotal = Reader.GetInt32(4),
                        LateTotal = Reader.GetInt32(5)
                    };
                }

                return summary;
            }
            catch (Exception exception)
            {
                throw new Exception($"Failed to get dashboard summary\n" + exception.Message);
            }
            finally
            {
                ReaderClose();
                ConnectionClose();
            }
        }

    }

}
