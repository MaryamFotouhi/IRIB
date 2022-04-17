using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.ProductAgg;

namespace Shop.Infrastructure.Persistent.EF.ProductAgg
{
    internal class ProductConfiguration:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "product");

            builder.HasIndex(b => b.Slug).IsUnique();

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(b => b.ImageName)
                .IsRequired()
                .HasMaxLength(110);

            builder.Property(b => b.Description)
                .IsRequired();

            builder.Property(b => b.Slug)
                .IsRequired()
                .IsUnicode(false);

            builder.OwnsOne(b => b.SeoData, option =>
            {
                option.Property(b => b.MetaDescription)
                    .HasMaxLength(500)
                    .HasColumnName("MetaDescription");

                option.Property(b => b.MetaTitle)
                    .HasMaxLength(500)
                    .HasColumnName("MetaTitle");

                option.Property(b => b.MetaKeyWords)
                    .HasMaxLength(500)
                    .HasColumnName("MetaKeyWords");

                option.Property(b => b.IndexPage)
                    .HasColumnName("IndexPage");

                option.Property(b => b.Canonical)
                    .HasMaxLength(500)
                    .HasColumnName("Canonical");

                option.Property(b => b.Schema)
                    .HasMaxLength(500)
                    .HasColumnName("Schema");
            });

            builder.OwnsMany(b => b.Images, option =>
            {
                option.ToTable("Images", "product");

                option.Property(b => b.ImageName)
                    .IsRequired()
                    .HasMaxLength(100);

            });

            builder.OwnsMany(b => b.Specifications, option =>
            {
                option.ToTable("Specifications", "product");

                option.Property(b => b.Key)
                    .IsRequired()
                    .HasMaxLength(50);

                option.Property(b => b.Value)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}