using AdayaTestWeb.Helpers;
using AdayaTestWeb.Models;
using AdayaTestWeb.Repositories.Contract;
using Dapper;

namespace AdayaTestWeb.Repositories.Implementation
{
    public class Repository : IRepository
    {
        private readonly DapperContext _context;
        public Repository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> DeleteAsync()
        {
            using (var sqlConn = _context.CreateConnection())
            {
                return await sqlConn.ExecuteAsync("TruncateTable", commandType: System.Data.CommandType.StoredProcedure, commandTimeout: 60);
            }   
        }

        public async Task GenerateAsync(IList<GenerateDataModel> models)
        {
            if (!models.Any()) return;
            using (var sqlConn = _context.CreateConnection())
            {
              await sqlConn.ExecuteAsync("SubmitGenerateData", 
                    new { generateDataUdayaTable  = models.ToDataTable().AsTableValuedParameter("GenerateDataUdayaTable") },
                    commandType: System.Data.CommandType.StoredProcedure, commandTimeout: 60);
            }
        }

        public async Task<IEnumerable<GenerateDataModel>> ListAsync()
        {
            using (var sqlConn = _context.CreateConnection())
            {
                var response = await sqlConn.QueryAsync<GenerateDataModel>("GetPersonals", commandType: System.Data.CommandType.StoredProcedure);
                return response;
            }
        }
    }
}
