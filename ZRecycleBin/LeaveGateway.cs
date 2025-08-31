using AttendancePayrollWebServerApp.Models;
using AttendancePayrollWebServerApp.Pages.CategoryAndItems;
using AttendancePayrollWebServerApp.Pages.Department;
using AttendancePayrollWebServerApp.Pages.Shift;
using AttendancePayrollWebServerApp.UtilityClass;
using System.Data.SqlClient;

namespace AttendancePayrollWebServerApp.Gateway
{
    public class LeaveGateway : Gateway
    {

        public async Task<Alert> Save(Leave leave, string existCondition = "")
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

                Query = "INSERT INTO Leaves (EmployeeId,LeaveApplyDate,ApplyFromDate,ApplyToDate,ApplyDays,LeaveType,Reason,IssuedFromDate,IssuedToDate,IssuedDays,IssuedRemarks,CLTotal,SLTotal,ELTotal,MLTotal,CLBalance,SLBalance,ELBalance,MLBalance,LeaveIssuedDate,AddedBy,AddedDate,EditBy,EditedDate) VALUES(@employeeId,@leaveApplyDate,@applyFromDate,@applyToDate,@applyDays,@leaveType,@reason,@issuedFromDate,@issuedToDate,@issuedDays,@issuedRemarks,@cLTotal,@sLTotal,@eLTotal,@mLTotal,@cLBalance,@sLBalance,@eLBalance,@mLBalance,@leaveIssuedDate,@addedBy,@addedDate,@editBy,@editedDate)";

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@leaveId", leave.LeaveId);
                Command.Parameters.AddWithValue("@employeeId", leave.EmployeeId);
                Command.Parameters.AddWithValue("@leaveApplyDate", leave.LeaveApplyDate);
                Command.Parameters.AddWithValue("@applyFromDate", leave.ApplyFromDate);
                Command.Parameters.AddWithValue("@applyToDate", leave.ApplyToDate);
                Command.Parameters.AddWithValue("@applyDays", leave.ApplyDays);
                Command.Parameters.AddWithValue("@leaveType", leave.LeaveType);
                Command.Parameters.AddWithValue("@reason", leave.Reason);
                Command.Parameters.AddWithValue("@issuedFromDate", leave.IssuedFromDate);
                Command.Parameters.AddWithValue("@issuedToDate", leave.IssuedToDate);
                Command.Parameters.AddWithValue("@issuedDays", leave.IssuedDays);
                Command.Parameters.AddWithValue("@issuedRemarks", leave.IssuedRemarks);
                Command.Parameters.AddWithValue("@cLTotal", leave.CLTotal);
                Command.Parameters.AddWithValue("@sLTotal", leave.SLTotal);
                Command.Parameters.AddWithValue("@eLTotal", leave.ELTotal);
                Command.Parameters.AddWithValue("@mLTotal", leave.MLTotal);
                Command.Parameters.AddWithValue("@cLBalance", leave.CLBalance);
                Command.Parameters.AddWithValue("@sLBalance", leave.SLBalance);
                Command.Parameters.AddWithValue("@eLBalance", leave.ELBalance);
                Command.Parameters.AddWithValue("@mLBalance", leave.MLBalance);
                Command.Parameters.AddWithValue("@leaveIssuedDate", leave.LeaveIssuedDate);
                Command.Parameters.AddWithValue("@addedBy", leave.AddedBy);
                Command.Parameters.AddWithValue("@addedDate", leave.AddedDate);
                Command.Parameters.AddWithValue("@editBy", leave.EditBy);
                Command.Parameters.AddWithValue("@editedDate", leave.EditedDate);

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

        public async Task<Alert> Edit(Leave leave, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "UPDATE Leaves SET EmployeeId=@employeeId,LeaveApplyDate=@leaveApplyDate,ApplyFromDate=@applyFromDate,ApplyToDate=@applyToDate,ApplyDays=@applyDays,LeaveType=@leaveType,Reason=@reason,IssuedFromDate=@issuedFromDate,IssuedToDate=@issuedToDate,IssuedDays=@issuedDays,IssuedRemarks=@issuedRemarks,CLTotal=@cLTotal,SLTotal=@sLTotal,ELTotal=@eLTotal,MLTotal=@mLTotal,CLBalance=@cLBalance,SLBalance=@sLBalance,ELBalance=@eLBalance,MLBalance=@mLBalance,LeaveIssuedDate=@leaveIssuedDate,AddedBy=@addedBy,AddedDate=@addedDate,EditBy=@editBy,EditedDate=@editedDate WHERE LeaveId = @leaveId";
                }
                else
                {
                    Query = "UPDATE Leaves SET EmployeeId=@employeeId,LeaveApplyDate=@leaveApplyDate,ApplyFromDate=@applyFromDate,ApplyToDate=@applyToDate,ApplyDays=@applyDays,LeaveType=@leaveType,Reason=@reason,IssuedFromDate=@issuedFromDate,IssuedToDate=@issuedToDate,IssuedDays=@issuedDays,IssuedRemarks=@issuedRemarks,CLTotal=@cLTotal,SLTotal=@sLTotal,ELTotal=@eLTotal,MLTotal=@mLTotal,CLBalance=@cLBalance,SLBalance=@sLBalance,ELBalance=@eLBalance,MLBalance=@mLBalance,LeaveIssuedDate=@leaveIssuedDate,AddedBy=@addedBy,AddedDate=@addedDate,EditBy=@editBy,EditedDate=@editedDate WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@leaveId", leave.LeaveId);
                Command.Parameters.AddWithValue("@employeeId", leave.EmployeeId);
                Command.Parameters.AddWithValue("@leaveApplyDate", leave.LeaveApplyDate);
                Command.Parameters.AddWithValue("@applyFromDate", leave.ApplyFromDate);
                Command.Parameters.AddWithValue("@applyToDate", leave.ApplyToDate);
                Command.Parameters.AddWithValue("@applyDays", leave.ApplyDays);
                Command.Parameters.AddWithValue("@leaveType", leave.LeaveType);
                Command.Parameters.AddWithValue("@reason", leave.Reason);
                Command.Parameters.AddWithValue("@issuedFromDate", leave.IssuedFromDate);
                Command.Parameters.AddWithValue("@issuedToDate", leave.IssuedToDate);
                Command.Parameters.AddWithValue("@issuedDays", leave.IssuedDays);
                Command.Parameters.AddWithValue("@issuedRemarks", leave.IssuedRemarks);
                Command.Parameters.AddWithValue("@cLTotal", leave.CLTotal);
                Command.Parameters.AddWithValue("@sLTotal", leave.SLTotal);
                Command.Parameters.AddWithValue("@eLTotal", leave.ELTotal);
                Command.Parameters.AddWithValue("@mLTotal", leave.MLTotal);
                Command.Parameters.AddWithValue("@cLBalance", leave.CLBalance);
                Command.Parameters.AddWithValue("@sLBalance", leave.SLBalance);
                Command.Parameters.AddWithValue("@eLBalance", leave.ELBalance);
                Command.Parameters.AddWithValue("@mLBalance", leave.MLBalance);
                Command.Parameters.AddWithValue("@leaveIssuedDate", leave.LeaveIssuedDate);
                Command.Parameters.AddWithValue("@addedBy", leave.AddedBy);
                Command.Parameters.AddWithValue("@addedDate", leave.AddedDate);
                Command.Parameters.AddWithValue("@editBy", leave.EditBy);
                Command.Parameters.AddWithValue("@editedDate", leave.EditedDate);

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

        public async Task<Alert> Delete(int leaveId, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "DELETE Leaves WHERE LeaveId = @leaveId";
                }
                else
                {
                    Query = "DELETE Leaves WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@leaveId", leaveId);

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
                    Query = "SELECT 1 FROM Leaves";
                }
                else
                {
                    Query = "SELECT 1 FROM Leaves WHERE " + condition;
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

        public async Task<Leave> GetLeave(int leaveId, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM Leaves WHERE LeaveId = @leaveId";
                }
                else
                {
                    Query = "SELECT * FROM Leaves WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@leaveId", leaveId);
                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                Leave leave = new Leave();
                while (Reader.Read())
                {
                    leave.LeaveId = (int)Reader["LeaveId"];
                    leave.EmployeeId = Reader["EmployeeId"].ToString();
                    leave.LeaveApplyDate = (DateTime)Reader["LeaveApplyDate"];
                    leave.ApplyFromDate = (DateTime)Reader["ApplyFromDate"];
                    leave.ApplyToDate = (DateTime)Reader["ApplyToDate"];
                    leave.ApplyDays = (int)Reader["ApplyDays"];
                    leave.LeaveType = Reader["LeaveType"].ToString();
                    leave.Reason = Reader["Reason"].ToString();
                    leave.IssuedFromDate = (DateTime)Reader["IssuedFromDate"];
                    leave.IssuedToDate = (DateTime)Reader["IssuedToDate"];
                    leave.IssuedDays = (int)Reader["IssuedDays"];
                    leave.IssuedRemarks = Reader["IssuedRemarks"].ToString();
                    leave.CLTotal = (decimal)Reader["CLTotal"];
                    leave.SLTotal = (decimal)Reader["SLTotal"];
                    leave.ELTotal = (decimal)Reader["ELTotal"];
                    leave.MLTotal = (decimal)Reader["MLTotal"];
                    leave.CLBalance = (decimal)Reader["CLBalance"];
                    leave.SLBalance = (decimal)Reader["SLBalance"];
                    leave.ELBalance = (decimal)Reader["ELBalance"];
                    leave.MLBalance = (decimal)Reader["MLBalance"];
                    leave.LeaveIssuedDate = (DateTime)Reader["LeaveIssuedDate"];
                    leave.AddedBy = (int)Reader["AddedBy"];
                    leave.AddedDate = (DateTime)Reader["AddedDate"];
                    leave.EditBy = (int)Reader["EditBy"];
                    leave.EditedDate = (DateTime)Reader["EditedDate"];
                }
                Reader.Close();
                ConnectionClose();
                return leave;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get Leave\n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<List<Leave>> GetLeaveList(string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM Leaves";
                }
                else
                {
                    Query = "SELECT * FROM Leaves WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<Leave> leaveList = new List<Leave>();
                while (Reader.Read())
                {
                    Leave leave = new Leave();

                    leave.LeaveId = (int)Reader["LeaveId"];
                    leave.EmployeeId = Reader["EmployeeId"].ToString();
                    leave.LeaveApplyDate = (DateTime)Reader["LeaveApplyDate"];
                    leave.ApplyFromDate = (DateTime)Reader["ApplyFromDate"];
                    leave.ApplyToDate = (DateTime)Reader["ApplyToDate"];
                    leave.ApplyDays = (int)Reader["ApplyDays"];
                    leave.LeaveType = Reader["LeaveType"].ToString();
                    leave.Reason = Reader["Reason"].ToString();
                    leave.IssuedFromDate = (DateTime)Reader["IssuedFromDate"];
                    leave.IssuedToDate = (DateTime)Reader["IssuedToDate"];
                    leave.IssuedDays = (int)Reader["IssuedDays"];
                    leave.IssuedRemarks = Reader["IssuedRemarks"].ToString();
                    leave.CLTotal = (decimal)Reader["CLTotal"];
                    leave.SLTotal = (decimal)Reader["SLTotal"];
                    leave.ELTotal = (decimal)Reader["ELTotal"];
                    leave.MLTotal = (decimal)Reader["MLTotal"];
                    leave.CLBalance = (decimal)Reader["CLBalance"];
                    leave.SLBalance = (decimal)Reader["SLBalance"];
                    leave.ELBalance = (decimal)Reader["ELBalance"];
                    leave.MLBalance = (decimal)Reader["MLBalance"];
                    leave.LeaveIssuedDate = (DateTime)Reader["LeaveIssuedDate"];
                    leave.AddedBy = (int)Reader["AddedBy"];
                    leave.AddedDate = (DateTime)Reader["AddedDate"];
                    leave.EditBy = (int)Reader["EditBy"];
                    leave.EditedDate = (DateTime)Reader["EditedDate"];

                    leaveList.Add(leave);
                }
                Reader.Close();
                ConnectionClose();
                return leaveList;
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

        public async Task<List<Leave>> GetLeaveListMinCol(string columns, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT " + columns + " FROM Leaves";
                }
                else
                {
                    Query = "SELECT " + columns + " FROM Leaves WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<Leave> leaveList = new List<Leave>();
                while (Reader.Read())
                {
                    Leave leave = new Leave();

                    SkipOnError(() => leave.LeaveId = (int)Reader["LeaveId"]);
                    SkipOnError(() => leave.EmployeeId = Reader["EmployeeId"].ToString());
                    SkipOnError(() => leave.LeaveApplyDate = (DateTime)Reader["LeaveApplyDate"]);
                    SkipOnError(() => leave.ApplyFromDate = (DateTime)Reader["ApplyFromDate"]);
                    SkipOnError(() => leave.ApplyToDate = (DateTime)Reader["ApplyToDate"]);
                    SkipOnError(() => leave.ApplyDays = (int)Reader["ApplyDays"]);
                    SkipOnError(() => leave.LeaveType = Reader["LeaveType"].ToString());
                    SkipOnError(() => leave.Reason = Reader["Reason"].ToString());
                    SkipOnError(() => leave.IssuedFromDate = (DateTime)Reader["IssuedFromDate"]);
                    SkipOnError(() => leave.IssuedToDate = (DateTime)Reader["IssuedToDate"]);
                    SkipOnError(() => leave.IssuedDays = (int)Reader["IssuedDays"]);
                    SkipOnError(() => leave.IssuedRemarks = Reader["IssuedRemarks"].ToString());
                    SkipOnError(() => leave.CLTotal = (decimal)Reader["CLTotal"]);
                    SkipOnError(() => leave.SLTotal = (decimal)Reader["SLTotal"]);
                    SkipOnError(() => leave.ELTotal = (decimal)Reader["ELTotal"]);
                    SkipOnError(() => leave.MLTotal = (decimal)Reader["MLTotal"]);
                    SkipOnError(() => leave.CLBalance = (decimal)Reader["CLBalance"]);
                    SkipOnError(() => leave.SLBalance = (decimal)Reader["SLBalance"]);
                    SkipOnError(() => leave.ELBalance = (decimal)Reader["ELBalance"]);
                    SkipOnError(() => leave.MLBalance = (decimal)Reader["MLBalance"]);
                    SkipOnError(() => leave.LeaveIssuedDate = (DateTime)Reader["LeaveIssuedDate"]);
                    SkipOnError(() => leave.AddedBy = (int)Reader["AddedBy"]);
                    SkipOnError(() => leave.AddedDate = (DateTime)Reader["AddedDate"]);
                    SkipOnError(() => leave.EditBy = (int)Reader["EditBy"]);
                    SkipOnError(() => leave.EditedDate = (DateTime)Reader["EditedDate"]);

                    leaveList.Add(leave);
                }
                Reader.Close();
                ConnectionClose();
                return leaveList;
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



        //**********************************************************************************//

        public async Task<int> SumIssuedDaysCL(string employeeId)
        {
            try
            {
                Query = "SELECT SUM(IssuedDays) FROM Leaves WHERE EmployeeId = @employeeId AND LeaveType ='CL'";
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@employeeId", employeeId);
               // Command.Parameters.AddWithValue("@leaveType", leaveType);
                ConnectionOpen();
                var result = await Command.ExecuteScalarAsync();
                ConnectionClose();

                if (result != DBNull.Value && result != null)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception exception)
            {
                throw new Exception($"Failed To Sum IssuedDays for CL\n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }



        public async Task<int> SumIssuedDaysSL(string employeeId)
        {
            try
            {
                Query = "SELECT SUM(IssuedDays) FROM Leaves WHERE EmployeeId = @employeeId AND LeaveType ='SL'";
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@employeeId", employeeId);
                // Command.Parameters.AddWithValue("@leaveType", leaveType);
                ConnectionOpen();
                var result = await Command.ExecuteScalarAsync();
                ConnectionClose();

                if (result != DBNull.Value && result != null)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception exception)
            {
                throw new Exception($"Failed To Sum IssuedDays for SL\n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }



        public async Task<int> SumIssuedDaysEL(string employeeId)
        {
            try
            {
                Query = "SELECT SUM(IssuedDays) FROM Leaves WHERE EmployeeId = @employeeId AND LeaveType ='EL'";
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@employeeId", employeeId);
                // Command.Parameters.AddWithValue("@leaveType", leaveType);
                ConnectionOpen();
                var result = await Command.ExecuteScalarAsync();
                ConnectionClose();

                if (result != DBNull.Value && result != null)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception exception)
            {
                throw new Exception($"Failed To Sum IssuedDays for EL\n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }



        public async Task<int> SumIssuedDaysML(string employeeId)
        {
            try
            {
                Query = "SELECT SUM(IssuedDays) FROM Leaves WHERE EmployeeId = @employeeId AND LeaveType ='ML'";
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@employeeId", employeeId);
                // Command.Parameters.AddWithValue("@leaveType", leaveType);
                ConnectionOpen();
                var result = await Command.ExecuteScalarAsync();
                ConnectionClose();

                if (result != DBNull.Value && result != null)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception exception)
            {
                throw new Exception($"Failed To Sum IssuedDays for ML\n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        //**********************************************************************************//







        public async Task<int> SumIssuedDays(string employeeId, string leaveType)
        {
            try
            {
                Query = "SELECT SUM(IssuedDays) FROM Leaves WHERE EmployeeId = @employeeId AND LeaveType = @leaveType";
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@employeeId", employeeId);
                Command.Parameters.AddWithValue("@leaveType", leaveType);
                ConnectionOpen();
                var result = await Command.ExecuteScalarAsync();
                ConnectionClose();

                if (result != DBNull.Value && result != null)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception exception)
            {
                throw new Exception($"Failed To Sum IssuedDays for {leaveType}\n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }






    }
}
