using JBD.DATA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JBD.DATA.EntityConfigurations;

public class YahooStoreSettingConfiguration: IEntityTypeConfiguration<YahooStoreSetting>
{
    public void Configure(EntityTypeBuilder<YahooStoreSetting> builder)
    {
        builder.ToTable("YahooStoreSetting");
        builder.HasKey(x => x.YahooStoreSettingId);
        builder.Property(e=> e.StoreId).HasMaxLength(50);
        builder.Property(e=> e.StoreName).HasMaxLength(256);
        builder.Property(e=> e.Secret).HasMaxLength(128);
        builder.Property(e=> e.Publickey).HasMaxLength(128);
        builder.Property(e=> e.ClientID).HasMaxLength(128);
    }
}