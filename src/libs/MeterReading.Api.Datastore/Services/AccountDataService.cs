using Dapper;
using MeterReading.Api.Datastore.Interfaces;
using MeterReading.Api.Datastore.Models;
using System.Data;

namespace MeterReading.Api.Datastore.Services
{
    public class AccountDataService : IAccountDataService
    {

        private readonly ApplicationDbContext _applicationDbContext;

        public AccountDataService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Task<int> AddAsync(Accounts entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Accounts>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Accounts> GetByIdAsync(int id)
        {
            using var connection = _applicationDbContext.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Accounts>("SELECT * FROM Accounts WHERE AccountId = @id", new { id });
        }

        public Task<int> UpdateAsync(Accounts entity)
        {
            throw new NotImplementedException();
        }
    }
}
