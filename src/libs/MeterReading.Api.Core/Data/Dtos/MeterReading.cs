namespace MeterReading.Api.Core.Data.Dtos
{
    public class MeterReading
    {
        public MeterReading()
        {

        }

        public int ReadingId { get; set; }
        public int AccountId { get; set; }
        public int MeterReadValue { get; set; }        
        public DateTime MeterReadingDateTime { get; set; }
    }
}
