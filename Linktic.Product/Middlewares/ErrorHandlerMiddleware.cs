using Linktic.Product.Model.DTO;
using System.Net;
using System.Text.Json;

namespace Linktic.Product.Middlewares
{
	public class ErrorHandlerMiddleware
	{
		private readonly RequestDelegate _next;

		private readonly ILogger<ErrorHandlerMiddleware> logger;

		public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
		{
			_next = next;
			this.logger = logger;
		}

		public async Task Invoke(HttpContext context)
		{
			MemoryStream solicutudInyectada = new MemoryStream();
			string cuerpoPeticion = await context.GetRequestBody();
			try
			{
				await context.ConfigureRequestData(solicutudInyectada, cuerpoPeticion);
				await _next(context);
			}
			catch (Exception error)
			{
				HttpResponse response = context.Response;
				response.ContentType = "application/json";
				List<string> errores = new List<string>();
				ResponseDTO<string> responseModel = new ResponseDTO<string>
				{
					StatusCode = HttpStatusCode.InternalServerError,
					Error = errores
				};
				if (error is LinkticException ex)
				{
					responseModel.Error = ex.Errores;
					response.StatusCode = 400;
				}
				else
				{
					string message = await context.GetObjectToPersist(cuerpoPeticion);
					logger.LogWarning(error, message);
					response.StatusCode = 500;
					responseModel.Error.Add(error?.Message);
				}

				string text = JsonSerializer.Serialize(responseModel);
				await response.WriteAsync(text);
			}
		}
	}
}
