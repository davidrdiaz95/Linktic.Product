using Linktic.Product.Model.DTO;
using Linktic.Product.Model.Util;
using Linktic.Product.Repository.Repository.Interface;
using Linktic.Product.Services.Command;
using Linktic.Product.Services.Mapper;

namespace Linktic.Product.BusinessServices.Command
{
	public class GetProductCommand : IGetProductCommand
	{
		private readonly IRepository<Repository.Entity.Product> repository;
		private readonly IMapper<ProductDTO, Repository.Entity.Product> mapper;

		public GetProductCommand(IRepository<Repository.Entity.Product> repository,
			IMapper<ProductDTO, Repository.Entity.Product> mapper)
		{
			this.repository = repository;
			this.mapper = mapper;
		}

		public async Task<ResponseDTO<List<ProductDTO>>> Execute()
		{
			var products = this.repository.All();
			return products.Any()?
				ResponseStatus.ResponseSucessful<List<ProductDTO>>(products.Select(x=> this.mapper.MapTo(x)).ToList()) :
				ResponseStatus.ResponseWithoutData<List<ProductDTO>>("No se encontraron productos");
		}
	}
}
