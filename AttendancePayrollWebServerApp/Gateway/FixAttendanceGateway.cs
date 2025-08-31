using AttendancePayrollWebServerApp.Models;
using AttendancePayrollWebServerApp.Models.View;
using AttendancePayrollWebServerApp.UtilityClass;
using System.Data;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.Net;


namespace AttendancePayrollWebServerApp.Gateway
{
    public class FixAttendanceGateway : Gateway
    {
        //public async Task<Alert> Save(FixAttendance fixAttendance, string existCondition = "")
        //{
        //    try
        //    {
        //        if (existCondition != "")
        //        {
        //            if (await IsExist(existCondition) == true)
        //            {
        //                return new Alert("warning", "The record is already exist");
        //            }
        //        }

        //        Query = "INSERT INTO FixAttendance (EmployeeId,AttendanceDate,TimeIn,TimeOut,ActualTimeIn,ActualTimeOut,ActualStatus,ActualOT,ActualLate,OT,Status,Remarks,FixDate,UserID,PC,IP) VALUES(@employeeId,@date,@timeIn,@timeOut,@actualTimeIn,@actualTimeOut,@actualStatus,@actualOT,@actualLate,@oT,@status,@remark,@fixDate,@userID,@pC,@iP)";
        //        Command = new SqlCommand(Query, Connection);
        //        Command.Parameters.AddWithValue("@fixAttendanceId", fixAttendance.FixAttendanceId);
        //        Command.Parameters.AddWithValue("@employeeId", fixAttendance.EmployeeId);
        //        Command.Parameters.AddWithValue("@date", fixAttendance.AttendanceDate);
        //        Command.Parameters.AddWithValue("@timeIn", fixAttendance.TimeIn);
        //        Command.Parameters.AddWithValue("@timeOut", fixAttendance.TimeOut);
        //        Command.Parameters.AddWithValue("@actualTimeIn", fixAttendance.ActualTimeIn);
        //        Command.Parameters.AddWithValue("@actualTimeOut", fixAttendance.ActualTimeOut);
        //        Command.Parameters.AddWithValue("@actualStatus", fixAttendance.ActualStatus);
        //        Command.Parameters.AddWithValue("@actualOT", fixAttendance.ActualOT);
        //        Command.Parameters.AddWithValue("@actualLate", fixAttendance.ActualLate);
        //        Command.Parameters.AddWithValue("@oT", fixAttendance.OT);
        //        Command.Parameters.AddWithValue("@status", fixAttendance.Status);
        //        Command.Parameters.AddWithValue("@remark", fixAttendance.Remarks);
        //        Command.Parameters.AddWithValue("@fixDate", fixAttendance.FixDate);
        //        Command.Parameters.AddWithValue("@userID", fixAttendance.UserID);
        //        Command.Parameters.AddWithValue("@pC", fixAttendance.PC);
        //        Command.Parameters.AddWithValue("@iP", fixAttendance.IP);


        //        ConnectionOpen();
        //        int rowAffected = await Command.ExecuteNonQueryAsync();
        //        ConnectionClose();

        //        if (rowAffected > 0)
        //        {
        //            return new Alert("success", "Saved");
        //        }
        //        return new Alert("warning", "Not Saved");
        //    }
        //    catch (Exception exception)
        //    {
        //        return new Alert("danger", "Failed To Save\n" + exception.Message);
        //    }
        //    finally
        //    {
        //        ConnectionClose();
        //    }
        //}




        //public async Task<Alert> InsertFixAttendanceAsync(AttendanceView originalItem, AttendanceView changedItem)
        //{


        //}



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





        public async Task<Alert> InsertFixAttendanceAsync(FixAttendanceView originalItem, FixAttendanceView changedItem)   //, FixAttendance fixAttendance
        {
            try
            {
                string pc = Dns.GetHostName();
                //string ip = Dns.GetHostEntry(pc).AddressList[0].ToString();

                string ip = Dns.GetHostEntry(pc).AddressList
                 .FirstOrDefault(addr => addr.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                 ?.ToString();

                //string localIP = GetLocalIPAddress();
                //string userName = Environment.UserName;
                Query = @"INSERT INTO FixAttendance (EmployeeId,AttendanceDate,TimeIn,TimeOut,ActualTimeIn,ActualTimeOut,ActualStatus,ActualOT,ActualLate,OT,Status,Remarks,FixDate,ProcessedYN,IP,PC) VALUES(@employeeId,@date,@fixedTimeIn,@fixedTimeOut,@actualTimeIn,@actualTimeOut,@actualStatus,@actualOT,@actualLate,@oT,@status,@remark,@fixDate,@processedYN,@ip,@pc)";
                Command = new SqlCommand(Query, Connection);
                // Command.Parameters.AddWithValue("@fixAttendanceId", fixAttendance.FixAttendanceId);
                Command.Parameters.AddWithValue("@employeeId", originalItem.EmployeeId);
                Command.Parameters.AddWithValue("@date", originalItem.AttendanceDate);



                //if (changedItem.FixedTimein == originalItem.FixedTimein)
                //{
                //    Command.Parameters.AddWithValue("@fixedTimeIn", DateTime.Parse("1900-01-01 00:00:00"));
                //}
                //else
                //{
                //    Command.Parameters.AddWithValue("@fixedTimeIn", changedItem.FixedTimein);
                //}


                Command.Parameters.AddWithValue("@fixedTimeIn", changedItem.FixedTimein);


                //if (changedItem.FixedTimeOut == originalItem.FixedTimeOut)
                //{
                //    Command.Parameters.AddWithValue("@fixedTimeOut", DateTime.Parse("1900-01-01 00:00:00"));
                //}

                //else
                //{
                //    Command.Parameters.AddWithValue("@fixedTimeOut", changedItem.FixedTimeOut);
                //}

                Command.Parameters.AddWithValue("@fixedTimeOut", changedItem.FixedTimeOut);


                Command.Parameters.AddWithValue("@actualTimeIn", originalItem.ActualTimeIn);
                Command.Parameters.AddWithValue("@actualTimeOut", originalItem.ActualTimeOut);

                Command.Parameters.AddWithValue("@actualStatus", originalItem.Status);
                Command.Parameters.AddWithValue("@actualOT", originalItem.OT);
                Command.Parameters.AddWithValue("@actualLate", originalItem.Late);
                Command.Parameters.AddWithValue("@oT", originalItem.OT);
                Command.Parameters.AddWithValue("@status", changedItem.Status);
                Command.Parameters.AddWithValue("@remark", changedItem.Remarks);
                Command.Parameters.AddWithValue("@fixDate", originalItem.AttendanceDate);
                Command.Parameters.AddWithValue("@processedYN", 'N');
                //   Command.Parameters.AddWithValue("@noneJoinedAttId", originalItem.AttendanceId);
                Command.Parameters.AddWithValue("@ip", ip);
                Command.Parameters.AddWithValue("@pc", pc);
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


        public async Task<bool> IsExistDateEmployee(DateTime? attendanceDate, string? employeeId)
        {
            try
            {
                if (attendanceDate != null && employeeId != null)
                {
                    Query = $"SELECT 1 FROM FixAttendance WHERE AttendanceDate='{attendanceDate}' and EmployeeId ='{employeeId}' ";
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

        public async Task<String> DeleteFixAttendanceId(DateTime? attendanceDate, string? employeeId)
        {
            try
            {
                if (attendanceDate != null && employeeId != null)
                {
                    Query = "DELETE FixAttendance WHERE AttendanceDate = @attendanceDate And EmployeeId=@employeeId ";
                }
                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@attendanceDate", attendanceDate);
                Command.Parameters.AddWithValue("@employeeId", employeeId);

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






























        public async Task<Alert> Edit(FixAttendance fixAttendance, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "UPDATE FixAttendance SET EmployeeId=@employeeId,AttendanceDate=@date,TimeIn=@timeIn,TimeOut=@timeOut,ActualTimeIn=@actualTimeIn,ActualTimeOut=@actualTimeOut,ActualStatus=@actualStatus,ActualOT=@actualOT,ActualLate=@actualLate,OT=@oT,Status=@status,Remarks=@remark,FixDate=@fixDate,UserID=@userID,PC=@pC,IP=@iP WHERE FixAttendanceId = @fixAttendanceId";
                }
                else
                {
                    Query = "UPDATE FixAttendance SET EmployeeId=@employeeId,AttendanceDate=@date,TimeIn=@timeIn,TimeOut=@timeOut,ActualTimeIn=@actualTimeIn,ActualTimeOut=@actualTimeOut,ActualStatus=@actualStatus,ActualOT=@actualOT,ActualLate=@actualLate,OT=@oT,Status=@status,Remarks=@remark,FixDate=@fixDate,UserID=@userID,PC=@pC,IP=@iP WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@fixAttendanceId", fixAttendance.FixAttendanceId);
                Command.Parameters.AddWithValue("@employeeId", fixAttendance.EmployeeId);
                Command.Parameters.AddWithValue("@date", fixAttendance.AttendanceDate);
                Command.Parameters.AddWithValue("@timeIn", fixAttendance.TimeIn);
                Command.Parameters.AddWithValue("@timeOut", fixAttendance.TimeOut);
                Command.Parameters.AddWithValue("@actualTimeIn", fixAttendance.ActualTimeIn);
                Command.Parameters.AddWithValue("@actualTimeOut", fixAttendance.ActualTimeOut);
                Command.Parameters.AddWithValue("@actualStatus", fixAttendance.ActualStatus);
                Command.Parameters.AddWithValue("@actualOT", fixAttendance.ActualOT);
                Command.Parameters.AddWithValue("@actualLate", fixAttendance.ActualLate);
                Command.Parameters.AddWithValue("@oT", fixAttendance.OT);
                Command.Parameters.AddWithValue("@status", fixAttendance.Status);
                Command.Parameters.AddWithValue("@remark", fixAttendance.Remarks);
                Command.Parameters.AddWithValue("@fixDate", fixAttendance.FixDate);
                Command.Parameters.AddWithValue("@userID", fixAttendance.UserID);
                Command.Parameters.AddWithValue("@pC", fixAttendance.PC);
                Command.Parameters.AddWithValue("@iP", fixAttendance.IP);

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

        public async Task<Alert> Delete(int fixAttendanceId, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "DELETE FixAttendance WHERE FixAttendanceId = @fixAttendanceId";
                }
                else
                {
                    Query = "DELETE FixAttendance WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@fixAttendanceId", fixAttendanceId);

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
                    Query = "SELECT 1 FROM FixAttendance";
                }
                else
                {
                    Query = "SELECT 1 FROM FixAttendance WHERE " + condition;
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

        public async Task<FixAttendance> GetFixAttendance(int fixAttendanceId, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM FixAttendance WHERE FixAttendanceId = @fixAttendanceId";
                }
                else
                {
                    Query = "SELECT * FROM FixAttendance WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@fixAttendanceId", fixAttendanceId);
                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                FixAttendance fixAttendance = new FixAttendance();
                while (Reader.Read())
                {
                    fixAttendance.FixAttendanceId = (int)Reader["FixAttendanceId"];
                    fixAttendance.EmployeeId = Reader["EmployeeId"].ToString();
                    fixAttendance.AttendanceDate = (DateTime)Reader["AttendanceDate"];
                    fixAttendance.TimeIn = (DateTime)Reader["TimeIn"];
                    fixAttendance.TimeOut = (DateTime)Reader["TimeOut"];
                    fixAttendance.ActualTimeIn = (DateTime)Reader["ActualTimeIn"];
                    fixAttendance.ActualTimeOut = (DateTime)Reader["ActualTimeOut"];
                    fixAttendance.ActualStatus = Reader["ActualStatus"].ToString();
                    fixAttendance.ActualOT = (DateTime)Reader["ActualOT"];
                    fixAttendance.ActualLate = (DateTime)Reader["ActualLate"];
                    fixAttendance.OT = (DateTime)Reader["OT"];
                    fixAttendance.Status = Reader["Status"].ToString();
                    fixAttendance.Remarks = Reader["Remarks"].ToString();
                    fixAttendance.FixDate = (DateTime)Reader["FixDate"];
                    fixAttendance.UserID = Reader["UserID"].ToString();
                    fixAttendance.PC = Reader["PC"].ToString();
                    fixAttendance.IP = Reader["IP"].ToString();
                }
                Reader.Close();
                ConnectionClose();
                return fixAttendance;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get FixAttendance\n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<List<FixAttendance>> GetFixAttendanceList(string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM FixAttendance";
                }
                else
                {
                    Query = "SELECT * FROM FixAttendance WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<FixAttendance> fixAttendanceList = new List<FixAttendance>();
                while (Reader.Read())
                {
                    FixAttendance fixAttendance = new FixAttendance();

                    fixAttendance.FixAttendanceId = (int)Reader["FixAttendanceId"];
                    fixAttendance.EmployeeId = Reader["EmployeeId"].ToString();
                    fixAttendance.AttendanceDate = (DateTime)Reader["AttendanceDate"];
                    fixAttendance.TimeIn = (DateTime)Reader["TimeIn"];
                    fixAttendance.TimeOut = (DateTime)Reader["TimeOut"];
                    fixAttendance.ActualTimeIn = (DateTime)Reader["ActualTimeIn"];
                    fixAttendance.ActualTimeOut = (DateTime)Reader["ActualTimeOut"];
                    fixAttendance.ActualStatus = Reader["ActualStatus"].ToString();
                    fixAttendance.ActualOT = (DateTime)Reader["ActualOT"];
                    fixAttendance.ActualLate = (DateTime)Reader["ActualLate"];
                    fixAttendance.OT = (DateTime)Reader["OT"];
                    fixAttendance.Status = Reader["Status"].ToString();
                    fixAttendance.Remarks = Reader["Remarks"].ToString();
                    fixAttendance.FixDate = (DateTime)Reader["FixDate"];
                    fixAttendance.UserID = Reader["UserID"].ToString();
                    fixAttendance.PC = Reader["PC"].ToString();
                    fixAttendance.IP = Reader["IP"].ToString();

                    fixAttendanceList.Add(fixAttendance);
                }
                Reader.Close();
                ConnectionClose();
                return fixAttendanceList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get FixAttendance List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }



        public async Task<List<FixAttendance>> GetFixAttendanceListByProcessedN(string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM FixAttendance WHERE ProcessedYN='N'";
                }
                else
                {
                    Query = "SELECT * FROM FixAttendance WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<FixAttendance> fixAttendanceList = new List<FixAttendance>();
                while (Reader.Read())
                {
                    FixAttendance fixAttendance = new FixAttendance();

                    fixAttendance.FixAttendanceId = (int)Reader["FixAttendanceId"];
                    fixAttendance.EmployeeId = Reader["EmployeeId"].ToString();
                    fixAttendance.AttendanceDate = (DateTime)Reader["AttendanceDate"];
                    fixAttendance.TimeIn = (DateTime)Reader["TimeIn"];
                    fixAttendance.TimeOut = (DateTime)Reader["TimeOut"];
                    fixAttendance.ActualTimeIn = (DateTime)Reader["ActualTimeIn"];
                    fixAttendance.ActualTimeOut = (DateTime)Reader["ActualTimeOut"];
                    fixAttendance.ActualStatus = Reader["ActualStatus"].ToString();
                    fixAttendance.ActualOT = (DateTime)Reader["ActualOT"];
                    fixAttendance.ActualLate = (DateTime)Reader["ActualLate"];
                    fixAttendance.OT = (DateTime)Reader["OT"];
                    fixAttendance.Status = Reader["Status"].ToString();
                    fixAttendance.Remarks = Reader["Remarks"].ToString();
                    fixAttendance.FixDate = (DateTime)Reader["FixDate"];
                    fixAttendance.UserID = Reader["UserID"].ToString();
                    fixAttendance.PC = Reader["PC"].ToString();
                    fixAttendance.IP = Reader["IP"].ToString();

                    fixAttendanceList.Add(fixAttendance);
                }
                Reader.Close();
                ConnectionClose();
                return fixAttendanceList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get FixAttendance List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }


        public async Task<List<FixAttendance>> GetFixAttendanceListMinCol(string columns, string condition = "")
        {

            try
            {
                if (condition == "")
                {
                    Query = "SELECT " + columns + " FROM FixAttendance";
                }
                else
                {
                    Query = "SELECT " + columns + " FROM FixAttendance WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<FixAttendance> fixAttendanceList = new List<FixAttendance>();
                while (Reader.Read())
                {
                    FixAttendance fixAttendance = new FixAttendance();

                    SkipOnError(() => fixAttendance.FixAttendanceId = (int)Reader["FixAttendanceId"]);
                    SkipOnError(() => fixAttendance.EmployeeId = Reader["EmployeeId"].ToString());
                    SkipOnError(() => fixAttendance.AttendanceDate = (DateTime)Reader["AttendanceDate"]);
                    SkipOnError(() => fixAttendance.TimeIn = (DateTime)Reader["TimeIn"]);
                    SkipOnError(() => fixAttendance.TimeOut = (DateTime)Reader["TimeOut"]);
                    SkipOnError(() => fixAttendance.ActualTimeIn = (DateTime)Reader["ActualTimeIn"]);
                    SkipOnError(() => fixAttendance.ActualTimeOut = (DateTime)Reader["ActualTimeOut"]);
                    SkipOnError(() => fixAttendance.ActualStatus = Reader["ActualStatus"].ToString());
                    SkipOnError(() => fixAttendance.ActualOT = (DateTime)Reader["ActualOT"]);
                    SkipOnError(() => fixAttendance.ActualLate = (DateTime)Reader["ActualLate"]);
                    SkipOnError(() => fixAttendance.OT = (DateTime)Reader["OT"]);
                    SkipOnError(() => fixAttendance.Status = Reader["Status"].ToString());
                    SkipOnError(() => fixAttendance.Remarks = Reader["Remarks"].ToString());
                    SkipOnError(() => fixAttendance.FixDate = (DateTime)Reader["FixDate"]);
                    SkipOnError(() => fixAttendance.UserID = Reader["UserID"].ToString());
                    SkipOnError(() => fixAttendance.PC = Reader["PC"].ToString());
                    SkipOnError(() => fixAttendance.IP = Reader["IP"].ToString());

                    fixAttendanceList.Add(fixAttendance);
                }
                Reader.Close();
                ConnectionClose();
                return fixAttendanceList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get FixAttendance List \n" + exception.Message);
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
