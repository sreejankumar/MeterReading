
using Api.Core.Commands;
using MeterReading.Api.Core.Commands;
using MeterReading.Api.Core.Data.Dtos;
using Microsoft.AspNetCore.Mvc;
using ControllerBase = Api.Core.Controller.ControllerBase;

namespace MeterReading.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeterReadingController : ControllerBase
    {
        public MeterReadingController(ICommandService commandService) : base(commandService)
        {
        }

        /// <summary>
        /// Process the word from the text file uploaded.
        /// </summary>
        /// <param name="file">Upload a file</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(List<MeterReadingUploadResult>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        [ProducesResponseType(typeof(ErrorMessage), 500)]
        public Task<ActionResult> Post(IFormFile file) =>
            Run<PostMeterReadingCommand, RequestObject, MeterReadingUploadResult>(
                new RequestObject
                {
                    File = file
                });
    }
}