﻿namespace MeterReading.Api.Datastore.Models
{
    public class MeterReading
    {
        public int ReadingId { get; set; }
        public int AccountId { get; set; }
        public int MeterReadValue { get; set; }
        public DateTime MeterReadingDateTime { get; set; }
    }
}
