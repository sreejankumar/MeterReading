using System.Data;

namespace MeterReading.Api.Datastore
{
    public interface IApplicationDbContext :IDisposable
    {
        public IDbConnection Connection { get; }
      
    }
}