using MeterReading.Api.Datastore.Interfaces;

namespace MeterReading.Api.Datastore
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IAccountDataService customerDataService, IMeterReadingDataService meterReading)
        {
            Customers = customerDataService;
            MeterReading = meterReading;
        }

        public IAccountDataService Customers { get; }
        public IMeterReadingDataService MeterReading { get; }

    }
}
