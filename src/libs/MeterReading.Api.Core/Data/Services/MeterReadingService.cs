using AutoMapper;
using Logging.Interfaces;
using MeterReading.Api.Datastore.Interfaces;

namespace MeterReading.Api.Core.Data.Services
{
    public class MeterReadingService : IMeterReadingService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<MeterReadingService> _logger;
        private readonly IMapper _mapper;

        public MeterReadingService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<MeterReadingService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> SubmitMeterReading(List<Dtos.MeterReading> meterReadings)
        {

            int failureCount = 0;
            foreach (var reading in meterReadings)
            {
                try
                {
                    var account = await _unitOfWork.Customers.GetByIdAsync(reading.AccountId);
                    if (account == null)
                    {
                        _logger.LogDebug("Cannot Find the Account, Exiting.");
                        failureCount++;
                        continue;
                    }

                    var readings = await _unitOfWork.MeterReading.GetAllMeterReadingPerAccountAsync(account.AccountId);

                    if (readings.Any(x => x.MeterReadValue == reading.MeterReadValue && x.MeterReadingDateTime == reading.MeterReadingDateTime))
                    {
                        _logger.LogDebug("Duplicate Reading");
                        failureCount++;
                        continue;
                    }

                    var readingModel = _mapper.Map<Datastore.Models.MeterReading>(reading);

                    if (await _unitOfWork.MeterReading.AddAsync(readingModel) <= 0)
                    {
                        _logger.LogDebug("Meter Reading Cannot be submitted: ");
                        failureCount++;
                        continue;
                    }
                }
                catch (System.Exception ex)
                {
                    _logger.LogError($"Failure while trying to save meter reading for Account {reading.AccountId} for date {reading.MeterReadingDateTime}", ex);
                    failureCount++;
                    continue;
                }
            }
            return failureCount;
        }
    }
}
