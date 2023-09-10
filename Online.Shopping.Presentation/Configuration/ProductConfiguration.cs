using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Online.Shopping.Domain.Products;

namespace Online.Shopping.Persistence.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasConversion(
                productId => productId.Value,
                value => new ProductId(value));

            builder.OwnsOne(p => p.Price, priceBuilder =>
            {
                priceBuilder.Property(m => m.Currency).HasMaxLength(3);
            });
        }
    }
}
