using Microsoft.Data.SqlClient;

namespace StudentWebFormApp.DAL
{
    public class DapperDBContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        public SqlConnection CreateConnection()
        {
            try
            {
                SqlConnection conn = new(_connectionString);
                conn.Open();
                return conn;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
       
    }
}
