using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OlxShop.Data.Entities;

namespace OlxShop.Data.Configurations
{
    public class CityConfigs : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();

            builder.HasMany(x => x.Products).WithOne(x => x.City).HasForeignKey(x => x.CityId);
            builder.HasMany(x => x.ContactInfos).WithOne(x => x.City).HasForeignKey(x => x.CityId);
            builder.HasOne(x => x.Country).WithMany(x => x.Cities).HasForeignKey(x => x.CountryId);
        }
    }
}
