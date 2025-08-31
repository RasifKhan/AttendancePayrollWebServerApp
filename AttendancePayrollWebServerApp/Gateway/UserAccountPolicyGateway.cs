using AttendancePayrollWebServerApp.Models;
using System.Data.SqlClient;

namespace AttendancePayrollWebServerApp.Gateway
{
    public class UserAccountPolicyGateway : Gateway
    {
        public async Task<List<UserAccountPolicy>> GetUserAccountPolicyList(string condition = "")
        {
            List<UserAccountPolicy> userAccountPolicyList = new List<UserAccountPolicy>();

            try
            {
                if (string.IsNullOrEmpty(condition))
                {
                    Query = "SELECT * FROM UserAccountPolicy";
                }
                else
                {
                    Query = "SELECT * FROM UserAccountPolicy WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);
                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                while (Reader.Read())
                {
                    UserAccountPolicy userAccountPolicy = new UserAccountPolicy();
                    userAccountPolicy.PolicyId = Reader["PolicyId"] as int? ?? 0;

                    var userAccountIdValue = Reader["UserAccountId"];
                    userAccountPolicy.UserAccountId = userAccountIdValue == DBNull.Value ? null : userAccountIdValue?.ToString();

                    var userPolicyValue = Reader["UserPolicy"];
                    userAccountPolicy.UserPolicy = userPolicyValue == DBNull.Value ? null : userPolicyValue?.ToString();

                    var isEnabledValue = Reader["IsEnabled"];
                    userAccountPolicy.IsEnabled = isEnabledValue != DBNull.Value && Convert.ToBoolean(isEnabledValue);

                    var userModule = Reader["Module"];
                    userAccountPolicy.Module = userModule == DBNull.Value ? null : userModule?.ToString();

                    userAccountPolicyList.Add(userAccountPolicy);
                }

                return userAccountPolicyList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get UserAccountPolicy List \n" + exception.Message);
            }
            finally
            {
                if (Reader != null && !Reader.IsClosed)
                {
                    Reader.Close();
                }
                ConnectionClose();
            }
        }
    }
}





//using AttendancePayrollWebServerApp.Models;
//using System.Data.SqlClient;

//namespace AttendancePayrollWebServerApp.Gateway
//{
//    public class UserAccountPolicyGateway : Gateway
//    {

//        public async Task<List<UserAccountPolicy>> GetUserAccountPolicyList(string condition = "")
//        {
//            try
//            {

//                if (condition == "")
//                {
//                    Query = "SELECT * FROM UserAccountPolicy";
//                }
//                else
//                {
//                    Query = "SELECT * FROM UserAccountPolicy WHERE " + condition;
//                }


//                Command = new SqlCommand(Query, Connection);
//                ConnectionOpen();
//                Reader = await Command.ExecuteReaderAsync();

//                List<UserAccountPolicy> userAccountPolicyList = new List<UserAccountPolicy>();
//                while (Reader.Read())
//                {
//                    UserAccountPolicy userAccountPolicy = new UserAccountPolicy();

//                    userAccountPolicy.PolicyId = (int)Reader["PolicyId"];
//                    userAccountPolicy.UserAccountId = (int)Reader["UserAccountId"];
//                    userAccountPolicy.UserPolicy = Reader["UserPolicy"].ToString();
//                    userAccountPolicy.IsEnabled = Convert.ToBoolean(Reader["IsEnabled"]);

//                    userAccountPolicyList.Add(userAccountPolicy);
//                }
//                Reader.Close();
//                ConnectionClose();
//                return userAccountPolicyList;
//            }
//            catch (Exception exception)
//            {
//                throw new Exception("Failed To Get UserAccountPolicy List \n" + exception.Message);
//            }
//            finally
//            {
//                ConnectionClose();
//            }
//        }
//    }
//}
