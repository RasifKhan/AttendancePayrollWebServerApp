using AttendancePayrollWebServerApp.Models;
using AttendancePayrollWebServerApp.Pages.Department;
using AttendancePayrollWebServerApp.Pages.ShiftDetail;
using AttendancePayrollWebServerApp.UtilityClass;
using DevExpress.Xpo.DB.Helpers;
using System.Data.SqlClient;

namespace AttendancePayrollWebServerApp.Gateway
{
    public class SalaryBreakdownSetupGateway : Gateway
    {
       
        public async Task<(bool Success, string Message, string ModalHeaderClass, string ModalTitle)> 
            ExecuteSalaryProc(DateTime fromDate, DateTime toDate, DateTime payDate, string salStr)
        {
            try
            {
                ConnectionOpen();
                Command = new SqlCommand("SalaryProc", Connection);
                Command.CommandType = System.Data.CommandType.StoredProcedure;
                Command.Parameters.Add(new SqlParameter("@FromDate", fromDate));
                Command.Parameters.Add(new SqlParameter("@ToDate", toDate));
                Command.Parameters.Add(new SqlParameter("@PayDate", payDate));
                Command.Parameters.Add(new SqlParameter("@SalStr", salStr));

                await Command.ExecuteNonQueryAsync();
                return (true, "The Process executed successfully.", "bg-success text-white", "Success");
            }
            catch (Exception ex)
            {
                return (false, $"Error executing Process: {ex.Message}", "bg-danger text-white", "Error");
            }
            finally
            {
                ConnectionClose();
            }
        }


       

        public async Task<Alert> Save(SalaryBreakdownSetup salaryBreakdownSetup, string existCondition = "")
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

                Query = "INSERT INTO SalaryBreakdownSetup (EmpTypeCatItemId,BreakDwonType,BreakDownBasedON,TA,MA,FA,HR,BS) VALUES(@empTypeCatItemId,@breakDwonType,@breakDownBasedON,@tA,@mA,@fA,@hR,@bS)";

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@id", salaryBreakdownSetup.Id);
                Command.Parameters.AddWithValue("@empTypeCatItemId", salaryBreakdownSetup.EmpTypeCatItemId);
                Command.Parameters.AddWithValue("@breakDwonType", salaryBreakdownSetup.BreakDwonType);
                Command.Parameters.AddWithValue("@breakDownBasedON", salaryBreakdownSetup.BreakDownBasedON);
                Command.Parameters.AddWithValue("@tA", salaryBreakdownSetup.TA);
                Command.Parameters.AddWithValue("@mA", salaryBreakdownSetup.MA);
                Command.Parameters.AddWithValue("@fA", salaryBreakdownSetup.FA);
                Command.Parameters.AddWithValue("@hR", salaryBreakdownSetup.HR);
                Command.Parameters.AddWithValue("@bS", salaryBreakdownSetup.BS);

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


        public async Task<Alert> Edit(SalaryBreakdownSetup salaryBreakdownSetup, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "UPDATE SalaryBreakdownSetup SET EmpTypeCatItemId=@empTypeCatItemId,BreakDwonType=@breakDwonType,BreakDownBasedON=@breakDownBasedON,TA=@tA,MA=@mA,FA=@fA,HR=@hR,BS=@bS WHERE Id = @id";
                }
                else
                {
                    Query = "UPDATE SalaryBreakdownSetup SET EmpTypeCatItemId=@empTypeCatItemId,BreakDwonType=@breakDwonType,BreakDownBasedON=@breakDownBasedON,TA=@tA,MA=@mA,FA=@fA,HR=@hR,BS=@bS WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@id", salaryBreakdownSetup.Id);
                Command.Parameters.AddWithValue("@empTypeCatItemId", salaryBreakdownSetup.EmpTypeCatItemId);
                Command.Parameters.AddWithValue("@breakDwonType", salaryBreakdownSetup.BreakDwonType);
                Command.Parameters.AddWithValue("@breakDownBasedON", salaryBreakdownSetup.BreakDownBasedON);
                Command.Parameters.AddWithValue("@tA", salaryBreakdownSetup.TA);
                Command.Parameters.AddWithValue("@mA", salaryBreakdownSetup.MA);
                Command.Parameters.AddWithValue("@fA", salaryBreakdownSetup.FA);
                Command.Parameters.AddWithValue("@hR", salaryBreakdownSetup.HR);
                Command.Parameters.AddWithValue("@bS", salaryBreakdownSetup.BS);

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

        public async Task<Alert> Delete(int id, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "DELETE SalaryBreakdownSetup WHERE Id = @id";
                }
                else
                {
                    Query = "DELETE SalaryBreakdownSetup WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@id", id);

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
                    Query = "SELECT 1 FROM SalaryBreakdownSetup";
                }
                else
                {
                    Query = "SELECT 1 FROM SalaryBreakdownSetup WHERE " + condition;
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

        public async Task<SalaryBreakdownSetup> GetSalaryBreakdownSetup(int id, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM SalaryBreakdownSetup WHERE Id = @id";
                }
                else
                {
                    Query = "SELECT * FROM SalaryBreakdownSetup WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@id", id);
                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                SalaryBreakdownSetup salaryBreakdownSetup = new SalaryBreakdownSetup();
                while (Reader.Read())
                {
                    salaryBreakdownSetup.Id = (int)Reader["Id"];
                    salaryBreakdownSetup.EmpTypeCatItemId = (int)Reader["EmpTypeCatItemId"];
                    salaryBreakdownSetup.BreakDwonType = Reader["BreakDwonType"].ToString();
                    salaryBreakdownSetup.BreakDownBasedON = Reader["BreakDownBasedON"].ToString();
                    salaryBreakdownSetup.TA = (decimal)Reader["TA"];
                    salaryBreakdownSetup.MA = (decimal)Reader["MA"];
                    salaryBreakdownSetup.FA = (decimal)Reader["FA"];
                    salaryBreakdownSetup.HR = (decimal)Reader["HR"];
                    salaryBreakdownSetup.BS = (decimal)Reader["BS"];
                }
                Reader.Close();
                ConnectionClose();
                return salaryBreakdownSetup;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get SalaryBreakdownSetup\n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<List<SalaryBreakdownSetup>> GetSalaryBreakdownSetupList(string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM SalaryBreakdownSetup";
                }
                else
                {
                    Query = "SELECT * FROM SalaryBreakdownSetup WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<SalaryBreakdownSetup> salaryBreakdownSetupList = new List<SalaryBreakdownSetup>();
                while (Reader.Read())
                {
                    SalaryBreakdownSetup salaryBreakdownSetup = new SalaryBreakdownSetup();

                    salaryBreakdownSetup.Id = (int)Reader["Id"];
                    salaryBreakdownSetup.EmpTypeCatItemId = (int)Reader["EmpTypeCatItemId"];
                    salaryBreakdownSetup.BreakDwonType = Reader["BreakDwonType"].ToString();
                    salaryBreakdownSetup.BreakDownBasedON = Reader["BreakDownBasedON"].ToString();
                    salaryBreakdownSetup.TA = (decimal)Reader["TA"];
                    salaryBreakdownSetup.MA = (decimal)Reader["MA"];
                    salaryBreakdownSetup.FA = (decimal)Reader["FA"];
                    salaryBreakdownSetup.HR = (decimal)Reader["HR"];
                    salaryBreakdownSetup.BS = (decimal)Reader["BS"];

                    salaryBreakdownSetupList.Add(salaryBreakdownSetup);
                }
                Reader.Close();
                ConnectionClose();
                return salaryBreakdownSetupList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get SalaryBreakdownSetup List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<List<SalaryBreakdownSetup>> GetSalaryBreakdownSetupListMinCol(string columns, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT " + columns + " FROM SalaryBreakdownSetup";
                }
                else
                {
                    Query = "SELECT " + columns + " FROM SalaryBreakdownSetup WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<SalaryBreakdownSetup> salaryBreakdownSetupList = new List<SalaryBreakdownSetup>();
                while (Reader.Read())
                {
                    SalaryBreakdownSetup salaryBreakdownSetup = new SalaryBreakdownSetup();

                    SkipOnError(() => salaryBreakdownSetup.Id = (int)Reader["Id"]);
                    SkipOnError(() => salaryBreakdownSetup.EmpTypeCatItemId = (int)Reader["EmpTypeCatItemId"]);
                    SkipOnError(() => salaryBreakdownSetup.BreakDwonType = Reader["BreakDwonType"].ToString());
                    SkipOnError(() => salaryBreakdownSetup.BreakDownBasedON = Reader["BreakDownBasedON"].ToString());
                    SkipOnError(() => salaryBreakdownSetup.TA = (decimal)Reader["TA"]);
                    SkipOnError(() => salaryBreakdownSetup.MA = (decimal)Reader["MA"]);
                    SkipOnError(() => salaryBreakdownSetup.FA = (decimal)Reader["FA"]);
                    SkipOnError(() => salaryBreakdownSetup.HR = (decimal)Reader["HR"]);
                    SkipOnError(() => salaryBreakdownSetup.BS = (decimal)Reader["BS"]);

                    salaryBreakdownSetupList.Add(salaryBreakdownSetup);
                }
                Reader.Close();
                ConnectionClose();
                return salaryBreakdownSetupList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get SalaryBreakdownSetup List \n" + exception.Message);
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
