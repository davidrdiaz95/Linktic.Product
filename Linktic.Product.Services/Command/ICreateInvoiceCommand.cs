using Linktic.Product.Model.DTO;

namespace Linktic.Product.Services.Command
{
	public interface ICreateInvoiceCommand
	{
		Task<ResponseDTO<int>> Execute(List<InvoiceProductDTO> invoiceProduct, decimal price);
	}
}
