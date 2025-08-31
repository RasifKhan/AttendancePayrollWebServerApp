using AttendancePayrollWebServerApp.Models;
using AttendancePayrollWebServerApp.Pages.CategoryAndItems;
using AttendancePayrollWebServerApp.Pages.Department;
using AttendancePayrollWebServerApp.Pages.ShiftDetail;
using AttendancePayrollWebServerApp.UtilityClass;
using DevExpress.Xpo.DB.Helpers;
using System.Data.SqlClient;

namespace AttendancePayrollWebServerApp.Gateway
{
    public class CategoryItemGateway : Gateway
    {

        public async Task<Alert> Save(CategoryItem categoryItem, string existCondition = "")
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

                Query = "INSERT INTO CategoryItem (CategoryId,CategoryItemName,CategoryItemNameBan) VALUES(@categoryId,@categoryItemName,@categoryItemNameBan)";

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@categoryItemId", categoryItem.CategoryItemId);
                Command.Parameters.AddWithValue("@categoryId", categoryItem.CategoryId);
                Command.Parameters.AddWithValue("@categoryItemName", categoryItem.CategoryItemName);
                Command.Parameters.AddWithValue("@categoryItemNameBan", categoryItem.CategoryItemNameBan);

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

        public async Task<Alert> Edit(CategoryItem categoryItem, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "UPDATE CategoryItem SET CategoryId=@categoryId,CategoryItemName=@categoryItemName,CategoryItemNameBan=@categoryItemNameBan WHERE CategoryItemId = @categoryItemId";
                }
                else
                {
                    Query = "UPDATE CategoryItem SET CategoryId=@categoryId,CategoryItemName=@categoryItemName,CategoryItemNameBan=@categoryItemNameBan WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@categoryItemId", categoryItem.CategoryItemId);
                Command.Parameters.AddWithValue("@categoryId", categoryItem.CategoryId);
                Command.Parameters.AddWithValue("@categoryItemName", categoryItem.CategoryItemName);
                Command.Parameters.AddWithValue("@categoryItemNameBan", categoryItem.CategoryItemNameBan);

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

        public async Task<Alert> Delete(int categoryItemId, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "DELETE CategoryItem WHERE CategoryItemId = @categoryItemId";
                }
                else
                {
                    Query = "DELETE CategoryItem WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.AddWithValue("@categoryItemId", categoryItemId);

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


            //if (categoryName == "")
            //    {
            //        Query = "SELECT 1 FROM Categories";
            //    }

            //    if (categoryName != "" && categoryId == 0)
            //    {
            //        Query = $"SELECT 1 FROM Categories WHERE CategoryName = '{categoryName}' ";
            //    }

            //if (categoryName != "" && categoryId != 0)
            //{
            //    Query = $"SELECT 1 FROM Categories WHERE CategoryName = '{categoryName}' and CategoryId <> '{categoryId}'";
            //}



        public async Task<bool> IsExist(string categoryItemName = "",int categoryItemId=0,int categoryId =0)
        {
            try
            {
                if (categoryItemName == "")
                {
                    Query = "SELECT 1 FROM CategoryItem";
                }
                if (categoryItemName != "" && categoryId !=0 && categoryItemId == 0)
                {
                    Query = $"SELECT 1 FROM CategoryItem WHERE CategoryItemName = '{categoryItemName}' and CategoryId='{categoryId}'";
                }

                if (categoryItemName != "" && categoryId != 0 && categoryItemId != 0)
                {
                    Query = $"SELECT 1 FROM CategoryItem WHERE CategoryItemName = '{categoryItemName}' and CategoryId='{categoryId}' and CategoryItemId <> '{categoryItemId}'";
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

        public async Task<CategoryItem> GetCategoryItem(int categoryItemId, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM CategoryItem WHERE CategoryItemId = @categoryItemId";
                }
                else
                {
                    Query = "SELECT * FROM CategoryItem WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@categoryItemId", categoryItemId);
                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                CategoryItem categoryItem = new CategoryItem();
                while (Reader.Read())
                {
                    categoryItem.CategoryItemId = (int)Reader["CategoryItemId"];
                    categoryItem.CategoryId = (int)Reader["CategoryId"];
                    categoryItem.CategoryItemName = Reader["CategoryItemName"].ToString();
                    categoryItem.CategoryItemNameBan = Reader["CategoryItemNameBan"].ToString();
                }
                Reader.Close();
                ConnectionClose();
                return categoryItem;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get CategoryItem\n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<List<CategoryItem>> GetCategoryItemList(string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT * FROM CategoryItem";
                }
                else
                {
                    Query = "SELECT * FROM CategoryItem WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<CategoryItem> categoryItemList = new List<CategoryItem>();
                while (Reader.Read())
                {
                    CategoryItem categoryItem = new CategoryItem();

                    categoryItem.CategoryItemId = (int)Reader["CategoryItemId"];
                    categoryItem.CategoryId = (int)Reader["CategoryId"];
                    categoryItem.CategoryItemName = Reader["CategoryItemName"].ToString();
                    categoryItem.CategoryItemNameBan = Reader["CategoryItemNameBan"].ToString();

                    categoryItemList.Add(categoryItem);
                }
                Reader.Close();
                ConnectionClose();
                return categoryItemList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get CategoryItem List \n" + exception.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<List<CategoryItem>> GetCategoryItemListMinCol(string columns, string condition = "")
        {
            try
            {
                if (condition == "")
                {
                    Query = "SELECT " + columns + " FROM CategoryItem";
                }
                else
                {
                    Query = "SELECT " + columns + " FROM CategoryItem WHERE " + condition;
                }

                Command = new SqlCommand(Query, Connection);

                ConnectionOpen();
                Reader = await Command.ExecuteReaderAsync();

                List<CategoryItem> categoryItemList = new List<CategoryItem>();
                while (Reader.Read())
                {
                    CategoryItem categoryItem = new CategoryItem();

                    SkipOnError(() => categoryItem.CategoryItemId = (int)Reader["CategoryItemId"]);
                    SkipOnError(() => categoryItem.CategoryId = (int)Reader["CategoryId"]);
                    SkipOnError(() => categoryItem.CategoryItemName = Reader["CategoryItemName"].ToString());

                    categoryItemList.Add(categoryItem);
                }
                Reader.Close();
                ConnectionClose();
                return categoryItemList;
            }
            catch (Exception exception)
            {
                throw new Exception("Failed To Get CategoryItem List \n" + exception.Message);
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
