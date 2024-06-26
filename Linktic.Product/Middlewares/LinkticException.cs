using System.Runtime.Serialization;

namespace Linktic.Product.Middlewares
{
	public class LinkticException : Exception
	{
		public List<string> Errores { get; set; } = new List<string>();


		public LinkticException()
		{
		}

		public LinkticException(string message)
			: base(message)
		{
			Errores.Add(message);
		}

		public LinkticException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected LinkticException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
