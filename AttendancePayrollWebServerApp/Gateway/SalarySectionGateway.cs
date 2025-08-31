using AttendancePayrollWebServerApp.Models;
using AttendancePayrollWebServerApp.Pages.Company;
using AttendancePayrollWebServerApp.Pages.Department;
using AttendancePayrollWebServerApp.Pages.ShiftDetail;
using AttendancePayrollWebServerApp.UtilityClass;
using DevExpress.Xpo.DB.Helpers;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using static System.Collections.Specialized.BitVector32;

namespace AttendancePayrollWebServerApp.Gateway
{
    public class SalarySectionGateway : Gateway
    {


        public async Task<Alert> Save(SalarySection salarySection, string existCondition = "")
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

                Query = "INSERT INTO SalarySection (SalarySectionName,SalarySectionBan) VALUES(@salarySectionName,@salarySectionBan)";

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@salarySectionId", salarySection.SalarySectionId);
                Command.Parameters.AddWithValue("@salarySectionName", salarySection.SalarySectionName);
                Command.Parameters.AddWithValue("@salarySectionBan", salarySection.SalarySectionBan);

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

        public async Task<Alert> Edit(SalarySection salarySection, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "UPDATE SalarySection SET SalarySectionName=@salarySectionName,SalarySectionBan=@salarySectionBan WHERE SalarySectionId = @salarySectionId";
                }
                else
                {
                    Query = "UPDATE SalarySection SET SalarySectionName=@salarySectionName,SalarySectionBan=@salarySectionBan WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@salarySectionId", salarySection.SalarySectionId);
                Command.Parameters.AddWithValue("@salarySectionName", salarySection.SalarySectionName);
                Command.Parameters.AddWithValue("@salarySectionBan", salarySection.SalarySectionBan);

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

        public async Task<Alert> Delete(int salarySectionId, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "DELETE SalarySection WHERE SalarySectionId = @salarySectionId";
                }
                else
                {
                    Query = "DELETE SalarySection WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@salarySectionId", salarySectionId);

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



//         if (companyName == "")
//                {
//                    Query = "SELECT 1 FROM Companies";
//                }
//                if (companyName != "" && companyId == 0)
//                {
//                    Query = $"SELECT 1 FROM Companies WHERE CompanyName='{companyName}'";
//                }
//if (companyName != "" && companyId != 0)
//{
//    Query = $"SELECT 1 FROM Companies WHERE CompanyName='{companyName}' and CompanyId <> '{companyId}'";
//}






public async Task<bool> IsExist(string salSecName = "" ,int salSecId=0)
        {
            try
            {
                if (salSecName == "")
                {
                    Query = "SELECT 1 FROM SalarySection";
                }
                if (salSecName != "" && salSecId==0)
                {
                    Query = $"SELECT 1 FROM SalarySection WHERE SalarySectionName='{salSecName}' ";
                }

                if (salSecName != "" && salSecId != 0)
                {
                    Query = $"SELECT 1 FROM SalarySection WHERE SalarySectionName='{salSecName}' and SalarySectionId <> '{salSecId}' ";
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

        public async Task<SalarySection> GetSalarySection(int salarySectionId, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM SalarySection WHERE SalarySectionId = @salarySectionId";
                }
                else
                {
                    Query = "SELECT * FROM SalarySection WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@salarySectionId", salarySectionId);
                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                SalarySection salarySection = new SalarySection();
                while (Reader.Read())
                {
                    salarySection.SalarySectionId = (int)Reader["SalarySectionId"];
                    salarySection.SalarySectionName = Reader["SalarySectionName"].ToString();
                    salarySection.SalarySectionBan = Reader["SalarySectionBan"].ToString();
                }
                Reader.Close();
                ConnectionClose();
                return salarySection;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get SalarySection\n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<List<SalarySection>> GetSalarySectionList(string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM SalarySection";
                }
                else
                {
                    Query = "SELECT * FROM SalarySection WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<SalarySection> salarySectionList = new List<SalarySection>();
                while (Reader.Read())
                {
                    SalarySection salarySection = new SalarySection();

                    salarySection.SalarySectionId = (int)Reader["SalarySectionId"];
                    salarySection.SalarySectionName = Reader["SalarySectionName"].ToString();
                    salarySection.SalarySectionBan = Reader["SalarySectionBan"].ToString();

                    salarySectionList.Add(salarySection);
                }
                Reader.Close();
                ConnectionClose();
                return salarySectionList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get SalarySection List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<List<SalarySection>> GetSalarySectionListMinCol(string columns, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT " + columns + " FROM SalarySection";
                }
                else
                {
                    Query = "SELECT " + columns + " FROM SalarySection WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<SalarySection> salarySectionList = new List<SalarySection>();
                while (Reader.Read())
                {
                    SalarySection salarySection = new SalarySection();

                    SkipOnError(() => salarySection.SalarySectionId = (int)Reader["SalarySectionId"]);
                    SkipOnError(() => salarySection.SalarySectionName = Reader["SalarySectionName"].ToString());
                    SkipOnError(() => salarySection.SalarySectionBan = Reader["SalarySectionBan"].ToString());

                    salarySectionList.Add(salarySection);
                }
                Reader.Close();
                ConnectionClose();
                return salarySectionList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get SalarySection List \n" + exception.Message);
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
