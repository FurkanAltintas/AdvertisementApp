using AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvertisementApp.DataAccess.Configurations
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.Property(a => a.Definition).HasMaxLength(300);
            builder.Property(a => a.Definition).IsRequired();

            builder.HasData(new AppRole[]
            {
                new() { Id = 1,Definition = "Admin"},
                new() { Id = 2, Definition = "Member"}
            });
        }
    }
}
