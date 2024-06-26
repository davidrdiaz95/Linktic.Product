using Linktic.Product.Model.DTO;
using Linktic.Product.Repository.Entity;
using Linktic.Product.Services.Mapper;

namespace Linktic.Product.BusinessServices.Mapper
{
	public class InvoiceProductMapper : IMapper<InvoiceProductDTO, InvoiceProductType>
	{
		public InvoiceProductType MapFrom(InvoiceProductDTO model)
		{
			var product = new InvoiceProductType();
			product.IdProduct = model.IdProduct;
			product.AmountProduct = model.AmountProduct;
			return product;
		}

		public InvoiceProductDTO MapTo(InvoiceProductType model)
		{
			var product = new InvoiceProductDTO();
			product.IdProduct = model.IdProduct;
			product.AmountProduct = model.AmountProduct;
			return product;
		}
	}
}
