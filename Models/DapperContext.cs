using AdayaTestWeb.Helpers;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace AdayaTestWeb.Models
{
    public class DapperContext
    {
        private readonly ConnectionString _connectionString;
        public DapperContext(IOptions<ConnectionString> options)
        {
            _connectionString = options.Value;
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString.DatabaseConnection);
        }   
    }
}
