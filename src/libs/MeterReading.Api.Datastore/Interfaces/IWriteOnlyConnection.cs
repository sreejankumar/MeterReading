using System.Data;

namespace MeterReading.Api.Datastore.Interfaces
{
    public interface IWriteOnlyConnection: IDisposable
    {
        Task<int> ExecuteAsync(string sql, object? param = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default);
    }
}
