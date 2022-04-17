using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.OrderAgg;

namespace Shop.Infrastructure.Persistent.EF.OrderAgg
{
    internal class OrderConfiguration:IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders", "order");

            builder.OwnsOne(b => b.Discount, option =>
            {
                option.Property(b => b.DiscountTitle)
                    .HasMaxLength(50);
            });

            builder.OwnsOne(b => b.ShippingMethod, option =>
            {
                option.Property(b => b.ShippingType)
                    .HasMaxLength(50);
            });

            builder.OwnsMany(b => b.Items, option =>
            {
                option.ToTable("Items", "order");
            });

            builder.OwnsOne(b => b.Address, option =>
            {
                option.ToTable("Addresses", "order");

                option.HasKey(b => b.Id);

                option.Property(b => b.Shire)
                    .IsRequired()
                    .HasMaxLength(50);

                option.Property(b => b.City)
                    .IsRequired()
                    .HasMaxLength(50);

                option.Property(b => b.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(11);

                option.Property(b => b.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                option.Property(b => b.Family)
                    .IsRequired()
                    .HasMaxLength(50);

                option.Property(b => b.NationalCode)
                    .IsRequired()
                    .HasMaxLength(10);

                option.Property(b => b.PostalCode)
                    .IsRequired()
                    .HasMaxLength(40);
            });

        }
    }
}