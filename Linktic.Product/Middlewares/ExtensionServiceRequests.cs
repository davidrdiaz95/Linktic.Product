using Microsoft.Extensions.Primitives;
using System.Text.Json;
using System.Text;

namespace Linktic.Product.Middlewares
{
	public static class ExtensionServiceRequests
	{
		public static async Task ConfigureRequestData(this HttpContext context, MemoryStream solicutudInyectada, string cuerpoPeticion)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(cuerpoPeticion);
			await solicutudInyectada.WriteAsync(bytes, 0, bytes.Length);
			solicutudInyectada.Seek(0L, SeekOrigin.Begin);
			context.Request.Body = solicutudInyectada;
		}

		public static async Task<string> GetRequestBody(this HttpContext context)
		{
			if (!context.Request.HasFormContentType)
			{
				return await new StreamReader(context.Request.Body).ReadToEndAsync();
			}

			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			foreach (KeyValuePair<string, StringValues> item in context.Request.Form)
			{
				dictionary.Add(item.Key, item.Value);
			}

			return JsonSerializer.Serialize(dictionary);
		}

		public static async Task<string> GetObjectToPersist(this HttpContext context, string cuerpoPeticion)
		{
			if (OwnsDataQueryString(context) && string.IsNullOrEmpty(cuerpoPeticion))
			{
				cuerpoPeticion = context.Request.QueryString.Value;
			}

			if (OwnsDataQueryString(context) && string.IsNullOrEmpty(cuerpoPeticion))
			{
				cuerpoPeticion = JsonSerializer.Serialize(context.Request.RouteValues);
			}

			return await Task.Run(() => cuerpoPeticion);
		}

		private static bool OwnsDataQueryString(HttpContext context)
		{
			return !string.IsNullOrEmpty(context.Request.QueryString.Value);
		}

		private static bool OwnDataOnRoute(HttpContext context)
		{
			return !string.IsNullOrEmpty(context.Request.RouteValues.ToString());
		}
	}
}
