using Linktic.Product.Model.DTO;
using Linktic.Product.Services.Mapper;

namespace Linktic.Product.BusinessServices.Mapper
{
	public class ProductMapper : IMapper<ProductDTO, Repository.Entity.Product>
	{
		public Repository.Entity.Product MapFrom(ProductDTO model)
		{
			var product = new Repository.Entity.Product();
			product.Price = model.Price;
			product.Description = model.Description;
			product.Name = model.Name;
			product.Id = model.Id;
			product.Amount = model.Amount;
			return product;
		}

		public ProductDTO MapTo(Repository.Entity.Product model)
		{
			var product = new ProductDTO();
			product.Price = model.Price;
			product.Description = model.Description;
			product.Name = model.Name;
			product.Id = model.Id;
			product.Amount = model.Amount;
			return product;
		}
	}
}
