using AttendancePayrollWebServerApp.Models;
using AttendancePayrollWebServerApp.Pages.Department;
using AttendancePayrollWebServerApp.Pages.ShiftDetail;
using AttendancePayrollWebServerApp.UtilityClass;
using DevExpress.Xpo.DB.Helpers;
using System.Data.SqlClient;

namespace AttendancePayrollWebServerApp.Gateway
{
    public class DesignationGateway : Gateway
    {
        public async Task<Alert> Save(Designation designation, string existCondition = "")
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

                Query = "INSERT INTO Designation (DesignationName,DesignationNameBan,RankCategoryItemId,GradeCategoryItemId,AttendanceBonus,NightAllowance,HolidayAllowance,WorkType) VALUES(@designationName,@designationNameBan,@rankCategoryItemId,@gradeCategoryItemId,@attendanceBonus,@nightAllowance,@holidayAllowance,@workType)";

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@designationId", designation.DesignationId);
                Command.Parameters.AddWithValue("@designationName", designation.DesignationName);
                Command.Parameters.AddWithValue("@designationNameBan", designation.DesignationNameBan);
                Command.Parameters.AddWithValue("@rankCategoryItemId", designation.RankCategoryItemId);
                Command.Parameters.AddWithValue("@gradeCategoryItemId", designation.GradeCategoryItemId);
                Command.Parameters.AddWithValue("@attendanceBonus", designation.AttendanceBonus);
                Command.Parameters.AddWithValue("@nightAllowance", designation.NightAllowance);
                Command.Parameters.AddWithValue("@holidayAllowance", designation.HolidayAllowance);
                Command.Parameters.AddWithValue("@workType", designation.WorkType);

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

        public async Task<Alert> Edit(Designation designation, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "UPDATE Designation SET DesignationName=@designationName,DesignationNameBan=@designationNameBan,RankCategoryItemId=@rankCategoryItemId,GradeCategoryItemId=@gradeCategoryItemId,AttendanceBonus=@attendanceBonus,NightAllowance=@nightAllowance,HolidayAllowance=@holidayAllowance,WorkType=@workType WHERE DesignationId = @designationId";
                }
                else
                {
                    Query = "UPDATE Designation SET DesignationName=@designationName,DesignationNameBan=@designationNameBan,RankCategoryItemId=@rankCategoryItemId,GradeCategoryItemId=@gradeCategoryItemId,AttendanceBonus=@attendanceBonus,NightAllowance=@nightAllowance,HolidayAllowance=@holidayAllowance,WorkType=@workType WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@designationId", designation.DesignationId);
                Command.Parameters.AddWithValue("@designationName", designation.DesignationName);
                Command.Parameters.AddWithValue("@designationNameBan", designation.DesignationNameBan);
                Command.Parameters.AddWithValue("@rankCategoryItemId", designation.RankCategoryItemId);
                Command.Parameters.AddWithValue("@gradeCategoryItemId", designation.GradeCategoryItemId);
                Command.Parameters.AddWithValue("@attendanceBonus", designation.AttendanceBonus);
                Command.Parameters.AddWithValue("@nightAllowance", designation.NightAllowance);
                Command.Parameters.AddWithValue("@holidayAllowance", designation.HolidayAllowance);
                Command.Parameters.AddWithValue("@workType", designation.WorkType);

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

        public async Task<Alert> Delete(int designationId, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "DELETE Designation WHERE DesignationId = @designationId";
                }
                else
                {
                    Query = "DELETE Designation WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@designationId", designationId);

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


        //public async Task<bool> IsExist(string shiftName = "", string shiftType = "", int shiftId = 0)
        //{
        //    try
        //    {
        //        if (shiftName == "" && shiftType == "")
        //        {
        //            Query = "SELECT 1 FROM Shifts";
        //        }


        //        if (shiftName != "" && shiftType != "" && shiftId == 0) //This logic will work for creating new item
        //        {
        //            Query = $"SELECT 1 FROM Shifts WHERE ShiftName = '{shiftName}' and ShiftType= '{shiftType}'";
        //        }


        //        if (shiftName != "" && shiftType != "" && shiftId != 0)
        //        {
        //            Query = $"SELECT 1 FROM Shifts WHERE ShiftName = '{shiftName}' and ShiftType= '{shiftType}' and ShiftId <> '{shiftId}'";
        //        }





        public async Task<bool> IsExist(string designationsName = "", int designationsId = 0)
        {
            try
            {
                if (designationsName == "")
                {
                    Query = "SELECT 1 FROM Designation";
                }

                if (designationsName != "" && designationsId == 0) //This logic will work for creating new item
                {
                    Query = $"SELECT 1 FROM Designation WHERE DesignationName = '{designationsName}'";
                }


                if (designationsName != "" && designationsId != 0)
                {
                    Query = $"SELECT 1 FROM Designation WHERE DesignationName = '{designationsName}' and DesignationId <> '{designationsId}'";
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

        public async Task<Designation> GetDesignation(int designationId, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM Designation WHERE DesignationId = @designationId";
                }
                else
                {
                    Query = "SELECT * FROM Designation WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@designationId", designationId);
                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                Designation designation = new Designation();
                while (Reader.Read())
                {
                    designation.DesignationId = (int)Reader["DesignationId"];
                    designation.DesignationName = Reader["DesignationName"].ToString();
                    designation.DesignationNameBan = Reader["DesignationNameBan"].ToString();
                    designation.RankCategoryItemId = (int)Reader["RankCategoryItemId"];
                    designation.GradeCategoryItemId = (int)Reader["GradeCategoryItemId"];
                    designation.AttendanceBonus = (decimal)Reader["AttendanceBonus"];
                    designation.NightAllowance = (decimal)Reader["NightAllowance"];
                    designation.HolidayAllowance = (decimal)Reader["HolidayAllowance"];
                    designation.WorkType = Reader["WorkType"].ToString();

                }
                Reader.Close();
                ConnectionClose();
                return designation;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get Designation\n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }
        public async Task<List<Designation>> GetDesignationList(string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM Designation";
                }
                else
                {
                    Query = "SELECT * FROM Designation WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<Designation> designationList = new List<Designation>();
                while (Reader.Read())
                {
                    Designation designation = new Designation();

                    designation.DesignationId = (int)Reader["DesignationId"];
                    designation.DesignationName = Reader["DesignationName"].ToString();
                    designation.DesignationNameBan = Reader["DesignationNameBan"].ToString();
                    designation.RankCategoryItemId = (int)Reader["RankCategoryItemId"];
                    designation.GradeCategoryItemId = (int)Reader["GradeCategoryItemId"];
                    designation.AttendanceBonus = (decimal)Reader["AttendanceBonus"];
                    designation.NightAllowance = (decimal)Reader["NightAllowance"];
                    designation.HolidayAllowance = (decimal)Reader["HolidayAllowance"];
                    designation.WorkType = Reader["WorkType"].ToString();

                    designationList.Add(designation);
                }
                Reader.Close();
                ConnectionClose();
                return designationList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get Designation List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }
        public async Task<List<Designation>> GetDesignationListMinCol(string columns, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT " + columns + " FROM Designation";
                }
                else
                {
                    Query = "SELECT " + columns + " FROM Designation WHERE " + condition;
                }
                Command = new SqlCommand(Query, Connection);
                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();
                List<Designation> designationList = new List<Designation>();
                while (Reader.Read())
                {
                    Designation designation = new Designation();

                    SkipOnError(() => designation.DesignationId = (int)Reader["DesignationId"]);
                    SkipOnError(() => designation.DesignationName = Reader["DesignationName"].ToString());
                    SkipOnError(() => designation.DesignationNameBan = Reader["DesignationNameBan"].ToString());
                    SkipOnError(() => designation.RankCategoryItemId = (int)Reader["RankCategoryItemId"]);
                    SkipOnError(() => designation.GradeCategoryItemId = (int)Reader["GradeCategoryItemId"]);
                    SkipOnError(() => designation.AttendanceBonus = (decimal)Reader["AttendanceBonus"]);
                    SkipOnError(() => designation.NightAllowance = (decimal)Reader["NightAllowance"]);
                    SkipOnError(() => designation.HolidayAllowance = (decimal)Reader["HolidayAllowance"]);
                    SkipOnError(() => designation.WorkType = Reader["WorkType"].ToString());

                    designationList.Add(designation);
                }
                Reader.Close();
                ConnectionClose();
                return designationList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get Designation List \n" + exception.Message);
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
