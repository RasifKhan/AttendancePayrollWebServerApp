using AttendancePayrollWebServerApp.Models;
using AttendancePayrollWebServerApp.Pages.Department;
using AttendancePayrollWebServerApp.Pages.ShiftDetail;
using AttendancePayrollWebServerApp.UtilityClass;
using DevExpress.Xpo.DB.Helpers;
using System.Data.SqlClient;

namespace AttendancePayrollWebServerApp.Gateway
{
    public class CategoryGateway : Gateway
    {

        public async Task<Alert> Save(Category category, string existCondition = "")
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

                Query = "INSERT INTO Category (CategoryName) VALUES(@categoryName)";
                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@categoryId",category.CategoryId);
                Command.Parameters.AddWithValue("@categoryName", category.CategoryName);

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

        public async Task<Alert> Edit(Category category, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "UPDATE Category SET CategoryName=@categoryName WHERE CategoryId = @categoryId";
                }
                else
                {
                    Query = "UPDATE Category SET CategoryName=@categoryName WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@categoryId", category.CategoryId);
                Command.Parameters.AddWithValue("@categoryName", category.CategoryName);

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

        public async Task<Alert> Delete(int categoryId, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "DELETE Category WHERE CategoryId = @categoryId";
                }
                else
                {
                    Query = "DELETE Category WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@categoryId", categoryId);

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




        public async Task<bool> IsExist(string categoryName = "",int categoryId=0)
        {
            try
            {
                if (categoryName == "")
                {
                    Query = "SELECT 1 FROM Category";
                }

                if (categoryName != "" && categoryId == 0)
                {
                    Query = $"SELECT 1 FROM Category WHERE CategoryName = '{categoryName}' ";
                }

                if (categoryName != "" && categoryId != 0)
                {
                    Query = $"SELECT 1 FROM Category WHERE CategoryName = '{categoryName}' and CategoryId <> '{categoryId}'";
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

        public async Task<Category> GetCategory(int categoryId, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM Category WHERE CategoryId = @categoryId";
                }
                else
                {
                    Query = "SELECT * FROM Category WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@categoryId", categoryId);
                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                Category category = new Category();
                while (Reader.Read())
                {
                    category.CategoryId = (int)Reader["CategoryId"];
                    category.CategoryName = Reader["CategoryName"].ToString();
                }
                Reader.Close();
                ConnectionClose();
                return category;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get Category\n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<List<Category>> GetCategoryList(string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM Category";
                }
                else
                {
                    Query = "SELECT * FROM Category WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<Category> categoryList = new List<Category>();
                while (Reader.Read())
                {
                    Category category = new Category();

                    category.CategoryId = (int)Reader["CategoryId"];
                    category.CategoryName = Reader["CategoryName"].ToString();

                    categoryList.Add(category);
                }
                Reader.Close();
                ConnectionClose();
                return categoryList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get Category List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<List<Category>> GetCategoryListMinCol(string columns, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT " + columns + " FROM Category";
                }
                else
                {
                    Query = "SELECT " + columns + " FROM Category WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<Category> categoryList = new List<Category>();
                while (Reader.Read())
                {
                    Category category = new Category();

                    SkipOnError(() => category.CategoryId = (int)Reader["CategoryId"]);
                    SkipOnError(() => category.CategoryName = Reader["CategoryName"].ToString());

                    categoryList.Add(category);
                }
                Reader.Close();
                ConnectionClose();
                return categoryList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get Category List \n" + exception.Message);
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
