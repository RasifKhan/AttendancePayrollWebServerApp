using AttendancePayrollWebServerApp.Models;
using AttendancePayrollWebServerApp.Pages.CategoryAndItems;
using AttendancePayrollWebServerApp.UtilityClass;
using DevExpress.Xpo.DB.Helpers;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace AttendancePayrollWebServerApp.Gateway
{
    public class UserGateway : Gateway
    {
        public async Task<Alert> Save(User user, string existCondition = "")
        {
            string PWD = "";
            PWD = CryptoHelper.AES_Encrypt("123", "atl@Enc");

            try
            {
                Query = "INSERT INTO UserInfo (UserId,UserName,UserPassword,RoleId,Access,MobileNumber,EMail,Status) VALUES(TRIM(@userId),@userName,@userPassword,@roleId,@access,@mobileNumber,@eMail,@status)";
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@userId", user.UserId);
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








        //public async Task<Alert> Save(User user, string existCondition = "")
        //{
        //    try
        //    {
        //        Query = "INSERT INTO User (UserId,UserName,UserPassword,UserType,Access,MobileNumber,EMail,Status) VALUES(@userId,@userName,@userPassword,@userType,@access,@mobileNumber,@eMail,@status)";
        //        Command = new SqlCommand(Query, Connection);

        //        Command.Parameters.AddWithValue("@userId", user.UserId);
        //        Command.Parameters.AddWithValue("@userName", user.UserName);
        //        Command.Parameters.AddWithValue("@userPassword", user.UserPassword);
        //        Command.Parameters.AddWithValue("@userType", user.UserType);
        //        Command.Parameters.AddWithValue("@access", user.Access);
        //        Command.Parameters.AddWithValue("@mobileNumber", user.MobileNumber);
        //        Command.Parameters.AddWithValue("@eMail", user.EMail);
        //        Command.Parameters.AddWithValue("@status", user.Status);

        //        ConnectionOpen();
        //        int rowAffected = await Command.ExecuteNonQueryAsync();
        //        ConnectionClose();

        //        if (rowAffected > 0)
        //        {
        //            return new Alert("success", "Saved");
        //        }
        //        return new Alert("warning", "Not Saved");
        //    }
        //    catch (Exception exception)
        //    {
        //        return new Alert("danger", "Failed To Save\n" + exception.Message);
        //    }
        //    finally
        //    {
        //        ConnectionClose();
        //    }
        //}

        public async Task<Alert> Login(string userName, string password)
        {
            try
            {
                Query = "SELECT UserName, UserPassword, RoleId, Access, Status FROM UserInfo WHERE UserName = @userName AND Status = 'Y'";
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@userName", userName.Trim());

                ConnectionOpen();
                using var reader = await Command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    string storedPassword = reader["UserPassword"].ToString();
                    int RoleId = (int)reader["RoleId"];
                    string access = reader["Access"].ToString();

                    // Decrypt stored password and compare with input
                    string decryptedPassword = CryptoHelper.AES_Decrypt(storedPassword, "atl@Enc");

                    if (password == decryptedPassword)
                    {
                        ConnectionClose();
                        return new Alert("success", $"Login successful|{RoleId}|{access}");
                    }
                }
                ConnectionClose();
                return new Alert("error", "Invalid credentials");
            }
            catch (Exception ex)
            {
                ConnectionClose();
                return new Alert("error", "Login failed: " + ex.Message);
            }
        }
    }
}
