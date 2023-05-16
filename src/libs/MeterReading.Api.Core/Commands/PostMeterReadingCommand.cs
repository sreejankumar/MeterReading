using Api.Core.Commands;
using MeterReading.Api.Core.Data.Dtos;
using MeterReading.Api.Core.Data.Services;

namespace MeterReading.Api.Core.Commands
{
    public class PostMeterReadingCommand : Command<RequestObject, MeterReadingUploadResult>
    {

        private readonly IMeterReadingService _meterReadingService;

        public PostMeterReadingCommand(IMeterReadingService meterReadingService)
        {
            _meterReadingService = meterReadingService;
        }

        public override async Task<MeterReadingUploadResult> Run(RequestObject input)
        {
            var failureCount = await _meterReadingService.SubmitMeterReading(input.Readings.ValidRows);

            return new MeterReadingUploadResult
            {
                FailureCount = input.Readings.Errors.Count + failureCount,
                SuccessCount = input.Readings.ValidRows.Count - failureCount
            };
        }
        public override async Task Validate(RequestObject input)
        {
            await input.Validate();
        }
    }
}
