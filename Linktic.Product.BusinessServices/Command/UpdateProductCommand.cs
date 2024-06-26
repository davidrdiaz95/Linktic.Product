using Linktic.Product.Model.DTO;
using Linktic.Product.Model.Util;
using Linktic.Product.Repository.Constant.Parameters;
using Linktic.Product.Repository.Constant.Procedure;
using Linktic.Product.Repository.Repository.Interface;
using Linktic.Product.Services.Command;
using Microsoft.Data.SqlClient;

namespace Linktic.Product.BusinessServices.Command
{
	public class UpdateProductCommand : IUpdateProductCommand
	{
		private readonly IRepository<Repository.Entity.Product> repository;

		public UpdateProductCommand(IRepository<Repository.Entity.Product> repository)
		{
			this.repository = repository;
		}

		public async Task<ResponseDTO<int>> Execute(ProductDTO product)
		{
			var parameters = new List<SqlParameter>();
			parameters.Add(new SqlParameter { ParameterName = UpdateProductParameters.id, Value = product.Id });
			parameters.Add(new SqlParameter { ParameterName = UpdateProductParameters.price, Value = product.Price });
			parameters.Add(new SqlParameter { ParameterName = UpdateProductParameters.amount, Value = product.Amount });
			var insert = this.repository.ExecuteSp(ProcedureProcedure.updateProduct, parameters);
			return insert > 0 ?
				ResponseStatus.ResponseSucessful<int>(insert) :
				ResponseStatus.ResponseWithoutData<int>("No se pudo registrar el producto");
		}
	}
}
