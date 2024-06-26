using Linktic.Product.Model.DTO;
using Linktic.Product.Model.Util;
using Linktic.Product.Repository.Constant.Parameters;
using Linktic.Product.Repository.Constant.Procedure;
using Linktic.Product.Repository.Entity;
using Linktic.Product.Repository.Repository.Interface;
using Linktic.Product.Services.Command;
using Linktic.Product.Services.Mapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text.Json;

namespace Linktic.Product.BusinessServices.Command
{
	public class CreateInvoiceCommand : ICreateInvoiceCommand
	{
		private readonly IRepository<InvoiceProductType> repository;
		private readonly IMapper<InvoiceProductDTO, InvoiceProductType> mapper;

		public CreateInvoiceCommand(IRepository<InvoiceProductType> repository,
			IMapper<InvoiceProductDTO, InvoiceProductType> mapper)
		{
			this.repository = repository;
			this.mapper = mapper;
		}

		public async Task<ResponseDTO<int>> Execute(List<InvoiceProductDTO>invoiceProduct, decimal price)
		{
			var procuts = invoiceProduct.Select(x => this.mapper.MapFrom(x));
			var parameters = new List<SqlParameter>();
			parameters.Add(new SqlParameter { ParameterName = CreateInvoiceParameters.price, Value = price });
			var dt = new DataTable();
			dt.Columns.Add("IdProduct");
			dt.Columns.Add("AmountProduct");
			foreach (var item in procuts)
			{
				dt.Rows.Add(item.IdProduct, item.AmountProduct);
			}
			parameters.Add(new SqlParameter { ParameterName = CreateInvoiceParameters.product, Value = dt, TypeName = "DescriptionInvoice" });
			var insert = this.repository.ExecuteSp(ProcedureProcedure.createInvoice, parameters);
			return insert > 0 ?
				ResponseStatus.ResponseSucessful<int>(insert) :
				ResponseStatus.ResponseWithoutData<int>("No se pudo registrar el producto");
		}
	}
}
