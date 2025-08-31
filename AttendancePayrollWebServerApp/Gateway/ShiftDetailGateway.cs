using AttendancePayrollWebServerApp.Models;
//using AttendancePayrollWebServerApp.Pages.Shift2;
using AttendancePayrollWebServerApp.UtilityClass;
using DevExpress.Xpo.DB.Helpers;
using System.Data.SqlClient;

namespace AttendancePayrollWebServerApp.Gateway
{
    public class ShiftDetailGateway :Gateway
    {
        public async Task<Alert> Save(ShiftDetail shiftDetail, string existCondition = "")
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

                Query = "INSERT INTO ShiftDetail (ShiftTypeMasterId,ShiftName,ShiftIn,ShiftOut,ShiftHr,ShiftLate,LunchIn,LunchOut,LunchLate,LunchHr) VALUES(@shiftTypeMasterId,@shiftName,@shiftIn,@shiftOut,@shiftHr,@shiftLate,@lunchIn,@lunchOut,@lunchLate,@lunchHr)";

                //Query = "INSERT INTO ShiftDetail (ShiftName,ShiftType,ShiftIn,ShiftOut,ShiftLate,ShiftHr,LunchIn,LunchOut,LunchLate,LunchHr) VALUES(@shiftName,@shiftType,@shiftIn,@shiftOut,@shiftLate,@shiftHr,@lunchIn,@lunchOut,@lunchLate,@lunchHr)";

                Command = new SqlCommand(Query, Connection);


                Command.Parameters.AddWithValue("@shiftDetailId", shiftDetail.ShiftDetailId);
                Command.Parameters.AddWithValue("@shiftTypeMasterId", shiftDetail.ShiftTypeMasterId);
                Command.Parameters.AddWithValue("@shiftName", shiftDetail.ShiftName);
              //  Command.Parameters.AddWithValue("@shiftType", shiftDetail.ShiftType);
                Command.Parameters.AddWithValue("@shiftIn", shiftDetail.ShiftIn);
                Command.Parameters.AddWithValue("@shiftOut", shiftDetail.ShiftOut);
                Command.Parameters.AddWithValue("@shiftLate", shiftDetail.ShiftLate);
                Command.Parameters.AddWithValue("@shiftHr", shiftDetail.ShiftHr);
                Command.Parameters.AddWithValue("@lunchIn", shiftDetail.LunchIn);
                Command.Parameters.AddWithValue("@lunchOut", shiftDetail.LunchOut);
                Command.Parameters.AddWithValue("@lunchLate", shiftDetail.LunchLate);
                Command.Parameters.AddWithValue("@lunchHr", shiftDetail.LunchHr);

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


        public async Task<Alert> Edit(ShiftDetail shiftDetail, string condition = "@shiftDetailId")
        {
            try
            {
                if (condition == "")
                {
                  //  Query = "UPDATE ShiftDetail SET ShiftName=@shiftName,ShiftType=@shiftType,ShiftIn=@shiftIn,ShiftOut=@shiftOut,ShiftLate=@shiftLate,ShiftHr=@shiftHr,LunchIn=@lunchIn,LunchOut=@lunchOut,LunchLate=@lunchLate,LunchHr=@lunchHr WHERE ShiftTypeMasterId = @shiftTypeMasterId";
                    Query = "UPDATE ShiftDetail SET ShiftTypeMasterId=@shiftTypeMasterId,ShiftName=@shiftName,ShiftIn=@shiftIn,ShiftOut=@shiftOut,ShiftLate=@shiftLate,ShiftHr=@shiftHr,LunchIn=@lunchIn,LunchOut=@lunchOut,LunchLate=@lunchLate ,LunchHr=@lunchHr WHERE ShiftDetailId = @shiftDetailId";
                }
                else
                {
                    // Query = "UPDATE ShiftDetail SET ShiftName=@shiftName,ShiftType=@shiftType,ShiftIn=@shiftIn,ShiftOut=@shiftOut,ShiftLate=@shiftLate,ShiftHr=@shiftHr,LunchIn=@lunchIn,LunchOut=@lunchOut,LunchLate=@lunchLate,LunchHr=@lunchHr WHERE " + condition;
                    Query = "UPDATE ShiftDetail SET ShiftTypeMasterId=@shiftTypeMasterId,ShiftName=@shiftName,ShiftIn=@shiftIn,ShiftOut=@shiftOut,ShiftLate=@shiftLate,ShiftHr=@shiftHr,LunchIn=@lunchIn,LunchOut=@lunchOut,LunchLate=@lunchLate ,LunchHr=@lunchHr WHERE ShiftDetailId = @shiftDetailId";

                }

                Command = new SqlCommand(Query, Connection);


                Command.Parameters.AddWithValue("@shiftDetailId", shiftDetail.ShiftDetailId);
                Command.Parameters.AddWithValue("@shiftTypeMasterId", shiftDetail.ShiftTypeMasterId);
               
                Command.Parameters.AddWithValue("@shiftName", shiftDetail.ShiftName);
               // Command.Parameters.AddWithValue("@shiftType", shiftDetail.ShiftType);
                Command.Parameters.AddWithValue("@shiftIn", shiftDetail.ShiftIn);
                Command.Parameters.AddWithValue("@shiftOut", shiftDetail.ShiftOut);
                Command.Parameters.AddWithValue("@shiftLate", shiftDetail.ShiftLate);
                Command.Parameters.AddWithValue("@shiftHr", shiftDetail.ShiftHr);
                Command.Parameters.AddWithValue("@lunchIn", shiftDetail.LunchIn);
                Command.Parameters.AddWithValue("@lunchOut", shiftDetail.LunchOut);
                Command.Parameters.AddWithValue("@lunchLate", shiftDetail.LunchLate);
                Command.Parameters.AddWithValue("@lunchHr", shiftDetail.LunchHr);

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
        //public async Task<bool> IsExist(string shiftName = "", string shiftType = "", int shiftId = 0)
        //{
        //    try
        //    {
        //        if (shiftName == "" && shiftType == "")
        //        {
        //            Query = "SELECT 1 FROM Shift";
        //        }
        //        if (shiftName != "" && shiftType != "" && shiftId == 0) //This logic will work for creating new item
        //        {
        //            Query = $"SELECT 1 FROM Shift WHERE ShiftName = '{shiftName}' and ShiftType= '{shiftType}'";
        //        }
        //        if (shiftName != "" && shiftType != "" && shiftId != 0)
        //        {
        //            Query = $"SELECT 1 FROM Shift WHERE ShiftName = '{shiftName}' and ShiftType= '{shiftType}' and ShiftId <> '{shiftId}'";
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
        public async Task<bool> IsExist(string shiftName = "", int? shiftDetailId = 0, int? shiftTypeMasterId=0)
        {
            try
            {
                if (shiftName == "" && shiftTypeMasterId == null)
                {
                    Query = "SELECT 1 FROM ShiftDetail";
                }


                if(shiftName !="" && shiftTypeMasterId != null && shiftDetailId == 0) //This logic will work for creating new item
                {
                    Query = $"SELECT 1 FROM ShiftDetail WHERE ShiftName = '{shiftName}' and ShiftTypeMasterId= '{shiftTypeMasterId}'";
                }


                if (shiftName != "" && shiftTypeMasterId !=null && shiftDetailId != 0)
                { 
                        Query = $"SELECT 1 FROM ShiftDetail WHERE ShiftName = '{shiftName}' and ShiftTypeMasterId= '{shiftTypeMasterId}' and ShiftDetailId <> '{shiftDetailId}'";
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


        public async Task<ShiftDetail> GetShifts(int shiftDetailId, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM ShiftDetail WHERE ShiftDetailId = @shiftDetailId";
                }
                else
                {
                    Query = "SELECT * FROM ShiftDetail WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@shiftDetailId", shiftDetailId);
                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                ShiftDetail shiftDetail = new ShiftDetail();
                while (Reader.Read())
                {
                    shiftDetail.ShiftTypeMasterId = (int)Reader["ShiftTypeMasterId"];
                    shiftDetail.ShiftDetailId = (int)Reader["ShiftDetailId"];
                    shiftDetail.ShiftName = Reader["ShiftName"].ToString();
                   // shiftDetail.ShiftType = Reader["ShiftType"].ToString();

                    shiftDetail.ShiftIn = (DateTime)Reader["ShiftIn"];
                    shiftDetail.ShiftOut = (DateTime)Reader["ShiftOut"];
                    shiftDetail.ShiftLate = (DateTime)Reader["ShiftLate"];
                    shiftDetail.ShiftHr = (DateTime)Reader["ShiftHr"];
                    shiftDetail.LunchIn = (DateTime)Reader["LunchIn"];
                    shiftDetail.LunchOut = (DateTime)Reader["LunchOut"];
                    shiftDetail.LunchLate = (DateTime)Reader["LunchLate"];
                    shiftDetail.LunchHr = (DateTime)Reader["LunchHr"];
                }
                Reader.Close();
                ConnectionClose();
                return shiftDetail;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get ShiftDetail\n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<List<ShiftDetail>> GetShiftsList(string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM ShiftDetail";
                }
                else
                {
                    Query = "SELECT * FROM ShiftDetail WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<ShiftDetail> shiftList = new List<ShiftDetail>();
                while (Reader.Read())
                {
                    ShiftDetail shiftDetail = new ShiftDetail();


                    shiftDetail.ShiftTypeMasterId = (int)Reader["ShiftTypeMasterId"];
                    shiftDetail.ShiftDetailId = (int)Reader["ShiftDetailId"];

                    shiftDetail.ShiftName = Reader["ShiftName"].ToString();
                   
                    shiftDetail.ShiftIn = (DateTime)Reader["ShiftIn"];
                    shiftDetail.ShiftOut = (DateTime)Reader["ShiftOut"];
                    shiftDetail.ShiftLate = (DateTime)Reader["ShiftLate"];
                    shiftDetail.ShiftHr = (DateTime)Reader["ShiftHr"];
                    shiftDetail.LunchIn = (DateTime)Reader["LunchIn"];
                    shiftDetail.LunchOut = (DateTime)Reader["LunchOut"];
                    shiftDetail.LunchLate = (DateTime)Reader["LunchLate"];
                    shiftDetail.LunchHr = (DateTime)Reader["LunchHr"];

                    shiftList.Add(shiftDetail);
                }
                Reader.Close();
                ConnectionClose();
                return shiftList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get ShiftDetail List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<List<ShiftDetail>> GetShiftsListMinCol(string columns, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT " + columns + " FROM ShiftDetail";
                }
                else
                {
                    Query = "SELECT " + columns + " FROM ShiftDetail WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<ShiftDetail> shiftList = new List<ShiftDetail>();
                while (Reader.Read())
                {
                    ShiftDetail shiftDetail = new ShiftDetail();

                    SkipOnError(() => shiftDetail.ShiftTypeMasterId = (int)Reader["ShiftTypeMasterId"]);
                    SkipOnError(() => shiftDetail.ShiftName = Reader["ShiftName"].ToString());
                   // SkipOnError(() => shiftDetail.ShiftType = Reader["ShiftType"].ToString());
                    SkipOnError(() => shiftDetail.ShiftIn = (DateTime)Reader["ShiftIn"]);
                    SkipOnError(() => shiftDetail.ShiftOut = (DateTime)Reader["ShiftOut"]);
                    SkipOnError(() => shiftDetail.ShiftLate = (DateTime)Reader["ShiftLate"]);
                    SkipOnError(() => shiftDetail.ShiftHr = (DateTime)Reader["ShiftHr"]);
                    SkipOnError(() => shiftDetail.LunchIn = (DateTime)Reader["LunchIn"]);
                    SkipOnError(() => shiftDetail.LunchOut = (DateTime)Reader["LunchOut"]);
                    SkipOnError(() => shiftDetail.LunchLate = (DateTime)Reader["LunchLate"]);
                    SkipOnError(() => shiftDetail.LunchHr = (DateTime)Reader["LunchHr"]);

                    shiftList.Add(shiftDetail);
                }
                Reader.Close();
                ConnectionClose();
                return shiftList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get ShiftDetail List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }


        public async Task<int> GetShifTypeMtid(int shiftDetailId)
        {
            try
            {
                //Query = "SELECT SUM(IssuedDays) FROM Leave WHERE EmployeeId = @employeeId AND LeaveType ='ML'";
                Query = "SELECT ShiftTypeMasterId from ShiftDetail WHERE ShiftDetailId= @shiftDetailId";
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@shiftDetailId", shiftDetailId);
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
                throw new Exception($"Failed \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }



        public async Task<List<ShiftDetail>> GetGeneralNameList(string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM ShiftDetail WHERE ShiftName like '%General%'";
                }

                //else
                //{
                //    Query = "SELECT * FROM ShiftDetail WHERE ShiftName like '%General%'" + condition;
                //}

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<ShiftDetail> shiftDetailList = new List<ShiftDetail>();
                while (Reader.Read())
                {


                    ShiftDetail shiftDetail = new ShiftDetail();


                    shiftDetail.ShiftTypeMasterId = (int)Reader["ShiftTypeMasterId"];
                    shiftDetail.ShiftDetailId = (int)Reader["ShiftDetailId"];

                    shiftDetail.ShiftName = Reader["ShiftName"].ToString();

                    shiftDetail.ShiftIn = (DateTime)Reader["ShiftIn"];
                    shiftDetail.ShiftOut = (DateTime)Reader["ShiftOut"];
                    shiftDetail.ShiftLate = (DateTime)Reader["ShiftLate"];
                    shiftDetail.ShiftHr = (DateTime)Reader["ShiftHr"];
                    shiftDetail.LunchIn = (DateTime)Reader["LunchIn"];
                    shiftDetail.LunchOut = (DateTime)Reader["LunchOut"];
                    shiftDetail.LunchLate = (DateTime)Reader["LunchLate"];
                    shiftDetail.LunchHr = (DateTime)Reader["LunchHr"];

                    shiftDetailList.Add(shiftDetail);
                }
                Reader.Close();
                ConnectionClose();
                return shiftDetailList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get ShiftDetail List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }




        public async Task<int> SaveEmployeeGeneralShift(string employeeId, int shiftDetailId)
        {
            try
            {
                // SQL query to insert a new record into the EmployeeGeneralShift table
                Query = "INSERT INTO EmployeeGeneralShift (EmployeeId, ShiftDetailId) VALUES (@employeeId, @shiftDetailId)";

                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@employeeId", employeeId);
                Command.Parameters.AddWithValue("@shiftDetailId", shiftDetailId);

                ConnectionOpen();
                var result = await Command.ExecuteNonQueryAsync();
                ConnectionClose();

                // Return the number of rows affected (should be 1 if successful)
                return result;
            }
            catch (Exception exception)
            {
                throw new Exception($"Failed to save EmployeeGeneralShift\n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        //public async Task<int> SaveEmployeeGeneralShift(string employeeId, int shiftDetailId)
        //{
        //    try
        //    {
        //        string query = @"
        //    INSERT INTO EmployeeGeneralShift (EmployeeId, ShiftDetailId)
        //    VALUES (@employeeId, @shiftDetailId)
        //    SELECT CAST(SCOPE_IDENTITY() AS INT)";

        //        using (SqlCommand command = new SqlCommand(query, Connection))
        //        {
        //            command.Parameters.AddWithValue("@employeeId", employeeId);
        //            command.Parameters.AddWithValue("@shiftDetailId", shiftDetailId);

        //            ConnectionOpen();
        //            int insertedId = await (int)command.ExecuteScalarAsync();
        //            ConnectionClose();

        //            return insertedId;
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        throw new Exception($"Failed To Save Employee General Shift\n" + exception.Message);
        //    }
        //    finally
        //    {
        //        ConnectionClose();
        //    }
        //}







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
