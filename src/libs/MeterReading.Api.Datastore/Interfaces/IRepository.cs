using System.Data;

namespace MeterReading.Api.Datastore.Interfaces
{
    public interface IRepository<T> where T : class
    {

        public Task<T> GetByIdAsync(int id);
        public Task<IReadOnlyList<T>> GetAllAsync();
        public Task<int> AddAsync(T entity);
        public Task<int> UpdateAsync(T entity);
        public Task<int> DeleteAsync(int id);
    }
}