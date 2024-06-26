using Linktic.Product.Model.Section;

namespace Linktic.Product.Extensions
{
	public static class MapSectionConfigServicesExtension
	{
		public static void ConfigureMapSectionConfiguration(this IServiceCollection services, IConfiguration configuration)
		{
			IConfigurationSection configuracionFocos = configuration.GetSection("TokenConfiguration");
			services.Configure<TokenConfiguration>(configuracionFocos);
		}
	}
}
