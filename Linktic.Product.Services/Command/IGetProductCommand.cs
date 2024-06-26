using Linktic.Product.Model.DTO;

namespace Linktic.Product.Services.Command
{
	public interface IGetProductCommand
	{
		Task<ResponseDTO<List<Model.DTO.ProductDTO>>> Execute();
	}
}
