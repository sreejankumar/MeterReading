using Api.Core.Commands;
using MeterReading.Api.Core.Dtos;

namespace MeterReading.Api.Core.Commands
{
    public class PostMeterReadingCommand : Command<RequestObject, object>
    {
        public override Task<object> Run(RequestObject input)
        {
            throw new NotImplementedException();
        }

        public override Task Validate(RequestObject input)
        {
            throw new NotImplementedException();
        }
    }
}
