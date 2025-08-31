using AttendancePayrollWebServerApp.Models;
using AttendancePayrollWebServerApp.Pages.Employee;
using System;
using System.Data.SqlClient;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
namespace AttendancePayrollWebServerApp.Gateway.GatewayProcess
{
    public class DailyProcessGateway : Gateway
    {





        public async Task<(bool Success, string Message, string ModalHeaderClass, string ModalTitle)> ExecuteDailyProc(DateTime attendanceDate)
        {
            try
            {
                ConnectionOpen();
                Command = new SqlCommand("DailyProc", Connection);
                Command.CommandType = System.Data.CommandType.StoredProcedure;
                Command.Parameters.Add(new SqlParameter("@AttendanceDate", attendanceDate));
                await Command.ExecuteNonQueryAsync();
                return (true, "The Process executed successfully.", "bg-success text-white", "Success");
            }

            catch (Exception ex)
            {
                return (false, $"Error executing Process: {ex.Message}", "bg-danger text-white", "Error");
            }

            finally
            {
                ConnectionClose();
            }
        }
        public async Task<int> CountPresentEmpByAttDate(DateTime? attendanceDate=null)
        {
            try
            {
                if (attendanceDate == null )
                {
                    return 0;
                }
                else
                {
                  string Query = $"SELECT count(EmployeeId) from  Attendances WHERE Status='{'P'}' and AttendanceDate = '{attendanceDate}' ";
                  Command = new SqlCommand(Query, Connection);
                  Command.Parameters.AddWithValue("@attendanceDate", attendanceDate);
                  ConnectionOpen();
                  var result = await Command.ExecuteScalarAsync();
                  ConnectionClose();

                  return Convert.ToInt32(result);
                }
            }
            catch (Exception exception)
            {
                throw new Exception($"Failed" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }



        public async Task<int> CountAbsentEmpByAttDate(DateTime? attendanceDate = null)
        {
            try
            {
                if (attendanceDate == null)
                {
                    return 0;
                }
                else
                {
                    string Query = $"SELECT count(EmployeeId) from  Attendances WHERE Status='{'A'}' and AttendanceDate = '{attendanceDate}' ";
                    Command = new SqlCommand(Query, Connection);
                    Command.Parameters.AddWithValue("@attendanceDate", attendanceDate);
                    ConnectionOpen();
                    var result = await Command.ExecuteScalarAsync();
                    ConnectionClose();

                    return Convert.ToInt32(result);
                }
            }
            catch (Exception exception)
            {
                throw new Exception($"Failed" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<int> CountLateEmpByAttDate(DateTime? attendanceDate = null)
        {
            try
            {
                if (attendanceDate == null)
                {
                    return 0;
                }
                else
                {
                    string Query = $"SELECT count(EmployeeId) from  Attendances WHERE Status='{'L'}' and AttendanceDate = '{attendanceDate}' ";
                    Command = new SqlCommand(Query, Connection);
                    Command.Parameters.AddWithValue("@attendanceDate", attendanceDate);
                    ConnectionOpen();
                    var result = await Command.ExecuteScalarAsync();
                    ConnectionClose();

                    return Convert.ToInt32(result);
                }
            }
            catch (Exception exception)
            {
                throw new Exception($"Failed" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }


        public async Task<int> CountLeaveEmpByAttDate(DateTime? attendanceDate = null)
        {
            try
            {
                if (attendanceDate == null)
                {
                    return 0;
                }
                else
                {
                    string Query = $"SELECT count(EmployeeId) from  Attendances WHERE Status in ('SL','CL','EL','ML') and AttendanceDate = '{attendanceDate}' ";
                    Command = new SqlCommand(Query, Connection);
                    Command.Parameters.AddWithValue("@attendanceDate", attendanceDate);
                    ConnectionOpen();
                    var result = await Command.ExecuteScalarAsync();
                    ConnectionClose();

                    return Convert.ToInt32(result);
                }
            }
            catch (Exception exception)
            {
                throw new Exception($"Failed" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<int> CountTotalEmpByAttDate(DateTime? attendanceDate = null)
        {
            try
            {
                if (attendanceDate == null)
                {
                    return 0;
                }
                else
                {
                    string Query = $"SELECT count(EmployeeId) from  Attendances WHERE AttendanceDate = '{attendanceDate}' ";
                    Command = new SqlCommand(Query, Connection);
                    Command.Parameters.AddWithValue("@attendanceDate", attendanceDate);
                    ConnectionOpen();
                    var result = await Command.ExecuteScalarAsync();
                    ConnectionClose();
                    return Convert.ToInt32(result);
                }
            }
            catch (Exception exception)
            {
                throw new Exception($"Failed" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }
        public async Task<int> CountTotalMaleEmpByAttDate(DateTime? attendanceDate = null)
        {
            try
            {
                if (attendanceDate == null)
                {
                    return 0;
                }
                else
                {
                    string Query = $"SELECT count(a.EmployeeId) from  Attendances a,Employees e" +
                                   $" WHERE a.AttendanceDate = '{attendanceDate}'" +
                                   $" and a.EmployeeId=e.EmployeeId" +
                                   $" and e.Sex= 'Male'";
                    Command = new SqlCommand(Query, Connection);
                    Command.Parameters.AddWithValue("@attendanceDate", attendanceDate);
                    ConnectionOpen();
                    var result = await Command.ExecuteScalarAsync();
                    ConnectionClose();
                    return Convert.ToInt32(result);
                }
            }
            catch (Exception exception)
            {
                throw new Exception($"Failed" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<int> CountTotalFemaleEmpByAttDate(DateTime? attendanceDate = null)
        {
            try
            {
                if (attendanceDate == null)
                {
                    return 0;
                }
                else
                {
                    string Query = $"SELECT count(a.EmployeeId) from  Attendances a,Employees e" +
                                   $" WHERE a.AttendanceDate = '{attendanceDate}'" +
                                   $" and a.EmployeeId=e.EmployeeId" +
                                   $" and e.Sex= 'Female'";
                    Command = new SqlCommand(Query, Connection);
                    Command.Parameters.AddWithValue("@attendanceDate", attendanceDate);
                    ConnectionOpen();
                    var result = await Command.ExecuteScalarAsync();
                    ConnectionClose();
                    return Convert.ToInt32(result);
                }
            }
            catch (Exception exception)
            {
                throw new Exception($"Failed" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }





        public async Task<List<Attendance>> GetAttendanceList(string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM Attendances";
                }
                else
                {
                    Query = "SELECT * FROM Attendances WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<Attendance> attendancesList = new List<Attendance>();
                while (Reader.Read())
                {
                    Attendance attendances = new Attendance();

                    attendances.AttendanceId = (int)Reader["AttendanceId"];
                    attendances.EmployeeId = Reader["EmployeeId"].ToString();
                    attendances.CardId = Reader["CardId"].ToString();
                    attendances.DepartmentId = (int)Reader["DepartmentId"];
                    attendances.SectionId = (int)Reader["SectionId"];
                    attendances.SalarySectionId = (int)Reader["SalarySectionId"];
                    attendances.DesignationId = (int)Reader["DesignationId"];
                    attendances.CompanyId = (int)Reader["CompanyId"];
                    attendances.AttendanceDate = (DateTime)Reader["AttendanceDate"];
                    attendances.TimeIn = (DateTime)Reader["TimeIn"];
                    attendances.TimeOut = (DateTime)Reader["TimeOut"];
                    attendances.Late = (DateTime)Reader["Late"];
                    attendances.ShiftId = (int)Reader["ShiftId"];
                    attendances.ShiftType = Reader["ShiftType"].ToString();
                    attendances.ShiftIn = (DateTime)Reader["ShiftIn"];
                    attendances.ShiftOut = (DateTime)Reader["ShiftOut"];
                    attendances.ShiftLate = (DateTime)Reader["ShiftLate"];
                    attendances.ShiftLunchIn = (DateTime)Reader["ShiftLunchIn"];
                    attendances.ShiftLunchOut = (DateTime)Reader["ShiftLunchOut"];
                    attendances.ShiftLunchLate = (DateTime)Reader["ShiftLunchLate"];
                    attendances.ShiftLunchHr = (DateTime)Reader["ShiftLunchHr"];
                    attendances.DutyHr = (DateTime)Reader["DutyHr"];
                    attendances.WorkHr = (decimal)Reader["WorkHr"];
                    attendances.LateHr = (decimal)Reader["LateHr"];
                    attendances.OT = (DateTime)Reader["OT"];
                    attendances.OTHr = (decimal)Reader["OTHr"];
                    attendances.OTMin = (decimal)Reader["OTMin"];
                    attendances.Status = Reader["Status"].ToString();
                    attendances.PCnt = (decimal)Reader["PCnt"];
                    attendances.Remark = Reader["Remark"].ToString();
                    attendances.SftEmp = Reader["SftEmp"].ToString();
                    attendances.ActIn = (DateTime)Reader["ActIn"];
                    attendances.ActOut = (DateTime)Reader["ActOut"];
                    attendances.LnOut = (DateTime)Reader["LnOut"];
                    attendances.LnBk = (DateTime)Reader["LnBk"];
                    attendances.LnLtHr = (decimal)Reader["LnLtHr"];
                    attendances.EOut = (DateTime)Reader["EOut"];
                    attendances.EOHr = (decimal)Reader["EOHr"];
                    attendances.ActOT = (decimal)Reader["ActOT"];
                    attendances.ExtOT = (decimal)Reader["ExtOT"];
                    attendances.DedOT = (decimal)Reader["DedOT"];
                    attendances.OTRem = Reader["OTRem"].ToString();
                    attendances.Pnc = (decimal)Reader["Pnc"];
                    attendances.FID = Reader["FID"].ToString();
                    attendances.N1 = (decimal)Reader["N1"];
                    attendances.N2 = (decimal)Reader["N2"];
                    attendances.S1 = Reader["S1"].ToString();
                    attendances.S2 = Reader["S2"].ToString();
                    attendances.D1 = (DateTime)Reader["D1"];
                    attendances.D2 = (DateTime)Reader["D2"];

                    attendancesList.Add(attendances);
                }
                Reader.Close();
                ConnectionClose();
                return attendancesList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get Attendance List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }








        public async Task<Attendance> GetAttendance(int attendanceId, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM Attendances WHERE AttendanceId = @attendanceId";
                }
                else
                {
                    Query = "SELECT * FROM Attendances WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@attendanceId", attendanceId);
                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                Attendance attendances = new Attendance();
                while (Reader.Read())
                {
                    attendances.AttendanceId = (int)Reader["AttendanceId"];
                    attendances.EmployeeId = Reader["EmployeeId"].ToString();
                    attendances.CardId = Reader["CardId"].ToString();
                    attendances.DepartmentId = (int)Reader["DepartmentId"];
                    attendances.SectionId = (int)Reader["SectionId"];
                    attendances.SalarySectionId = (int)Reader["SalarySectionId"];
                    attendances.DesignationId = (int)Reader["DesignationId"];
                    attendances.CompanyId = (int)Reader["CompanyId"];
                    attendances.AttendanceDate = (DateTime)Reader["AttendanceDate"];
                    attendances.TimeIn = (DateTime)Reader["TimeIn"];
                    attendances.TimeOut = (DateTime)Reader["TimeOut"];
                    attendances.Late = (DateTime)Reader["Late"];
                    attendances.ShiftId = (int)Reader["ShiftId"];
                    attendances.ShiftType = Reader["ShiftType"].ToString();
                    attendances.ShiftIn = (DateTime)Reader["ShiftIn"];
                    attendances.ShiftOut = (DateTime)Reader["ShiftOut"];
                    attendances.ShiftLate = (DateTime)Reader["ShiftLate"];
                    attendances.ShiftLunchIn = (DateTime)Reader["ShiftLunchIn"];
                    attendances.ShiftLunchOut = (DateTime)Reader["ShiftLunchOut"];
                    attendances.ShiftLunchLate = (DateTime)Reader["ShiftLunchLate"];
                    attendances.ShiftLunchHr = (DateTime)Reader["ShiftLunchHr"];
                    attendances.DutyHr = (DateTime)Reader["DutyHr"];
                    attendances.WorkHr = (decimal)Reader["WorkHr"];
                    attendances.LateHr = (decimal)Reader["LateHr"];
                    attendances.OT = (DateTime)Reader["OT"];
                    attendances.OTHr = (decimal)Reader["OTHr"];
                    attendances.OTMin = (decimal)Reader["OTMin"];
                    attendances.Status = Reader["Status"].ToString();
                    attendances.PCnt = (decimal)Reader["PCnt"];
                    attendances.Remark = Reader["Remark"].ToString();
                    attendances.SftEmp = Reader["SftEmp"].ToString();
                    attendances.ActIn = (DateTime)Reader["ActIn"];
                    attendances.ActOut = (DateTime)Reader["ActOut"];
                    attendances.LnOut = (DateTime)Reader["LnOut"];
                    attendances.LnBk = (DateTime)Reader["LnBk"];
                    attendances.LnLtHr = (decimal)Reader["LnLtHr"];
                    attendances.EOut = (DateTime)Reader["EOut"];
                    attendances.EOHr = (decimal)Reader["EOHr"];
                    attendances.ActOT = (decimal)Reader["ActOT"];
                    attendances.ExtOT = (decimal)Reader["ExtOT"];
                    attendances.DedOT = (decimal)Reader["DedOT"];
                    attendances.OTRem = Reader["OTRem"].ToString();
                    attendances.Pnc = (decimal)Reader["Pnc"];
                    attendances.FID = Reader["FID"].ToString();
                    attendances.N1 = (decimal)Reader["N1"];
                    attendances.N2 = (decimal)Reader["N2"];
                    attendances.S1 = Reader["S1"].ToString();
                    attendances.S2 = Reader["S2"].ToString();
                    attendances.D1 = (DateTime)Reader["D1"];
                    attendances.D2 = (DateTime)Reader["D2"];
                }
                Reader.Close();
                ConnectionClose();
                return attendances;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get Attendance\n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }





        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        public async Task<int> CountAttenDanceDateByAttDate(DateTime? attendanceDate = null)
        {
            try
            {
                if (attendanceDate == null)
                {
                    return 0;
                }
                else
                {
                    string Query = $"SELECT count(AttendanceDate) from  Attendances WHERE AttendanceDate = '{attendanceDate}' ";
                    Command = new SqlCommand(Query, Connection);
                    Command.Parameters.AddWithValue("@attendanceDate", attendanceDate);
                    ConnectionOpen();
                    var result = await Command.ExecuteScalarAsync();
                    ConnectionClose();
                    return Convert.ToInt32(result);
                }
            }
            catch (Exception exception)
            {
                throw new Exception($"Failed" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<bool> IsExist(DateTime? fixDateFrom = null, int fixDayId = 0)
        {
            try
            {
                if (fixDateFrom == null)
                {
                    Query = "SELECT 1 FROM FixDays";
                }

                if (fixDateFrom != null && fixDayId == 0)
                {
                    Query = $"SELECT 1 FROM FixDays WHERE FixDateFrom='{fixDateFrom}'";
                }

                if (fixDateFrom != null && fixDayId != 0)
                {
                    Query = $"SELECT 1 FROM FixDays WHERE FixDateFrom='{fixDateFrom}' and FixDayId <> '{fixDayId}' ";
                }


                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();
                bool exist = Reader.HasRows;
                Reader.Close();
                ConnectionClose();
                return exist;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }
    }
}