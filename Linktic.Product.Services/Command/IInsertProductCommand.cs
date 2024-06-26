using Linktic.Product.Model.DTO;

namespace Linktic.Product.Services.Command
{
	public interface IInsertProductCommand
	{
		Task<ResponseDTO<int>> Execute(ProductDTO product);
	}
}
