using AttendancePayrollWebServerApp.Models.View;
using AttendancePayrollWebServerApp.UtilityClass;
using System.Data.SqlClient;

namespace AttendancePayrollWebServerApp.Gateway.View
{
    public class JobCardViewGateway :Gateway
    {



        public async Task<Alert> Save(JobCardView jobCardView, string existCondition = "")
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

                Query = "INSERT INTO JobCardView (SN,DepartmentName,DesignationName,EmployeeName,ShiftName,ShiftType,SectionName,SalarySectionName,AttendanceId,EmployeeId,CardId,DepartmentId,SectionId,Expr6,DesignationId,CompanyId,AttendanceDate,TimeIn,TimeOut,ShiftDetailId,Late,ShiftIn,ShiftOut,ShiftLate,ShiftLunchIn,ShiftLunchOut,ShiftLunchLate,ShiftLunchHr,DutyHr,WorkHr,LateHr,OT,OTHr,OTMin,Status,PCnt,Remark,SftEmp,ActIn,ActOut,LnOut,LnBk,LnLtHr,EOut,EOHr,ActOT,ExtOT,DedOT,OTRem,Pnc,FID,N1,N2,S1,S2,D1,D2,Sex,CompNameBan,FromDate,ToDate,P,A,L,HD,WHD,CL,SL,EL,Expr1,MD,WD,TotalLeave) VALUES(@sN,@departmentName,@designationName,@employeeName,@shiftName,@shiftType,@sectionName,@salarySectionName,@attendanceId,@employeeId,@cardId,@departmentId,@sectionId,@expr6,@designationId,@companyId,@attendanceDate,@timeIn,@timeOut,@shiftDetailId,@late,@shiftIn,@shiftOut,@shiftLate,@shiftLunchIn,@shiftLunchOut,@shiftLunchLate,@shiftLunchHr,@dutyHr,@workHr,@lateHr,@oT,@oTHr,@oTMin,@status,@pCnt,@remark,@sftEmp,@actIn,@actOut,@lnOut,@lnBk,@lnLtHr,@eOut,@eOHr,@actOT,@extOT,@dedOT,@oTRem,@pnc,@fID,@n1,@n2,@s1,@s2,@d1,@d2,@sex,@compNameBan,@fromDate,@toDate,@p,@a,@l,@hD,@wHD,@cL,@sL,@eL,@expr1,@mD,@wD,@totalLeave)";

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@companyName", jobCardView.CompanyName);
                Command.Parameters.AddWithValue("@sN", jobCardView.SN);
                Command.Parameters.AddWithValue("@departmentName", jobCardView.DepartmentName);
                Command.Parameters.AddWithValue("@designationName", jobCardView.DesignationName);
                Command.Parameters.AddWithValue("@employeeName", jobCardView.EmployeeName);
                Command.Parameters.AddWithValue("@shiftName", jobCardView.ShiftName);
                Command.Parameters.AddWithValue("@shiftType", jobCardView.ShiftType);
                Command.Parameters.AddWithValue("@sectionName", jobCardView.SectionName);
                Command.Parameters.AddWithValue("@salarySectionName", jobCardView.SalarySectionName);
                Command.Parameters.AddWithValue("@attendanceId", jobCardView.AttendanceId);
                Command.Parameters.AddWithValue("@employeeId", jobCardView.EmployeeId);
                Command.Parameters.AddWithValue("@cardId", jobCardView.CardId);
                Command.Parameters.AddWithValue("@departmentId", jobCardView.DepartmentId);
                Command.Parameters.AddWithValue("@sectionId", jobCardView.SectionId);
                Command.Parameters.AddWithValue("@expr6", jobCardView.Expr6);
                Command.Parameters.AddWithValue("@designationId", jobCardView.DesignationId);
                Command.Parameters.AddWithValue("@companyId", jobCardView.CompanyId);
                Command.Parameters.AddWithValue("@attendanceDate", jobCardView.AttendanceDate);
                Command.Parameters.AddWithValue("@timeIn", jobCardView.TimeIn);
                Command.Parameters.AddWithValue("@timeOut", jobCardView.TimeOut);
                Command.Parameters.AddWithValue("@shiftDetailId", jobCardView.ShiftDetailId);
                Command.Parameters.AddWithValue("@late", jobCardView.Late);
                Command.Parameters.AddWithValue("@shiftIn", jobCardView.ShiftIn);
                Command.Parameters.AddWithValue("@shiftOut", jobCardView.ShiftOut);
                Command.Parameters.AddWithValue("@shiftLate", jobCardView.ShiftLate);
                Command.Parameters.AddWithValue("@shiftLunchIn", jobCardView.ShiftLunchIn);
                Command.Parameters.AddWithValue("@shiftLunchOut", jobCardView.ShiftLunchOut);
                Command.Parameters.AddWithValue("@shiftLunchLate", jobCardView.ShiftLunchLate);
                Command.Parameters.AddWithValue("@shiftLunchHr", jobCardView.ShiftLunchHr);
                Command.Parameters.AddWithValue("@dutyHr", jobCardView.DutyHr);
                Command.Parameters.AddWithValue("@workHr", jobCardView.WorkHr);
                Command.Parameters.AddWithValue("@lateHr", jobCardView.LateHr);
                Command.Parameters.AddWithValue("@oT", jobCardView.OT);
                Command.Parameters.AddWithValue("@oTHr", jobCardView.OTHr);
                Command.Parameters.AddWithValue("@oTMin", jobCardView.OTMin);
                Command.Parameters.AddWithValue("@status", jobCardView.Status);
                Command.Parameters.AddWithValue("@pCnt", jobCardView.PCnt);
                Command.Parameters.AddWithValue("@remark", jobCardView.Remark);
                Command.Parameters.AddWithValue("@sftEmp", jobCardView.SftEmp);
                Command.Parameters.AddWithValue("@actIn", jobCardView.ActIn);
                Command.Parameters.AddWithValue("@actOut", jobCardView.ActOut);
                Command.Parameters.AddWithValue("@lnOut", jobCardView.LnOut);
                Command.Parameters.AddWithValue("@lnBk", jobCardView.LnBk);
                Command.Parameters.AddWithValue("@lnLtHr", jobCardView.LnLtHr);
                Command.Parameters.AddWithValue("@eOut", jobCardView.EOut);
                Command.Parameters.AddWithValue("@eOHr", jobCardView.EOHr);
                Command.Parameters.AddWithValue("@actOT", jobCardView.ActOT);
                Command.Parameters.AddWithValue("@extOT", jobCardView.ExtOT);
                Command.Parameters.AddWithValue("@dedOT", jobCardView.DedOT);
                Command.Parameters.AddWithValue("@oTRem", jobCardView.OTRem);
                Command.Parameters.AddWithValue("@pnc", jobCardView.Pnc);
                Command.Parameters.AddWithValue("@fID", jobCardView.FID);
                Command.Parameters.AddWithValue("@n1", jobCardView.N1);
                Command.Parameters.AddWithValue("@n2", jobCardView.N2);
                Command.Parameters.AddWithValue("@s1", jobCardView.S1);
                Command.Parameters.AddWithValue("@s2", jobCardView.S2);
                Command.Parameters.AddWithValue("@d1", jobCardView.D1);
                Command.Parameters.AddWithValue("@d2", jobCardView.D2);
                Command.Parameters.AddWithValue("@sex", jobCardView.Sex);
                Command.Parameters.AddWithValue("@compNameBan", jobCardView.CompNameBan);
                Command.Parameters.AddWithValue("@fromDate", jobCardView.FromDate);
                Command.Parameters.AddWithValue("@toDate", jobCardView.ToDate);
                Command.Parameters.AddWithValue("@p", jobCardView.P);
                Command.Parameters.AddWithValue("@a", jobCardView.A);
                Command.Parameters.AddWithValue("@l", jobCardView.L);
                Command.Parameters.AddWithValue("@hD", jobCardView.HD);
                Command.Parameters.AddWithValue("@wHD", jobCardView.WHD);
                Command.Parameters.AddWithValue("@cL", jobCardView.CL);
                Command.Parameters.AddWithValue("@sL", jobCardView.SL);
                Command.Parameters.AddWithValue("@eL", jobCardView.EL);
                Command.Parameters.AddWithValue("@expr1", jobCardView.Expr1);
                Command.Parameters.AddWithValue("@mD", jobCardView.MD);
                Command.Parameters.AddWithValue("@wD", jobCardView.WD);
                Command.Parameters.AddWithValue("@totalLeave", jobCardView.TotalLeave);

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

        public async Task<Alert> Edit(JobCardView jobCardView, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "UPDATE JobCardView SET SN=@sN,DepartmentName=@departmentName,DesignationName=@designationName,EmployeeName=@employeeName,ShiftName=@shiftName,ShiftType=@shiftType,SectionName=@sectionName,SalarySectionName=@salarySectionName,AttendanceId=@attendanceId,EmployeeId=@employeeId,CardId=@cardId,DepartmentId=@departmentId,SectionId=@sectionId,Expr6=@expr6,DesignationId=@designationId,CompanyId=@companyId,AttendanceDate=@attendanceDate,TimeIn=@timeIn,TimeOut=@timeOut,ShiftDetailId=@shiftDetailId,Late=@late,ShiftIn=@shiftIn,ShiftOut=@shiftOut,ShiftLate=@shiftLate,ShiftLunchIn=@shiftLunchIn,ShiftLunchOut=@shiftLunchOut,ShiftLunchLate=@shiftLunchLate,ShiftLunchHr=@shiftLunchHr,DutyHr=@dutyHr,WorkHr=@workHr,LateHr=@lateHr,OT=@oT,OTHr=@oTHr,OTMin=@oTMin,Status=@status,PCnt=@pCnt,Remark=@remark,SftEmp=@sftEmp,ActIn=@actIn,ActOut=@actOut,LnOut=@lnOut,LnBk=@lnBk,LnLtHr=@lnLtHr,EOut=@eOut,EOHr=@eOHr,ActOT=@actOT,ExtOT=@extOT,DedOT=@dedOT,OTRem=@oTRem,Pnc=@pnc,FID=@fID,N1=@n1,N2=@n2,S1=@s1,S2=@s2,D1=@d1,D2=@d2,Sex=@sex,CompNameBan=@compNameBan,FromDate=@fromDate,ToDate=@toDate,P=@p,A=@a,L=@l,HD=@hD,WHD=@wHD,CL=@cL,SL=@sL,EL=@eL,Expr1=@expr1,MD=@mD,WD=@wD,TotalLeave=@totalLeave WHERE CompanyName = @companyName";
                }
                else
                {
                    Query = "UPDATE JobCardView SET SN=@sN,DepartmentName=@departmentName,DesignationName=@designationName,EmployeeName=@employeeName,ShiftName=@shiftName,ShiftType=@shiftType,SectionName=@sectionName,SalarySectionName=@salarySectionName,AttendanceId=@attendanceId,EmployeeId=@employeeId,CardId=@cardId,DepartmentId=@departmentId,SectionId=@sectionId,Expr6=@expr6,DesignationId=@designationId,CompanyId=@companyId,AttendanceDate=@attendanceDate,TimeIn=@timeIn,TimeOut=@timeOut,ShiftDetailId=@shiftDetailId,Late=@late,ShiftIn=@shiftIn,ShiftOut=@shiftOut,ShiftLate=@shiftLate,ShiftLunchIn=@shiftLunchIn,ShiftLunchOut=@shiftLunchOut,ShiftLunchLate=@shiftLunchLate,ShiftLunchHr=@shiftLunchHr,DutyHr=@dutyHr,WorkHr=@workHr,LateHr=@lateHr,OT=@oT,OTHr=@oTHr,OTMin=@oTMin,Status=@status,PCnt=@pCnt,Remark=@remark,SftEmp=@sftEmp,ActIn=@actIn,ActOut=@actOut,LnOut=@lnOut,LnBk=@lnBk,LnLtHr=@lnLtHr,EOut=@eOut,EOHr=@eOHr,ActOT=@actOT,ExtOT=@extOT,DedOT=@dedOT,OTRem=@oTRem,Pnc=@pnc,FID=@fID,N1=@n1,N2=@n2,S1=@s1,S2=@s2,D1=@d1,D2=@d2,Sex=@sex,CompNameBan=@compNameBan,FromDate=@fromDate,ToDate=@toDate,P=@p,A=@a,L=@l,HD=@hD,WHD=@wHD,CL=@cL,SL=@sL,EL=@eL,Expr1=@expr1,MD=@mD,WD=@wD,TotalLeave=@totalLeave WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@companyName", jobCardView.CompanyName);
                Command.Parameters.AddWithValue("@sN", jobCardView.SN);
                Command.Parameters.AddWithValue("@departmentName", jobCardView.DepartmentName);
                Command.Parameters.AddWithValue("@designationName", jobCardView.DesignationName);
                Command.Parameters.AddWithValue("@employeeName", jobCardView.EmployeeName);
                Command.Parameters.AddWithValue("@shiftName", jobCardView.ShiftName);
                Command.Parameters.AddWithValue("@shiftType", jobCardView.ShiftType);
                Command.Parameters.AddWithValue("@sectionName", jobCardView.SectionName);
                Command.Parameters.AddWithValue("@salarySectionName", jobCardView.SalarySectionName);
                Command.Parameters.AddWithValue("@attendanceId", jobCardView.AttendanceId);
                Command.Parameters.AddWithValue("@employeeId", jobCardView.EmployeeId);
                Command.Parameters.AddWithValue("@cardId", jobCardView.CardId);
                Command.Parameters.AddWithValue("@departmentId", jobCardView.DepartmentId);
                Command.Parameters.AddWithValue("@sectionId", jobCardView.SectionId);
                Command.Parameters.AddWithValue("@expr6", jobCardView.Expr6);
                Command.Parameters.AddWithValue("@designationId", jobCardView.DesignationId);
                Command.Parameters.AddWithValue("@companyId", jobCardView.CompanyId);
                Command.Parameters.AddWithValue("@attendanceDate", jobCardView.AttendanceDate);
                Command.Parameters.AddWithValue("@timeIn", jobCardView.TimeIn);
                Command.Parameters.AddWithValue("@timeOut", jobCardView.TimeOut);
                Command.Parameters.AddWithValue("@shiftDetailId", jobCardView.ShiftDetailId);
                Command.Parameters.AddWithValue("@late", jobCardView.Late);
                Command.Parameters.AddWithValue("@shiftIn", jobCardView.ShiftIn);
                Command.Parameters.AddWithValue("@shiftOut", jobCardView.ShiftOut);
                Command.Parameters.AddWithValue("@shiftLate", jobCardView.ShiftLate);
                Command.Parameters.AddWithValue("@shiftLunchIn", jobCardView.ShiftLunchIn);
                Command.Parameters.AddWithValue("@shiftLunchOut", jobCardView.ShiftLunchOut);
                Command.Parameters.AddWithValue("@shiftLunchLate", jobCardView.ShiftLunchLate);
                Command.Parameters.AddWithValue("@shiftLunchHr", jobCardView.ShiftLunchHr);
                Command.Parameters.AddWithValue("@dutyHr", jobCardView.DutyHr);
                Command.Parameters.AddWithValue("@workHr", jobCardView.WorkHr);
                Command.Parameters.AddWithValue("@lateHr", jobCardView.LateHr);
                Command.Parameters.AddWithValue("@oT", jobCardView.OT);
                Command.Parameters.AddWithValue("@oTHr", jobCardView.OTHr);
                Command.Parameters.AddWithValue("@oTMin", jobCardView.OTMin);
                Command.Parameters.AddWithValue("@status", jobCardView.Status);
                Command.Parameters.AddWithValue("@pCnt", jobCardView.PCnt);
                Command.Parameters.AddWithValue("@remark", jobCardView.Remark);
                Command.Parameters.AddWithValue("@sftEmp", jobCardView.SftEmp);
                Command.Parameters.AddWithValue("@actIn", jobCardView.ActIn);
                Command.Parameters.AddWithValue("@actOut", jobCardView.ActOut);
                Command.Parameters.AddWithValue("@lnOut", jobCardView.LnOut);
                Command.Parameters.AddWithValue("@lnBk", jobCardView.LnBk);
                Command.Parameters.AddWithValue("@lnLtHr", jobCardView.LnLtHr);
                Command.Parameters.AddWithValue("@eOut", jobCardView.EOut);
                Command.Parameters.AddWithValue("@eOHr", jobCardView.EOHr);
                Command.Parameters.AddWithValue("@actOT", jobCardView.ActOT);
                Command.Parameters.AddWithValue("@extOT", jobCardView.ExtOT);
                Command.Parameters.AddWithValue("@dedOT", jobCardView.DedOT);
                Command.Parameters.AddWithValue("@oTRem", jobCardView.OTRem);
                Command.Parameters.AddWithValue("@pnc", jobCardView.Pnc);
                Command.Parameters.AddWithValue("@fID", jobCardView.FID);
                Command.Parameters.AddWithValue("@n1", jobCardView.N1);
                Command.Parameters.AddWithValue("@n2", jobCardView.N2);
                Command.Parameters.AddWithValue("@s1", jobCardView.S1);
                Command.Parameters.AddWithValue("@s2", jobCardView.S2);
                Command.Parameters.AddWithValue("@d1", jobCardView.D1);
                Command.Parameters.AddWithValue("@d2", jobCardView.D2);
                Command.Parameters.AddWithValue("@sex", jobCardView.Sex);
                Command.Parameters.AddWithValue("@compNameBan", jobCardView.CompNameBan);
                Command.Parameters.AddWithValue("@fromDate", jobCardView.FromDate);
                Command.Parameters.AddWithValue("@toDate", jobCardView.ToDate);
                Command.Parameters.AddWithValue("@p", jobCardView.P);
                Command.Parameters.AddWithValue("@a", jobCardView.A);
                Command.Parameters.AddWithValue("@l", jobCardView.L);
                Command.Parameters.AddWithValue("@hD", jobCardView.HD);
                Command.Parameters.AddWithValue("@wHD", jobCardView.WHD);
                Command.Parameters.AddWithValue("@cL", jobCardView.CL);
                Command.Parameters.AddWithValue("@sL", jobCardView.SL);
                Command.Parameters.AddWithValue("@eL", jobCardView.EL);
                Command.Parameters.AddWithValue("@expr1", jobCardView.Expr1);
                Command.Parameters.AddWithValue("@mD", jobCardView.MD);
                Command.Parameters.AddWithValue("@wD", jobCardView.WD);
                Command.Parameters.AddWithValue("@totalLeave", jobCardView.TotalLeave);

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

        public async Task<Alert> Delete(string companyName, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "DELETE JobCardView WHERE CompanyName = @companyName";
                }
                else
                {
                    Query = "DELETE JobCardView WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@companyName", companyName);

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
                    Query = "SELECT 1 FROM JobCardView";
                }
                else
                {
                    Query = "SELECT 1 FROM JobCardView WHERE " + condition;
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

        public async Task<JobCardView> GetJobCardView(string companyName, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM JobCardView WHERE CompanyName = @companyName";
                }
                else
                {
                    Query = "SELECT * FROM JobCardView WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@companyName", companyName);
                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                JobCardView jobCardView = new JobCardView();
                while (Reader.Read())
                {
                    jobCardView.CompanyName = Reader["CompanyName"].ToString();
                    jobCardView.SN = (decimal)Reader["SN"];
                    jobCardView.DepartmentName = Reader["DepartmentName"].ToString();
                    jobCardView.DesignationName = Reader["DesignationName"].ToString();
                    jobCardView.EmployeeName = Reader["EmployeeName"].ToString();
                    jobCardView.ShiftName = Reader["ShiftName"].ToString();
                    jobCardView.ShiftType = Reader["ShiftType"].ToString();
                    jobCardView.SectionName = Reader["SectionName"].ToString();
                    jobCardView.SalarySectionName = Reader["SalarySectionName"].ToString();
                    jobCardView.AttendanceId = (int)Reader["AttendanceId"];
                    jobCardView.EmployeeId = Reader["EmployeeId"].ToString();
                    jobCardView.CardId = Reader["CardId"].ToString();
                    jobCardView.DepartmentId = (int)Reader["DepartmentId"];
                    jobCardView.SectionId = (int)Reader["SectionId"];
                    jobCardView.Expr6 = (int)Reader["Expr6"];
                    jobCardView.DesignationId = (int)Reader["DesignationId"];
                    jobCardView.CompanyId = (int)Reader["CompanyId"];
                    jobCardView.AttendanceDate = (DateTime)Reader["AttendanceDate"];
                    jobCardView.TimeIn = (DateTime)Reader["TimeIn"];
                    jobCardView.TimeOut = (DateTime)Reader["TimeOut"];
                    jobCardView.ShiftDetailId = (int)Reader["ShiftDetailId"];
                    jobCardView.Late = (DateTime)Reader["Late"];
                    jobCardView.ShiftIn = (DateTime)Reader["ShiftIn"];
                    jobCardView.ShiftOut = (DateTime)Reader["ShiftOut"];
                    jobCardView.ShiftLate = (DateTime)Reader["ShiftLate"];
                    jobCardView.ShiftLunchIn = (DateTime)Reader["ShiftLunchIn"];
                    jobCardView.ShiftLunchOut = (DateTime)Reader["ShiftLunchOut"];
                    jobCardView.ShiftLunchLate = (DateTime)Reader["ShiftLunchLate"];
                    jobCardView.ShiftLunchHr = (DateTime)Reader["ShiftLunchHr"];
                    jobCardView.DutyHr = (DateTime)Reader["DutyHr"];
                    jobCardView.WorkHr = (decimal)Reader["WorkHr"];
                    jobCardView.LateHr = (decimal)Reader["LateHr"];
                    jobCardView.OT = (DateTime)Reader["OT"];
                    jobCardView.OTHr = (decimal)Reader["OTHr"];
                    jobCardView.OTMin = (decimal)Reader["OTMin"];
                    jobCardView.Status = Reader["Status"].ToString();
                    jobCardView.PCnt = (decimal)Reader["PCnt"];
                    jobCardView.Remark = Reader["Remark"].ToString();
                    jobCardView.SftEmp = Reader["SftEmp"].ToString();
                    jobCardView.ActIn = (DateTime)Reader["ActIn"];
                    jobCardView.ActOut = (DateTime)Reader["ActOut"];
                    jobCardView.LnOut = (DateTime)Reader["LnOut"];
                    jobCardView.LnBk = (DateTime)Reader["LnBk"];
                    jobCardView.LnLtHr = (decimal)Reader["LnLtHr"];
                    jobCardView.EOut = (DateTime)Reader["EOut"];
                    jobCardView.EOHr = (decimal)Reader["EOHr"];
                    jobCardView.ActOT = (decimal)Reader["ActOT"];
                    jobCardView.ExtOT = (decimal)Reader["ExtOT"];
                    jobCardView.DedOT = (decimal)Reader["DedOT"];
                    jobCardView.OTRem = Reader["OTRem"].ToString();
                    jobCardView.Pnc = (decimal)Reader["Pnc"];
                    jobCardView.FID = Reader["FID"].ToString();
                    jobCardView.N1 = (decimal)Reader["N1"];
                    jobCardView.N2 = (decimal)Reader["N2"];
                    jobCardView.S1 = Reader["S1"].ToString();
                    jobCardView.S2 = Reader["S2"].ToString();
                    jobCardView.D1 = (DateTime)Reader["D1"];
                    jobCardView.D2 = (DateTime)Reader["D2"];
                    jobCardView.Sex = Reader["Sex"].ToString();
                    jobCardView.CompNameBan = Reader["CompNameBan"].ToString();
                    jobCardView.FromDate = (DateTime)Reader["FromDate"];
                    jobCardView.ToDate = (DateTime)Reader["ToDate"];
                    jobCardView.P = (decimal)Reader["P"];
                    jobCardView.A = (decimal)Reader["A"];
                    jobCardView.L = (decimal)Reader["L"];
                    jobCardView.HD = (decimal)Reader["HD"];
                    jobCardView.WHD = (decimal)Reader["WHD"];
                    jobCardView.CL = (decimal)Reader["CL"];
                    jobCardView.SL = (decimal)Reader["SL"];
                    jobCardView.EL = (decimal)Reader["EL"];
                    jobCardView.Expr1 = (decimal)Reader["Expr1"];
                    jobCardView.MD = (decimal)Reader["MD"];
                    jobCardView.WD = (decimal)Reader["WD"];
                    jobCardView.TotalLeave = (decimal)Reader["TotalLeave"];
                }
                Reader.Close();
                ConnectionClose();
                return jobCardView;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get JobCardView\n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<List<JobCardView>> GetJobCardViewList(string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM JobCardView";
                }
                else
                {
                    Query = "SELECT * FROM JobCardView WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<JobCardView> jobCardViewList = new List<JobCardView>();
                while (Reader.Read())
                {
                    JobCardView jobCardView = new JobCardView();

                    jobCardView.CompanyName = Reader["CompanyName"].ToString();
                    jobCardView.SN = (decimal)Reader["SN"];
                    jobCardView.DepartmentName = Reader["DepartmentName"].ToString();
                    jobCardView.DesignationName = Reader["DesignationName"].ToString();
                    jobCardView.EmployeeName = Reader["EmployeeName"].ToString();
                    jobCardView.ShiftName = Reader["ShiftName"].ToString();
                    jobCardView.ShiftType = Reader["ShiftType"].ToString();
                    jobCardView.SectionName = Reader["SectionName"].ToString();
                    jobCardView.SalarySectionName = Reader["SalarySectionName"].ToString();
                    jobCardView.AttendanceId = (int)Reader["AttendanceId"];
                    jobCardView.EmployeeId = Reader["EmployeeId"].ToString();
                    jobCardView.CardId = Reader["CardId"].ToString();
                    jobCardView.DepartmentId = (int)Reader["DepartmentId"];
                    jobCardView.SectionId = (int)Reader["SectionId"];
                    jobCardView.Expr6 = (int)Reader["Expr6"];
                    jobCardView.DesignationId = (int)Reader["DesignationId"];
                    jobCardView.CompanyId = (int)Reader["CompanyId"];
                    jobCardView.AttendanceDate = (DateTime)Reader["AttendanceDate"];
                    jobCardView.TimeIn = (DateTime)Reader["TimeIn"];
                    jobCardView.TimeOut = (DateTime)Reader["TimeOut"];
                    jobCardView.ShiftDetailId = (int)Reader["ShiftDetailId"];
                    jobCardView.Late = (DateTime)Reader["Late"];
                    jobCardView.ShiftIn = (DateTime)Reader["ShiftIn"];
                    jobCardView.ShiftOut = (DateTime)Reader["ShiftOut"];
                    jobCardView.ShiftLate = (DateTime)Reader["ShiftLate"];
                    jobCardView.ShiftLunchIn = (DateTime)Reader["ShiftLunchIn"];
                    jobCardView.ShiftLunchOut = (DateTime)Reader["ShiftLunchOut"];
                    jobCardView.ShiftLunchLate = (DateTime)Reader["ShiftLunchLate"];
                    jobCardView.ShiftLunchHr = (DateTime)Reader["ShiftLunchHr"];
                    jobCardView.DutyHr = (DateTime)Reader["DutyHr"];
                    jobCardView.WorkHr = (decimal)Reader["WorkHr"];
                    jobCardView.LateHr = (decimal)Reader["LateHr"];
                    jobCardView.OT = (DateTime)Reader["OT"];
                    jobCardView.OTHr = (decimal)Reader["OTHr"];
                    jobCardView.OTMin = (decimal)Reader["OTMin"];
                    jobCardView.Status = Reader["Status"].ToString();
                    jobCardView.PCnt = (decimal)Reader["PCnt"];
                    jobCardView.Remark = Reader["Remark"].ToString();
                    jobCardView.SftEmp = Reader["SftEmp"].ToString();
                    jobCardView.ActIn = (DateTime)Reader["ActIn"];
                    jobCardView.ActOut = (DateTime)Reader["ActOut"];
                    jobCardView.LnOut = (DateTime)Reader["LnOut"];
                    jobCardView.LnBk = (DateTime)Reader["LnBk"];
                    jobCardView.LnLtHr = (decimal)Reader["LnLtHr"];
                    jobCardView.EOut = (DateTime)Reader["EOut"];
                    jobCardView.EOHr = (decimal)Reader["EOHr"];
                    jobCardView.ActOT = (decimal)Reader["ActOT"];
                    jobCardView.ExtOT = (decimal)Reader["ExtOT"];
                    jobCardView.DedOT = (decimal)Reader["DedOT"];
                    jobCardView.OTRem = Reader["OTRem"].ToString();
                    jobCardView.Pnc = (decimal)Reader["Pnc"];
                    jobCardView.FID = Reader["FID"].ToString();
                    jobCardView.N1 = (decimal)Reader["N1"];
                    jobCardView.N2 = (decimal)Reader["N2"];
                    jobCardView.S1 = Reader["S1"].ToString();
                    jobCardView.S2 = Reader["S2"].ToString();
                    jobCardView.D1 = (DateTime)Reader["D1"];
                    jobCardView.D2 = (DateTime)Reader["D2"];
                    jobCardView.Sex = Reader["Sex"].ToString();
                    jobCardView.CompNameBan = Reader["CompNameBan"].ToString();
                    jobCardView.FromDate = (DateTime)Reader["FromDate"];
                    jobCardView.ToDate = (DateTime)Reader["ToDate"];
                    jobCardView.P = (decimal)Reader["P"];
                    jobCardView.A = (decimal)Reader["A"];
                    jobCardView.L = (decimal)Reader["L"];
                    jobCardView.HD = (decimal)Reader["HD"];
                    jobCardView.WHD = (decimal)Reader["WHD"];
                    jobCardView.CL = (decimal)Reader["CL"];
                    jobCardView.SL = (decimal)Reader["SL"];
                    jobCardView.EL = (decimal)Reader["EL"];
                    jobCardView.Expr1 = (decimal)Reader["Expr1"];
                    jobCardView.MD = (decimal)Reader["MD"];
                    jobCardView.WD = (decimal)Reader["WD"];
                    jobCardView.TotalLeave = (decimal)Reader["TotalLeave"];

                    jobCardViewList.Add(jobCardView);
                }
                Reader.Close();
                ConnectionClose();
                return jobCardViewList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get JobCardView List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<List<JobCardView>> GetJobCardViewListMinCol(string columns, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT " + columns + " FROM JobCardView";
                }
                else
                {
                    Query = "SELECT " + columns + " FROM JobCardView WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<JobCardView> jobCardViewList = new List<JobCardView>();
                while (Reader.Read())
                {
                    JobCardView jobCardView = new JobCardView();

                    SkipOnError(() => jobCardView.CompanyName = Reader["CompanyName"].ToString());
                    SkipOnError(() => jobCardView.SN = (decimal)Reader["SN"]);
                    SkipOnError(() => jobCardView.DepartmentName = Reader["DepartmentName"].ToString());
                    SkipOnError(() => jobCardView.DesignationName = Reader["DesignationName"].ToString());
                    SkipOnError(() => jobCardView.EmployeeName = Reader["EmployeeName"].ToString());
                    SkipOnError(() => jobCardView.ShiftName = Reader["ShiftName"].ToString());
                    SkipOnError(() => jobCardView.ShiftType = Reader["ShiftType"].ToString());
                    SkipOnError(() => jobCardView.SectionName = Reader["SectionName"].ToString());
                    SkipOnError(() => jobCardView.SalarySectionName = Reader["SalarySectionName"].ToString());
                    SkipOnError(() => jobCardView.AttendanceId = (int)Reader["AttendanceId"]);
                    SkipOnError(() => jobCardView.EmployeeId = Reader["EmployeeId"].ToString());
                    SkipOnError(() => jobCardView.CardId = Reader["CardId"].ToString());
                    SkipOnError(() => jobCardView.DepartmentId = (int)Reader["DepartmentId"]);
                    SkipOnError(() => jobCardView.SectionId = (int)Reader["SectionId"]);
                    SkipOnError(() => jobCardView.Expr6 = (int)Reader["Expr6"]);
                    SkipOnError(() => jobCardView.DesignationId = (int)Reader["DesignationId"]);
                    SkipOnError(() => jobCardView.CompanyId = (int)Reader["CompanyId"]);
                    SkipOnError(() => jobCardView.AttendanceDate = (DateTime)Reader["AttendanceDate"]);
                    SkipOnError(() => jobCardView.TimeIn = (DateTime)Reader["TimeIn"]);
                    SkipOnError(() => jobCardView.TimeOut = (DateTime)Reader["TimeOut"]);
                    SkipOnError(() => jobCardView.ShiftDetailId = (int)Reader["ShiftDetailId"]);
                    SkipOnError(() => jobCardView.Late = (DateTime)Reader["Late"]);
                    SkipOnError(() => jobCardView.ShiftIn = (DateTime)Reader["ShiftIn"]);
                    SkipOnError(() => jobCardView.ShiftOut = (DateTime)Reader["ShiftOut"]);
                    SkipOnError(() => jobCardView.ShiftLate = (DateTime)Reader["ShiftLate"]);
                    SkipOnError(() => jobCardView.ShiftLunchIn = (DateTime)Reader["ShiftLunchIn"]);
                    SkipOnError(() => jobCardView.ShiftLunchOut = (DateTime)Reader["ShiftLunchOut"]);
                    SkipOnError(() => jobCardView.ShiftLunchLate = (DateTime)Reader["ShiftLunchLate"]);
                    SkipOnError(() => jobCardView.ShiftLunchHr = (DateTime)Reader["ShiftLunchHr"]);
                    SkipOnError(() => jobCardView.DutyHr = (DateTime)Reader["DutyHr"]);
                    SkipOnError(() => jobCardView.WorkHr = (decimal)Reader["WorkHr"]);
                    SkipOnError(() => jobCardView.LateHr = (decimal)Reader["LateHr"]);
                    SkipOnError(() => jobCardView.OT = (DateTime)Reader["OT"]);
                    SkipOnError(() => jobCardView.OTHr = (decimal)Reader["OTHr"]);
                    SkipOnError(() => jobCardView.OTMin = (decimal)Reader["OTMin"]);
                    SkipOnError(() => jobCardView.Status = Reader["Status"].ToString());
                    SkipOnError(() => jobCardView.PCnt = (decimal)Reader["PCnt"]);
                    SkipOnError(() => jobCardView.Remark = Reader["Remark"].ToString());
                    SkipOnError(() => jobCardView.SftEmp = Reader["SftEmp"].ToString());
                    SkipOnError(() => jobCardView.ActIn = (DateTime)Reader["ActIn"]);
                    SkipOnError(() => jobCardView.ActOut = (DateTime)Reader["ActOut"]);
                    SkipOnError(() => jobCardView.LnOut = (DateTime)Reader["LnOut"]);
                    SkipOnError(() => jobCardView.LnBk = (DateTime)Reader["LnBk"]);
                    SkipOnError(() => jobCardView.LnLtHr = (decimal)Reader["LnLtHr"]);
                    SkipOnError(() => jobCardView.EOut = (DateTime)Reader["EOut"]);
                    SkipOnError(() => jobCardView.EOHr = (decimal)Reader["EOHr"]);
                    SkipOnError(() => jobCardView.ActOT = (decimal)Reader["ActOT"]);
                    SkipOnError(() => jobCardView.ExtOT = (decimal)Reader["ExtOT"]);
                    SkipOnError(() => jobCardView.DedOT = (decimal)Reader["DedOT"]);
                    SkipOnError(() => jobCardView.OTRem = Reader["OTRem"].ToString());
                    SkipOnError(() => jobCardView.Pnc = (decimal)Reader["Pnc"]);
                    SkipOnError(() => jobCardView.FID = Reader["FID"].ToString());
                    SkipOnError(() => jobCardView.N1 = (decimal)Reader["N1"]);
                    SkipOnError(() => jobCardView.N2 = (decimal)Reader["N2"]);
                    SkipOnError(() => jobCardView.S1 = Reader["S1"].ToString());
                    SkipOnError(() => jobCardView.S2 = Reader["S2"].ToString());
                    SkipOnError(() => jobCardView.D1 = (DateTime)Reader["D1"]);
                    SkipOnError(() => jobCardView.D2 = (DateTime)Reader["D2"]);
                    SkipOnError(() => jobCardView.Sex = Reader["Sex"].ToString());
                    SkipOnError(() => jobCardView.CompNameBan = Reader["CompNameBan"].ToString());
                    SkipOnError(() => jobCardView.FromDate = (DateTime)Reader["FromDate"]);
                    SkipOnError(() => jobCardView.ToDate = (DateTime)Reader["ToDate"]);
                    SkipOnError(() => jobCardView.P = (decimal)Reader["P"]);
                    SkipOnError(() => jobCardView.A = (decimal)Reader["A"]);
                    SkipOnError(() => jobCardView.L = (decimal)Reader["L"]);
                    SkipOnError(() => jobCardView.HD = (decimal)Reader["HD"]);
                    SkipOnError(() => jobCardView.WHD = (decimal)Reader["WHD"]);
                    SkipOnError(() => jobCardView.CL = (decimal)Reader["CL"]);
                    SkipOnError(() => jobCardView.SL = (decimal)Reader["SL"]);
                    SkipOnError(() => jobCardView.EL = (decimal)Reader["EL"]);
                    SkipOnError(() => jobCardView.Expr1 = (decimal)Reader["Expr1"]);
                    SkipOnError(() => jobCardView.MD = (decimal)Reader["MD"]);
                    SkipOnError(() => jobCardView.WD = (decimal)Reader["WD"]);
                    SkipOnError(() => jobCardView.TotalLeave = (decimal)Reader["TotalLeave"]);

                    jobCardViewList.Add(jobCardView);
                }
                Reader.Close();
                ConnectionClose();
                return jobCardViewList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get JobCardView List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }



        public async Task<List<JobCardView>> GetEmpReport(DateTime? fromDate = null, DateTime? toDate = null)
        {
            try
            {
                if (fromDate == null && toDate == null)
                {
                    Query = "SELECT * FROM JobCardView order by SN";
                }
                else
                {
                    Query = $"SELECT * FROM JobCardView WHERE  AttendanceDate between '{fromDate}' and '{toDate}' order by sn asc,AttendanceDate asc ";
                }
                Command = new SqlCommand(Query, Connection);
                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();
                List<JobCardView> jobCardViewList = new List<JobCardView>();
                while (Reader.Read())
                {
                    JobCardView jobCardView = new JobCardView();
                    jobCardView.CompanyName = Reader["CompanyName"].ToString();
                    jobCardView.SN = (decimal)Reader["SN"];
                    jobCardView.DepartmentName = Reader["DepartmentName"].ToString();
                    jobCardView.DesignationName = Reader["DesignationName"].ToString();
                    jobCardView.EmployeeName = Reader["EmployeeName"].ToString();
                    jobCardView.ShiftName = Reader["ShiftName"].ToString();
                    jobCardView.ShiftType = Reader["ShiftType"].ToString();
                    jobCardView.SectionName = Reader["SectionName"].ToString();
                    jobCardView.SalarySectionName = Reader["SalarySectionName"].ToString();
                    jobCardView.AttendanceId = (int)Reader["AttendanceId"];
                    jobCardView.EmployeeId = Reader["EmployeeId"].ToString();
                    jobCardView.CardId = Reader["CardId"].ToString();
                    jobCardView.DepartmentId = (int)Reader["DepartmentId"];
                    jobCardView.SectionId = (int)Reader["SectionId"];
                    jobCardView.Expr6 = (int)Reader["Expr6"];
                    jobCardView.DesignationId = (int)Reader["DesignationId"];
                    jobCardView.CompanyId = (int)Reader["CompanyId"];
                    jobCardView.AttendanceDate = (DateTime)Reader["AttendanceDate"];
                    jobCardView.TimeIn = (DateTime)Reader["TimeIn"];
                    jobCardView.TimeOut = (DateTime)Reader["TimeOut"];
                    jobCardView.ShiftDetailId = (int)Reader["ShiftDetailId"];
                    jobCardView.Late = (DateTime)Reader["Late"];
                    jobCardView.ShiftIn = (DateTime)Reader["ShiftIn"];
                    jobCardView.ShiftOut = (DateTime)Reader["ShiftOut"];
                    jobCardView.ShiftLate = (DateTime)Reader["ShiftLate"];
                    jobCardView.ShiftLunchIn = (DateTime)Reader["ShiftLunchIn"];
                    jobCardView.ShiftLunchOut = (DateTime)Reader["ShiftLunchOut"];
                    jobCardView.ShiftLunchLate = (DateTime)Reader["ShiftLunchLate"];
                    jobCardView.ShiftLunchHr = (DateTime)Reader["ShiftLunchHr"];
                    jobCardView.DutyHr = (DateTime)Reader["DutyHr"];
                    jobCardView.WorkHr = (decimal)Reader["WorkHr"];
                    jobCardView.LateHr = (decimal)Reader["LateHr"];
                    jobCardView.OT = (DateTime)Reader["OT"];
                    jobCardView.OTHr = (decimal)Reader["OTHr"];
                    jobCardView.OTMin = (decimal)Reader["OTMin"];
                    jobCardView.Status = Reader["Status"].ToString();
                    jobCardView.PCnt = (decimal)Reader["PCnt"];
                    jobCardView.Remark = Reader["Remark"].ToString();
                    jobCardView.SftEmp = Reader["SftEmp"].ToString();
                    jobCardView.ActIn = (DateTime)Reader["ActIn"];
                    jobCardView.ActOut = (DateTime)Reader["ActOut"];
                    jobCardView.LnOut = (DateTime)Reader["LnOut"];
                    jobCardView.LnBk = (DateTime)Reader["LnBk"];
                    jobCardView.LnLtHr = (decimal)Reader["LnLtHr"];
                    jobCardView.EOut = (DateTime)Reader["EOut"];
                    jobCardView.EOHr = (decimal)Reader["EOHr"];
                    jobCardView.ActOT = (decimal)Reader["ActOT"];
                    jobCardView.ExtOT = (decimal)Reader["ExtOT"];
                    jobCardView.DedOT = (decimal)Reader["DedOT"];
                    jobCardView.OTRem = Reader["OTRem"].ToString();
                    jobCardView.Pnc = (decimal)Reader["Pnc"];
                    jobCardView.FID = Reader["FID"].ToString();
                    jobCardView.N1 = (decimal)Reader["N1"];
                    jobCardView.N2 = (decimal)Reader["N2"];
                    jobCardView.S1 = Reader["S1"].ToString();
                    jobCardView.S2 = Reader["S2"].ToString();
                    jobCardView.D1 = (DateTime)Reader["D1"];
                    jobCardView.D2 = (DateTime)Reader["D2"];
                    jobCardView.Sex = Reader["Sex"].ToString();
                    jobCardView.CompNameBan = Reader["CompNameBan"].ToString();
                    jobCardView.FromDate = (DateTime)Reader["FromDate"];
                    jobCardView.ToDate = (DateTime)Reader["ToDate"];
                    jobCardView.P = (decimal)Reader["P"];
                    jobCardView.A = (decimal)Reader["A"];
                    jobCardView.L = (decimal)Reader["L"];
                    jobCardView.HD = (decimal)Reader["HD"];
                    jobCardView.WHD = (decimal)Reader["WHD"];
                    jobCardView.CL = (decimal)Reader["CL"];
                    jobCardView.SL = (decimal)Reader["SL"];
                    jobCardView.EL = (decimal)Reader["EL"];
                    jobCardView.Expr1 = (decimal)Reader["Expr1"];
                    jobCardView.MD = (decimal)Reader["MD"];
                    jobCardView.WD = (decimal)Reader["WD"];
                    jobCardView.TotalLeave = (decimal)Reader["TotalLeave"];
                    jobCardViewList.Add(jobCardView);
                }
                Reader.Close();
                ConnectionClose();
                return jobCardViewList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get JobCardView List \n" + exception.Message);
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
