using Linktic.Product.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Linktic.Product.Extensions
{
	public static class RepositoryServicesExtension
	{
		public static void ConfigureDataBaseConnection(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<ProductContext>(options =>
			{
				options.UseSqlServer(connectionString);
			});
		}
	}
}
