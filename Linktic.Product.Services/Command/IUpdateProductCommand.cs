using Linktic.Product.Model.DTO;

namespace Linktic.Product.Services.Command
{
	public interface IUpdateProductCommand
	{
		Task<ResponseDTO<int>> Execute(ProductDTO product);
	}
}
