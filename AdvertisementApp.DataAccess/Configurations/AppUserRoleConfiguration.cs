using AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.DataAccess.Configurations
{
    public class AppUserRoleConfiguration : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasIndex(a => new
            {
                a.AppRoleId,
                a.AppUserId
            }).IsUnique();

            builder.HasOne(a => a.AppRole).WithMany(a => a.AppUserRoles).HasForeignKey(a => a.AppRoleId);
            builder.HasOne(a => a.AppUser).WithMany(a => a.AppUserRoles).HasForeignKey(a => a.AppUserId);

            // Hangi ilişkili tabloda tek yani ıd olan var ise ondan başlıyoruz
            // Hangisi tek AppUserRole tablosunda, AppRole tek. AppRole tablosunda hangisi çok, AppUserRole çok. Aralarında ki ilişkiyi sağlayan AppRoleId
        }
    }
}
