using AttendancePayrollWebServerApp.Models;
using AttendancePayrollWebServerApp.Pages.Department;
using AttendancePayrollWebServerApp.Pages.ShiftDetail;
using AttendancePayrollWebServerApp.UtilityClass;
using DevExpress.Xpo.DB.Helpers;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
namespace AttendancePayrollWebServerApp.Gateway
{
    public class EmployeeBankAccInfoGateway : Gateway
    {
        public async Task<Alert> Save(EmployeeBankAccInfo employeeBankAccInfo, string existCondition = "")
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
                //   TRIM(@employeeId)   TRIM(@accNo)
                string cleanedAccNo = Regex.Replace(employeeBankAccInfo.AccNo.Trim(), @"\s+", "");
                Query = "INSERT INTO EmployeeBankAccInfo (EmployeeId,BankCatItemId,BranchCatItemId,AccNo,Status,Remarks) VALUES(@employeeId,@bankCatItemId,@branchCatItemId, @accNo,@status,@remarks)";
                //Query = "INSERT INTO EmployeeBankAccInfo (EmployeeId,BankCatItemId,BranchCatItemId,AccNo,FromDate,ToDate,Remarks) VALUES(@employeeId,@bankCatItemId,@branchCatItemId,@accNo,@fromDate,@toDate,@remarks)";    Regex.Replace(accNo.Trim(), @"\s+", "")
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@infoId", employeeBankAccInfo.InfoId);
                Command.Parameters.AddWithValue("@employeeId", employeeBankAccInfo.EmployeeId);
                Command.Parameters.AddWithValue("@bankCatItemId", employeeBankAccInfo.BankCatItemId);
                //   Command.Parameters.AddWithValue("@branchCatItemId", employeeBankAccInfo.BranchCatItemId);
                Command.Parameters.AddWithValue("@branchCatItemId", (object)employeeBankAccInfo.BranchCatItemId?? DBNull.Value);
                // Command.Parameters.AddWithValue("@accNo", employeeBankAccInfo.AccNo);
                Command.Parameters.AddWithValue("@accNo", cleanedAccNo);
                Command.Parameters.AddWithValue("@status", employeeBankAccInfo.Status);
                
                Command.Parameters.AddWithValue("@remarks", employeeBankAccInfo.Remarks);
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

        public async Task<Alert> Edit(EmployeeBankAccInfo employeeBankAccInfo, string condition = "")
        {
            try
            {
                string cleanedAccNo = Regex.Replace(employeeBankAccInfo.AccNo.Trim(), @"\s+", "");
                if (condition == "")
                {
                    Query = "UPDATE EmployeeBankAccInfo SET EmployeeId=@employeeId,BankCatItemId=@bankCatItemId,BranchCatItemId=@branchCatItemId,AccNo=TRIM(@accNo),Status=@status,Remarks=@remarks WHERE InfoId = @infoId";
                }
                else
                {
                    Query = "UPDATE EmployeeBankAccInfo SET EmployeeId=@employeeId,BankCatItemId=@bankCatItemId,BranchCatItemId=@branchCatItemId,AccNo=TRIM(@accNo),Status=@status,Remarks=@remarks WHERE " + condition;
                }
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@infoId", employeeBankAccInfo.InfoId);
                Command.Parameters.AddWithValue("@employeeId", employeeBankAccInfo.EmployeeId);
                Command.Parameters.AddWithValue("@bankCatItemId", employeeBankAccInfo.BankCatItemId);
                Command.Parameters.AddWithValue("@branchCatItemId", employeeBankAccInfo.BranchCatItemId);
                // Command.Parameters.AddWithValue("@accNo", employeeBankAccInfo.AccNo);
                Command.Parameters.AddWithValue("@accNo", cleanedAccNo);
                Command.Parameters.AddWithValue("@status", employeeBankAccInfo.Status);
                Command.Parameters.AddWithValue("@remarks", employeeBankAccInfo.Remarks);
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

        public async Task<Alert> Delete(int infoId, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "DELETE EmployeeBankAccInfo WHERE InfoId = @infoId";
                }
                else
                {
                    Query = "DELETE EmployeeBankAccInfo WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@infoId", infoId);

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


        public async Task<bool> IsExist(string accNo = "", 
                                         int infoId = 0, string employeeId ="", 
                                         int bankCatItemId =0)
        {
            try
            {
                if (accNo == "")
                {
                    Query = "SELECT 1 FROM EmployeeBankAccInfo";
                }

                if (accNo != "" && infoId == 0 && employeeId !="" && bankCatItemId !=0 ) //This logic will work for creating new item
                {
                    accNo = Regex.Replace(accNo.Trim(), @"\s+", "");
                    Query = $"SELECT 1 FROM EmployeeBankAccInfo WHERE AccNo = '{accNo}' And EmployeeId='{employeeId}' And BankCatItemId='{bankCatItemId}' ";   //Trim()
                    Command = new SqlCommand(Query, Connection);
                    ConnectionOpen();
                    Reader = await Command.ExecuteReaderAsync();
                    bool exist1 = Reader.HasRows;
                    Reader.Close();
                    ConnectionClose();

                    if (exist1 == false)
                    {
                       //1st old // Query = $"SELECT 1 FROM EmployeeBankAccInfo WHERE AccNo = '{accNo}' And EmployeeId <> '{employeeId}' And BankCatItemId='{bankCatItemId}' ";                                  //Trim()
                       //2nd old // Query = $"SELECT 1 FROM EmployeeBankAccInfo WHERE AccNo = '{accNo}' And EmployeeId <> '{employeeId}' And BankCatItemId <> '{bankCatItemId}' ";                               //Trim()
                        Query = $"SELECT 1 FROM EmployeeBankAccInfo WHERE AccNo = '{accNo}' And EmployeeId <> '{employeeId}' And (BankCatItemId = '{bankCatItemId}' OR BankCatItemId <> '{bankCatItemId}') ";    //Trim()

                    }
                }

                if (infoId != 0 && accNo != "" && employeeId != "" && bankCatItemId != 0) //update
                {
                    accNo = Regex.Replace(accNo.Trim(), @"\s+", "");
                    Query = $"SELECT 1 FROM EmployeeBankAccInfo WHERE AccNo = '{accNo}' and  EmployeeId ='{employeeId}' and BankCatItemId ='{bankCatItemId}'   and InfoId <> '{infoId}'";


                    Command = new SqlCommand(Query, Connection);
                    ConnectionOpen();
                    Reader = await Command.ExecuteReaderAsync();
                    bool exist1 = Reader.HasRows;
                    Reader.Close();
                    ConnectionClose();
                    if (exist1 == false)
                    {
                        //Query = $"SELECT 1 FROM EmployeeBankAccInfo WHERE AccNo = '{accNo}' And EmployeeId <> '{employeeId}' And BankCatItemId='{bankCatItemId}' ";   //Trim()
                        Query = $"SELECT 1 FROM EmployeeBankAccInfo WHERE AccNo = '{accNo}' And EmployeeId <> '{employeeId}' And (BankCatItemId = '{bankCatItemId}' OR BankCatItemId <> '{bankCatItemId}') ";   //Trim()
                    }
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


        public async Task<bool> IsExistStatusY(string employeeId = "",
                                               int bankCatItemId = 0,
                                               string accNo = "" 
                                               )
        {
            try
            {
                if (employeeId !="" && bankCatItemId!=0 && accNo != "")
                {
                    accNo = Regex.Replace(accNo.Trim(), @"\s+", ""); 
                    Query = $"SELECT 1 FROM EmployeeBankAccInfo WHERE EmployeeId ='{employeeId}' and BankCatItemId ='{bankCatItemId}'  and (AccNo ='{accNo}' or AccNo <> '{accNo}') and Status = 'Y'";
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



        //public async Task<bool> IsExist(string accNo = "", int infoId = 0)
        //{
        //    try
        //    {
        //        if (accNo == "")
        //        {
        //            Query = "SELECT 1 FROM EmployeeBankAccInfo";
        //        }

        //        if (accNo != "" && infoId == 0) //This logic will work for creating new item
        //        {
        //            accNo = Regex.Replace(accNo.Trim(), @"\s+", "");
        //            Query = $"SELECT 1 FROM EmployeeBankAccInfo WHERE AccNo = '{accNo}'";   //Trim()
        //        }


        //        if (accNo != "" && infoId != 0)
        //        {
        //            accNo = Regex.Replace(accNo.Trim(), @"\s+", "");
        //            Query = $"SELECT 1 FROM EmployeeBankAccInfo WHERE AccNo = '{accNo}' and InfoId <> '{infoId}'";
        //        }

        //        Command = new SqlCommand(Query, Connection);

        //        ConnectionOpen();
        //        Reader = await Command.ExecuteReaderAsync();
        //        bool exist = Reader.HasRows;
        //        Reader.Close();
        //        ConnectionClose();
        //        return exist;
        //    }
        //    catch (Exception exception)
        //    {
        //        throw new Exception(exception.Message);
        //    }
        //    finally
        //    {
        //        ConnectionClose();
        //    }
        //}






        //public async Task<bool> IsExist(string condition = "")
        //{
        //    try
        //    {
        //        if (condition == "")
        //        {
        //            Query = "SELECT 1 FROM EmployeeBankAccInfo";
        //        }
        //        else
        //        {
        //            Query = "SELECT 1 FROM EmployeeBankAccInfo WHERE " + condition;
        //        }

        //        Command = new SqlCommand(Query, Connection);

        //        ConnectionOpen();
        //        Reader = await Command.ExecuteReaderAsync();
        //        bool exist = Reader.HasRows;
        //        Reader.Close();
        //        ConnectionClose();
        //        return exist;
        //    }
        //    catch (Exception exception)
        //    {
        //        throw new Exception(exception.Message);
        //    }
        //    finally
        //    {
        //        ConnectionClose();
        //    }
        //}

        public async Task<EmployeeBankAccInfo> GetEmployeeBankAccInfo(int infoId, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM EmployeeBankAccInfo WHERE InfoId = @infoId";
                }
                else
                {
                    Query = "SELECT * FROM EmployeeBankAccInfo WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@infoId", infoId);
                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                EmployeeBankAccInfo employeeBankAccInfo = new EmployeeBankAccInfo();
                while (Reader.Read())
                {
                    employeeBankAccInfo.InfoId = (int)Reader["InfoId"];
                    employeeBankAccInfo.EmployeeId = Reader["EmployeeId"].ToString();
                    employeeBankAccInfo.BankCatItemId = (int)Reader["BankCatItemId"];
                    employeeBankAccInfo.BranchCatItemId = (int)Reader["BranchCatItemId"];
                    employeeBankAccInfo.AccNo = Reader["AccNo"].ToString();

                    employeeBankAccInfo.Status = Reader["Status"].ToString();
                 
                    employeeBankAccInfo.Remarks = Reader["Remarks"].ToString();
                }
                Reader.Close();
                ConnectionClose();
                return employeeBankAccInfo;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get EmployeeBankAccInfo\n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<List<EmployeeBankAccInfo>> GetEmployeeBankAccInfoList(string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM EmployeeBankAccInfo";
                }
                else
                {
                    Query = "SELECT * FROM EmployeeBankAccInfo WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<EmployeeBankAccInfo> employeeBankAccInfoList = new List<EmployeeBankAccInfo>();
                while (Reader.Read())
                {
                    EmployeeBankAccInfo employeeBankAccInfo = new EmployeeBankAccInfo();

                    employeeBankAccInfo.InfoId = (int)Reader["InfoId"];
                    employeeBankAccInfo.EmployeeId = Reader["EmployeeId"].ToString();
                    employeeBankAccInfo.BankCatItemId = (int)Reader["BankCatItemId"];
                    employeeBankAccInfo.BranchCatItemId = (int)Reader["BranchCatItemId"];
                    employeeBankAccInfo.AccNo = Reader["AccNo"].ToString();
                    employeeBankAccInfo.Status = Reader["Status"].ToString();
                    employeeBankAccInfo.Remarks = Reader["Remarks"].ToString();

                    employeeBankAccInfoList.Add(employeeBankAccInfo);
                }
                Reader.Close();
                ConnectionClose();
                return employeeBankAccInfoList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get EmployeeBankAccInfo List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<List<EmployeeBankAccInfo>> GetEmployeeBankAccInfoListMinCol(string columns, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT " + columns + " FROM EmployeeBankAccInfo";
                }
                else
                {
                    Query = "SELECT " + columns + " FROM EmployeeBankAccInfo WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<EmployeeBankAccInfo> employeeBankAccInfoList = new List<EmployeeBankAccInfo>();
                while (Reader.Read())
                {
                    EmployeeBankAccInfo employeeBankAccInfo = new EmployeeBankAccInfo();

                    SkipOnError(() => employeeBankAccInfo.InfoId = (int)Reader["InfoId"]);
                    SkipOnError(() => employeeBankAccInfo.EmployeeId = Reader["EmployeeId"].ToString());
                    SkipOnError(() => employeeBankAccInfo.BankCatItemId = (int)Reader["BankCatItemId"]);
                    SkipOnError(() => employeeBankAccInfo.BranchCatItemId = (int)Reader["BranchCatItemId"]);
                    SkipOnError(() => employeeBankAccInfo.AccNo = Reader["AccNo"].ToString());
                    SkipOnError(() => employeeBankAccInfo.Remarks = Reader["Remarks"].ToString());
                    SkipOnError(() => employeeBankAccInfo.Status = Reader["Status"].ToString());
                    employeeBankAccInfoList.Add(employeeBankAccInfo);
                }
                Reader.Close();
                ConnectionClose();
                return employeeBankAccInfoList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get EmployeeBankAccInfo List \n" + exception.Message);
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
