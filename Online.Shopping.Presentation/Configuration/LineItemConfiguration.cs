using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Online.Shopping.Domain.Carts;
using Online.Shopping.Domain.Products;

namespace Online.Shopping.Persistence.Configuration;

internal class LineItemConfiguration : IEntityTypeConfiguration<LineItem>
{
    public void Configure(EntityTypeBuilder<LineItem> builder)
    {
        builder.HasKey(li => li.LineItemId);

        builder.Property(li => li.LineItemId).HasConversion(
            lineItemId => lineItemId.Id,
            value => new LineItemId(value));

        builder.HasOne<Product>()
            .WithMany()
            .HasForeignKey(li => li.ProductId);
    }
}
