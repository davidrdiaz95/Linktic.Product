namespace Linktic.Product.Extensions
{
	public static class CorsServicesExtension
	{
		public static void ConfigureCors(this IServiceCollection servicios)
		{
			servicios.AddCors(options =>
			{
				options.AddPolicy("MyOrigin",
					builder => builder.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyHeader());
			});
		}
	}
}
