using Microsoft.EntityFrameworkCore;

namespace Linktic.Product.Repository.Configuration
{
	public class ProductEntityConfiguration : IEntityTypeConfiguration<Entity.Product>
	{
		public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entity.Product> builder)
		{
			builder.ToTable("Product");
			builder.Property(x => x.Id).HasColumnName("id");
			builder.Property(x => x.Name).HasColumnName("name");
			builder.Property(x => x.Price).HasColumnName("price");
			builder.Property(x => x.Description).HasColumnName("description");
			builder.Property(x => x.Amount).HasColumnName("Amount");
		}
	}
}
