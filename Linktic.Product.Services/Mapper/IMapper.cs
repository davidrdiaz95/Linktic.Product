namespace Linktic.Product.Services.Mapper
{
	public interface IMapper<P, T>
	{
		P MapTo(T model);
		T MapFrom(P model);
	}
}
