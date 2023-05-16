namespace MeterReading.Api.Core.Data.Services
{
    public interface IMeterReadingService
    {
        public Task<int> SubmitMeterReading(List<Dtos.MeterReading> meterReadings);
    }
}