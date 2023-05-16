namespace MeterReading.Api.Core.Data.Dtos
{
    public class CsvExtractorData<T>
    {
        public CsvExtractorData()
        {
            ValidRows = new List<T>();
            Errors = new List<RowError>();
        }
        public List<T> ValidRows { get; set; }
        public List<RowError> Errors { get; set; }
    }
}
