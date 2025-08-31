using AttendancePayrollWebServerApp.Models;
using AttendancePayrollWebServerApp.Models.View;
using AttendancePayrollWebServerApp.Pages.Employee;
using AttendancePayrollWebServerApp.UtilityClass;
using DevExpress.Xpo.DB.Helpers;
using System;
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
                    attendanceView.SalarySectionId = Reader["SalarySectionId"].ToString();
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
                    attendanceView.Late = (DateTime)Reader["Late"];
                    attendanceView.ShiftId = (int)Reader["ShiftId"];
                    attendanceView.ShiftType = Reader["ShiftType"].ToString();
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





        public async Task<List<AttendanceView>> GetAttendanceViewListByMaxAttDate(DateTime? attendanceDate = null)
        {
            try
            {
                if (attendanceDate == null)
                {
                    //Query = "SELECT * FROM AttendanceView";

                    Query= "select* from AttendanceView where AttendanceDate = (select  MAX(AttendanceDate) from AttendanceView" ;
                }
                else
                {
                  //  Query = "select* from AttendanceView where AttendanceDate = (select  MAX(AttendanceDate) from AttendanceView";
                    //Query = $"SELECT * FROM AttendanceView WHERE AttendanceDate='{attendanceDate}'";
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
                    attendanceView.SalarySectionId = Reader["SalarySectionId"].ToString();
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
                    attendanceView.Late = (DateTime)Reader["Late"];
                    attendanceView.ShiftId = (int)Reader["ShiftId"];
                    attendanceView.ShiftType = Reader["ShiftType"].ToString();
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





















    }
}