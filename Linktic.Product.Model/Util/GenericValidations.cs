namespace Linktic.Product.Model.Util
{
	public static class GenericValidations
	{
		private static int SinRegistros;

		public static bool OwnData<T>(IEnumerable<T> listaItemsValidacion)
		{
			return listaItemsValidacion?.Any() ?? false;
		}
	}
}
