using AttendancePayrollWebServerApp.Models;
using AttendancePayrollWebServerApp.Pages.Department;
using AttendancePayrollWebServerApp.Pages.ShiftDetail;
using AttendancePayrollWebServerApp.UtilityClass;
using DevExpress.Xpo.DB.Helpers;
using System.Data.SqlClient;
using static System.Collections.Specialized.BitVector32;

namespace AttendancePayrollWebServerApp.Gateway
{
    public class SectionGateway : Gateway
    {

        public async Task<Alert> Save(AttendancePayrollWebServerApp.Models.Section  section, string existCondition = "")
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

                Query = "INSERT INTO Section (SectionName,SectionNameBan) VALUES(@sectionName,@sectionNameBan)";

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@sectionId", section.SectionId);
                Command.Parameters.AddWithValue("@sectionName", section.SectionName);
                Command.Parameters.AddWithValue("@sectionNameBan", section.SectionNameBan);

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

        public async Task<Alert> Edit(AttendancePayrollWebServerApp.Models.Section section, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "UPDATE Section SET SectionName=@sectionName,SectionNameBan=@sectionNameBan WHERE SectionId = @sectionId";
                }
                else
                {
                    Query = "UPDATE Section SET SectionName=@sectionName,SectionNameBan=@sectionNameBan WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@sectionId", section.SectionId);
                Command.Parameters.AddWithValue("@sectionName", section.SectionName);
                Command.Parameters.AddWithValue("@sectionNameBan", section.SectionNameBan);

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

        public async Task<Alert> Delete(int sectionId, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "DELETE Section WHERE SectionId = @sectionId";
                }
                else
                {
                    Query = "DELETE Section WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@sectionId", sectionId);

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

        public async Task<bool> IsExist(string sectionName = "",int sectionId=0)
        {
            try
            {
                if (sectionName == "")
                {
                    Query = "SELECT 1 FROM Section";
                }

                if(sectionName != "" && sectionId ==0)
                {
                    Query = $"SELECT 1 FROM Section WHERE SectionName='{sectionName}' ";
                }

                if (sectionName != "" && sectionId != 0)
                {
                    Query = $"SELECT 1 FROM Section WHERE SectionName='{sectionName}' and SectionId <> '{sectionId}' ";
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

        public async Task<AttendancePayrollWebServerApp.Models.Section> GetSection(int sectionId, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM Section WHERE SectionId = @sectionId";
                }
                else
                {
                    Query = "SELECT * FROM Section WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@sectionId", sectionId);
                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                AttendancePayrollWebServerApp.Models.Section section = new AttendancePayrollWebServerApp.Models.Section();
                while (Reader.Read())
                {
                    section.SectionId = (int)Reader["SectionId"];
                    section.SectionName = Reader["SectionName"].ToString();
                    section.SectionNameBan = Reader["SectionNameBan"].ToString();
                }
                Reader.Close();
                ConnectionClose();
                return section;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get Section\n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<List<AttendancePayrollWebServerApp.Models.Section>> GetSectionList(string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM Section";
                }
                else
                {
                    Query = "SELECT * FROM Section WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<AttendancePayrollWebServerApp.Models.Section> sectionList = new List<AttendancePayrollWebServerApp.Models.Section>();
                while (Reader.Read())
                {
                    AttendancePayrollWebServerApp.Models.Section section = new AttendancePayrollWebServerApp.Models.Section();

                    section.SectionId = (int)Reader["SectionId"];
                    section.SectionName = Reader["SectionName"].ToString();
                    section.SectionNameBan = Reader["SectionNameBan"].ToString();

                    sectionList.Add(section);
                }
                Reader.Close();
                ConnectionClose();
                return sectionList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get Section List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<List<AttendancePayrollWebServerApp.Models.Section>> GetSectionListMinCol(string columns, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT " + columns + " FROM Section";
                }
                else
                {
                    Query = "SELECT " + columns + " FROM Section WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<AttendancePayrollWebServerApp.Models.Section> sectionList = new List<AttendancePayrollWebServerApp.Models.Section>();
                while (Reader.Read())
                {
                    AttendancePayrollWebServerApp.Models.Section section = new AttendancePayrollWebServerApp.Models.Section();

                    SkipOnError(() => section.SectionId = (int)Reader["SectionId"]);
                    SkipOnError(() => section.SectionName = Reader["SectionName"].ToString());
                    SkipOnError(() => section.SectionNameBan = Reader["SectionNameBan"].ToString());

                    sectionList.Add(section);
                }
                Reader.Close();
                ConnectionClose();
                return sectionList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get Section List \n" + exception.Message);
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
