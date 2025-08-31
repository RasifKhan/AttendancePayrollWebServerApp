using AttendancePayrollWebServerApp.Models;
using DevExpress.Xpo.DB.Helpers;
using System.Data.SqlClient;


namespace AttendancePayrollWebServerApp.Gateway
{
    public class UserRoleGateway : Gateway
    {
        public async Task<List<UserRole>> GetUserRoleList(string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM UserRole";
                }
                else
                {
                    Query = "SELECT * FROM UserRole WHERE " + condition;
                }


                Command = new SqlCommand(Query, Connection);
                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<UserRole> userRoleList = new List<UserRole>();
                while (Reader.Read())
                {
                    UserRole userRole = new UserRole();
                    userRole.RoleId = (int)Reader["RoleId"];
                    userRole.RoleName = Reader["RoleName"].ToString();
                    userRoleList.Add(userRole);
                }
                Reader.Close();
                ConnectionClose();
                return userRoleList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get UserRole List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

       
        public static async Task<List<UserRole>> GetUserRoleListStatic(string condition = "")
        {
            var gateway = new UserRoleGateway(); // use instance method
            return await gateway.GetUserRoleList(condition);
        }


























        public async Task<string> GetRoleFromDb(string roleKey)
        {
            try
            {
                Query = "SELECT RoleName FROM UserRole WHERE RoleId = @roleKey OR RoleName = @roleKey";
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@roleKey", roleKey);

                ConnectionOpen();
                var result = await Command.ExecuteScalarAsync();
                ConnectionClose();

                return result?.ToString() ?? roleKey;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get Role From DB \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        

        public static async Task<string> GetRoleFromDbStatic(string roleKey)
        {
            var gateway = new UserRoleGateway();
            return await gateway.GetRoleFromDb(roleKey);
        }

    }
}
