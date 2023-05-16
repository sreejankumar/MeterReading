using CsvHelper.Configuration;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MeterReading.Api.Core.External_Services.CsvMapping
{
    public class MeterReadingDtoCSVMapping : ClassMap<Data.Dtos.MeterReading>
	{
		public static readonly Regex _digitRegex = new Regex("^[0-9]{5}$");

		public MeterReadingDtoCSVMapping()
		{
			Map(m => m.AccountId)
				.Index(0)
				.Validate(expression => int.TryParse(expression.Field, out _));

			Map(m => m.MeterReadValue)
				.Index(2)
				.Validate(expression => _digitRegex.IsMatch(expression.Field));

			Map(m => m.MeterReadingDateTime)
				.Index(1)
				.Validate(expression => DateTime.TryParseExact(expression.Field, "dd/MM/yyyy HH:mm",
					   CultureInfo.InvariantCulture,
					   DateTimeStyles.None,
					   out _))
				.TypeConverterOption.Format("dd/MM/yyyy HH:mm");

			Map(m => m.ReadingId)
				.Ignore();

		}
	}
}
