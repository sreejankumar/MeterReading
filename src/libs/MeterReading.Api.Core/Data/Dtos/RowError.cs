namespace MeterReading.Api.Core.Data.Dtos
{
    public class RowError
    {
        public int LineNumber { get; set; }
        public string? FieldName { get; set; }
        public string? FieldValue { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
