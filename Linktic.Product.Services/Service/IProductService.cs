using Linktic.Product.Model.DTO;

namespace Linktic.Product.Services.Service
{
	public interface IProductService
	{
        Task<ResponseDTO<int>> Insert(ProductDTO productDTO);
		Task<ResponseDTO<int>> Update(ProductDTO productDTO);
		Task<ResponseDTO<List<ProductDTO>>> GetAllProduct();
		Task<ResponseDTO<int>> CreateInvoice(List<InvoiceProductDTO> invoiceProduct, decimal price);
	}
}
