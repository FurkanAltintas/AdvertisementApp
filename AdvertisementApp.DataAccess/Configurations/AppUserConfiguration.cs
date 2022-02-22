using AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvertisementApp.DataAccess.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(a => a.Firstname).HasMaxLength(50);
            builder.Property(a => a.Firstname).IsRequired();
            builder.Property(a => a.Surname).HasMaxLength(50);
            builder.Property(a => a.Surname).IsRequired();
            builder.Property(a => a.PhoneNumber).HasMaxLength(20);
            builder.Property(a => a.PhoneNumber).IsRequired();
            builder.Property(a => a.Password).HasMaxLength(50);
            builder.Property(a => a.Password).IsRequired();

            builder.HasIndex(a => a.UserName).IsUnique();
            builder.HasOne(a => a.Gender).WithMany(a => a.AppUsers).HasForeignKey(a => a.GenderId);
        }
    }
}
