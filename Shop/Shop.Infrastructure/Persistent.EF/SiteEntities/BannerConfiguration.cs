using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.SiteEntities;

namespace Shop.Infrastructure.Persistent.Ef.SiteEntities
{
    internal class BannerConfiguration : IEntityTypeConfiguration<Banner>
    {
        public void Configure(EntityTypeBuilder<Banner> builder)
        {
            builder.Property(b => b.ImageName)
                .IsRequired()
                .HasMaxLength(120);

            builder.Property(b => b.Link)
                .IsRequired()
                .HasMaxLength(500);
        }
    }
}
