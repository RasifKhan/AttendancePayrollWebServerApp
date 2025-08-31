using AttendancePayrollWebServerApp.Models;
using AttendancePayrollWebServerApp.UtilityClass;
using DevExpress.Xpo.DB.Helpers;
using System.Data.SqlClient;

namespace AttendancePayrollWebServerApp.Gateway
{
    public class UserAccountGateway: Gateway
    {

        public async Task<List<UserAccount>> GetUserAccountList(string condition = "")
        {
            try
            {

                if (condition == "")
                {
                    Query = "SELECT * FROM UserAccount";
                }
                else
                {
                    Query = "SELECT * FROM UserAccount WHERE " + condition;
                }


                Command = new SqlCommand(Query, Connection);
                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<UserAccount> userAccountList = new List<UserAccount>();
                while (Reader.Read())
                {
                    UserAccount userAccount = new UserAccount();
                    userAccount.UserAccountId = Reader["UserAccountId"].ToString();

                    // userAccount.UserAccountId = (int)Reader["UserAccountId"];
                    userAccount.UserName = Reader["UserName"].ToString();
                    userAccount.Password = Reader["Password"].ToString();
                    userAccountList.Add(userAccount);
                }
                Reader.Close();
                ConnectionClose();
                return userAccountList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get UserAccount List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }




        public async Task<Alert> Save(UserAccount user, string existCondition = "")
        {
            string PWD = "";
            PWD = CryptoHelper.AES_Encrypt("123", "atl@Enc");

            try
            {
                Query = "INSERT INTO UserAccount (UserAccountId,UserName,Password,RoleId,Access,MobileNumber,EMail,Status) VALUES(TRIM(@userAccountId),@userName,@userPassword,@roleId,@access,@mobileNumber,@eMail,@status)";
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@UserAccountId", user.UserAccountId);
                Command.Parameters.AddWithValue("@userName", user.UserName);
                Command.Parameters.AddWithValue("@userPassword", PWD);
                Command.Parameters.AddWithValue("@roleId", user.RoleId);
                Command.Parameters.AddWithValue("@access", user.Access);
                Command.Parameters.AddWithValue("@mobileNumber", user.MobileNumber);
                Command.Parameters.AddWithValue("@eMail", user.EMail);
                Command.Parameters.AddWithValue("@status", user.Status);

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

        public async Task<string> Login(string userName, string password)
        {
            try
            {
                Query = "SELECT UserName, Password, RoleId, Access, Status FROM UserAccount WHERE UserName = @userName AND Status = 'Y'";
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@userName", userName.Trim());
                ConnectionOpen();
                using var reader = await Command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    string storedPassword = reader["Password"].ToString();
                    int RoleId = (int)reader["RoleId"];
                    string access = reader["Access"].ToString();

                    // Decrypt stored password and compare with input
                    string decryptedPassword = CryptoHelper.AES_Decrypt(storedPassword, "atl@Enc");

                    if (password == decryptedPassword)
                    {
                        ConnectionClose();
                        return new string("succeed");
                    }
                }
                ConnectionClose();
                return new string("failed");
            }
            catch (Exception ex)
            {
                ConnectionClose();
                return new string( "Login failed: " + ex.Message);
            }
        }


        //public async Task<Alert> Login(string userName, string password)
        //{
        //    try
        //    {
        //        Query = "SELECT UserName, Password, RoleId, Access, Status FROM UserAccount WHERE UserName = @userName AND Status = 'Y'";
        //        Command = new SqlCommand(Query, Connection);
        //        Command.Parameters.AddWithValue("@userName", userName.Trim());
        //        ConnectionOpen();
        //        using var reader = await Command.ExecuteReaderAsync();

        //        if (await reader.ReadAsync())
        //        {
        //            string storedPassword = reader["Password"].ToString();
        //            int RoleId = (int)reader["RoleId"];
        //            string access = reader["Access"].ToString();

        //            // Decrypt stored password and compare with input
        //            string decryptedPassword = CryptoHelper.AES_Decrypt(storedPassword, "atl@Enc");

        //            if (password == decryptedPassword)
        //            {
        //                ConnectionClose();
        //                return new Alert("success", $"Login successful|{RoleId}|{access}");
        //            }
        //        }
        //        ConnectionClose();
        //        return new Alert("error", "Invalid credentials");
        //    }
        //    catch (Exception ex)
        //    {
        //        ConnectionClose();
        //        return new Alert("error", "Login failed: " + ex.Message);
        //    }
        //}



    }
}
