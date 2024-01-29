using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataAccess.Data.Entities;

namespace DataAccess.Data.Configurations
{
    public class ProductConfigs : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(9000);
            builder.Property(x => x.Price).HasMaxLength(20);
            builder.Property(x => x.Discount).HasMaxLength(20);
            builder.Property(x => x.InStock).IsRequired();
            builder.Property(x => x.ImageUrl).HasMaxLength(1000).IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.Products).HasForeignKey(x => x.UserId);
            builder.Property(x => x.CategoryId).HasDefaultValue(9);
        }
    }
}
