using Linktic.Product.BusinessServices.Mapper;
using Linktic.Product.Model.DTO;
using Linktic.Product.Repository.Entity;
using Linktic.Product.Repository.Repository.Interface;
using Linktic.Product.Repository.Repository.Service;
using Linktic.Product.Services.Mapper;
using NetCore.AutoRegisterDi;
using System.Reflection;

namespace Linktic.Product.Extensions
{
	public static class SolveDependecyInjectionServicesExtension
	{
		public static void ConfigureDependencyInjection(this IServiceCollection services)
		{
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			services.AddScoped(typeof(IMapper<InvoiceProductDTO, InvoiceProductType>), typeof(InvoiceProductMapper));
			services.AddScoped(typeof(IMapper<ProductDTO, Repository.Entity.Product>), typeof(ProductMapper));

			Assembly assemblyServicesInterface = AppDomain.CurrentDomain.Load("Linktic.Product.Services");
			Assembly assemblyServicesImplementation = AppDomain.CurrentDomain.Load("Linktic.Product.BusinessServices");
			Assembly assemblyDataInterface = AppDomain.CurrentDomain.Load("Linktic.Product.Repository");
			Assembly assemblyDataImplementation = AppDomain.CurrentDomain.Load("Linktic.Product.Repository");

			services.RegisterAssemblyPublicNonGenericClasses(new Assembly[] { assemblyServicesInterface, assemblyServicesImplementation })
				.Where(c => c.Name.EndsWith("Command"))
				.AsPublicImplementedInterfaces();

			services.RegisterAssemblyPublicNonGenericClasses(new Assembly[] { assemblyServicesInterface, assemblyServicesImplementation })
				.Where(c => c.Name.EndsWith("Invoker"))
				.AsPublicImplementedInterfaces();

			services.RegisterAssemblyPublicNonGenericClasses(new Assembly[] { assemblyServicesInterface, assemblyServicesImplementation })
				.Where(c => c.Name.EndsWith("Service"))
				.AsPublicImplementedInterfaces();

			services.RegisterAssemblyPublicNonGenericClasses(new Assembly[] { assemblyServicesInterface, assemblyServicesImplementation })
				.Where(c => c.Name.EndsWith("Mapper"))
				.AsPublicImplementedInterfaces();

			services.RegisterAssemblyPublicNonGenericClasses(new Assembly[] { assemblyDataInterface, assemblyDataImplementation })
				.Where(c => c.Name.Contains("QueryObject"))
				.AsPublicImplementedInterfaces();

		}
	}
}
