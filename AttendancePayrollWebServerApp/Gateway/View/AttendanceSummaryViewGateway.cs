using AttendancePayrollWebServerApp.Models;
using AttendancePayrollWebServerApp.Models.View;
using AttendancePayrollWebServerApp.UtilityClass;
//using DevExpress.Pdf.Native.BouncyCastle.Ocsp;
using DevExpress.Xpo.DB.Helpers;
using System.Data.SqlClient;

namespace AttendancePayrollWebServerApp.Gateway.View
{
    public class AttendanceSummaryViewGateway :Gateway
    {
        public async Task<(bool Success, string Message, string ModalHeaderClass, string ModalTitle)> ExecuteAttendanceSummaryProc(DateTime fromDate, DateTime toDate)
        {
            try
            {
                ConnectionOpen();
                Command = new SqlCommand("AttendanceSumProc", Connection);
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


      

        public async Task<List<AttendanceSummaryView>> GetAttSumViewListByDate(DateTime? fromDate = null , DateTime? toDate = null)
        {
            try
            {
                if (fromDate == null && toDate ==null)
                {
                    Query = "SELECT * FROM AttendanceSummaryView order by SN";
                }
                else
                {
                    Query = $"SELECT * FROM AttendanceSummaryView WHERE FromDate='{fromDate}' and ToDate='{toDate}' order by SN";
                }
                Command = new SqlCommand(Query, Connection);
                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<AttendanceSummaryView> attendanceSummaryViewList = new List<AttendanceSummaryView>();
                while (Reader.Read())
                {
                    AttendanceSummaryView attendanceSummaryView = new AttendanceSummaryView();

                    attendanceSummaryView.Id = (decimal)Reader["Id"];
                    attendanceSummaryView.EmployeeId = Reader["EmployeeId"].ToString();
                    attendanceSummaryView.EmployeeName = Reader["EmployeeName"].ToString();
                    attendanceSummaryView.SectionName = Reader["SectionName"].ToString();
                    attendanceSummaryView.DepartmentName = Reader["DepartmentName"].ToString();
                    attendanceSummaryView.DesignationName = Reader["DesignationName"].ToString();
                    attendanceSummaryView.worktype = Reader["worktype"].ToString();
                    attendanceSummaryView.MAttStr = Reader["MAttStr"].ToString();
                    attendanceSummaryView.FromDate = (DateTime)Reader["FromDate"];
                    attendanceSummaryView.ToDate = (DateTime)Reader["ToDate"];
                    attendanceSummaryView.MonthDays = (decimal)Reader["MonthDays"];
                    attendanceSummaryView.WHD = (decimal)Reader["WHD"];
                    attendanceSummaryView.HD = (decimal)Reader["HD"];
                    attendanceSummaryView.WD = (decimal)Reader["WD"];
                    attendanceSummaryView.P = (decimal)Reader["P"];
                    attendanceSummaryView.A = (decimal)Reader["A"];
                    attendanceSummaryView.L = (decimal)Reader["L"];
                    attendanceSummaryView.WHDPL = (decimal)Reader["WHDPL"];
                    attendanceSummaryView.HDPL = (decimal)Reader["HDPL"];
                    attendanceSummaryView.TotalPresent = (decimal)Reader["TotalPresent"];
                    attendanceSummaryView.CL = (decimal)Reader["CL"];
                    attendanceSummaryView.SL = (decimal)Reader["SL"];
                    attendanceSummaryView.EL = (decimal)Reader["EL"];
                    attendanceSummaryView.ML = (decimal)Reader["ML"];
                    attendanceSummaryView.LWP = (decimal)Reader["LWP"];
                    attendanceSummaryView.OL = (decimal)Reader["OL"];
                    attendanceSummaryView.TotalLeave = (decimal)Reader["TotalLeave"];
                    attendanceSummaryView.LeaveStr = Reader["LeaveStr"].ToString();
                    attendanceSummaryView.PayD = (decimal)Reader["PayD"];
                    attendanceSummaryView.LHr = (decimal)Reader["LHr"];
                    attendanceSummaryView.LStr = Reader["LStr"].ToString();
                    attendanceSummaryView.OT = (decimal)Reader["OT"];
                    attendanceSummaryView.ExtOT = (decimal)Reader["ExtOT"];
                    attendanceSummaryView.DedOT = (decimal)Reader["DedOT"];
                    attendanceSummaryView.TotalOT = (decimal)Reader["TotalOT"];
                    attendanceSummaryView.Remarks = Reader["Remarks"].ToString();
                    attendanceSummaryView.SN = (decimal)Reader["SN"];
                    attendanceSummaryViewList.Add(attendanceSummaryView);
                }
                Reader.Close();
                ConnectionClose();
                return attendanceSummaryViewList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get AttendanceSummaryView List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }



        //Filter by dept
        //Filter by dept


        public async Task<List<AttendanceSummaryView>> GetAttSumViewListByDateByDept(DateTime? fromDate = null, DateTime? toDate = null)
        {
            try
            {
                if (fromDate == null && toDate ==null )
                {
                    Query = "SELECT * FROM AttendanceSummaryView";
                }
                else
                {
                    Query = $"SELECT * FROM AttendanceSummaryView WHERE FromDate='{fromDate}' and ToDate='{toDate}' and EmployeeId in (select EmployeeId from tblTempStr)";
                  
                }

                Command = new SqlCommand(Query, Connection);
                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();



                List<AttendanceSummaryView> attendanceSummaryViewList = new List<AttendanceSummaryView>();
                while (Reader.Read())
                {
                    AttendanceSummaryView attendanceSummaryView = new AttendanceSummaryView
                    {
                        Id = (decimal)Reader["Id"],
                        EmployeeId = Reader["EmployeeId"].ToString(),
                        EmployeeName = Reader["EmployeeName"].ToString(),
                        SectionName = Reader["SectionName"].ToString(),
                        DepartmentName = Reader["DepartmentName"].ToString(),
                        DesignationName = Reader["DesignationName"].ToString(),
                        worktype = Reader["worktype"].ToString(),
                        MAttStr = Reader["MAttStr"].ToString(),
                        FromDate = (DateTime)Reader["FromDate"],
                        ToDate = (DateTime)Reader["ToDate"],
                        MonthDays = (decimal)Reader["MonthDays"],
                        WHD = (decimal)Reader["WHD"],
                        HD = (decimal)Reader["HD"],
                        WD = (decimal)Reader["WD"],
                        P = (decimal)Reader["P"],
                        A = (decimal)Reader["A"],
                        L = (decimal)Reader["L"],
                        WHDPL = (decimal)Reader["WHDPL"],
                        HDPL = (decimal)Reader["HDPL"],
                        TotalPresent = (decimal)Reader["TotalPresent"],
                        CL = (decimal)Reader["CL"],
                        SL = (decimal)Reader["SL"],
                        EL = (decimal)Reader["EL"],
                        ML = (decimal)Reader["ML"],
                        LWP = (decimal)Reader["LWP"],
                        OL = (decimal)Reader["OL"],
                        TotalLeave = (decimal)Reader["TotalLeave"],
                        LeaveStr = Reader["LeaveStr"].ToString(),
                        PayD = (decimal)Reader["PayD"],
                        LHr = (decimal)Reader["LHr"],
                        LStr = Reader["LStr"].ToString(),
                        OT = (decimal)Reader["OT"],
                        ExtOT = (decimal)Reader["ExtOT"],
                        DedOT = (decimal)Reader["DedOT"],
                        TotalOT = (decimal)Reader["TotalOT"],
                        Remarks = Reader["Remarks"].ToString(),
                        JoinDate = (DateTime)Reader["JoinDate"]
                    };

                    attendanceSummaryViewList.Add(attendanceSummaryView);
                }

                Reader.Close();
                return attendanceSummaryViewList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get AttendanceSummaryView List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }




        //public async Task<List<AttendanceSummaryView>> GetAttSumViewListByDateByDept(DateTime? fromDate = null, DateTime? toDate = null, List<string> departNames=null)
        //{
        //    try
        //    {
        //        ConnectionOpen();

        //        string query;
        //        if (fromDate == null && toDate == null && (departNames == null || !departNames.Any()))
        //        {
        //            query = "SELECT * FROM AttendanceSummaryView";
        //            Command = new SqlCommand(query, Connection);
        //        }
        //        else
        //        {
        //            query = "SELECT * FROM AttendanceSummaryView WHERE 1=1";
        //            var parameters = new List<SqlParameter>();

        //            if (fromDate.HasValue)
        //            {
        //                query += " AND FromDate = @FromDate";
        //                parameters.Add(new SqlParameter("@FromDate", fromDate.Value));
        //            }

        //            if (toDate.HasValue)
        //            {
        //                query += " AND ToDate = @ToDate";
        //                parameters.Add(new SqlParameter("@ToDate", toDate.Value));
        //            }

        //            if (departNames != null && departNames.Any())
        //            {
        //                var paramNames = departNames.Select((_, index) => $"@Dept{index}").ToList();
        //                query += $" AND DepartmentName IN ({string.Join(",", paramNames)})";
        //                for (int i = 0; i < departNames.Count; i++)
        //                {
        //                    parameters.Add(new SqlParameter(paramNames[i], departNames[i]));
        //                }
        //            }

        //            Command = new SqlCommand(query, Connection);
        //            Command.Parameters.AddRange(parameters.ToArray());
        //        }

        //        Reader = await Command.ExecuteReaderAsync();

        //        List<AttendanceSummaryView> attendanceSummaryViewList = new List<AttendanceSummaryView>();
        //        while (Reader.Read())
        //        {
        //            AttendanceSummaryView attendanceSummaryView = new AttendanceSummaryView
        //            {
        //                Id = (decimal)Reader["Id"],
        //                EmployeeId = Reader["EmployeeId"].ToString(),
        //                EmployeeName = Reader["EmployeeName"].ToString(),
        //                SectionName = Reader["SectionName"].ToString(),
        //                DepartmentName = Reader["DepartmentName"].ToString(),
        //                DesignationName = Reader["DesignationName"].ToString(),
        //                worktype = Reader["worktype"].ToString(),
        //                MAttStr = Reader["MAttStr"].ToString(),
        //                FromDate = (DateTime)Reader["FromDate"],
        //                ToDate = (DateTime)Reader["ToDate"],
        //                MonthDays = (decimal)Reader["MonthDays"],
        //                WHD = (decimal)Reader["WHD"],
        //                HD = (decimal)Reader["HD"],
        //                WD = (decimal)Reader["WD"],
        //                P = (decimal)Reader["P"],
        //                A = (decimal)Reader["A"],
        //                L = (decimal)Reader["L"],
        //                WHDPL = (decimal)Reader["WHDPL"],
        //                HDPL = (decimal)Reader["HDPL"],
        //                TotalPresent = (decimal)Reader["TotalPresent"],
        //                CL = (decimal)Reader["CL"],
        //                SL = (decimal)Reader["SL"],
        //                EL = (decimal)Reader["EL"],
        //                ML = (decimal)Reader["ML"],
        //                LWP = (decimal)Reader["LWP"],
        //                OL = (decimal)Reader["OL"],
        //                TotalLeave = (decimal)Reader["TotalLeave"],
        //                LeaveStr = Reader["LeaveStr"].ToString(),
        //                PayD = (decimal)Reader["PayD"],
        //                LHr = (decimal)Reader["LHr"],
        //                LStr = Reader["LStr"].ToString(),
        //                OT = (decimal)Reader["OT"],
        //                ExtOT = (decimal)Reader["ExtOT"],
        //                DedOT = (decimal)Reader["DedOT"],
        //                TotalOT = (decimal)Reader["TotalOT"],
        //                Remarks = Reader["Remarks"].ToString()
        //            };

        //            attendanceSummaryViewList.Add(attendanceSummaryView);
        //        }

        //        Reader.Close();
        //        return attendanceSummaryViewList;
        //    }
        //    catch (Exception exception)
        //    {
        //        throw new Exception("Failed To Get AttendanceSummaryView List \n" + exception.Message);
        //    }
        //    finally
        //    {
        //        ConnectionClose();
        //    }
        //}




        //   public async Task<List<AttendanceSummaryView>> GetAttSumViewListByDateByDept(DateTime? fromDate = null, DateTime? toDate = null, List<string> departNames = null)
        //   // public async Task<List<AttendanceSummaryView>> GetAttSumViewListByDateByDept(DateTime? fromDate = null, DateTime? toDate = null)
        //    {
        //    try
        //    {
        //        if (fromDate == null && toDate == null)
        //        {
        //            Query = "SELECT * FROM AttendanceSummaryView";
        //        }
        //        else
        //        {
        //            Query = $"SELECT * FROM AttendanceSummaryView WHERE " +
        //                    $"FromDate='{fromDate}' and ToDate='{toDate}' and DepartmentName in '{departNames}' ";
        //        }

        //        Command = new SqlCommand(Query, Connection);

        //        ConnectionOpen();
        //        Reader = await Command.ExecuteReaderAsync();

        //        List<AttendanceSummaryView> attendanceSummaryViewList = new List<AttendanceSummaryView>();
        //        while (Reader.Read())
        //        {
        //            AttendanceSummaryView attendanceSummaryView = new AttendanceSummaryView();

        //            attendanceSummaryView.Id = (decimal)Reader["Id"];
        //            attendanceSummaryView.EmployeeId = Reader["EmployeeId"].ToString();
        //            attendanceSummaryView.EmployeeName = Reader["EmployeeName"].ToString();
        //            attendanceSummaryView.SectionName = Reader["SectionName"].ToString();
        //            attendanceSummaryView.DepartmentName = Reader["DepartmentName"].ToString();
        //            attendanceSummaryView.DesignationName = Reader["DesignationName"].ToString();
        //            attendanceSummaryView.worktype = Reader["worktype"].ToString();
        //            attendanceSummaryView.MAttStr = Reader["MAttStr"].ToString();
        //            attendanceSummaryView.FromDate = (DateTime)Reader["FromDate"];
        //            attendanceSummaryView.ToDate = (DateTime)Reader["ToDate"];
        //            attendanceSummaryView.MonthDays = (decimal)Reader["MonthDays"];
        //            attendanceSummaryView.WHD = (decimal)Reader["WHD"];
        //            attendanceSummaryView.HD = (decimal)Reader["HD"];
        //            attendanceSummaryView.WD = (decimal)Reader["WD"];
        //            attendanceSummaryView.P = (decimal)Reader["P"];
        //            attendanceSummaryView.A = (decimal)Reader["A"];
        //            attendanceSummaryView.L = (decimal)Reader["L"];
        //            attendanceSummaryView.WHDPL = (decimal)Reader["WHDPL"];
        //            attendanceSummaryView.HDPL = (decimal)Reader["HDPL"];
        //            attendanceSummaryView.TotalPresent = (decimal)Reader["TotalPresent"];
        //            attendanceSummaryView.CL = (decimal)Reader["CL"];
        //            attendanceSummaryView.SL = (decimal)Reader["SL"];
        //            attendanceSummaryView.EL = (decimal)Reader["EL"];
        //            attendanceSummaryView.ML = (decimal)Reader["ML"];
        //            attendanceSummaryView.LWP = (decimal)Reader["LWP"];
        //            attendanceSummaryView.OL = (decimal)Reader["OL"];
        //            attendanceSummaryView.TotalLeave = (decimal)Reader["TotalLeave"];
        //            attendanceSummaryView.LeaveStr = Reader["LeaveStr"].ToString();
        //            attendanceSummaryView.PayD = (decimal)Reader["PayD"];
        //            attendanceSummaryView.LHr = (decimal)Reader["LHr"];
        //            attendanceSummaryView.LStr = Reader["LStr"].ToString();
        //            attendanceSummaryView.OT = (decimal)Reader["OT"];
        //            attendanceSummaryView.ExtOT = (decimal)Reader["ExtOT"];
        //            attendanceSummaryView.DedOT = (decimal)Reader["DedOT"];
        //            attendanceSummaryView.TotalOT = (decimal)Reader["TotalOT"];
        //            attendanceSummaryView.Remarks = Reader["Remarks"].ToString();

        //            attendanceSummaryViewList.Add(attendanceSummaryView);
        //        }
        //        Reader.Close();
        //        ConnectionClose();
        //        return attendanceSummaryViewList;
        //    }
        //    catch (Exception exception)
        //    {
        //        throw new Exception("Failed To Get AttendanceSummaryView List \n" + exception.Message);
        //    }
        //    finally
        //    {
        //        ConnectionClose();
        //    }
        //}

        //Filter by dept
        //Filter by dept












        public async Task<Alert> Save(AttendanceSummaryView attendanceSummaryView, string existCondition = "")
        {
            try
            {
                if (existCondition != "")
                {
                    if (await IsExist(existCondition) == true)
                    {
                        return new Alert("warning", "The record is already exist");
                    }
                }

                Query = "INSERT INTO AttendanceSummaryView (EmployeeId,EmployeeName,SectionName,DepartmentName,DesignationName,Worktype,MAttStr,FromDate,ToDate,MonthDays,WHD,HD,WD,P,A,L,WHDPL,HDPL,TotalPresent,CL,SL,EL,ML,LWP,OL,TotalLeave,LeaveStr,PayD,LHr,LStr,OT,ExtOT,DedOT,TotalOT,Remarks) VALUES(@employeeId,@employeeName,@sectionName,@departmentName,@designationName,@worktype,@mAttStr,@fromDate,@toDate,@monthDays,@wHD,@hD,@wD,@p,@a,@l,@wHDPL,@hDPL,@totalPresent,@cL,@sL,@eL,@mL,@lWP,@oL,@totalLeave,@leaveStr,@payD,@lHr,@lStr,@oT,@extOT,@dedOT,@totalOT,@remarks)";

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@id", attendanceSummaryView.Id);
                Command.Parameters.AddWithValue("@employeeId", attendanceSummaryView.EmployeeId);
                Command.Parameters.AddWithValue("@employeeName", attendanceSummaryView.EmployeeName);
                Command.Parameters.AddWithValue("@sectionName", attendanceSummaryView.SectionName);
                Command.Parameters.AddWithValue("@departmentName", attendanceSummaryView.DepartmentName);
                Command.Parameters.AddWithValue("@designationName", attendanceSummaryView.DesignationName);
                Command.Parameters.AddWithValue("@worktype", attendanceSummaryView.worktype);
                Command.Parameters.AddWithValue("@mAttStr", attendanceSummaryView.MAttStr);
                Command.Parameters.AddWithValue("@fromDate", attendanceSummaryView.FromDate);
                Command.Parameters.AddWithValue("@toDate", attendanceSummaryView.ToDate);
                Command.Parameters.AddWithValue("@monthDays", attendanceSummaryView.MonthDays);
                Command.Parameters.AddWithValue("@wHD", attendanceSummaryView.WHD);
                Command.Parameters.AddWithValue("@hD", attendanceSummaryView.HD);
                Command.Parameters.AddWithValue("@wD", attendanceSummaryView.WD);
                Command.Parameters.AddWithValue("@p", attendanceSummaryView.P);
                Command.Parameters.AddWithValue("@a", attendanceSummaryView.A);
                Command.Parameters.AddWithValue("@l", attendanceSummaryView.L);
                Command.Parameters.AddWithValue("@wHDPL", attendanceSummaryView.WHDPL);
                Command.Parameters.AddWithValue("@hDPL", attendanceSummaryView.HDPL);
                Command.Parameters.AddWithValue("@totalPresent", attendanceSummaryView.TotalPresent);
                Command.Parameters.AddWithValue("@cL", attendanceSummaryView.CL);
                Command.Parameters.AddWithValue("@sL", attendanceSummaryView.SL);
                Command.Parameters.AddWithValue("@eL", attendanceSummaryView.EL);
                Command.Parameters.AddWithValue("@mL", attendanceSummaryView.ML);
                Command.Parameters.AddWithValue("@lWP", attendanceSummaryView.LWP);
                Command.Parameters.AddWithValue("@oL", attendanceSummaryView.OL);
                Command.Parameters.AddWithValue("@totalLeave", attendanceSummaryView.TotalLeave);
                Command.Parameters.AddWithValue("@leaveStr", attendanceSummaryView.LeaveStr);
                Command.Parameters.AddWithValue("@payD", attendanceSummaryView.PayD);
                Command.Parameters.AddWithValue("@lHr", attendanceSummaryView.LHr);
                Command.Parameters.AddWithValue("@lStr", attendanceSummaryView.LStr);
                Command.Parameters.AddWithValue("@oT", attendanceSummaryView.OT);
                Command.Parameters.AddWithValue("@extOT", attendanceSummaryView.ExtOT);
                Command.Parameters.AddWithValue("@dedOT", attendanceSummaryView.DedOT);
                Command.Parameters.AddWithValue("@totalOT", attendanceSummaryView.TotalOT);
                Command.Parameters.AddWithValue("@remarks", attendanceSummaryView.Remarks);

                ConnectionOpen();
                int rowAffected = await Command.ExecuteNonQueryAsync();
                ConnectionClose();

                if (rowAffected > 0)
                {
                    return new Alert("success", "Saved");
                }
                return new Alert("warning", "Not Saved");
            }
            catch (Exception exception)
            {
                return new Alert("danger", "Failed To Save\n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<Alert> Edit(AttendanceSummaryView attendanceSummaryView, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "UPDATE AttendanceSummaryView SET EmployeeId=@employeeId,EmployeeName=@employeeName,SectionName=@sectionName,DepartmentName=@departmentName,DesignationName=@designationName,worktype=@worktype,MAttStr=@mAttStr,FromDate=@fromDate,ToDate=@toDate,MonthDays=@monthDays,WHD=@wHD,HD=@hD,WD=@wD,P=@p,A=@a,L=@l,WHDPL=@wHDPL,HDPL=@hDPL,TotalPresent=@totalPresent,CL=@cL,SL=@sL,EL=@eL,ML=@mL,LWP=@lWP,OL=@oL,TotalLeave=@totalLeave,LeaveStr=@leaveStr,PayD=@payD,LHr=@lHr,LStr=@lStr,OT=@oT,ExtOT=@extOT,DedOT=@dedOT,TotalOT=@totalOT,Remarks=@remarks WHERE Id = @id";
                }
                else
                {
                    Query = "UPDATE AttendanceSummaryView SET EmployeeId=@employeeId,EmployeeName=@employeeName,SectionName=@sectionName,DepartmentName=@departmentName,DesignationName=@designationName,worktype=@worktype,MAttStr=@mAttStr,FromDate=@fromDate,ToDate=@toDate,MonthDays=@monthDays,WHD=@wHD,HD=@hD,WD=@wD,P=@p,A=@a,L=@l,WHDPL=@wHDPL,HDPL=@hDPL,TotalPresent=@totalPresent,CL=@cL,SL=@sL,EL=@eL,ML=@mL,LWP=@lWP,OL=@oL,TotalLeave=@totalLeave,LeaveStr=@leaveStr,PayD=@payD,LHr=@lHr,LStr=@lStr,OT=@oT,ExtOT=@extOT,DedOT=@dedOT,TotalOT=@totalOT,Remarks=@remarks WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@id", attendanceSummaryView.Id);
                Command.Parameters.AddWithValue("@employeeId", attendanceSummaryView.EmployeeId);
                Command.Parameters.AddWithValue("@employeeName", attendanceSummaryView.EmployeeName);
                Command.Parameters.AddWithValue("@sectionName", attendanceSummaryView.SectionName);
                Command.Parameters.AddWithValue("@departmentName", attendanceSummaryView.DepartmentName);
                Command.Parameters.AddWithValue("@designationName", attendanceSummaryView.DesignationName);
                Command.Parameters.AddWithValue("@worktype", attendanceSummaryView.worktype);
                Command.Parameters.AddWithValue("@mAttStr", attendanceSummaryView.MAttStr);
                Command.Parameters.AddWithValue("@fromDate", attendanceSummaryView.FromDate);
                Command.Parameters.AddWithValue("@toDate", attendanceSummaryView.ToDate);
                Command.Parameters.AddWithValue("@monthDays", attendanceSummaryView.MonthDays);
                Command.Parameters.AddWithValue("@wHD", attendanceSummaryView.WHD);
                Command.Parameters.AddWithValue("@hD", attendanceSummaryView.HD);
                Command.Parameters.AddWithValue("@wD", attendanceSummaryView.WD);
                Command.Parameters.AddWithValue("@p", attendanceSummaryView.P);
                Command.Parameters.AddWithValue("@a", attendanceSummaryView.A);
                Command.Parameters.AddWithValue("@l", attendanceSummaryView.L);
                Command.Parameters.AddWithValue("@wHDPL", attendanceSummaryView.WHDPL);
                Command.Parameters.AddWithValue("@hDPL", attendanceSummaryView.HDPL);
                Command.Parameters.AddWithValue("@totalPresent", attendanceSummaryView.TotalPresent);
                Command.Parameters.AddWithValue("@cL", attendanceSummaryView.CL);
                Command.Parameters.AddWithValue("@sL", attendanceSummaryView.SL);
                Command.Parameters.AddWithValue("@eL", attendanceSummaryView.EL);
                Command.Parameters.AddWithValue("@mL", attendanceSummaryView.ML);
                Command.Parameters.AddWithValue("@lWP", attendanceSummaryView.LWP);
                Command.Parameters.AddWithValue("@oL", attendanceSummaryView.OL);
                Command.Parameters.AddWithValue("@totalLeave", attendanceSummaryView.TotalLeave);
                Command.Parameters.AddWithValue("@leaveStr", attendanceSummaryView.LeaveStr);
                Command.Parameters.AddWithValue("@payD", attendanceSummaryView.PayD);
                Command.Parameters.AddWithValue("@lHr", attendanceSummaryView.LHr);
                Command.Parameters.AddWithValue("@lStr", attendanceSummaryView.LStr);
                Command.Parameters.AddWithValue("@oT", attendanceSummaryView.OT);
                Command.Parameters.AddWithValue("@extOT", attendanceSummaryView.ExtOT);
                Command.Parameters.AddWithValue("@dedOT", attendanceSummaryView.DedOT);
                Command.Parameters.AddWithValue("@totalOT", attendanceSummaryView.TotalOT);
                Command.Parameters.AddWithValue("@remarks", attendanceSummaryView.Remarks);

                ConnectionOpen();
                int rowAffected = await Command.ExecuteNonQueryAsync();
                ConnectionClose();

                if (rowAffected > 0)
                {
                    return new Alert("success", "Updated");
                }
                return new Alert("warning", "Not Updated");
            }
            catch (Exception exception)
            {
                return new Alert("danger", "Failed To Updated\n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<Alert> Delete(decimal id, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "DELETE AttendanceSummaryView WHERE Id = @id";
                }
                else
                {
                    Query = "DELETE AttendanceSummaryView WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@id", id);

                ConnectionOpen();
                int rowAffected = await Command.ExecuteNonQueryAsync();
                ConnectionClose();

                if (rowAffected > 0)
                {
                    return new Alert("success", "Deleted");
                }
                return new Alert("warning", "Not Deleted");
            }
            catch (Exception exception)
            {
                return new Alert("danger", "Failed To Delete\n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<bool> IsExist(string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT 1 FROM AttendanceSummaryView";
                }
                else
                {
                    Query = "SELECT 1 FROM AttendanceSummaryView WHERE " + condition;
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

        public async Task<AttendanceSummaryView> GetAttendanceSummaryView(decimal id, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM AttendanceSummaryView WHERE Id = @id";
                }
                else
                {
                    Query = "SELECT * FROM AttendanceSummaryView WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@id", id);
                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                AttendanceSummaryView attendanceSummaryView = new AttendanceSummaryView();
                while (Reader.Read())
                {
                    attendanceSummaryView.Id = (decimal)Reader["Id"];
                    attendanceSummaryView.EmployeeId = Reader["EmployeeId"].ToString();
                    attendanceSummaryView.EmployeeName = Reader["EmployeeName"].ToString();
                    attendanceSummaryView.SectionName = Reader["SectionName"].ToString();
                    attendanceSummaryView.DepartmentName = Reader["DepartmentName"].ToString();
                    attendanceSummaryView.DesignationName = Reader["DesignationName"].ToString();
                    attendanceSummaryView.worktype = Reader["worktype"].ToString();
                    attendanceSummaryView.MAttStr = Reader["MAttStr"].ToString();
                    attendanceSummaryView.FromDate = (DateTime)Reader["FromDate"];
                    attendanceSummaryView.ToDate = (DateTime)Reader["ToDate"];
                    attendanceSummaryView.MonthDays = (decimal)Reader["MonthDays"];
                    attendanceSummaryView.WHD = (decimal)Reader["WHD"];
                    attendanceSummaryView.HD = (decimal)Reader["HD"];
                    attendanceSummaryView.WD = (decimal)Reader["WD"];
                    attendanceSummaryView.P = (decimal)Reader["P"];
                    attendanceSummaryView.A = (decimal)Reader["A"];
                    attendanceSummaryView.L = (decimal)Reader["L"];
                    attendanceSummaryView.WHDPL = (decimal)Reader["WHDPL"];
                    attendanceSummaryView.HDPL = (decimal)Reader["HDPL"];
                    attendanceSummaryView.TotalPresent = (decimal)Reader["TotalPresent"];
                    attendanceSummaryView.CL = (decimal)Reader["CL"];
                    attendanceSummaryView.SL = (decimal)Reader["SL"];
                    attendanceSummaryView.EL = (decimal)Reader["EL"];
                    attendanceSummaryView.ML = (decimal)Reader["ML"];
                    attendanceSummaryView.LWP = (decimal)Reader["LWP"];
                    attendanceSummaryView.OL = (decimal)Reader["OL"];
                    attendanceSummaryView.TotalLeave = (decimal)Reader["TotalLeave"];
                    attendanceSummaryView.LeaveStr = Reader["LeaveStr"].ToString();
                    attendanceSummaryView.PayD = (decimal)Reader["PayD"];
                    attendanceSummaryView.LHr = (decimal)Reader["LHr"];
                    attendanceSummaryView.LStr = Reader["LStr"].ToString();
                    attendanceSummaryView.OT = (decimal)Reader["OT"];
                    attendanceSummaryView.ExtOT = (decimal)Reader["ExtOT"];
                    attendanceSummaryView.DedOT = (decimal)Reader["DedOT"];
                    attendanceSummaryView.TotalOT = (decimal)Reader["TotalOT"];
                    attendanceSummaryView.Remarks = Reader["Remarks"].ToString();
                }
                Reader.Close();
                ConnectionClose();
                return attendanceSummaryView;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get AttendanceSummaryView\n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<List<AttendanceSummaryView>> GetAttendanceSummaryViewList(string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM AttendanceSummaryView";
                }
                else
                {
                    Query = "SELECT * FROM AttendanceSummaryView WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<AttendanceSummaryView> attendanceSummaryViewList = new List<AttendanceSummaryView>();
                while (Reader.Read())
                {
                    AttendanceSummaryView attendanceSummaryView = new AttendanceSummaryView();

                    attendanceSummaryView.Id = (decimal)Reader["Id"];
                    attendanceSummaryView.EmployeeId = Reader["EmployeeId"].ToString();
                    attendanceSummaryView.EmployeeName = Reader["EmployeeName"].ToString();
                    attendanceSummaryView.SectionName = Reader["SectionName"].ToString();
                    attendanceSummaryView.DepartmentName = Reader["DepartmentName"].ToString();
                    attendanceSummaryView.DesignationName = Reader["DesignationName"].ToString();
                    attendanceSummaryView.worktype = Reader["worktype"].ToString();
                    attendanceSummaryView.MAttStr = Reader["MAttStr"].ToString();
                    attendanceSummaryView.FromDate = (DateTime)Reader["FromDate"];
                    attendanceSummaryView.ToDate = (DateTime)Reader["ToDate"];
                    attendanceSummaryView.MonthDays = (decimal)Reader["MonthDays"];
                    attendanceSummaryView.WHD = (decimal)Reader["WHD"];
                    attendanceSummaryView.HD = (decimal)Reader["HD"];
                    attendanceSummaryView.WD = (decimal)Reader["WD"];
                    attendanceSummaryView.P = (decimal)Reader["P"];
                    attendanceSummaryView.A = (decimal)Reader["A"];
                    attendanceSummaryView.L = (decimal)Reader["L"];
                    attendanceSummaryView.WHDPL = (decimal)Reader["WHDPL"];
                    attendanceSummaryView.HDPL = (decimal)Reader["HDPL"];
                    attendanceSummaryView.TotalPresent = (decimal)Reader["TotalPresent"];
                    attendanceSummaryView.CL = (decimal)Reader["CL"];
                    attendanceSummaryView.SL = (decimal)Reader["SL"];
                    attendanceSummaryView.EL = (decimal)Reader["EL"];
                    attendanceSummaryView.ML = (decimal)Reader["ML"];
                    attendanceSummaryView.LWP = (decimal)Reader["LWP"];
                    attendanceSummaryView.OL = (decimal)Reader["OL"];
                    attendanceSummaryView.TotalLeave = (decimal)Reader["TotalLeave"];
                    attendanceSummaryView.LeaveStr = Reader["LeaveStr"].ToString();
                    attendanceSummaryView.PayD = (decimal)Reader["PayD"];
                    attendanceSummaryView.LHr = (decimal)Reader["LHr"];
                    attendanceSummaryView.LStr = Reader["LStr"].ToString();
                    attendanceSummaryView.OT = (decimal)Reader["OT"];
                    attendanceSummaryView.ExtOT = (decimal)Reader["ExtOT"];
                    attendanceSummaryView.DedOT = (decimal)Reader["DedOT"];
                    attendanceSummaryView.TotalOT = (decimal)Reader["TotalOT"];
                    attendanceSummaryView.Remarks = Reader["Remarks"].ToString();

                    attendanceSummaryViewList.Add(attendanceSummaryView);
                }
                Reader.Close();
                ConnectionClose();
                return attendanceSummaryViewList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get AttendanceSummaryView List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }


        public async Task<List<AttendanceSummaryView>> GetAttendanceSummary(DateTime? fromDate = null, DateTime? toDate = null)
        {
            try
            {
                if (fromDate != null && toDate != null)
                {
                    Query = $"SELECT * FROM AttendanceSummaryView WHERE  FromDate ='{fromDate}' and ToDate= '{toDate}'";
                }
                Command = new SqlCommand(Query, Connection);
                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();
                List<AttendanceSummaryView> attendanceSummaryViewList = new List<AttendanceSummaryView>();
                while (Reader.Read())
                {
                    AttendanceSummaryView attendanceSummaryView = new AttendanceSummaryView();

                    attendanceSummaryView.Id = (decimal)Reader["Id"];
                    attendanceSummaryView.EmployeeId = Reader["EmployeeId"].ToString();
                    attendanceSummaryView.EmployeeName = Reader["EmployeeName"].ToString();
                    attendanceSummaryView.SectionName = Reader["SectionName"].ToString();
                    attendanceSummaryView.DepartmentName = Reader["DepartmentName"].ToString();
                    attendanceSummaryView.DesignationName = Reader["DesignationName"].ToString();
                    attendanceSummaryView.worktype = Reader["worktype"].ToString();
                    attendanceSummaryView.MAttStr = Reader["MAttStr"].ToString();
                    attendanceSummaryView.FromDate = (DateTime)Reader["FromDate"];
                    attendanceSummaryView.JoinDate = (DateTime)Reader["JoinDate"];
                    attendanceSummaryView.ToDate = (DateTime)Reader["ToDate"];
                    attendanceSummaryView.MonthDays = (decimal)Reader["MonthDays"];
                    attendanceSummaryView.WHD = (decimal)Reader["WHD"];
                    attendanceSummaryView.HD = (decimal)Reader["HD"];
                    attendanceSummaryView.WD = (decimal)Reader["WD"];
                    attendanceSummaryView.P = (decimal)Reader["P"];
                    attendanceSummaryView.A = (decimal)Reader["A"];
                    attendanceSummaryView.L = (decimal)Reader["L"];
                    attendanceSummaryView.WHDPL = (decimal)Reader["WHDPL"];
                    attendanceSummaryView.HDPL = (decimal)Reader["HDPL"];
                    attendanceSummaryView.TotalPresent = (decimal)Reader["TotalPresent"];
                    attendanceSummaryView.CL = (decimal)Reader["CL"];
                    attendanceSummaryView.SL = (decimal)Reader["SL"];
                    attendanceSummaryView.EL = (decimal)Reader["EL"];
                    attendanceSummaryView.ML = (decimal)Reader["ML"];
                    attendanceSummaryView.LWP = (decimal)Reader["LWP"];
                    attendanceSummaryView.OL = (decimal)Reader["OL"];
                    attendanceSummaryView.TotalLeave = (decimal)Reader["TotalLeave"];
                    attendanceSummaryView.LeaveStr = Reader["LeaveStr"].ToString();
                    attendanceSummaryView.PayD = (decimal)Reader["PayD"];
                    attendanceSummaryView.LHr = (decimal)Reader["LHr"];
                    attendanceSummaryView.LStr = Reader["LStr"].ToString();
                    attendanceSummaryView.OT = (decimal)Reader["OT"];
                    attendanceSummaryView.ExtOT = (decimal)Reader["ExtOT"];
                    attendanceSummaryView.DedOT = (decimal)Reader["DedOT"];
                    attendanceSummaryView.TotalOT = (decimal)Reader["TotalOT"];
                    attendanceSummaryView.Remarks = Reader["Remarks"].ToString();

                    attendanceSummaryViewList.Add(attendanceSummaryView);
                }
                Reader.Close();
                ConnectionClose();
                return attendanceSummaryViewList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get AttendanceSummaryView List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }





        public async Task<List<AttendanceSummaryView>> GetAttendanceSummaryViewListMinCol(string columns, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT " + columns + " FROM AttendanceSummaryView";
                }
                else
                {
                    Query = "SELECT " + columns + " FROM AttendanceSummaryView WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<AttendanceSummaryView> attendanceSummaryViewList = new List<AttendanceSummaryView>();
                while (Reader.Read())
                {
                    AttendanceSummaryView attendanceSummaryView = new AttendanceSummaryView();

                    SkipOnError(() => attendanceSummaryView.Id = (decimal)Reader["Id"]);
                    SkipOnError(() => attendanceSummaryView.EmployeeId = Reader["EmployeeId"].ToString());
                    SkipOnError(() => attendanceSummaryView.EmployeeName = Reader["EmployeeName"].ToString());
                    SkipOnError(() => attendanceSummaryView.SectionName = Reader["SectionName"].ToString());
                    SkipOnError(() => attendanceSummaryView.DepartmentName = Reader["DepartmentName"].ToString());
                    SkipOnError(() => attendanceSummaryView.DesignationName = Reader["DesignationName"].ToString());
                    SkipOnError(() => attendanceSummaryView.worktype = Reader["worktype"].ToString());
                    SkipOnError(() => attendanceSummaryView.MAttStr = Reader["MAttStr"].ToString());
                    SkipOnError(() => attendanceSummaryView.FromDate = (DateTime)Reader["FromDate"]);
                    SkipOnError(() => attendanceSummaryView.ToDate = (DateTime)Reader["ToDate"]);
                    SkipOnError(() => attendanceSummaryView.MonthDays = (decimal)Reader["MonthDays"]);
                    SkipOnError(() => attendanceSummaryView.WHD = (decimal)Reader["WHD"]);
                    SkipOnError(() => attendanceSummaryView.HD = (decimal)Reader["HD"]);
                    SkipOnError(() => attendanceSummaryView.WD = (decimal)Reader["WD"]);
                    SkipOnError(() => attendanceSummaryView.P = (decimal)Reader["P"]);
                    SkipOnError(() => attendanceSummaryView.A = (decimal)Reader["A"]);
                    SkipOnError(() => attendanceSummaryView.L = (decimal)Reader["L"]);
                    SkipOnError(() => attendanceSummaryView.WHDPL = (decimal)Reader["WHDPL"]);
                    SkipOnError(() => attendanceSummaryView.HDPL = (decimal)Reader["HDPL"]);
                    SkipOnError(() => attendanceSummaryView.TotalPresent = (decimal)Reader["TotalPresent"]);
                    SkipOnError(() => attendanceSummaryView.CL = (decimal)Reader["CL"]);
                    SkipOnError(() => attendanceSummaryView.SL = (decimal)Reader["SL"]);
                    SkipOnError(() => attendanceSummaryView.EL = (decimal)Reader["EL"]);
                    SkipOnError(() => attendanceSummaryView.ML = (decimal)Reader["ML"]);
                    SkipOnError(() => attendanceSummaryView.LWP = (decimal)Reader["LWP"]);
                    SkipOnError(() => attendanceSummaryView.OL = (decimal)Reader["OL"]);
                    SkipOnError(() => attendanceSummaryView.TotalLeave = (decimal)Reader["TotalLeave"]);
                    SkipOnError(() => attendanceSummaryView.LeaveStr = Reader["LeaveStr"].ToString());
                    SkipOnError(() => attendanceSummaryView.PayD = (decimal)Reader["PayD"]);
                    SkipOnError(() => attendanceSummaryView.LHr = (decimal)Reader["LHr"]);
                    SkipOnError(() => attendanceSummaryView.LStr = Reader["LStr"].ToString());
                    SkipOnError(() => attendanceSummaryView.OT = (decimal)Reader["OT"]);
                    SkipOnError(() => attendanceSummaryView.ExtOT = (decimal)Reader["ExtOT"]);
                    SkipOnError(() => attendanceSummaryView.DedOT = (decimal)Reader["DedOT"]);
                    SkipOnError(() => attendanceSummaryView.TotalOT = (decimal)Reader["TotalOT"]);
                    SkipOnError(() => attendanceSummaryView.Remarks = Reader["Remarks"].ToString());

                    attendanceSummaryViewList.Add(attendanceSummaryView);
                }
                Reader.Close();
                ConnectionClose();
                return attendanceSummaryViewList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get AttendanceSummaryView List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        private void SkipOnError(Action action)
        {
            try
            {
                action();
            }
            catch
            {
            }
        }





    }
}
