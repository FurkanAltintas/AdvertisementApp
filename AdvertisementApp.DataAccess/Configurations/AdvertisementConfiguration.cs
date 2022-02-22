using AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvertisementApp.DataAccess.Configurations
{
    public class AdvertisementConfiguration : IEntityTypeConfiguration<Advertisement>
    {
        public void Configure(EntityTypeBuilder<Advertisement> builder)
        {
            builder.Property(a => a.Title).HasMaxLength(200);
            builder.Property(a => a.Title).IsRequired();
            builder.Property(a => a.Description).HasColumnType("ntext");
            builder.Property(a => a.Description).IsRequired();

            builder.Property(a => a.CreatedDate).HasDefaultValueSql("getdate()");
        }
    }
}
