using AttendancePayrollWebServerApp.Models;
using AttendancePayrollWebServerApp.Pages.ShiftDetail;
using AttendancePayrollWebServerApp.UtilityClass;
using DevExpress.Xpo.DB.Helpers;
using System.Data.SqlClient;

namespace AttendancePayrollWebServerApp.Gateway
{
    public class DepartmentGateway : Gateway
    {

        public async Task<Alert> Save(Department department, string existCondition = "")
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

                Query = "INSERT INTO Department (DepartmentName,DepartmentNameBan) VALUES(@departmentName,@departmentNameBan)";

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@departmentId", department.DepartmentId);
                Command.Parameters.AddWithValue("@departmentName", department.DepartmentName);
                Command.Parameters.AddWithValue("@departmentNameBan", department.DepartmentNameBan);

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

        public async Task<Alert> Edit(Department department, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "UPDATE Department SET DepartmentName=@departmentName,DepartmentNameBan=@departmentNameBan WHERE DepartmentId = @departmentId";
                }
                else
                {
                    Query = "UPDATE Department SET DepartmentName=@departmentName,DepartmentNameBan=@departmentNameBan WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@departmentId", department.DepartmentId);
                Command.Parameters.AddWithValue("@departmentName", department.DepartmentName);
                Command.Parameters.AddWithValue("@departmentNameBan", department.DepartmentNameBan);

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

        public async Task<Alert> Delete(int departmentId, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "DELETE Department WHERE DepartmentId = @departmentId";
                }
                else
                {
                    Query = "DELETE Department WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@departmentId", departmentId);

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

        public async Task<bool> IsExist(string departmentName = "",int departmentId=0)
        {
            try
            {
                if (departmentName == "")
                {
                    Query = "SELECT 1 FROM Department";
                }
                if (departmentName !="" && departmentId ==0)
                {
                    Query = $"SELECT 1 FROM Department WHERE DepartmentName = '{departmentName}'";
                }

                if (departmentName != "" && departmentId !=0)
                {
                    Query = $"SELECT 1 FROM Department WHERE DepartmentName = '{departmentName}' and DepartmentId <> '{departmentId}'";
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


        public async Task<Department> GetDepartments(int departmentId, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM Department WHERE DepartmentId = @departmentId";
                }
                else
                {
                    Query = "SELECT * FROM Department WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@departmentId", departmentId);
                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                Department department = new Department();
                while (Reader.Read())
                {
                    department.DepartmentId = (int)Reader["DepartmentId"];
                    department.DepartmentName = Reader["DepartmentName"].ToString();
                    department.DepartmentNameBan = Reader["DepartmentNameBan"].ToString();
                }
                Reader.Close();
                ConnectionClose();
                return department;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get Department\n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<List<Department>> GetDepartmentsList(string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM Department";
                }
                else
                {
                    Query = "SELECT * FROM Department WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<Department> departmentsList = new List<Department>();
                while (Reader.Read())
                {
                    Department department = new Department();

                    department.DepartmentId = (int)Reader["DepartmentId"];
                    department.DepartmentName = Reader["DepartmentName"].ToString();
                    department.DepartmentNameBan = Reader["DepartmentNameBan"].ToString();

                    departmentsList.Add(department);
                }
                Reader.Close();
                ConnectionClose();
                return departmentsList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get Department List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<List<Department>> GetDepartmentsListMinCol(string columns, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT " + columns + " FROM Department";
                }
                else
                {
                    Query = "SELECT " + columns + " FROM Department WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<Department> departmentList = new List<Department>();
                while (Reader.Read())
                {
                    Department department = new Department();

                    SkipOnError(() => department.DepartmentId = (int)Reader["DepartmentId"]);
                    SkipOnError(() => department.DepartmentName = Reader["DepartmentName"].ToString());
                    SkipOnError(() => department.DepartmentNameBan = Reader["DepartmentNameBan"].ToString());

                    departmentList.Add(department);
                }
                Reader.Close();
                ConnectionClose();
                return departmentList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get Department List \n" + exception.Message);
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
