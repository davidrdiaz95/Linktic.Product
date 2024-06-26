using Linktic.Product.Model.DTO;

namespace Linktic.Product.Model.Util
{
	public class ResponseStatus
	{
		public static ResponseDTO<T> ResponseSucessful<T>(T data)
		{
			return new ResponseDTO<T>() { StatusCode = System.Net.HttpStatusCode.OK, Data = data };
		}

		public static ResponseDTO<T> ResponseWithoutData<T>(string message)
		{
			return new ResponseDTO<T>() { StatusCode = System.Net.HttpStatusCode.NotFound, Message = message };
		}

		public static ResponseDTO<T> ResponseError<T>(string message)
		{
			return new ResponseDTO<T>() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = message };
		}

		public static ResponseDTO<T> ResponseErrors<T>(IEnumerable<string> errors)
		{
			return new ResponseDTO<T>() { StatusCode = System.Net.HttpStatusCode.BadRequest, Error = errors.ToList() };
		}
	}
}
