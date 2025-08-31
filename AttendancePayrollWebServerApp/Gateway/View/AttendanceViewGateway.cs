using AttendancePayrollWebServerApp.Models;
using AttendancePayrollWebServerApp.Models.View;
using AttendancePayrollWebServerApp.Pages.Employee;
using AttendancePayrollWebServerApp.UtilityClass;
//using DevExpress.Pdf.Native.BouncyCastle.Utilities.Encoders;
using DevExpress.Xpo.DB.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
namespace AttendancePayrollWebServerApp.Gateway.View
{
    public class AttendanceViewGateway : Gateway
    {

        public async Task<List<AttendanceView>> GetAttendanceViewList(DateTime? attendanceDate =null)
        {
            try
            {
                if (attendanceDate == null)
                {
                    Query = "SELECT * FROM AttendanceView";
                }
                else
                {
                    Query = $"SELECT * FROM AttendanceView WHERE AttendanceDate='{attendanceDate}'";
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<AttendanceView> attendanceViewList = new List<AttendanceView>();
                while (Reader.Read())
                {
                    AttendanceView attendanceView = new AttendanceView();
                    attendanceView.CompanyName = Reader["CompanyName"].ToString();
                    attendanceView.DepartmentName = Reader["DepartmentName"].ToString();
                    attendanceView.DesignationName = Reader["DesignationName"].ToString();
                    attendanceView.EmployeeName = Reader["EmployeeName"].ToString();
                    attendanceView.ShiftName = Reader["ShiftName"].ToString();
                    attendanceView.ShiftType = Reader["ShiftType"].ToString();
                    attendanceView.SectionName = Reader["SectionName"].ToString();
                    attendanceView.SalarySectionName = Reader["SalarySectionName"].ToString();
                    attendanceView.AttendanceId = (int)Reader["AttendanceId"];
                    attendanceView.EmployeeId = Reader["EmployeeId"].ToString();
                    attendanceView.CardId = Reader["CardId"].ToString();
                    attendanceView.DepartmentId = (int)Reader["DepartmentId"];
                    attendanceView.SectionId = (int)Reader["SectionId"];
                    attendanceView.Expr6 = (int)Reader["Expr6"];
                    attendanceView.DesignationId = (int)Reader["DesignationId"];
                    attendanceView.CompanyId = (int)Reader["CompanyId"];
                    attendanceView.AttendanceDate = (DateTime)Reader["AttendanceDate"];
                    attendanceView.TimeIn = (DateTime)Reader["TimeIn"];
                    attendanceView.TimeOut = (DateTime)Reader["TimeOut"];
                    attendanceView.ShiftDetailId = (int)Reader["ShiftDetailId"];
                    attendanceView.Late = (DateTime)Reader["Late"];
                    attendanceView.ShiftIn = (DateTime)Reader["ShiftIn"];
                    attendanceView.ShiftOut = (DateTime)Reader["ShiftOut"];
                    attendanceView.ShiftLate = (DateTime)Reader["ShiftLate"];
                    attendanceView.ShiftLunchIn = (DateTime)Reader["ShiftLunchIn"];
                    attendanceView.ShiftLunchOut = (DateTime)Reader["ShiftLunchOut"];
                    attendanceView.ShiftLunchLate = (DateTime)Reader["ShiftLunchLate"];
                    attendanceView.ShiftLunchHr = (DateTime)Reader["ShiftLunchHr"];
                    attendanceView.DutyHr = (DateTime)Reader["DutyHr"];
                    attendanceView.WorkHr = (decimal)Reader["WorkHr"];
                    attendanceView.LateHr = (decimal)Reader["LateHr"];
                    attendanceView.OT = (DateTime)Reader["OT"];
                    attendanceView.OTHr = (decimal)Reader["OTHr"];
                    attendanceView.OTMin = (decimal)Reader["OTMin"];
                    attendanceView.Status = Reader["Status"].ToString();
                    attendanceView.PCnt = (decimal)Reader["PCnt"];
                    attendanceView.Remark = Reader["Remark"].ToString();
                    attendanceView.SftEmp = Reader["SftEmp"].ToString();
                    attendanceView.ActIn = (DateTime)Reader["ActIn"];
                    attendanceView.ActOut = (DateTime)Reader["ActOut"];
                    attendanceView.LnOut = (DateTime)Reader["LnOut"];
                    attendanceView.LnBk = (DateTime)Reader["LnBk"];
                    attendanceView.LnLtHr = (decimal)Reader["LnLtHr"];
                    attendanceView.EOut = (DateTime)Reader["EOut"];
                    attendanceView.EOHr = (decimal)Reader["EOHr"];
                    attendanceView.ActOT = (decimal)Reader["ActOT"];
                    attendanceView.ExtOT = (decimal)Reader["ExtOT"];
                    attendanceView.DedOT = (decimal)Reader["DedOT"];
                    attendanceView.OTRem = Reader["OTRem"].ToString();
                    attendanceView.Pnc = (decimal)Reader["Pnc"];
                    attendanceView.FID = Reader["FID"].ToString();
                    attendanceView.N1 = (decimal)Reader["N1"];
                    attendanceView.N2 = (decimal)Reader["N2"];
                    attendanceView.S1 = Reader["S1"].ToString();
                    attendanceView.S2 = Reader["S2"].ToString();
                    attendanceView.D1 = (DateTime)Reader["D1"];
                    attendanceView.D2 = (DateTime)Reader["D2"];
                    attendanceView.Sex = Reader["Sex"].ToString();
                    attendanceViewList.Add(attendanceView);
                }
                Reader.Close();
                ConnectionClose();
                return attendanceViewList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get AttendanceView List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }












        public async Task<List<AttendanceView>> GetAttViewListByEmpIdByFromToDate(DateTime? fromDate = null, DateTime? toDate = null,string? employeeId = "")
        {
            try
            {
                if (fromDate == null && toDate==null && employeeId==null)
                {
                    Query = "SELECT * FROM AttendanceView";
                }
                else if (fromDate != null && toDate != null && employeeId == null)
                {
                    Query = $"SELECT * FROM AttendanceView WHERE AttendanceDate between '{fromDate}' and '{toDate}' order by sn asc ,AttendanceDate asc ";
                }
                else if(fromDate != null && toDate != null && employeeId !=null)
                {
                    Query = $"SELECT * FROM AttendanceView WHERE AttendanceDate between '{fromDate}' and '{toDate}' and EmployeeId='{employeeId}'  ";
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<AttendanceView> attendanceViewList = new List<AttendanceView>();
                while (Reader.Read())
                {
                    AttendanceView attendanceView = new AttendanceView();
                    attendanceView.CompanyName = Reader["CompanyName"].ToString();
                    attendanceView.DepartmentName = Reader["DepartmentName"].ToString();
                    attendanceView.DesignationName = Reader["DesignationName"].ToString();
                    attendanceView.EmployeeName = Reader["EmployeeName"].ToString();
                    attendanceView.ShiftName = Reader["ShiftName"].ToString();
                    attendanceView.ShiftType = Reader["ShiftType"].ToString();
                    attendanceView.SectionName = Reader["SectionName"].ToString();
                    attendanceView.SalarySectionName = Reader["SalarySectionName"].ToString();
                    attendanceView.AttendanceId = (int)Reader["AttendanceId"];
                    attendanceView.EmployeeId = Reader["EmployeeId"].ToString();
                    attendanceView.CardId = Reader["CardId"].ToString();
                    attendanceView.DepartmentId = (int)Reader["DepartmentId"];
                    attendanceView.SectionId = (int)Reader["SectionId"];
                    attendanceView.Expr6 = (int)Reader["Expr6"];
                    attendanceView.DesignationId = (int)Reader["DesignationId"];
                    attendanceView.CompanyId = (int)Reader["CompanyId"];
                    attendanceView.AttendanceDate = (DateTime)Reader["AttendanceDate"];
                    attendanceView.TimeIn = (DateTime)Reader["TimeIn"];
                    attendanceView.TimeOut = (DateTime)Reader["TimeOut"];
                    attendanceView.ShiftDetailId = (int)Reader["ShiftDetailId"];
                    attendanceView.Late = (DateTime)Reader["Late"];
                    attendanceView.ShiftIn = (DateTime)Reader["ShiftIn"];
                    attendanceView.ShiftOut = (DateTime)Reader["ShiftOut"];
                    attendanceView.ShiftLate = (DateTime)Reader["ShiftLate"];
                    attendanceView.ShiftLunchIn = (DateTime)Reader["ShiftLunchIn"];
                    attendanceView.ShiftLunchOut = (DateTime)Reader["ShiftLunchOut"];
                    attendanceView.ShiftLunchLate = (DateTime)Reader["ShiftLunchLate"];
                    attendanceView.ShiftLunchHr = (DateTime)Reader["ShiftLunchHr"];
                    attendanceView.DutyHr = (DateTime)Reader["DutyHr"];
                    attendanceView.WorkHr = (decimal)Reader["WorkHr"];
                    attendanceView.LateHr = (decimal)Reader["LateHr"];
                    attendanceView.OT = (DateTime)Reader["OT"];
                    attendanceView.OTHr = (decimal)Reader["OTHr"];
                    attendanceView.OTMin = (decimal)Reader["OTMin"];
                    attendanceView.Status = Reader["Status"].ToString();
                    attendanceView.PCnt = (decimal)Reader["PCnt"];
                    attendanceView.Remark = Reader["Remark"].ToString();
                    attendanceView.SftEmp = Reader["SftEmp"].ToString();
                    attendanceView.ActIn = (DateTime)Reader["ActIn"];
                    attendanceView.ActOut = (DateTime)Reader["ActOut"];
                    attendanceView.LnOut = (DateTime)Reader["LnOut"];
                    attendanceView.LnBk = (DateTime)Reader["LnBk"];
                    attendanceView.LnLtHr = (decimal)Reader["LnLtHr"];
                    attendanceView.EOut = (DateTime)Reader["EOut"];
                    attendanceView.EOHr = (decimal)Reader["EOHr"];
                    attendanceView.ActOT = (decimal)Reader["ActOT"];
                    attendanceView.ExtOT = (decimal)Reader["ExtOT"];
                    attendanceView.DedOT = (decimal)Reader["DedOT"];
                    attendanceView.OTRem = Reader["OTRem"].ToString();
                    attendanceView.Pnc = (decimal)Reader["Pnc"];
                    attendanceView.FID = Reader["FID"].ToString();
                    attendanceView.N1 = (decimal)Reader["N1"];
                    attendanceView.N2 = (decimal)Reader["N2"];
                    attendanceView.S1 = Reader["S1"].ToString();
                    attendanceView.S2 = Reader["S2"].ToString();
                    attendanceView.D1 = (DateTime)Reader["D1"];
                    attendanceView.D2 = (DateTime)Reader["D2"];
                    attendanceView.Sex = Reader["Sex"].ToString();
                    attendanceView.SN = (decimal)Reader["SN"];
                    //      attendanceView.DepartmentId = (int)Reader["DepartmentId"];
                    attendanceViewList.Add(attendanceView);

                }
                Reader.Close();
                ConnectionClose();
                return attendanceViewList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get AttendanceView List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }






        //public async Task<(bool Success, string Message, string ModalHeaderClass, string ModalTitle)> ExecuteJobCardProc(
        //                     DateTime fromDate,
        //                     DateTime toDate,
        //                     List<string> employeeIds)
        //{
        //    try
        //    {
        //        // Validate input
        //        if (employeeIds == null || !employeeIds.Any())
        //        {
        //            return (false, "Employee IDs cannot be empty.", "bg-warning text-white", "Warning");
        //        }

        //        // Convert employeeIds to a comma-separated string (e.g., "1,2,3")
        //        string employeeIdString = string.Join(",", employeeIds);

        //        // Open connection
        //        ConnectionOpen();

        //        // Configure the command
        //        using (Command = new SqlCommand("JobCardProc", Connection))
        //        {
        //            Command.CommandType = CommandType.StoredProcedure;

        //            // Add parameters
        //            Command.Parameters.AddWithValue("@FromDate", fromDate);
        //            Command.Parameters.AddWithValue("@ToDate", toDate);
        //            Command.Parameters.AddWithValue("@EmployeeId", employeeIdString);

        //            // Execute the stored procedure
        //            await Command.ExecuteNonQueryAsync();
        //        }

        //        return (true, "The Process executed successfully.", "bg-success text-white", "Success");
        //    }
        //    catch (Exception ex)
        //    {
        //        return (false, $"Error executing Process: {ex.Message}", "bg-danger text-white", "Error");
        //    }
        //    finally
        //    {
        //        ConnectionClose();
        //    }
        //}



        //public void InsertEmployeeIds(List<string> employeeIds)
        //{

        //    Query = "delete * from tblTempStr";
        //    ConnectionOpen();
        //    Command = new SqlCommand(Query, Connection);
        //    Command.ExecuteNonQuery();
        //    ConnectionClose();


        //    ConnectionOpen();
        //    foreach (string id in employeeIds)
        //        {
        //           string query = "insert into tblTempStr (EmployeeId) VALUES (@EmployeeId)";
        //            using (SqlCommand cmd = new SqlCommand(query, Connection))
        //            {
        //                cmd.Parameters.AddWithValue("@EmployeeId", id);
        //                cmd.ExecuteNonQuery();
        //            }
        //        }
        //    ConnectionClose();
        //}


        public async Task InsertEmployeeIdsAsync(List<string> employeeIds)
      {

        ConnectionOpen();

            // Delete existing records
            string deleteQuery = "DELETE FROM tblTempStr";
        using (SqlCommand command = new SqlCommand(deleteQuery, Connection))
        {
            await command.ExecuteNonQueryAsync();
        }

        // Insert new records
        foreach (string id in employeeIds)
        {
            string insertQuery = "INSERT INTO tblTempStr (EmployeeId) VALUES (@EmployeeId)";
            using (SqlCommand command = new SqlCommand(insertQuery, Connection))
              {
                command.Parameters.AddWithValue("@EmployeeId", id);
                await command.ExecuteNonQueryAsync();
               }
        }

         ConnectionClose();

        }



        public async Task<(bool Success, string Message, string ModalHeaderClass, string ModalTitle)> ExecuteJobCardProc(DateTime fromDate, DateTime toDate)
        {
            try
            {
                ConnectionOpen();
                Command = new SqlCommand("JobCardProc", Connection);
                Command.CommandType = System.Data.CommandType.StoredProcedure;
                Command.Parameters.Add(new SqlParameter("@FromDate", fromDate));
                Command.Parameters.Add(new SqlParameter("@ToDate", toDate));
                
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



        //public async Task<(bool Success, string Message, string ModalHeaderClass, string ModalTitle)> ExecuteJobCardProc(DateTime fromDate, DateTime toDate, string employeeId)
        //{
        //    try
        //    {
        //        ConnectionOpen();
        //        Command = new SqlCommand("JobCardProc", Connection);
        //        Command.CommandType = System.Data.CommandType.StoredProcedure;
        //        Command.Parameters.Add(new SqlParameter("@FromDate", fromDate));
        //        Command.Parameters.Add(new SqlParameter("@ToDate", toDate));
        //        Command.Parameters.Add(new SqlParameter("@EmployeeId", employeeId));
        //        await Command.ExecuteNonQueryAsync();
        //        return (true, "The Process executed successfully.", "bg-success text-white", "Success");
        //    }
        //    catch (Exception ex)
        //    {
        //        return (false, $"Error executing Process: {ex.Message}", "bg-danger text-white", "Error");
        //    }
        //    finally
        //    {
        //        ConnectionClose();
        //    }
        //}



        public async Task<List<AttendanceView>> GetAttendanceViewListByMaxAttDate(DateTime? attendanceDate = null)
        {
            try
            {
                if (attendanceDate == null)
                {
                    // Query = "SELECT * FROM AttendanceView";
                    Query= "select* from AttendanceView where AttendanceDate = (select  MAX(AttendanceDate) from AttendanceView" ;
                }
                else
                {
                  //  Query = "select* from AttendanceView where AttendanceDate = (select  MAX(AttendanceDate) from AttendanceView";
                  //  Query = $"SELECT * FROM AttendanceView WHERE AttendanceDate='{attendanceDate}'";
                }

                Command = new SqlCommand(Query, Connection);
                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();
                List<AttendanceView> attendanceViewList = new List<AttendanceView>();
                while (Reader.Read())
                {
                    AttendanceView attendanceView = new AttendanceView();
                    attendanceView.CompanyName = Reader["CompanyName"].ToString();
                    attendanceView.DepartmentName = Reader["DepartmentName"].ToString();
                    attendanceView.DesignationName = Reader["DesignationName"].ToString();
                    attendanceView.EmployeeName = Reader["EmployeeName"].ToString();
                    attendanceView.ShiftName = Reader["ShiftName"].ToString();
                    attendanceView.ShiftType = Reader["ShiftType"].ToString();
                    attendanceView.SectionName = Reader["SectionName"].ToString();
                    attendanceView.SalarySectionName = Reader["SalarySectionName"].ToString();
                    attendanceView.AttendanceId = (int)Reader["AttendanceId"];
                    attendanceView.EmployeeId = Reader["EmployeeId"].ToString();
                    attendanceView.CardId = Reader["CardId"].ToString();
                    attendanceView.DepartmentId = (int)Reader["DepartmentId"];
                    attendanceView.SectionId = (int)Reader["SectionId"];
                    attendanceView.Expr6 = (int)Reader["Expr6"];
                    attendanceView.DesignationId = (int)Reader["DesignationId"];
                    attendanceView.CompanyId = (int)Reader["CompanyId"];
                    attendanceView.AttendanceDate = (DateTime)Reader["AttendanceDate"];
                    attendanceView.TimeIn = (DateTime)Reader["TimeIn"];
                    attendanceView.TimeOut = (DateTime)Reader["TimeOut"];
                    attendanceView.ShiftDetailId = (int)Reader["ShiftDetailId"];
                    attendanceView.Late = (DateTime)Reader["Late"];
                    attendanceView.ShiftIn = (DateTime)Reader["ShiftIn"];
                    attendanceView.ShiftOut = (DateTime)Reader["ShiftOut"];
                    attendanceView.ShiftLate = (DateTime)Reader["ShiftLate"];
                    attendanceView.ShiftLunchIn = (DateTime)Reader["ShiftLunchIn"];
                    attendanceView.ShiftLunchOut = (DateTime)Reader["ShiftLunchOut"];
                    attendanceView.ShiftLunchLate = (DateTime)Reader["ShiftLunchLate"];
                    attendanceView.ShiftLunchHr = (DateTime)Reader["ShiftLunchHr"];
                    attendanceView.DutyHr = (DateTime)Reader["DutyHr"];
                    attendanceView.WorkHr = (decimal)Reader["WorkHr"];
                    attendanceView.LateHr = (decimal)Reader["LateHr"];
                    attendanceView.OT = (DateTime)Reader["OT"];
                    attendanceView.OTHr = (decimal)Reader["OTHr"];
                    attendanceView.OTMin = (decimal)Reader["OTMin"];
                    attendanceView.Status = Reader["Status"].ToString();
                    attendanceView.PCnt = (decimal)Reader["PCnt"];
                    attendanceView.Remark = Reader["Remark"].ToString();
                    attendanceView.SftEmp = Reader["SftEmp"].ToString();
                    attendanceView.ActIn = (DateTime)Reader["ActIn"];
                    attendanceView.ActOut = (DateTime)Reader["ActOut"];
                    attendanceView.LnOut = (DateTime)Reader["LnOut"];
                    attendanceView.LnBk = (DateTime)Reader["LnBk"];
                    attendanceView.LnLtHr = (decimal)Reader["LnLtHr"];
                    attendanceView.EOut = (DateTime)Reader["EOut"];
                    attendanceView.EOHr = (decimal)Reader["EOHr"];
                    attendanceView.ActOT = (decimal)Reader["ActOT"];
                    attendanceView.ExtOT = (decimal)Reader["ExtOT"];
                    attendanceView.DedOT = (decimal)Reader["DedOT"];
                    attendanceView.OTRem = Reader["OTRem"].ToString();
                    attendanceView.Pnc = (decimal)Reader["Pnc"];
                    attendanceView.FID = Reader["FID"].ToString();
                    attendanceView.N1 = (decimal)Reader["N1"];
                    attendanceView.N2 = (decimal)Reader["N2"];
                    attendanceView.S1 = Reader["S1"].ToString();
                    attendanceView.S2 = Reader["S2"].ToString();
                    attendanceView.D1 = (DateTime)Reader["D1"];
                    attendanceView.D2 = (DateTime)Reader["D2"];
                    attendanceViewList.Add(attendanceView);
                }
                Reader.Close();
                ConnectionClose();
                return attendanceViewList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get AttendanceView List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }


        ////////////////////////////   Testing Crystal Report   *****************************888888
        ////////////////////////////   **********************   *****************************888888
        ////////////////////////////   **********************   *****************************888888                      
      
        public async Task<List<AttendanceView>> GetEmpReport(DateTime? fromDate = null, DateTime? toDate = null, string? empId = null)
        {
            try
            {
                if (empId == null && fromDate ==null && toDate==null )
                {
                    Query = "SELECT * FROM AttendanceView";
                }
                else
                {
                    Query = $"SELECT * FROM AttendanceView WHERE EmployeeId='{empId}' " +
                        $"and AttendanceDate between '{fromDate}' and '{toDate}' order by AttendanceDate ";
                }

                Command = new SqlCommand(Query, Connection);
                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<AttendanceView> attendanceViewList = new List<AttendanceView>();
                while (Reader.Read())
                {
                    AttendanceView attendanceView = new AttendanceView();
                    attendanceView.CompanyName = Reader["CompanyName"].ToString();
                    attendanceView.DepartmentName = Reader["DepartmentName"].ToString();
                    attendanceView.DesignationName = Reader["DesignationName"].ToString();
                    attendanceView.EmployeeName = Reader["EmployeeName"].ToString();
                    attendanceView.ShiftName = Reader["ShiftName"].ToString();
                    attendanceView.ShiftType = Reader["ShiftType"].ToString();
                    attendanceView.SectionName = Reader["SectionName"].ToString();
                    attendanceView.SalarySectionName = Reader["SalarySectionName"].ToString();
                    attendanceView.AttendanceId = (int)Reader["AttendanceId"];
                    attendanceView.EmployeeId = Reader["EmployeeId"].ToString();
                    attendanceView.CardId = Reader["CardId"].ToString();
                    attendanceView.DepartmentId = (int)Reader["DepartmentId"];
                    attendanceView.SectionId = (int)Reader["SectionId"];
                    attendanceView.Expr6 = (int)Reader["Expr6"];
                    attendanceView.DesignationId = (int)Reader["DesignationId"];
                    attendanceView.CompanyId = (int)Reader["CompanyId"];
                    attendanceView.AttendanceDate = (DateTime)Reader["AttendanceDate"];
                    attendanceView.TimeIn = (DateTime)Reader["TimeIn"];
                    attendanceView.TimeOut = (DateTime)Reader["TimeOut"];
                    attendanceView.ShiftDetailId = (int)Reader["ShiftDetailId"];
                    attendanceView.Late = (DateTime)Reader["Late"];
                    attendanceView.ShiftIn = (DateTime)Reader["ShiftIn"];
                    attendanceView.ShiftOut = (DateTime)Reader["ShiftOut"];
                    attendanceView.ShiftLate = (DateTime)Reader["ShiftLate"];
                    attendanceView.ShiftLunchIn = (DateTime)Reader["ShiftLunchIn"];
                    attendanceView.ShiftLunchOut = (DateTime)Reader["ShiftLunchOut"];
                    attendanceView.ShiftLunchLate = (DateTime)Reader["ShiftLunchLate"];
                    attendanceView.ShiftLunchHr = (DateTime)Reader["ShiftLunchHr"];
                    attendanceView.DutyHr = (DateTime)Reader["DutyHr"];
                    attendanceView.WorkHr = (decimal)Reader["WorkHr"];
                    attendanceView.LateHr = (decimal)Reader["LateHr"];
                    attendanceView.OT = (DateTime)Reader["OT"];
                    attendanceView.OTHr = (decimal)Reader["OTHr"];
                    attendanceView.OTMin = (decimal)Reader["OTMin"];
                    attendanceView.Status = Reader["Status"].ToString();
                    attendanceView.PCnt = (decimal)Reader["PCnt"];
                    attendanceView.Remark = Reader["Remark"].ToString();
                    attendanceView.SftEmp = Reader["SftEmp"].ToString();
                    attendanceView.ActIn = (DateTime)Reader["ActIn"];
                    attendanceView.ActOut = (DateTime)Reader["ActOut"];
                    attendanceView.LnOut = (DateTime)Reader["LnOut"];
                    attendanceView.LnBk = (DateTime)Reader["LnBk"];
                    attendanceView.LnLtHr = (decimal)Reader["LnLtHr"];
                    attendanceView.EOut = (DateTime)Reader["EOut"];
                    attendanceView.EOHr = (decimal)Reader["EOHr"];
                    attendanceView.ActOT = (decimal)Reader["ActOT"];
                    attendanceView.ExtOT = (decimal)Reader["ExtOT"];
                    attendanceView.DedOT = (decimal)Reader["DedOT"];
                    attendanceView.OTRem = Reader["OTRem"].ToString();
                    attendanceView.Pnc = (decimal)Reader["Pnc"];
                    attendanceView.FID = Reader["FID"].ToString();
                    attendanceView.N1 = (decimal)Reader["N1"];
                    attendanceView.N2 = (decimal)Reader["N2"];
                    attendanceView.S1 = Reader["S1"].ToString();
                    attendanceView.S2 = Reader["S2"].ToString();
                    attendanceView.D1 = (DateTime)Reader["D1"];
                    attendanceView.D2 = (DateTime)Reader["D2"];
                    attendanceViewList.Add(attendanceView);
                }
                Reader.Close();
                ConnectionClose();
                return attendanceViewList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get AttendanceView List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        ///   ////////////////////////////*****************************888888
        ///    ////////////////////////////*****************************888888
        ///     ////////////////////////////*****************************888888
        ///      ////////////////////////////*****************************888888
        ///      




        ////////////////////////////   GetPresentReport Report *****************************888888
        /// ////////////////////////////*****************************888888
        ///  ////////////////////////////*****************************888888
        ///  

        public async Task<List<AttendanceView>> GetDailyAttendanceReport(DateTime? attendanceDate = null, string? sign =null)
        {
            try
            {
                if (attendanceDate == null)
                { 
                    Query = $"SELECT * FROM AttendanceView WHERE Status='P' ";
                }

                if (sign == "Present")
                {
                    Query = $"SELECT * FROM AttendanceView WHERE Status='P' and  AttendanceDate='{attendanceDate}'";
                }

                if (sign == "AllEmployee")
                {
                    Query = $"SELECT * FROM AttendanceView WHERE  AttendanceDate='{attendanceDate}'";
                }

                if (sign == "Absent")
                {
                    Query = $"SELECT * FROM AttendanceView WHERE Status='A' and AttendanceDate='{attendanceDate}'";
                }

                if (sign == "Leave")
                {
                    Query = $"SELECT * FROM AttendanceView WHERE Status in ('SL','CL','EL','ML') and AttendanceDate='{attendanceDate}'";
                }


                if (sign == "Late")
                {
                    Query = $"SELECT * FROM AttendanceView WHERE Status = 'L' and AttendanceDate='{attendanceDate}'";
                }


                if (sign == "Male")
                {
                    Query = $"SELECT * FROM AttendanceView WHERE Sex = 'Male' and AttendanceDate='{attendanceDate}'";
                }

                if (sign == "Female")
                {
                    Query = $"SELECT * FROM AttendanceView WHERE Sex = 'Female' and AttendanceDate='{attendanceDate}'";
                }





                Command = new SqlCommand(Query, Connection);
                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<AttendanceView> attendanceViewList = new List<AttendanceView>();
                while (Reader.Read())
                {
                    AttendanceView attendanceView = new AttendanceView();
                    attendanceView.CompanyName = Reader["CompanyName"].ToString();
                    attendanceView.DepartmentName = Reader["DepartmentName"].ToString();
                    attendanceView.DesignationName = Reader["DesignationName"].ToString();
                    attendanceView.EmployeeName = Reader["EmployeeName"].ToString();
                    attendanceView.ShiftName = Reader["ShiftName"].ToString();
                    attendanceView.ShiftType = Reader["ShiftType"].ToString();
                    attendanceView.SectionName = Reader["SectionName"].ToString();
                    attendanceView.SalarySectionName = Reader["SalarySectionName"].ToString();
                    attendanceView.AttendanceId = (int)Reader["AttendanceId"];
                    attendanceView.EmployeeId = Reader["EmployeeId"].ToString();
                    attendanceView.CardId = Reader["CardId"].ToString();
                    attendanceView.DepartmentId = (int)Reader["DepartmentId"];
                    attendanceView.SectionId = (int)Reader["SectionId"];
                    attendanceView.Expr6 = (int)Reader["Expr6"];
                    attendanceView.DesignationId = (int)Reader["DesignationId"];
                    attendanceView.CompanyId = (int)Reader["CompanyId"];
                    attendanceView.AttendanceDate = (DateTime)Reader["AttendanceDate"];
                    attendanceView.TimeIn = (DateTime)Reader["TimeIn"];
                    attendanceView.TimeOut = (DateTime)Reader["TimeOut"];
                    attendanceView.ShiftDetailId = (int)Reader["ShiftDetailId"];
                    attendanceView.Late = (DateTime)Reader["Late"];
                    attendanceView.ShiftIn = (DateTime)Reader["ShiftIn"];
                    attendanceView.ShiftOut = (DateTime)Reader["ShiftOut"];
                    attendanceView.ShiftLate = (DateTime)Reader["ShiftLate"];
                    attendanceView.ShiftLunchIn = (DateTime)Reader["ShiftLunchIn"];
                    attendanceView.ShiftLunchOut = (DateTime)Reader["ShiftLunchOut"];
                    attendanceView.ShiftLunchLate = (DateTime)Reader["ShiftLunchLate"];
                    attendanceView.ShiftLunchHr = (DateTime)Reader["ShiftLunchHr"];
                    attendanceView.DutyHr = (DateTime)Reader["DutyHr"];
                    attendanceView.WorkHr = (decimal)Reader["WorkHr"];
                    attendanceView.LateHr = (decimal)Reader["LateHr"];
                    attendanceView.OT = (DateTime)Reader["OT"];
                    attendanceView.OTHr = (decimal)Reader["OTHr"];
                    attendanceView.OTMin = (decimal)Reader["OTMin"];
                    attendanceView.Status = Reader["Status"].ToString();
                    attendanceView.PCnt = (decimal)Reader["PCnt"];
                    attendanceView.Remark = Reader["Remark"].ToString();
                    attendanceView.SftEmp = Reader["SftEmp"].ToString();
                    attendanceView.ActIn = (DateTime)Reader["ActIn"];
                    attendanceView.ActOut = (DateTime)Reader["ActOut"];
                    attendanceView.LnOut = (DateTime)Reader["LnOut"];
                    attendanceView.LnBk = (DateTime)Reader["LnBk"];
                    attendanceView.LnLtHr = (decimal)Reader["LnLtHr"];
                    attendanceView.EOut = (DateTime)Reader["EOut"];
                    attendanceView.EOHr = (decimal)Reader["EOHr"];
                    attendanceView.ActOT = (decimal)Reader["ActOT"];
                    attendanceView.ExtOT = (decimal)Reader["ExtOT"];
                    attendanceView.DedOT = (decimal)Reader["DedOT"];
                    attendanceView.OTRem = Reader["OTRem"].ToString();
                    attendanceView.Pnc = (decimal)Reader["Pnc"];
                    attendanceView.FID = Reader["FID"].ToString();
                    attendanceView.N1 = (decimal)Reader["N1"];
                    attendanceView.N2 = (decimal)Reader["N2"];
                    attendanceView.S1 = Reader["S1"].ToString();
                    attendanceView.S2 = Reader["S2"].ToString();
                    attendanceView.D1 = (DateTime)Reader["D1"];
                    attendanceView.D2 = (DateTime)Reader["D2"];
                    attendanceView.Sex = Reader["Sex"].ToString();
                    attendanceViewList.Add(attendanceView);
                   
                }
                Reader.Close();
                ConnectionClose();
                return attendanceViewList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get AttendanceView List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        ///   ////////////////////////////*****************************888888
        ///    ////////////////////////////*****************************888888
        ///     ////////////////////////////*****************************888888
        ///      ////////////////////////////*****************************888888

      



    }
}