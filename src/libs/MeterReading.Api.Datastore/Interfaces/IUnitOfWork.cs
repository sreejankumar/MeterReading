using System.Data;

namespace MeterReading.Api.Datastore.Interfaces
{
    public interface IUnitOfWork 
    {
        IAccountDataService Customers { get; }
        IMeterReadingDataService MeterReading { get; }

    }
}
