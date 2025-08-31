using AttendancePayrollWebServerApp.Models;
using AttendancePayrollWebServerApp.Pages;
using AttendancePayrollWebServerApp.Pages.CategoryAndItems;
using AttendancePayrollWebServerApp.Pages.Department;
using AttendancePayrollWebServerApp.Pages.ShiftDetail;
using AttendancePayrollWebServerApp.UtilityClass;
using System.Data.SqlClient;

namespace AttendancePayrollWebServerApp.Gateway
{
    public class CompanyGateway : Gateway
    {



        public async Task<Alert> Save(Company company, string existCondition = "")
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

                Query = "INSERT INTO Company (CompanyName,CompNameBan,Description,DescriptionBan,Contact,HotLine,CompReg) VALUES(@companyName,@compNameBan,@description,@descriptionBan,@contact,@hotLine,@compReg)";

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@companyId", company.CompanyId);
                Command.Parameters.AddWithValue("@companyName", company.CompanyName);
                Command.Parameters.AddWithValue("@compNameBan", company.CompNameBan);
                Command.Parameters.AddWithValue("@description", company.Description);
                Command.Parameters.AddWithValue("@descriptionBan", company.DescriptionBan);
                Command.Parameters.AddWithValue("@contact", company.Contact);
                Command.Parameters.AddWithValue("@hotLine", company.HotLine);
                Command.Parameters.AddWithValue("@compReg", company.CompReg);

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


        public async Task<List<Company>> Gridtest()
        {
            List<Company> companyList = new List<Company>();

            try
            {
                Query = "SELECT CompanyId, CompanyName, CompNameBan, Description, DescriptionBan, Contact, HotLine, CompReg FROM Company";
                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                while (await Reader.ReadAsync())
                {
                    Company company = new Company
                    {
                        CompanyId = Convert.ToInt32(Reader["CompanyId"]),
                        CompanyName = Reader["CompanyName"].ToString(),
                        CompNameBan = Reader["CompNameBan"].ToString(),
                        Description = Reader["Description"].ToString(),
                        DescriptionBan = Reader["DescriptionBan"].ToString(),
                        Contact = Reader["Contact"].ToString(),
                        HotLine = Reader["HotLine"].ToString(),
                        CompReg = Reader["CompReg"].ToString()
                    };

                    companyList.Add(company);
                }

                Reader.Close();
            }
            catch (Exception ex)
            {
                // Log or handle error as needed
                throw new Exception("Failed to load company list\n" + ex.Message);
            }
            finally
            {
                ConnectionClose();
            }

            return companyList;
        }



        public async Task<Alert> InsertCompanyAsyncGridTest(Company company)
        {
            try
            {
                Query = @"INSERT INTO Company 
                    (CompanyName, CompNameBan, Description, DescriptionBan, Contact, HotLine, CompReg) 
                  VALUES 
                    (@companyName, @compNameBan, @description, @descriptionBan, @contact, @hotLine, @compReg)";

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@companyName", company.CompanyName);
                Command.Parameters.AddWithValue("@compNameBan", company.CompNameBan);
                Command.Parameters.AddWithValue("@description", company.Description);
                Command.Parameters.AddWithValue("@descriptionBan", company.DescriptionBan);
                Command.Parameters.AddWithValue("@contact", company.Contact);
                Command.Parameters.AddWithValue("@hotLine", company.HotLine);
                Command.Parameters.AddWithValue("@compReg", company.CompReg);

                ConnectionOpen();
                int rowAffected = await Command.ExecuteNonQueryAsync();
                ConnectionClose();

                if (rowAffected > 0)
                {
                    return new Alert("success", "Company inserted successfully.");
                }

                return new Alert("warning", "Insert failed.");
            }
            catch (Exception ex)
            {
                return new Alert("danger", "Failed to insert company\n" + ex.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }



        public async Task<Alert> RemoveCompanyAsyncGridTest(Company company)
        {
            try
            {
                Query = "DELETE FROM Company WHERE CompanyId = @companyId";

                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@companyId", company.CompanyId);

                ConnectionOpen();
                int rowAffected = await Command.ExecuteNonQueryAsync();
                ConnectionClose();

                if (rowAffected > 0)
                {
                    return new Alert("success", "Company deleted successfully.");
                }

                return new Alert("warning", "Delete failed. Company not found.");
            }
            catch (Exception ex)
            {
                return new Alert("danger", "Failed to delete company\n" + ex.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }


        public async Task<Alert> UpdateCompanyAsyncGridTest(Company originalItem, Company changedItem)
        {
            try
            {
                Query = @"UPDATE Company SET 
                    CompanyName = @companyName,
                    CompNameBan = @compNameBan,
                    Description = @description,
                    DescriptionBan = @descriptionBan,
                    Contact = @contact,
                    HotLine = @hotLine,
                    CompReg = @compReg
                    WHERE CompanyId = @companyId";

                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@companyId", originalItem.CompanyId); // Assuming ID is from the original item
                Command.Parameters.AddWithValue("@companyName", changedItem.CompanyName);
                Command.Parameters.AddWithValue("@compNameBan", changedItem.CompNameBan);
                Command.Parameters.AddWithValue("@description", changedItem.Description);
                Command.Parameters.AddWithValue("@descriptionBan", changedItem.DescriptionBan);
                Command.Parameters.AddWithValue("@contact", changedItem.Contact);
                Command.Parameters.AddWithValue("@hotLine", changedItem.HotLine);
                Command.Parameters.AddWithValue("@compReg", changedItem.CompReg);

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





        public async Task<Alert> Edit(Company company, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "UPDATE Company SET CompanyName=@companyName,CompNameBan=@compNameBan,Description=@description,DescriptionBan=@descriptionBan,Contact=@contact,HotLine=@hotLine,CompReg=@compReg WHERE CompanyId = @companyId";
                }
                else
                {
                    Query = "UPDATE Company SET CompanyName=@companyName,CompNameBan=@compNameBan,Description=@description,DescriptionBan=@descriptionBan,Contact=@contact,HotLine=@hotLine,CompReg=@compReg WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@companyId", company.CompanyId);
                Command.Parameters.AddWithValue("@companyName", company.CompanyName);
                Command.Parameters.AddWithValue("@compNameBan", company.CompNameBan);
                Command.Parameters.AddWithValue("@description", company.Description);
                Command.Parameters.AddWithValue("@descriptionBan", company.DescriptionBan);
                Command.Parameters.AddWithValue("@contact", company.Contact);
                Command.Parameters.AddWithValue("@hotLine", company.HotLine);
                Command.Parameters.AddWithValue("@compReg", company.CompReg);

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

        public async Task<Alert> Delete(int companyId, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "DELETE Company WHERE CompanyId = @companyId";
                }
                else
                {
                    Query = "DELETE Company WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@companyId", companyId);

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
        public async Task<bool> IsExist(string companyName = "",int companyId=0)
        {
            try
            {
                if (companyName == "")
                {
                    Query = "SELECT 1 FROM Company";
                }
                if (companyName != "" && companyId == 0)
                {
                    Query = $"SELECT 1 FROM Company WHERE CompanyName='{companyName}'";
                }

                if (companyName != "" && companyId != 0)
                {
                    Query = $"SELECT 1 FROM Company WHERE CompanyName='{companyName}' and CompanyId <> '{companyId}'";
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

        public async Task<Company> GetCompany(int companyId, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM Company WHERE CompanyId = @companyId";
                }
                else
                {
                    Query = "SELECT * FROM Company WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@companyId", companyId);
                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                Company company = new Company();
                while (Reader.Read())
                {
                    company.CompanyId = (int)Reader["CompanyId"];
                    company.CompanyName = Reader["CompanyName"].ToString();
                    company.CompNameBan = Reader["CompNameBan"].ToString();
                    company.Description = Reader["Description"].ToString();
                    company.DescriptionBan = Reader["DescriptionBan"].ToString();
                    company.Contact = Reader["Contact"].ToString();
                    company.HotLine = Reader["HotLine"].ToString();
                    company.CompReg = Reader["CompReg"].ToString();
                }
                Reader.Close();
                ConnectionClose();
                return company;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get Company\n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<List<Company>> GetCompanyList(string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM Company";
                }
                else
                {
                    Query = "SELECT * FROM Company WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<Company> companyList = new List<Company>();
                while (Reader.Read())
                {
                    Company company = new Company();

                    company.CompanyId = (int)Reader["CompanyId"];
                    company.CompanyName = Reader["CompanyName"].ToString();
                    company.CompNameBan = Reader["CompNameBan"].ToString();
                    company.Description = Reader["Description"].ToString();
                    company.DescriptionBan = Reader["DescriptionBan"].ToString();
                    company.Contact = Reader["Contact"].ToString();
                    company.HotLine = Reader["HotLine"].ToString();
                    company.CompReg = Reader["CompReg"].ToString();

                    companyList.Add(company);
                }
                Reader.Close();
                ConnectionClose();
                return companyList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get Company List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<List<Company>> GetCompanyListMinCol(string columns, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT " + columns + " FROM Company";
                }
                else
                {
                    Query = "SELECT " + columns + " FROM Company WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<Company> companyList = new List<Company>();
                while (Reader.Read())
                {
                    Company company = new Company();

                    SkipOnError(() => company.CompanyId = (int)Reader["CompanyId"]);
                    SkipOnError(() => company.CompanyName = Reader["CompanyName"].ToString());
                    SkipOnError(() => company.CompNameBan = Reader["CompNameBan"].ToString());
                    SkipOnError(() => company.Description = Reader["Description"].ToString());
                    SkipOnError(() => company.DescriptionBan = Reader["DescriptionBan"].ToString());
                    SkipOnError(() => company.Contact = Reader["Contact"].ToString());
                    SkipOnError(() => company.HotLine = Reader["HotLine"].ToString());
                    SkipOnError(() => company.CompReg = Reader["CompReg"].ToString());

                    companyList.Add(company);
                }
                Reader.Close();
                ConnectionClose();
                return companyList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get Company List \n" + exception.Message);
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
