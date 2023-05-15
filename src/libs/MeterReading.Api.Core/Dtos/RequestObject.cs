using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterReading.Api.Core.Dtos
{
    public class RequestObject
    {
        public IFormFile? File { get; set; }
    }
}
