using AttendancePayrollWebServerApp.Models;
using AttendancePayrollWebServerApp.UtilityClass;
using DevExpress.Xpo.DB.Helpers;
using System.Data.SqlClient;

namespace AttendancePayrollWebServerApp.Gateway
{
    public class ShiftMasterGateway : Gateway
    {






        public async Task<Alert> Save(ShiftMaster shiftMaster, string existCondition = "")
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

                Query = "INSERT INTO ShiftMaster (ShiftType) VALUES(TRIM(@shiftType))";

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@shiftTypeMasterId", shiftMaster.ShiftTypeMasterId);
                Command.Parameters.AddWithValue("@shiftType", shiftMaster.ShiftType);

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

        public async Task<Alert> Edit(ShiftMaster shiftMaster, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "UPDATE ShiftMaster SET ShiftType=TRIM(@shiftType) WHERE ShiftTypeMasterId = @shiftTypeMasterId";
                }
                else
                {
                    Query = "UPDATE ShiftMaster SET ShiftType=TRIM(@shiftType) WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@shiftTypeMasterId", shiftMaster.ShiftTypeMasterId);
                Command.Parameters.AddWithValue("@shiftType", shiftMaster.ShiftType);

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

        public async Task<Alert> Delete(int shiftTypeMasterId, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "DELETE ShiftMaster WHERE ShiftTypeMasterId = @shiftTypeMasterId";
                }
                else
                {
                    Query = "DELETE ShiftMaster WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@shiftTypeMasterId", shiftTypeMasterId);

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



        //public async Task<bool> IsExist(string condition = "")
        //{
        //    try
        //    {
        //        if (condition == "")
        //        {
        //            Query = "SELECT 1 FROM ShiftMaster";
        //        }
        //        else
        //        {
        //            Query = "SELECT 1 FROM ShiftMaster WHERE " + condition;
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



        public async Task<bool> IsExist(string shiftType = "", int shiftTypeMasterId = 0)
        {
            try
            {
                if (shiftType == "")
                {
                    Query = "SELECT 1 FROM ShiftMaster";
                }

                if (shiftType != "" && shiftTypeMasterId == 0)
                {
                    Query = $"SELECT 1 FROM ShiftMaster WHERE ShiftType = TRIM('{shiftType}') ";
                }

                if (shiftType != "" && shiftTypeMasterId != 0)
                {
                    Query = $"SELECT 1 FROM ShiftMaster WHERE ShiftType = TRIM('{shiftType}') and ShiftTypeMasterId <> '{shiftTypeMasterId}'";
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



        public async Task<ShiftMaster> GetShiftMaster(int shiftTypeMasterId, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM ShiftMaster WHERE ShiftTypeMasterId = @shiftTypeMasterId";
                }
                else
                {
                    Query = "SELECT * FROM ShiftMaster WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@shiftTypeMasterId", shiftTypeMasterId);
                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                ShiftMaster shiftMaster = new ShiftMaster();
                while (Reader.Read())
                {
                    shiftMaster.ShiftTypeMasterId = (int)Reader["ShiftTypeMasterId"];
                    shiftMaster.ShiftType = Reader["ShiftType"].ToString();
                }
                Reader.Close();
                ConnectionClose();
                return shiftMaster;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get ShiftMaster\n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<List<ShiftMaster>> GetShiftMasterList(string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM ShiftMaster";
                }
                else
                {
                    Query = "SELECT * FROM ShiftMaster WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<ShiftMaster> shiftMasterList = new List<ShiftMaster>();
                while (Reader.Read())
                {
                    ShiftMaster shiftMaster = new ShiftMaster();

                    shiftMaster.ShiftTypeMasterId = (int)Reader["ShiftTypeMasterId"];
                    shiftMaster.ShiftType = Reader["ShiftType"].ToString();

                    shiftMasterList.Add(shiftMaster);
                }
                Reader.Close();
                ConnectionClose();
                return shiftMasterList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get ShiftMaster List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }




        public async Task<List<ShiftMaster>> GetTypeShiftingList(string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    //Query = "SELECT * FROM ShiftMaster WHERE ShiftType <> 'General'";

                    Query = "SELECT * FROM ShiftMaster WHERE ShiftType Not Like '%General%'";
                }

                else
                {
                    Query = "SELECT * FROM ShiftMaster WHERE ShiftType <>" + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<ShiftMaster> shiftMasterList = new List<ShiftMaster>();
                while (Reader.Read())
                {
                    ShiftMaster shiftMaster = new ShiftMaster();

                    shiftMaster.ShiftTypeMasterId = (int)Reader["ShiftTypeMasterId"];
                    shiftMaster.ShiftType = Reader["ShiftType"].ToString();

                    shiftMasterList.Add(shiftMaster);
                }
                Reader.Close();
                ConnectionClose();
                return shiftMasterList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get ShiftMaster List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<List<ShiftMaster>> GetShiftMasterListMinCol(string columns, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT " + columns + " FROM ShiftMaster";
                }
                else
                {
                    Query = "SELECT " + columns + " FROM ShiftMaster WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<ShiftMaster> shiftMasterList = new List<ShiftMaster>();
                while (Reader.Read())
                {
                    ShiftMaster shiftMaster = new ShiftMaster();

                    SkipOnError(() => shiftMaster.ShiftTypeMasterId = (int)Reader["ShiftTypeMasterId"]);
                    SkipOnError(() => shiftMaster.ShiftType = Reader["ShiftType"].ToString());

                    shiftMasterList.Add(shiftMaster);
                }
                Reader.Close();
                ConnectionClose();
                return shiftMasterList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get ShiftMaster List \n" + exception.Message);
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
