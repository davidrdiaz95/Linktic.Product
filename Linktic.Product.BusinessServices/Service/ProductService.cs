using Linktic.Product.Model.DTO;
using Linktic.Product.Services.Command;
using Linktic.Product.Services.Service;

namespace Linktic.Product.BusinessServices.Service
{
	public class ProductService : IProductService
	{
		private readonly IInsertProductCommand insertProductCommand;
		private readonly IUpdateProductCommand updateProductCommand;
		private readonly ICreateInvoiceCommand createInvoiceCommand;
		private readonly IGetProductCommand getProductCommand;

		public ProductService(IInsertProductCommand insertProductCommand,
			IUpdateProductCommand updateProductCommand,
			ICreateInvoiceCommand createInvoiceCommand,
			IGetProductCommand getProductCommand)
		{
			this.insertProductCommand = insertProductCommand;
			this.updateProductCommand = updateProductCommand;
			this.createInvoiceCommand = createInvoiceCommand;
			this.getProductCommand = getProductCommand;
		}

		public async Task<ResponseDTO<int>> CreateInvoice(List<InvoiceProductDTO> invoiceProduct, decimal price)
		{
			return await this.createInvoiceCommand.Execute(invoiceProduct, price);
		}

		public async Task<ResponseDTO<List<ProductDTO>>> GetAllProduct()
		{
			return await this.getProductCommand.Execute();
		}

		public async Task<ResponseDTO<int>> Insert(ProductDTO productDTO)
		{
			return await this.insertProductCommand.Execute(productDTO);
		}

		public async Task<ResponseDTO<int>> Update(ProductDTO productDTO)
		{
			return await this.updateProductCommand.Execute(productDTO);
		}
	}
}
