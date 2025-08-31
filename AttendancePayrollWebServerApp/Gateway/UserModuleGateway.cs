using AttendancePayrollWebServerApp.Models;
using AttendancePayrollWebServerApp.UtilityClass;
using System.Data.SqlClient;

namespace AttendancePayrollWebServerApp.Gateway
{
    public class UserModuleGateway :Gateway
    {

        public async Task<Alert> Save(UserModule userModule, string existCondition = "")
        {
           

            try
            {
                Query = "INSERT INTO UserModule (ModuleName,ModulePageName) VALUES(@moduleName,@modulePageName)";
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@moduleId", userModule.ModuleId);
                Command.Parameters.AddWithValue("@moduleName", userModule.ModuleName);
                Command.Parameters.AddWithValue("@modulePageName", userModule.ModulePageName);
               

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



    }
}
