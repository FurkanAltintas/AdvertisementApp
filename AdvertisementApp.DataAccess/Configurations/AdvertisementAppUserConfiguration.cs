using AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvertisementApp.DataAccess.Configurations
{
    public class AdvertisementAppUserConfiguration : IEntityTypeConfiguration<AdvertisementAppUser>
    {
        public void Configure(EntityTypeBuilder<AdvertisementAppUser> builder)
        {
            builder.HasIndex(a => new
            {
                a.AdvertisementId,
                a.AppUserId // unique olarak setledik ve tekrarlanmış datalar artık gelmiyecek
            }).IsUnique(); // default hali true

            builder.Property(a => a.CvPath).HasMaxLength(500);
            builder.Property(a => a.CvPath).IsRequired();

            builder.HasOne(a => a.Advertisement).WithMany(a => a.AdvertisementAppUsers).HasForeignKey(a => a.AdvertisementId);
            builder.HasOne(a => a.AppUser).WithMany(a => a.AdvertisementAppUsers).HasForeignKey(a => a.AppUserId);
            builder.HasOne(a => a.AdvertisementAppUserStatus).WithMany(a => a.AdvertisementAppUsers).HasForeignKey(a => a.AdvertisementAppUserStatusId);
            builder.HasOne(a => a.MilitaryStatus).WithMany(a => a.AdvertisementAppUsers).HasForeignKey(a => a.MilitaryStatusId);
        }
    }
}
