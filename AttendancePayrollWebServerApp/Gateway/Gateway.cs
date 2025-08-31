using Microsoft.AspNetCore.Hosting.Server;
using System.Data;
using System.Data.SqlClient;
namespace AttendancePayrollWebServerApp.Gateway
{
    public class Gateway
    {

        private string server = Server.server;
        private string database = Server.database;
        private string user = "sa";
        private string password = Server.password;
        private string conString;

        // // //expose conString as a protected property  //Rasif 
        protected string ConnectionString => conString;

        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }
        public string Query { get; set; }

        public Gateway()
        {
            if (password == "a")
            {
                password = "atl@sql";     //local 
               // password = "atl314";       
            }
            conString = "Data Source=" + server + ";Initial Catalog=" + database + ";Persist Security Info=True;User ID=" + user + ";Password=" + password + "";
            Connection = new SqlConnection(conString);
        }

        public void ConnectionOpen()
        {
            try
            {
                if (Connection.State == ConnectionState.Closed)
                {
                    Connection.Open();
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void ConnectionClose()
        {
            try
            {
                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void ReaderClose()
        {
            try
            {
                if (Reader != null && !Reader.IsClosed)
                {
                    Reader.Close();
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }









        //Old code 

        //private string server = Server.server;
        //private string database = Server.database;
        //private string user = "sa";
        //private string password = Server.password;
        //private string conString;
        //public SqlConnection Connection { get; set; }
        //public SqlCommand Command { get; set; }
        //public SqlDataReader Reader { get; set; }
        //public string Query { get; set; }
        //public Gateway()
        //{
        //    if (password == "a")
        //    {
        //        password = "atl@sql";
        //    }
        //    conString = "Data Source=" + server + ";Initial Catalog=" + database + ";Persist Security Info=True;User ID=" + user + ";Password=" + password + "";
        //    Connection = new SqlConnection(conString);
        //}
        //public void ConnectionOpen()
        //{
        //    try
        //    {
        //        if (Connection.State == ConnectionState.Closed)
        //        {
        //            Connection.Open();
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        throw new Exception(exception.Message);
        //    }
        //}
        //public void ConnectionClose()
        //{
        //    try
        //    {
        //        if (Connection.State == ConnectionState.Open)
        //        {
        //            Connection.Close();
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        throw new Exception(exception.Message);
        //    }
        //}

        //public void ReaderClose()
        //{
        //    try
        //    {
        //        if (Reader.IsClosed == false)
        //        {
        //            Connection.Close();
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        throw new Exception(exception.Message);
        //    }
        //}
    }
}
