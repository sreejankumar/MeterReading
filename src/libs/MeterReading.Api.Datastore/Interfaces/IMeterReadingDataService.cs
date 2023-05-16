namespace MeterReading.Api.Datastore.Interfaces
{
    public interface IMeterReadingDataService : IRepository<Models.MeterReading>  
    {

        public Task<IEnumerable<Models.MeterReading>> GetAllMeterReadingPerAccountAsync(int accountId);
    }
}
