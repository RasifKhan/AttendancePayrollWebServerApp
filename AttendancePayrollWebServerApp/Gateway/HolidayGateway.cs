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
    public class HolidayGateway : Gateway
    {
        public async Task<Alert> Save(Holiday holiday, DateTime? existCondition = null)
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

                Query = "INSERT INTO Holiday (FromDate,ToDate,HoliDay,Remarks,Addedby,AddedDate,EditedBy,EditedDate) VALUES(@fromDate,@toDate,@holiDay,@remarks,@addedby,@addedDate,@editedBy,@editedDate)";

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@holidayId", holiday.HolidayId);
                Command.Parameters.AddWithValue("@fromDate", holiday.FromDate);
                Command.Parameters.AddWithValue("@toDate", holiday.ToDate);
                Command.Parameters.AddWithValue("@holiDay", holiday.HoliDay);
                Command.Parameters.AddWithValue("@remarks", holiday.Remarks);
                Command.Parameters.AddWithValue("@addedby", holiday.Addedby);
                Command.Parameters.AddWithValue("@addedDate", holiday.AddedDate);
                Command.Parameters.AddWithValue("@editedBy", holiday.EditedBy);
                Command.Parameters.AddWithValue("@editedDate", holiday.EditedDate);

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

       
        public async Task<Alert> Edit(Holiday holiday, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "UPDATE Holiday SET FromDate=@fromDate,ToDate=@toDate,HoliDay=@holiDay,Remarks=@remarks,Addedby=@addedby,AddedDate=@addedDate,EditedBy=@editedBy,EditedDate=@editedDate WHERE HolidayId = @holidayId";
                }
                else
                {
                    Query = "UPDATE Holiday SET FromDate=@fromDate,ToDate=@toDate,HoliDay=@holiDay,Remarks=@remarks,Addedby=@addedby,AddedDate=@addedDate,EditedBy=@editedBy,EditedDate=@editedDate WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@holidayId", holiday.HolidayId);
                Command.Parameters.AddWithValue("@fromDate", holiday.FromDate);
                Command.Parameters.AddWithValue("@toDate", holiday.ToDate);
                Command.Parameters.AddWithValue("@holiDay", holiday.HoliDay);
                Command.Parameters.AddWithValue("@remarks", holiday.Remarks);
                Command.Parameters.AddWithValue("@addedby", holiday.Addedby);
                Command.Parameters.AddWithValue("@addedDate", holiday.AddedDate);
                Command.Parameters.AddWithValue("@editedBy", holiday.EditedBy);
                Command.Parameters.AddWithValue("@editedDate", holiday.EditedDate);

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

        public async Task<Alert> Delete(int holidayId, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "DELETE Holiday WHERE HolidayId = @holidayId";
                }
                else
                {
                    Query = "DELETE Holiday WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@holidayId", holidayId);

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





        public async Task<bool> IsExist(DateTime? fromDate = null, DateTime? toDate = null, int holidayId = 0)
        {
            try
            {
                if (fromDate == null || toDate == null)
                {
                    Query = "SELECT 1 FROM Holiday";
                }
                else if (holidayId == 0)
                {
                    // Check for any overlapping date ranges excluding the current record //Rasif
                    Query = @"SELECT 1 FROM Holiday 
                     WHERE (
                            (@FromDate BETWEEN FromDate AND ToDate)   
                            OR (@ToDate BETWEEN FromDate AND ToDate)    
                            OR (FromDate BETWEEN @FromDate AND @ToDate)  
                            OR (ToDate BETWEEN @FromDate AND @ToDate)      
                          )";
                }
                else
                {
                    // Same check but exclude the current holiday being edited //Rasif
                    Query = @"SELECT 1 FROM Holiday 
                     WHERE (
                            (@FromDate BETWEEN FromDate AND ToDate) 
                            OR (@ToDate BETWEEN FromDate AND ToDate) 
                            OR (FromDate BETWEEN @FromDate AND @ToDate) 
                            OR (ToDate BETWEEN @FromDate AND @ToDate)
                            ) 
                            AND HolidayId <> @HolidayId";
                }

                Command = new SqlCommand(Query, Connection);

                // Add parameters to prevent SQL injection //Rasif
                if (fromDate != null && toDate != null)
                {
                    Command.Parameters.AddWithValue("@FromDate", fromDate);
                    Command.Parameters.AddWithValue("@ToDate", toDate);
                    if (holidayId != 0)
                    {
                        Command.Parameters.AddWithValue("@HolidayId", holidayId);
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







        public async Task<Holiday> GetHoliday(int holidayId, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM Holiday WHERE HolidayId = @holidayId";
                }
                else
                {
                    Query = "SELECT * FROM Holiday WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@holidayId", holidayId);
                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                Holiday holiday = new Holiday();
                while (Reader.Read())
                {
                    holiday.HolidayId = (int)Reader["HolidayId"];
                    holiday.FromDate = (DateTime)Reader["FromDate"];
                    holiday.ToDate = (DateTime)Reader["ToDate"];
                    holiday.HoliDay = Reader["HoliDay"].ToString();
                    holiday.Remarks = Reader["Remarks"].ToString();
                    holiday.Addedby = (int)Reader["Addedby"];
                    holiday.AddedDate = (DateTime)Reader["AddedDate"];
                    holiday.EditedBy = (int)Reader["EditedBy"];
                    holiday.EditedDate = (DateTime)Reader["EditedDate"];
                }
                Reader.Close();
                ConnectionClose();
                return holiday;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get Holiday\n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<List<Holiday>> GetHolidayList(string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM Holiday";
                }
                else
                {
                    Query = "SELECT * FROM Holiday WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<Holiday> holidayList = new List<Holiday>();
                while (Reader.Read())
                {
                    Holiday holiday = new Holiday();

                    holiday.HolidayId = (int)Reader["HolidayId"];
                    holiday.FromDate = (DateTime)Reader["FromDate"];
                    holiday.ToDate = (DateTime)Reader["ToDate"];
                    holiday.HoliDay = Reader["HoliDay"].ToString();
                    holiday.Remarks = Reader["Remarks"].ToString();
                    holiday.Addedby = (int)Reader["Addedby"];
                    holiday.AddedDate = (DateTime)Reader["AddedDate"];
                    holiday.EditedBy = (int)Reader["EditedBy"];
                    holiday.EditedDate = (DateTime)Reader["EditedDate"];

                    holidayList.Add(holiday);
                }
                Reader.Close();
                ConnectionClose();
                return holidayList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get Holiday List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<List<Holiday>> GetHolidayListMinCol(string columns, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT " + columns + " FROM Holiday";
                }
                else
                {
                    Query = "SELECT " + columns + " FROM Holiday WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<Holiday> holidayList = new List<Holiday>();
                while (Reader.Read())
                {
                    Holiday holiday = new Holiday();

                    SkipOnError(() => holiday.HolidayId = (int)Reader["HolidayId"]);
                    SkipOnError(() => holiday.FromDate = (DateTime)Reader["FromDate"]);
                    SkipOnError(() => holiday.ToDate = (DateTime)Reader["ToDate"]);
                    SkipOnError(() => holiday.HoliDay = Reader["HoliDay"].ToString());
                    SkipOnError(() => holiday.Remarks = Reader["Remarks"].ToString());
                    SkipOnError(() => holiday.Addedby = (int)Reader["Addedby"]);
                    SkipOnError(() => holiday.AddedDate = (DateTime)Reader["AddedDate"]);
                    SkipOnError(() => holiday.EditedBy = (int)Reader["EditedBy"]);
                    SkipOnError(() => holiday.EditedDate = (DateTime)Reader["EditedDate"]);

                    holidayList.Add(holiday);
                }
                Reader.Close();
                ConnectionClose();
                return holidayList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get Holiday List \n" + exception.Message);
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
