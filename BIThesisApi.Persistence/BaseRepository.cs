using System.Data.SqlClient;

namespace BIThesisApi.Persistence
{
    public class BaseRepository
    {
        private static readonly SqlConnection Connection;

        static BaseRepository()
        {
            Connection = new SqlConnection("Data Source = 188.142.227.229,1433;Initial Catalog = AdventureWorks2016; User ID = RandomUser; Password=asda; MultipleActiveResultSets=True; Connection Timeout=4");
            OpenConnection();
        }
        
        public static SqlDataReader GetDataFromDb(string query)
        {
            return new SqlCommand(query, Connection).ExecuteReader();
        }

        public static void CloseConnection()
        {
            Connection.Close();
        }
        
        public static void OpenConnection()
        {
            Connection.Open();
        }
    }
}