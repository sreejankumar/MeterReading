using Dapper;
using MeterReading.Api.Datastore.Configuration;
using Microsoft.Extensions.Options;
using System.Data;
using MeterReading.Api.Datastore.Interfaces;

namespace MeterReading.Api.Datastore.Connections
{
    public class ReadOnlyConnection : ApplicationDbContext, IReadOnlyConnection
    {
        private readonly IDbConnection connection;
        public ReadOnlyConnection(IOptions<DatabaseConfiguration> databaseConfiguration) : base(databaseConfiguration)
        {
            connection = CreateConnection();
        }

        public async Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
        {
            return (await connection.QueryAsync<T>(sql, param, transaction)).AsList();
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
        {
            return await connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction);
        }

        public async Task<T> QuerySingleAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
        {
            return await connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction);

        }

        public void Dispose()
        {
            connection.Dispose();
        }
    }
}
