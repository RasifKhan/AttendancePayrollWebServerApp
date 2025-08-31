using AttendancePayrollWebServerApp.Models;
using AttendancePayrollWebServerApp.Models.View;
using AttendancePayrollWebServerApp.UtilityClass;
using System.Data.SqlClient;
using static System.Collections.Specialized.BitVector32;

namespace AttendancePayrollWebServerApp.Gateway.View
{
    public class FixAttendanceViewGateway : Gateway
    {



        public async Task<List<FixAttendanceView>> GetAttendanceViewList(DateTime? attendanceDate = null)
        {
            try
            {
                if (attendanceDate == null)
                {
                    // Query = "select  a.AttendanceDate,a.EmployeeId,a.OT,a.AttendanceId,e.EmployeeName,d.DepartmentName,s.SectionName,desig.DesignationName,a.TimeIn as ActualTimeIn, a.Late, e.SN,isnull(f.TimeIn , a.TimeIn) as FixedTimein,a.TimeOut as  ActualTimeOut, isnull(f.TimeOut , a.TimeOut) as FixedTimeOut,isnull(f.Remarks ,'') as Remarks,a.status, e.JoinDate from attendance a left join FixAttendance f on a.EmployeeId=f.EmployeeId and  a.AttendanceDate=f.AttendanceDate inner join Employee e on e.EmployeeId =a.EmployeeId inner join Department d on e.DepartmentId=d.DepartmentId inner join Section s on e.SectionId=s.SectionId inner join Designation desig on e.DesignationId=desig.DesignationId";
                    Query = $"select * from FixAttendanceView order by AttendanceDate asc ,sn asc ";
                }
                //else
                //{
                //    Query = "select  a.AttendanceDate,a.EmployeeId,a.OT,a.AttendanceId,e.EmployeeName,d.DepartmentName,s.SectionName,desig.DesignationName,a.TimeIn as ActualTimeIn, a.Late, e.SN,isnull(f.TimeIn , a.TimeIn) as FixedTimein,a.TimeOut as  ActualTimeOut, isnull(f.TimeOut , a.TimeOut) as FixedTimeOut,isnull(f.Remarks ,'') as Remarks,a.status, e.JoinDate from attendance a left join FixAttendance f on a.EmployeeId=f.EmployeeId and  a.AttendanceDate=f.AttendanceDate inner join Employee e on e.EmployeeId =a.EmployeeId inner join Department d on e.DepartmentId=d.DepartmentId inner join Section s on e.SectionId=s.SectionId inner join Designation desig on e.DesignationId=desig.DesignationId WHERE a.AttendanceDate = @AttendanceDate";
                //}

                Command = new SqlCommand(Query, Connection);

                // Add parameter if attendanceDate is provided
                if (attendanceDate != null)
                {
                    Command.Parameters.AddWithValue("@AttendanceDate", attendanceDate.Value);
                }

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();
                List<FixAttendanceView> fixAttendanceViewList = new List<FixAttendanceView>();

                while (Reader.Read())
                {
                    FixAttendanceView fixAttendanceView = new FixAttendanceView();

                    
                    fixAttendanceView.AttendanceDate = Reader["AttendanceDate"] != DBNull.Value ? (DateTime)Reader["AttendanceDate"] : DateTime.MinValue;
                    fixAttendanceView.AttendanceId = Reader["AttendanceId"] != DBNull.Value ? (int)Reader["AttendanceId"] : 0;
                    fixAttendanceView.OT = Reader["OT"] != DBNull.Value ? (DateTime)Reader["OT"] : DateTime.MinValue;
                    fixAttendanceView.Late = Reader["Late"] != DBNull.Value ? (DateTime)Reader["Late"] : DateTime.MinValue;
                    fixAttendanceView.ActualTimeIn = Reader["ActualTimeIn"] != DBNull.Value ? (DateTime)Reader["ActualTimeIn"] : DateTime.MinValue;
                    fixAttendanceView.FixedTimein = Reader["FixedTimein"] != DBNull.Value ? (DateTime)Reader["FixedTimein"] : DateTime.MinValue;
                    fixAttendanceView.ActualTimeOut = Reader["ActualTimeOut"] != DBNull.Value ? (DateTime)Reader["ActualTimeOut"] : DateTime.MinValue;
                    fixAttendanceView.FixedTimeOut = Reader["FixedTimeOut"] != DBNull.Value ? (DateTime)Reader["FixedTimeOut"] : DateTime.MinValue;
                    fixAttendanceView.JoinDate = Reader["JoinDate"] != DBNull.Value ? (DateTime)Reader["JoinDate"] : DateTime.MinValue;
                    fixAttendanceView.SN = Reader["SN"] != DBNull.Value ? (decimal)Reader["SN"] : 0m;

                    
                    fixAttendanceView.EmployeeId = Reader["EmployeeId"] != DBNull.Value ? Reader["EmployeeId"].ToString() : string.Empty;
                    fixAttendanceView.EmployeeName = Reader["EmployeeName"] != DBNull.Value ? Reader["EmployeeName"].ToString() : string.Empty;
                    fixAttendanceView.DepartmentName = Reader["DepartmentName"] != DBNull.Value ? Reader["DepartmentName"].ToString() : string.Empty;
                    fixAttendanceView.DesignationName = Reader["DesignationName"] != DBNull.Value ? Reader["DesignationName"].ToString() : string.Empty;
                    fixAttendanceView.SectionName = Reader["SectionName"] != DBNull.Value ? Reader["SectionName"].ToString() : string.Empty;
                    fixAttendanceView.Remarks = Reader["Remarks"] != DBNull.Value ? Reader["Remarks"].ToString() : string.Empty;
                    fixAttendanceView.Status = Reader["Status"] != DBNull.Value ? Reader["Status"].ToString() : string.Empty;

                    fixAttendanceViewList.Add(fixAttendanceView);
                }

                Reader.Close();
                ConnectionClose();
                return fixAttendanceViewList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get FixAttendanceView List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }


        public async Task<List<FixAttendanceView>> GetFixAttendanceViewList(DateTime? fromDate = null, DateTime? toDate = null, string? employeeId = "")
        {
            try
            {
                if (fromDate == null && toDate == null && employeeId == null)
                {
                    Query = $"select * from FixAttendanceView order by AttendanceDate asc ,sn asc ";
                    //Query = $"select  a.AttendanceDate,a.EmployeeId,a.AttendanceId,e.EmployeeName,d.DepartmentName," +
                    //     $"s.SectionName,desig.DesignationName,a.TimeIn as ActualTimeIn," +
                    //     $"isnull(f.TimeIn ,'1900-01-01 00:00:00') as FixedTimein,a.TimeOut as  ActualTimeOut," +
                    //     $"isnull(f.TimeOut ,'1900-01-01 00:00:00') as FixedTimeOut,isnull(f.Remarks ,'') as Remarks,a.status," +
                    //     $"e.JoinDate" +
                    //     $"from attendance a left join FixAttendance f on a.EmployeeId=f.EmployeeId and  a.AttendanceDate=f.AttendanceDate" +
                    //     $"inner join Employee e on e.EmployeeId =a.EmployeeId " +
                    //     $"inner join Department d on e.DepartmentId=d.DepartmentId " +
                    //     $"inner join Section s on e.SectionId=s.SectionId " +
                    //     $"inner join Designation desig on e.DesignationId=desig.DesignationId " +
                    //     $"order by e.sn asc ,a.AttendanceDate asc";
                }
                else if (fromDate != null && toDate != null && employeeId == null)
                {

                    Query = $"select * from FixAttendanceView where AttendanceDate between '{fromDate}' and '{toDate}' order by AttendanceDate asc ,sn asc ";

                    //Query = $"select  a.AttendanceDate,a.EmployeeId,a.AttendanceId,e.EmployeeName,d.DepartmentName," +
                    //    $"s.SectionName,desig.DesignationName,a.TimeIn as ActualTimeIn," +
                    //    $"isnull(f.TimeIn ,'1900-01-01 00:00:00') as FixedTimein,a.TimeOut as  ActualTimeOut," +
                    //    $"isnull(f.TimeOut ,'1900-01-01 00:00:00') as FixedTimeOut,isnull(f.Remarks ,'') as Remarks,a.status," +
                    //    $"e.JoinDate" +
                    //    $"from attendance a left join FixAttendance f on a.EmployeeId=f.EmployeeId and  a.AttendanceDate=f.AttendanceDate" +
                    //    $"inner join Employee e on e.EmployeeId =a.EmployeeId " +
                    //    $"inner join Department d on e.DepartmentId=d.DepartmentId " +
                    //    $"inner join Section s on e.SectionId=s.SectionId " +
                    //    $"inner join Designation desig on e.DesignationId=desig.DesignationId " +
                    //    $"where a.AttendanceDate between '{fromDate}' and '{toDate}'  " +
                    //    $"order by e.sn asc ,a.AttendanceDate asc";

                    // Query = $"SELECT * FROM FixAttendanceView WHERE AttendanceDate between '{fromDate}' and '{toDate}' order by sn asc ,AttendanceDate asc ";
                }
                else if (fromDate != null && toDate != null && employeeId != null)
                {

                    Query = $"select * from FixAttendanceView where AttendanceDate between '{fromDate}' and '{toDate}'  and EmployeeId= '{employeeId}' order by AttendanceDate asc ,sn asc ";

                    //Query = $"select  a.AttendanceDate,a.EmployeeId,a.AttendanceId,e.EmployeeName,d.DepartmentName," +
                    //   $"s.SectionName,desig.DesignationName,a.TimeIn as ActualTimeIn," +
                    //   $"isnull(f.TimeIn ,'1900-01-01 00:00:00') as FixedTimein,a.TimeOut as  ActualTimeOut," +
                    //   $"isnull(f.TimeOut ,'1900-01-01 00:00:00') as FixedTimeOut,isnull(f.Remarks ,'') as Remarks,a.status," +
                    //   $"e.JoinDate" +
                    //   $"from attendance a left join FixAttendance f on a.EmployeeId=f.EmployeeId and  a.AttendanceDate=f.AttendanceDate" +
                    //   $"inner join Employee e on e.EmployeeId =a.EmployeeId " +
                    //   $"inner join Department d on e.DepartmentId=d.DepartmentId " +
                    //   $"inner join Section s on e.SectionId=s.SectionId " +
                    //   $"inner join Designation desig on e.DesignationId=desig.DesignationId " +
                    //   $"where a.AttendanceDate between '{fromDate}' and '{toDate}'  and a.EmployeeId= '{employeeId}'" +
                    //   $"order by e.sn asc ,a.AttendanceDate asc";

                    // Query = $"SELECT * FROM FixAttendanceView WHERE AttendanceDate between '{fromDate}' and '{toDate}' and EmployeeId='{employeeId}' order by sn asc ,AttendanceDate asc ";
                }
                Command = new SqlCommand(Query, Connection);
                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<FixAttendanceView> fixAttendanceViewList = new List<FixAttendanceView>();
                while (Reader.Read())
                {

                    FixAttendanceView fixAttendanceView = new FixAttendanceView();


                    fixAttendanceView.AttendanceDate = Reader["AttendanceDate"] != DBNull.Value ? (DateTime)Reader["AttendanceDate"] : DateTime.MinValue;
                    fixAttendanceView.AttendanceId = Reader["AttendanceId"] != DBNull.Value ? (int)Reader["AttendanceId"] : 0;
                    fixAttendanceView.OT = Reader["OT"] != DBNull.Value ? (DateTime)Reader["OT"] : DateTime.MinValue;
                    fixAttendanceView.Late = Reader["Late"] != DBNull.Value ? (DateTime)Reader["Late"] : DateTime.MinValue;
                    fixAttendanceView.ActualTimeIn = Reader["ActualTimeIn"] != DBNull.Value ? (DateTime)Reader["ActualTimeIn"] : DateTime.MinValue;
                    fixAttendanceView.FixedTimein = Reader["FixedTimein"] != DBNull.Value ? (DateTime)Reader["FixedTimein"] : DateTime.MinValue;
                    fixAttendanceView.ActualTimeOut = Reader["ActualTimeOut"] != DBNull.Value ? (DateTime)Reader["ActualTimeOut"] : DateTime.MinValue;
                    fixAttendanceView.FixedTimeOut = Reader["FixedTimeOut"] != DBNull.Value ? (DateTime)Reader["FixedTimeOut"] : DateTime.MinValue;
                    fixAttendanceView.JoinDate = Reader["JoinDate"] != DBNull.Value ? (DateTime)Reader["JoinDate"] : DateTime.MinValue;
                    fixAttendanceView.SN = Reader["SN"] != DBNull.Value ? (decimal)Reader["SN"] : 0m;


                    fixAttendanceView.EmployeeId = Reader["EmployeeId"] != DBNull.Value ? Reader["EmployeeId"].ToString() : string.Empty;
                    fixAttendanceView.EmployeeName = Reader["EmployeeName"] != DBNull.Value ? Reader["EmployeeName"].ToString() : string.Empty;
                    fixAttendanceView.DepartmentName = Reader["DepartmentName"] != DBNull.Value ? Reader["DepartmentName"].ToString() : string.Empty;
                    fixAttendanceView.DesignationName = Reader["DesignationName"] != DBNull.Value ? Reader["DesignationName"].ToString() : string.Empty;
                    fixAttendanceView.SectionName = Reader["SectionName"] != DBNull.Value ? Reader["SectionName"].ToString() : string.Empty;
                    fixAttendanceView.Remarks = Reader["Remarks"] != DBNull.Value ? Reader["Remarks"].ToString() : string.Empty;
                    fixAttendanceView.Status = Reader["Status"] != DBNull.Value ? Reader["Status"].ToString() : string.Empty;

                    fixAttendanceViewList.Add(fixAttendanceView);

                }
                Reader.Close();
                ConnectionClose();
                return fixAttendanceViewList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get Leave List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }





        public async Task<List<FixAttendanceView>> GetAttViewListByEmpIdByFromToDate(DateTime? fromDate = null, DateTime? toDate = null, string? employeeId = "")
        {
            try 
            {
                if (fromDate == null && toDate == null && employeeId == null)
                {

                    Query = $"select * from FixAttendanceView order by AttendanceDate asc ,sn asc ";
                    //Query = $"select  a.AttendanceDate,a.EmployeeId,a.AttendanceId,e.EmployeeName,d.DepartmentName," +
                    //     $"s.SectionName,desig.DesignationName,a.TimeIn as ActualTimeIn," +
                    //     $"isnull(f.TimeIn ,'1900-01-01 00:00:00') as FixedTimein,a.TimeOut as  ActualTimeOut," +
                    //     $"isnull(f.TimeOut ,'1900-01-01 00:00:00') as FixedTimeOut,isnull(f.Remarks ,'') as Remarks,a.status," +
                    //     $"e.JoinDate" +
                    //     $"from attendance a left join FixAttendance f on a.EmployeeId=f.EmployeeId and  a.AttendanceDate=f.AttendanceDate" +
                    //     $"inner join Employee e on e.EmployeeId =a.EmployeeId " +
                    //     $"inner join Department d on e.DepartmentId=d.DepartmentId " +
                    //     $"inner join Section s on e.SectionId=s.SectionId " +
                    //     $"inner join Designation desig on e.DesignationId=desig.DesignationId " +
                    //     $"order by e.sn asc ,a.AttendanceDate asc";
                }
                else if (fromDate != null && toDate != null && employeeId == null)
                {

                    Query = $"select * from FixAttendanceView where AttendanceDate between '{fromDate}' and '{toDate}' order by AttendanceDate asc ,sn asc ";
                    //Query = $"select  a.AttendanceDate,a.EmployeeId,a.AttendanceId,e.EmployeeName,d.DepartmentName," +
                    //   $"s.SectionName,desig.DesignationName,a.TimeIn as ActualTimeIn," +
                    //   $"isnull(f.TimeIn ,'1900-01-01 00:00:00') as FixedTimein,a.TimeOut as  ActualTimeOut," +
                    //   $"isnull(f.TimeOut ,'1900-01-01 00:00:00') as FixedTimeOut,isnull(f.Remarks ,'') as Remarks,a.status," +
                    //   $"e.JoinDate" +
                    //   $"from attendance a left join FixAttendance f on a.EmployeeId=f.EmployeeId and  a.AttendanceDate=f.AttendanceDate" +
                    //   $"inner join Employee e on e.EmployeeId =a.EmployeeId " +
                    //   $"inner join Department d on e.DepartmentId=d.DepartmentId " +
                    //   $"inner join Section s on e.SectionId=s.SectionId " +
                    //   $"inner join Designation desig on e.DesignationId=desig.DesignationId " +
                    //   $"where a.AttendanceDate between '{fromDate}' and '{toDate}'  " +
                    //   $"order by e.sn asc ,a.AttendanceDate asc";
                }
                else if (fromDate != null && toDate != null && employeeId != null)
                {

                    Query = $"select * from FixAttendanceView where AttendanceDate between '{fromDate}' and '{toDate}'  and EmployeeId= '{employeeId}' order by AttendanceDate asc ,sn asc ";
                    //Query = $"select  a.AttendanceDate,a.EmployeeId,a.AttendanceId,e.EmployeeName,d.DepartmentName," +
                    //  $"s.SectionName,desig.DesignationName,a.TimeIn as ActualTimeIn," +
                    //  $"isnull(f.TimeIn ,'1900-01-01 00:00:00') as FixedTimein,a.TimeOut as  ActualTimeOut," +
                    //  $"isnull(f.TimeOut ,'1900-01-01 00:00:00') as FixedTimeOut,isnull(f.Remarks ,'') as Remarks,a.status," +
                    //  $"e.JoinDate" +
                    //  $"from attendance a left join FixAttendance f on a.EmployeeId=f.EmployeeId and  a.AttendanceDate=f.AttendanceDate" +
                    //  $"inner join Employee e on e.EmployeeId =a.EmployeeId " +
                    //  $"inner join Department d on e.DepartmentId=d.DepartmentId " +
                    //  $"inner join Section s on e.SectionId=s.SectionId " +
                    //  $"inner join Designation desig on e.DesignationId=desig.DesignationId " +
                    //  $"where a.AttendanceDate between '{fromDate}' and '{toDate}'  and a.EmployeeId= '{employeeId}'" +
                    //  $"order by e.sn asc ,a.AttendanceDate asc";
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<FixAttendanceView> fixAttendanceViewList = new List<FixAttendanceView>();
                while (Reader.Read())
                {
                    FixAttendanceView fixAttendanceView = new FixAttendanceView();


                    fixAttendanceView.AttendanceDate = Reader["AttendanceDate"] != DBNull.Value ? (DateTime)Reader["AttendanceDate"] : DateTime.MinValue;
                    fixAttendanceView.AttendanceId = Reader["AttendanceId"] != DBNull.Value ? (int)Reader["AttendanceId"] : 0;
                    fixAttendanceView.OT = Reader["OT"] != DBNull.Value ? (DateTime)Reader["OT"] : DateTime.MinValue;
                    fixAttendanceView.Late = Reader["Late"] != DBNull.Value ? (DateTime)Reader["Late"] : DateTime.MinValue;
                    fixAttendanceView.ActualTimeIn = Reader["ActualTimeIn"] != DBNull.Value ? (DateTime)Reader["ActualTimeIn"] : DateTime.MinValue;
                    fixAttendanceView.FixedTimein = Reader["FixedTimein"] != DBNull.Value ? (DateTime)Reader["FixedTimein"] : DateTime.MinValue;
                    fixAttendanceView.ActualTimeOut = Reader["ActualTimeOut"] != DBNull.Value ? (DateTime)Reader["ActualTimeOut"] : DateTime.MinValue;
                    fixAttendanceView.FixedTimeOut = Reader["FixedTimeOut"] != DBNull.Value ? (DateTime)Reader["FixedTimeOut"] : DateTime.MinValue;
                    fixAttendanceView.JoinDate = Reader["JoinDate"] != DBNull.Value ? (DateTime)Reader["JoinDate"] : DateTime.MinValue;
                    fixAttendanceView.SN = Reader["SN"] != DBNull.Value ? (decimal)Reader["SN"] : 0m;


                    fixAttendanceView.EmployeeId = Reader["EmployeeId"] != DBNull.Value ? Reader["EmployeeId"].ToString() : string.Empty;
                    fixAttendanceView.EmployeeName = Reader["EmployeeName"] != DBNull.Value ? Reader["EmployeeName"].ToString() : string.Empty;
                    fixAttendanceView.DepartmentName = Reader["DepartmentName"] != DBNull.Value ? Reader["DepartmentName"].ToString() : string.Empty;
                    fixAttendanceView.DesignationName = Reader["DesignationName"] != DBNull.Value ? Reader["DesignationName"].ToString() : string.Empty;
                    fixAttendanceView.SectionName = Reader["SectionName"] != DBNull.Value ? Reader["SectionName"].ToString() : string.Empty;
                    fixAttendanceView.Remarks = Reader["Remarks"] != DBNull.Value ? Reader["Remarks"].ToString() : string.Empty;
                    fixAttendanceView.Status = Reader["Status"] != DBNull.Value ? Reader["Status"].ToString() : string.Empty;

                    fixAttendanceViewList.Add(fixAttendanceView);

                }
                Reader.Close();
                ConnectionClose();
                return fixAttendanceViewList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get FixAttendanceView List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }









        public async Task<String> DeleteFixAttendanceId(int fixAttendanceId)
        {
            try
            {
                if (fixAttendanceId != null)
                {
                    Query = "DELETE FixAttendance WHERE FixAttendanceId = @FixAttendanceId And ProcessedYN='N' ";
                }
              
                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@fixAttendanceId",fixAttendanceId);

                ConnectionOpen();
                int rowAffected = await Command.ExecuteNonQueryAsync();
                ConnectionClose();


                if (rowAffected > 0)
                {
                    return new string("success");
                }
                return new string("Not Deleted");
            }
            catch (Exception exception)
            {
                return new string("Failed To Delete\n");
            }
            finally
            {
                ConnectionClose();
            }
        }
    }
}
