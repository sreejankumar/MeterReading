using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterReading.Api.Core.External_Services
{
	public class MeterReadingMappings : Profile
	{
		public MeterReadingMappings()
		{
			CreateMap<Datastore.Models.MeterReading, Data.Dtos.MeterReading>()
				.ReverseMap();
		}
	}
}
