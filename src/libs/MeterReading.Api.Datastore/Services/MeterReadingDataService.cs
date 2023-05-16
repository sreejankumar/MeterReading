using Dapper;
using MeterReading.Api.Datastore.Interfaces;

namespace MeterReading.Api.Datastore.Services
{
    public class MeterReadingDataService : IMeterReadingDataService
    {

        private readonly ApplicationDbContext _applicationDbContext;

        public MeterReadingDataService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<Models.MeterReading>> GetAllMeterReadingPerAccountAsync(int accountId)
        {
            using var connection = _applicationDbContext.CreateConnection();
            return await connection.QueryAsync<Models.MeterReading>("SELECT * FROM MeterReading WHERE AccountId = @accountId", new { accountId });
        }

        async Task<int> IRepository<Models.MeterReading>.AddAsync(Models.MeterReading entity)
        {
            using var connection = _applicationDbContext.CreateConnection();
            var sql = "INSERT INTO MeterReading (MeterReadValue, AccountId, MeterReadingDateTime)  VALUES (@meterReadValue, @accountId, @meterReadingDateTime)";
            object[] parameters = { new { meterReadValue = entity.MeterReadValue, 
                accountId = entity.AccountId, 
                meterReadingDateTime = entity.MeterReadingDateTime } };


            return await connection.ExecuteAsync(sql, entity);
        }

        Task<int> IRepository<Models.MeterReading>.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IReadOnlyList<Models.MeterReading>> IRepository<Models.MeterReading>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Models.MeterReading> IRepository<Models.MeterReading>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<int> IRepository<Models.MeterReading>.UpdateAsync(Models.MeterReading entity)
        {
            throw new NotImplementedException();
        }
    }
}
