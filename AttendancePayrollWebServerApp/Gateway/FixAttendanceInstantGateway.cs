using AttendancePayrollWebServerApp.Models;
using AttendancePayrollWebServerApp.UtilityClass;
using System.Data.SqlClient;

namespace AttendancePayrollWebServerApp.Gateway
{
    public class FixAttendanceInstantGateway : Gateway
    {


        public async Task<Alert> Save(FixAttendanceInstant fixAttendanceInstant, string existCondition = "")
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

                Query = "INSERT INTO FixAttendanceInstant (AttendanceId,EmployeeId,AttendanceDate,FixType,TimeIn,TimeOut,OT,ShiftDetailId,ActualShiftDetailId,Status,Remarks,ActualTimeIn,ActualTimeOut,ActualOT,ActualStatus,ARemarks,UId,UName,PCName,FixDate) VALUES(@attendanceId,@employeeId,@attendanceDate,@fixType,@timeIn,@timeOut,@oT,@shiftDetailId,@actualShiftDetailId,@status,@remarks,@actualTimeIn,@actualTimeOut,@actualOT,@actualStatus,@aRemarks,@uId,@uName,@pCName,@fixDate)";

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@fixInstId", fixAttendanceInstant.FixInstId);
                Command.Parameters.AddWithValue("@attendanceId", fixAttendanceInstant.AttendanceId);
                Command.Parameters.AddWithValue("@employeeId", fixAttendanceInstant.EmployeeId);
                Command.Parameters.AddWithValue("@attendanceDate", fixAttendanceInstant.AttendanceDate);
                Command.Parameters.AddWithValue("@fixType", fixAttendanceInstant.FixType);
                Command.Parameters.AddWithValue("@timeIn", fixAttendanceInstant.TimeIn);
                Command.Parameters.AddWithValue("@timeOut", fixAttendanceInstant.TimeOut);
                Command.Parameters.AddWithValue("@oT", fixAttendanceInstant.OT);
                Command.Parameters.AddWithValue("@shiftDetailId", fixAttendanceInstant.ShiftDetailId);
                Command.Parameters.AddWithValue("@actualShiftDetailId", fixAttendanceInstant.ActualShiftDetailId);
                Command.Parameters.AddWithValue("@status", fixAttendanceInstant.Status);
                Command.Parameters.AddWithValue("@remarks", fixAttendanceInstant.Remarks);
                Command.Parameters.AddWithValue("@actualTimeIn", fixAttendanceInstant.ActualTimeIn);
                Command.Parameters.AddWithValue("@actualTimeOut", fixAttendanceInstant.ActualTimeOut);
                Command.Parameters.AddWithValue("@actualOT", fixAttendanceInstant.ActualOT);
                Command.Parameters.AddWithValue("@actualStatus", fixAttendanceInstant.ActualStatus);
                Command.Parameters.AddWithValue("@aRemarks", fixAttendanceInstant.ARemarks);
                Command.Parameters.AddWithValue("@uId", fixAttendanceInstant.UId);
                Command.Parameters.AddWithValue("@uName", fixAttendanceInstant.UName);
                Command.Parameters.AddWithValue("@pCName", fixAttendanceInstant.PCName);
                Command.Parameters.AddWithValue("@fixDate", fixAttendanceInstant.FixDate);

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



        public async Task<Alert> Edit(FixAttendanceInstant fixAttendanceInstant, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "UPDATE FixAttendanceInstant SET AttendanceId=@attendanceId,EmployeeId=@employeeId,AttendanceDate=@attendanceDate,FixType=@fixType,TimeIn=@timeIn,TimeOut=@timeOut,OT=@oT,ShiftDetailId=@shiftDetailId,ActualShiftDetailId=@actualShiftDetailId,Status=@status,Remarks=@remarks,ActualTimeIn=@actualTimeIn,ActualTimeOut=@actualTimeOut,ActualOT=@actualOT,ActualStatus=@actualStatus,ARemarks=@aRemarks,UId=@uId,UName=@uName,PCName=@pCName,FixDate=@fixDate WHERE FixInstId = @fixInstId";
                }
                else
                {
                    Query = "UPDATE FixAttendanceInstant SET AttendanceId=@attendanceId,EmployeeId=@employeeId,AttendanceDate=@attendanceDate,FixType=@fixType,TimeIn=@timeIn,TimeOut=@timeOut,OT=@oT,ShiftDetailId=@shiftDetailId,ActualShiftDetailId=@actualShiftDetailId,Status=@status,Remarks=@remarks,ActualTimeIn=@actualTimeIn,ActualTimeOut=@actualTimeOut,ActualOT=@actualOT,ActualStatus=@actualStatus,ARemarks=@aRemarks,UId=@uId,UName=@uName,PCName=@pCName,FixDate=@fixDate WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@fixInstId", fixAttendanceInstant.FixInstId);
                Command.Parameters.AddWithValue("@attendanceId", fixAttendanceInstant.AttendanceId);
                Command.Parameters.AddWithValue("@employeeId", fixAttendanceInstant.EmployeeId);
                Command.Parameters.AddWithValue("@attendanceDate", fixAttendanceInstant.AttendanceDate);
                Command.Parameters.AddWithValue("@fixType", fixAttendanceInstant.FixType);
                Command.Parameters.AddWithValue("@timeIn", fixAttendanceInstant.TimeIn);
                Command.Parameters.AddWithValue("@timeOut", fixAttendanceInstant.TimeOut);
                Command.Parameters.AddWithValue("@oT", fixAttendanceInstant.OT);
                Command.Parameters.AddWithValue("@shiftDetailId", fixAttendanceInstant.ShiftDetailId);
                Command.Parameters.AddWithValue("@actualShiftDetailId", fixAttendanceInstant.ActualShiftDetailId);
                Command.Parameters.AddWithValue("@status", fixAttendanceInstant.Status);
                Command.Parameters.AddWithValue("@remarks", fixAttendanceInstant.Remarks);
                Command.Parameters.AddWithValue("@actualTimeIn", fixAttendanceInstant.ActualTimeIn);
                Command.Parameters.AddWithValue("@actualTimeOut", fixAttendanceInstant.ActualTimeOut);
                Command.Parameters.AddWithValue("@actualOT", fixAttendanceInstant.ActualOT);
                Command.Parameters.AddWithValue("@actualStatus", fixAttendanceInstant.ActualStatus);
                Command.Parameters.AddWithValue("@aRemarks", fixAttendanceInstant.ARemarks);
                Command.Parameters.AddWithValue("@uId", fixAttendanceInstant.UId);
                Command.Parameters.AddWithValue("@uName", fixAttendanceInstant.UName);
                Command.Parameters.AddWithValue("@pCName", fixAttendanceInstant.PCName);
                Command.Parameters.AddWithValue("@fixDate", fixAttendanceInstant.FixDate);

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

        public async Task<Alert> Delete(int fixInstId, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "DELETE FixAttendanceInstant WHERE FixInstId = @fixInstId";
                }
                else
                {
                    Query = "DELETE FixAttendanceInstant WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@fixInstId", fixInstId);

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
                    Query = "SELECT 1 FROM FixAttendanceInstant";
                }
                else
                {
                    Query = "SELECT 1 FROM FixAttendanceInstant WHERE " + condition;
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

        public async Task<FixAttendanceInstant> GetFixAttendanceInstant(int fixInstId, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM FixAttendanceInstant WHERE FixInstId = @fixInstId";
                }
                else
                {
                    Query = "SELECT * FROM FixAttendanceInstant WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@fixInstId", fixInstId);
                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                FixAttendanceInstant fixAttendanceInstant = new FixAttendanceInstant();
                while (Reader.Read())
                {
                    fixAttendanceInstant.FixInstId = (int)Reader["FixInstId"];
                    fixAttendanceInstant.AttendanceId = (int)Reader["AttendanceId"];
                    fixAttendanceInstant.EmployeeId = Reader["EmployeeId"].ToString();
                    fixAttendanceInstant.AttendanceDate = (DateTime)Reader["AttendanceDate"];
                    fixAttendanceInstant.FixType = Reader["FixType"].ToString();
                    fixAttendanceInstant.TimeIn = (DateTime)Reader["TimeIn"];
                    fixAttendanceInstant.TimeOut = (DateTime)Reader["TimeOut"];
                    fixAttendanceInstant.OT = (DateTime)Reader["OT"];
                    fixAttendanceInstant.ShiftDetailId = (int)Reader["ShiftDetailId"];
                    fixAttendanceInstant.ActualShiftDetailId = (int)Reader["ActualShiftDetailId"];
                    fixAttendanceInstant.Status = Reader["Status"].ToString();
                    fixAttendanceInstant.Remarks = Reader["Remarks"].ToString();
                    fixAttendanceInstant.ActualTimeIn = (DateTime)Reader["ActualTimeIn"];
                    fixAttendanceInstant.ActualTimeOut = (DateTime)Reader["ActualTimeOut"];
                    fixAttendanceInstant.ActualOT = (DateTime)Reader["ActualOT"];
                    fixAttendanceInstant.ActualStatus = Reader["ActualStatus"].ToString();
                    fixAttendanceInstant.ARemarks = Reader["ARemarks"].ToString();
                    fixAttendanceInstant.UId = Reader["UId"].ToString();
                    fixAttendanceInstant.UName = Reader["UName"].ToString();
                    fixAttendanceInstant.PCName = Reader["PCName"].ToString();
                    fixAttendanceInstant.FixDate = (DateTime)Reader["FixDate"];
                }
                Reader.Close();
                ConnectionClose();
                return fixAttendanceInstant;
            }

            catch (Exception exception)
            {
                throw new Exception("Failed To Get FixAttendanceInstant\n" + exception.Message);
            }

            finally
            {
                ConnectionClose();
            }
        }


        public async Task<List<FixAttendanceInstant>> GetFixAttendanceInstantList(string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM FixAttendanceInstant";
                }
                else
                {
                    Query = "SELECT * FROM FixAttendanceInstant WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<FixAttendanceInstant> fixAttendanceInstantList = new List<FixAttendanceInstant>();
                while (Reader.Read())
                {
                    FixAttendanceInstant fixAttendanceInstant = new FixAttendanceInstant();

                    fixAttendanceInstant.FixInstId = (int)Reader["FixInstId"];
                    fixAttendanceInstant.AttendanceId = (int)Reader["AttendanceId"];
                    fixAttendanceInstant.EmployeeId = Reader["EmployeeId"].ToString();
                    fixAttendanceInstant.AttendanceDate = (DateTime)Reader["AttendanceDate"];
                    fixAttendanceInstant.FixType = Reader["FixType"].ToString();
                    fixAttendanceInstant.TimeIn = (DateTime)Reader["TimeIn"];
                    fixAttendanceInstant.TimeOut = (DateTime)Reader["TimeOut"];
                    fixAttendanceInstant.OT = (DateTime)Reader["OT"];
                    fixAttendanceInstant.ShiftDetailId = (int)Reader["ShiftDetailId"];
                    fixAttendanceInstant.ActualShiftDetailId = (int)Reader["ActualShiftDetailId"];
                    fixAttendanceInstant.Status = Reader["Status"].ToString();
                    fixAttendanceInstant.Remarks = Reader["Remarks"].ToString();
                    fixAttendanceInstant.ActualTimeIn = (DateTime)Reader["ActualTimeIn"];
                    fixAttendanceInstant.ActualTimeOut = (DateTime)Reader["ActualTimeOut"];
                    fixAttendanceInstant.ActualOT = (DateTime)Reader["ActualOT"];
                    fixAttendanceInstant.ActualStatus = Reader["ActualStatus"].ToString();
                    fixAttendanceInstant.ARemarks = Reader["ARemarks"].ToString();
                    fixAttendanceInstant.UId = Reader["UId"].ToString();
                    fixAttendanceInstant.UName = Reader["UName"].ToString();
                    fixAttendanceInstant.PCName = Reader["PCName"].ToString();
                    fixAttendanceInstant.FixDate = (DateTime)Reader["FixDate"];

                    fixAttendanceInstantList.Add(fixAttendanceInstant);
                }
                Reader.Close();
                ConnectionClose();
                return fixAttendanceInstantList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get FixAttendanceInstant List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<List<FixAttendanceInstant>> GetFixAttendanceInstantListMinCol(string columns, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT " + columns + " FROM FixAttendanceInstant";
                }
                else
                {
                    Query = "SELECT " + columns + " FROM FixAttendanceInstant WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<FixAttendanceInstant> fixAttendanceInstantList = new List<FixAttendanceInstant>();
                while (Reader.Read())
                {
                    FixAttendanceInstant fixAttendanceInstant = new FixAttendanceInstant();

                    SkipOnError(() => fixAttendanceInstant.FixInstId = (int)Reader["FixInstId"]);
                    SkipOnError(() => fixAttendanceInstant.AttendanceId = (int)Reader["AttendanceId"]);
                    SkipOnError(() => fixAttendanceInstant.EmployeeId = Reader["EmployeeId"].ToString());
                    SkipOnError(() => fixAttendanceInstant.AttendanceDate = (DateTime)Reader["AttendanceDate"]);
                    SkipOnError(() => fixAttendanceInstant.FixType = Reader["FixType"].ToString());
                    SkipOnError(() => fixAttendanceInstant.TimeIn = (DateTime)Reader["TimeIn"]);
                    SkipOnError(() => fixAttendanceInstant.TimeOut = (DateTime)Reader["TimeOut"]);
                    SkipOnError(() => fixAttendanceInstant.OT = (DateTime)Reader["OT"]);
                    SkipOnError(() => fixAttendanceInstant.ShiftDetailId = (int)Reader["ShiftDetailId"]);
                    SkipOnError(() => fixAttendanceInstant.ActualShiftDetailId = (int)Reader["ActualShiftDetailId"]);
                    SkipOnError(() => fixAttendanceInstant.Status = Reader["Status"].ToString());
                    SkipOnError(() => fixAttendanceInstant.Remarks = Reader["Remarks"].ToString());
                    SkipOnError(() => fixAttendanceInstant.ActualTimeIn = (DateTime)Reader["ActualTimeIn"]);
                    SkipOnError(() => fixAttendanceInstant.ActualTimeOut = (DateTime)Reader["ActualTimeOut"]);
                    SkipOnError(() => fixAttendanceInstant.ActualOT = (DateTime)Reader["ActualOT"]);
                    SkipOnError(() => fixAttendanceInstant.ActualStatus = Reader["ActualStatus"].ToString());
                    SkipOnError(() => fixAttendanceInstant.ARemarks = Reader["ARemarks"].ToString());
                    SkipOnError(() => fixAttendanceInstant.UId = Reader["UId"].ToString());
                    SkipOnError(() => fixAttendanceInstant.UName = Reader["UName"].ToString());
                    SkipOnError(() => fixAttendanceInstant.PCName = Reader["PCName"].ToString());
                    SkipOnError(() => fixAttendanceInstant.FixDate = (DateTime)Reader["FixDate"]);

                    fixAttendanceInstantList.Add(fixAttendanceInstant);
                }
                Reader.Close();
                ConnectionClose();
                return fixAttendanceInstantList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get FixAttendanceInstant List \n" + exception.Message);
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
