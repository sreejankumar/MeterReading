using System;
namespace MeterReading.Api.Core.Data.Exception
{
	[Serializable]
	public class MalformedFileException : System.Exception

	{
		public MalformedFileException() { }
		public MalformedFileException(string message) : base(message) { }
		public MalformedFileException(string message, FormatException inner) : base(message, inner) { }
		protected MalformedFileException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
