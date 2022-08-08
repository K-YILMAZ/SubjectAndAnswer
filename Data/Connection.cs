using System.Data.SqlClient;

namespace Data
{
    public class Connection
    {
        private static SqlConnection _connection;

        public static readonly string connectionString = @"Server=KANBER\SQLEXPRESS;Database=WorkFollow_db;User Id=sa;Password=1234;";
        public static SqlConnection GetConnection
        {
            get 
            {

                _connection =  new SqlConnection(connectionString);
                return _connection;
            }
        }

        

        


    }
}