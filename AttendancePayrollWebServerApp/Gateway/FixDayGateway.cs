using AttendancePayrollWebServerApp.Models;
using AttendancePayrollWebServerApp.Pages.Company;
using AttendancePayrollWebServerApp.Pages.Department;
using AttendancePayrollWebServerApp.Pages.ShiftDetail;
using AttendancePayrollWebServerApp.UtilityClass;
using DevExpress.Xpo.DB.Helpers;
using System.ComponentModel.Design;
using System.Data.SqlClient;

namespace AttendancePayrollWebServerApp.Gateway
{
    public class FixDayGateway : Gateway
    {


        public async Task<Alert> Save(FixDay fixDay, DateTime? existCondition = null)
        {
            try
            {
                if (existCondition != null)
                {
                    if (await IsExist(existCondition) == true)
                    {
                        return new Alert("warning", "The record is already exist");
                    }
                }

                Query = "INSERT INTO FixDay (FixDateFrom,FixDateTo,FixType,FixRemarks,Addedby,AddedDate,EditedBy,EditedDate) VALUES(@fixDateFrom,@fixDateTo,@fixType,@fixRemarks,@addedby,@addedDate,@editedBy,@editedDate)";

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@fixDayId", fixDay.FixDayId);
                Command.Parameters.AddWithValue("@fixDateFrom", fixDay.FixDateFrom);
                Command.Parameters.AddWithValue("@fixDateTo", fixDay.FixDateTo);
                Command.Parameters.AddWithValue("@fixType", fixDay.FixType);
                Command.Parameters.AddWithValue("@fixRemarks", fixDay.FixRemarks);
                Command.Parameters.AddWithValue("@addedby", fixDay.Addedby);
                Command.Parameters.AddWithValue("@addedDate", fixDay.AddedDate);
                Command.Parameters.AddWithValue("@editedBy", fixDay.EditedBy);
                Command.Parameters.AddWithValue("@editedDate", fixDay.EditedDate);

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

        public async Task<Alert> Edit(FixDay fixDay, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "UPDATE FixDay SET FixDateFrom=@fixDateFrom,FixDateTo=@fixDateTo,FixType=@fixType,FixRemarks=@fixRemarks,Addedby=@addedby,AddedDate=@addedDate,EditedBy=@editedBy,EditedDate=@editedDate WHERE FixDayId = @fixDayId";
                }
                else
                {
                    Query = "UPDATE FixDay SET FixDateFrom=@fixDateFrom,FixDateTo=@fixDateTo,FixType=@fixType,FixRemarks=@fixRemarks,Addedby=@addedby,AddedDate=@addedDate,EditedBy=@editedBy,EditedDate=@editedDate WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@fixDayId", fixDay.FixDayId);
                Command.Parameters.AddWithValue("@fixDateFrom", fixDay.FixDateFrom);
                Command.Parameters.AddWithValue("@fixDateTo", fixDay.FixDateTo);
                Command.Parameters.AddWithValue("@fixType", fixDay.FixType);
                Command.Parameters.AddWithValue("@fixRemarks", fixDay.FixRemarks);
                Command.Parameters.AddWithValue("@addedby", fixDay.Addedby);
                Command.Parameters.AddWithValue("@addedDate", fixDay.AddedDate);
                Command.Parameters.AddWithValue("@editedBy", fixDay.EditedBy);
                Command.Parameters.AddWithValue("@editedDate", fixDay.EditedDate);

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

        public async Task<Alert> Delete(int fixDayId, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "DELETE FixDay WHERE FixDayId = @fixDayId";
                }
                else
                {
                    Query = "DELETE FixDay WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@fixDayId", fixDayId);

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






        public async Task<bool> IsExist(DateTime? fromDate = null, DateTime? toDate = null, int fixDayId = 0)
        {
            try
            {
                if (fromDate == null || toDate == null)
                {
                    Query = "SELECT 1 FROM FixDay";
                }
                else if (fixDayId == 0)
                {
                    // Check for any overlapping date ranges excluding the current record //Rasif
                    Query = @"SELECT 1 FROM FixDay 
                     WHERE (
                            (@FromDate BETWEEN FixDateFrom AND FixDateTo)   
                            OR (@ToDate BETWEEN FixDateFrom AND FixDateTo)    
                            OR (FixDateFrom BETWEEN @FromDate AND @ToDate)  
                            OR (FixDateTo BETWEEN @FromDate AND @ToDate)      
                          )";
                }
                else
                {
                    // Same check but exclude the current holiday being edited //Rasif
                    Query = @"SELECT 1 FROM FixDay 
                     WHERE (
                            (@FromDate BETWEEN FixDateFrom AND FixDateTo)   
                            OR (@ToDate BETWEEN FixDateFrom AND FixDateTo)    
                            OR (FixDateFrom BETWEEN @FromDate AND @ToDate)  
                            OR (FixDateTo BETWEEN @FromDate AND @ToDate)  
                            ) 
                            AND FixDayId <> @FixDayId";
                }

                Command = new SqlCommand(Query, Connection);

                // Add parameters to prevent SQL injection //Rasif
                if (fromDate != null && toDate != null)
                {
                    Command.Parameters.AddWithValue("@FromDate", fromDate);
                    Command.Parameters.AddWithValue("@ToDate", toDate);
                    if (fixDayId != 0)
                    {
                        Command.Parameters.AddWithValue("@FixDayId", fixDayId);
                    }
                }

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();
                bool exist = Reader.HasRows;
                Reader.Close();
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









        //public async Task<bool> IsExist(DateTime? fixDateFrom = null, int fixDayId = 0)
        //{
        //    try
        //    {
        //        if (fixDateFrom == null)
        //        {
        //            Query = "SELECT 1 FROM FixDay";
        //        }

        //        if (fixDateFrom != null && fixDayId == 0)
        //        {
        //            Query = $"SELECT 1 FROM FixDay WHERE FixDateFrom='{fixDateFrom}'";
        //        }

        //        if (fixDateFrom != null && fixDayId != 0)
        //        {
        //            Query = $"SELECT 1 FROM FixDay WHERE FixDateFrom='{fixDateFrom}' and FixDayId <> '{fixDayId}' ";
        //        }



        //        Command = new SqlCommand(Query, Connection);

        //        ConnectionOpen();
        //        Reader = await Command.ExecuteReaderAsync();
        //        bool exist = Reader.HasRows;
        //        Reader.Close();
        //        ConnectionClose();
        //        return exist;
        //    }
        //    catch (Exception exception)
        //    {
        //        throw new Exception(exception.Message);
        //    }
        //    finally
        //    {
        //        ConnectionClose();
        //    }
        //}

        public async Task<FixDay> GetFixDay(int fixDayId, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM FixDay WHERE FixDayId = @fixDayId";
                }
                else
                {
                    Query = "SELECT * FROM FixDay WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@fixDayId", fixDayId);
                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                FixDay fixDay = new FixDay();
                while (Reader.Read())
                {
                    fixDay.FixDayId = (int)Reader["FixDayId"];
                    fixDay.FixDateFrom = (DateTime)Reader["FixDateFrom"];
                    fixDay.FixDateTo = (DateTime)Reader["FixDateTo"];
                    fixDay.FixType = Reader["FixType"].ToString();
                    fixDay.FixRemarks = Reader["FixRemarks"].ToString();
                    fixDay.Addedby = (int)Reader["Addedby"];
                    fixDay.AddedDate = (DateTime)Reader["AddedDate"];
                    fixDay.EditedBy = (int)Reader["EditedBy"];
                    fixDay.EditedDate = (DateTime)Reader["EditedDate"];
                }
                Reader.Close();
                ConnectionClose();
                return fixDay;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get FixDay\n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<List<FixDay>> GetFixDayList(string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM FixDay";
                }
                else
                {
                    Query = "SELECT * FROM FixDay WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<FixDay> fixDayList = new List<FixDay>();
                while (Reader.Read())
                {
                    FixDay fixDay = new FixDay();

                    fixDay.FixDayId = (int)Reader["FixDayId"];
                    fixDay.FixDateFrom = (DateTime)Reader["FixDateFrom"];
                    fixDay.FixDateTo = (DateTime)Reader["FixDateTo"];
                    fixDay.FixType = Reader["FixType"].ToString();
                    fixDay.FixRemarks = Reader["FixRemarks"].ToString();
                    fixDay.Addedby = (int)Reader["Addedby"];
                    fixDay.AddedDate = (DateTime)Reader["AddedDate"];
                    fixDay.EditedBy = (int)Reader["EditedBy"];
                    fixDay.EditedDate = (DateTime)Reader["EditedDate"];

                    fixDayList.Add(fixDay);
                }
                Reader.Close();
                ConnectionClose();
                return fixDayList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get FixDay List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<List<FixDay>> GetFixDayListMinCol(string columns, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT " + columns + " FROM FixDay";
                }
                else
                {
                    Query = "SELECT " + columns + " FROM FixDay WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<FixDay> fixDayList = new List<FixDay>();
                while (Reader.Read())
                {
                    FixDay fixDay = new FixDay();

                    SkipOnError(() => fixDay.FixDayId = (int)Reader["FixDayId"]);
                    SkipOnError(() => fixDay.FixDateFrom = (DateTime)Reader["FixDateFrom"]);
                    SkipOnError(() => fixDay.FixDateTo = (DateTime)Reader["FixDateTo"]);
                    SkipOnError(() => fixDay.FixType = Reader["FixType"].ToString());
                    SkipOnError(() => fixDay.FixRemarks = Reader["FixRemarks"].ToString());
                    SkipOnError(() => fixDay.Addedby = (int)Reader["Addedby"]);
                    SkipOnError(() => fixDay.AddedDate = (DateTime)Reader["AddedDate"]);
                    SkipOnError(() => fixDay.EditedBy = (int)Reader["EditedBy"]);
                    SkipOnError(() => fixDay.EditedDate = (DateTime)Reader["EditedDate"]);

                    fixDayList.Add(fixDay);
                }
                Reader.Close();
                ConnectionClose();
                return fixDayList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get FixDay List \n" + exception.Message);
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
