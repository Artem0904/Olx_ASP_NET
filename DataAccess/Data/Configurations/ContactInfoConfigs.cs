using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataAccess.Data.Entities;

namespace DataAccess.Data.Configurations
{
    public class ContactInfoConfigs : IEntityTypeConfiguration<ContactInfo>
    {
        public void Configure(EntityTypeBuilder<ContactInfo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PhoneNumber).HasMaxLength(16).IsRequired();
            builder.Property(x => x.PhoneNumber2).HasMaxLength(16);
            builder.Property(x => x.WebSiteUrl).HasMaxLength(1000);

            builder.HasOne(x => x.User).WithOne(x => x.ContactInfo).HasForeignKey<ContactInfo>(x => x.Id).IsRequired();
        }
    }
}
