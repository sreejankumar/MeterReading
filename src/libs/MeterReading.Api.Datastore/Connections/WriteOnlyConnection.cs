using Dapper;
using MeterReading.Api.Datastore.Configuration;
using MeterReading.Api.Datastore.Interfaces;
using Microsoft.Extensions.Options;
using System.Data;

namespace MeterReading.Api.Datastore.Connections
{
    public class WriteOnlyConnection : ApplicationDbContext, IWriteOnlyConnection
    {
        private readonly IDbConnection connection;
        public WriteOnlyConnection(IOptions<DatabaseConfiguration> databaseConfiguration) : base(databaseConfiguration)
        {
            connection = CreateConnection();
        }



        public async Task<int> ExecuteAsync(string sql, object? param = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
        {
            return await connection.ExecuteAsync(sql, param, transaction);
        }

        public void Dispose()
        {
            connection.Dispose();
        }
    }
}
