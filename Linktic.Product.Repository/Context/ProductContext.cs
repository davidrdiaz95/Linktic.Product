using Linktic.Product.Repository.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Linktic.Product.Repository.Context
{
	public class ProductContext : DbContext
	{
		public DbSet<Entity.Product> Product { get; set; }

		public ProductContext(DbContextOptions options) : base(options)
		{
		}

		public ProductContext()
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
		}
	}
}
