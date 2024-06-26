using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Linktic.Product.Extensions
{
	public static class AuthenticationServicesExtension
	{
		public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
		{
			IConfigurationSection configuracionFocos = configuration.GetSection("TokenConfiguration");
			string sectretsForToken = configuracionFocos.GetSection("Secrect").Value;
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
					.AddJwtBearer(option =>
								option.TokenValidationParameters = new TokenValidationParameters
								{
									ValidateIssuerSigningKey = true,
									IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(sectretsForToken)),
									ValidateIssuer = false,
									ValidateAudience = false,
								});
		}
	}
}
