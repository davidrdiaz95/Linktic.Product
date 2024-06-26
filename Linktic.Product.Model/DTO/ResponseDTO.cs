using System.Net;

namespace Linktic.Product.Model.DTO
{
	public class ResponseDTO<T>
	{
		public List<string> Error { get; set; }

		public string Message { get; set; }

		public HttpStatusCode StatusCode { get; set; }

		public T Data { get; set; }
	}
}
