using CsvHelper;
using CsvHelper.Configuration;
using Logging.Extensions;
using MeterReading.Api.Core.Data.Exception;
using MeterReading.Api.Core.Data.Messages;
using MeterReading.Api.Core.External_Services.CsvMapping;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Text;
using ValidationException = Api.Core.Exceptions.ValidationException;

namespace MeterReading.Api.Core.Data.Dtos
{
    public class RequestObject
    {
        public IFormFile File { get; set; }

        public static readonly string[] AllowedContextTypes = { Data.Constants.MimeTypesConstants.Application.CSV };

        public CsvExtractorData<MeterReading> Readings { get; set; }

        public async Task Validate()
        {
            if (File == null)
            {
                throw new ValidationException(ExceptionMessages.InvalidInput(nameof(File)));
            }

            var contentType = File.ContentType;
            if (contentType.HasValue() && !AllowedContextTypes.Contains(contentType))
            {
                throw new ValidationException(ExceptionMessages.AllowedInputContentTypes(contentType, AllowedContextTypes));
            }

            Readings = await Parse();
        }


        private async Task<CsvExtractorData<MeterReading>> Parse()
        {
            var result = new CsvExtractorData<MeterReading>();
            try
            {
                using var reader = new StreamReader(File.OpenReadStream());
                using var csv = new CsvReader(reader,
                            new CsvConfiguration(CultureInfo.InvariantCulture)
                            {
                                Delimiter = ",",
                                Encoding = new UTF8Encoding(false)
                            });
                csv.Context.RegisterClassMap<MeterReadingDtoCSVMapping>();

                var records = new List<MeterReading>();
                await csv.ReadAsync();
                csv.ReadHeader();
                while (await csv.ReadAsync())
                {
                    try
                    {
                        var record = csv.GetRecord<MeterReading>();
                        result.ValidRows.Add(record);
                    }
                    catch (FieldValidationException exceptions)
                    {
                        result.Errors.Add(new RowError
                        {
                            LineNumber = exceptions.Context.Parser.Row,
                            FieldName = exceptions.Context.Reader.HeaderRecord[exceptions.Context.Reader.CurrentIndex],
                            FieldValue = exceptions.Field,
                            ErrorMessage = exceptions.Message
                        });
                    }
                }
                return result;
            }
            catch (ReaderException ex)
            {
                if (ex.Message.Contains("No header record was found"))
                    throw new MalformedFileException("No header record was found");

                throw new MalformedFileException(ex.Message);
            }
        }
    }
}
