using Linktic.Product.Model.DTO;
using Linktic.Product.Services.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Linktic.Product.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(Roles = "admin")]
	public class ProductSaleController : ControllerBase
	{
		private readonly IProductService productService;

		public ProductSaleController(IProductService productService)
		{
			this.productService = productService;
		}

		[HttpPost]
		public async Task<IActionResult> Insert(ProductDTO product)
		{
			return Ok(await this.productService.Insert(product));
		}

		[HttpPut]
		public async Task<IActionResult> Update(ProductDTO product)
		{
			return Ok(await this.productService.Update(product));
		}
	}
}
