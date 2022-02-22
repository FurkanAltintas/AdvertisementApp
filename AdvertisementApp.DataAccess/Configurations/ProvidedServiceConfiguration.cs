using AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvertisementApp.DataAccess.Configurations
{
    public class ProvidedServiceConfiguration : IEntityTypeConfiguration<ProvidedService>
    {
        public void Configure(EntityTypeBuilder<ProvidedService> builder)
        {
            builder.Property(p => p.Title).HasMaxLength(300);
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.Description).HasColumnType("ntext");
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.ImagePath).HasMaxLength(500);
            builder.Property(p => p.ImagePath).IsRequired();
            builder.Property(p => p.CreatedDate).HasDefaultValueSql("getdate()");
        }
    }
}
