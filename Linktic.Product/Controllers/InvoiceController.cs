using Linktic.Product.Model.DTO;
using Linktic.Product.Services.Service;
using Microsoft.AspNetCore.Mvc;

namespace Linktic.Product.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class InvoiceController : ControllerBase
	{
		private readonly IProductService productService;

		public InvoiceController(IProductService productService)
		{
			this.productService = productService;
		}

		[HttpPost]
		public async Task<IActionResult> CreateInvoice(SaleProductDTO invoiceProduct)
		{
			return Ok(await this.productService.CreateInvoice(invoiceProduct.InvoiceProduct, invoiceProduct.Price));
		}
	}
}
