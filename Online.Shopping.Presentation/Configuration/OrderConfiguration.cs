using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Online.Shopping.Domain.Carts;
using Online.Shopping.Domain.Customers;

namespace Online.Shopping.Persistence.Configuration;

internal class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id).HasConversion(
            cart => cart.Value,
            value => new CartId(value));

        builder.HasOne<Customer>()
            .WithMany()
            .HasForeignKey(o => o.CustomerId)
            .IsRequired();

        builder.HasMany(o => o.LineItems)
            .WithOne()
            .HasForeignKey(li => li.CartId);
    }
}
