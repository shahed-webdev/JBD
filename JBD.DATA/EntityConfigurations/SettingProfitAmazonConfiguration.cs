using JBD.DATA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JBD.DATA.EntityConfigurations;

public class SettingProfitAmazonConfiguration:IEntityTypeConfiguration<SettingProfitAmazon>
{
    public void Configure(EntityTypeBuilder<SettingProfitAmazon> builder)
    {
        builder.ToTable("SettingProfitAmazon");
        builder.HasKey(e => e.SettingProfitAmazonId);
        builder.Property(e => e.Commission).HasPrecision(18, 2);
        builder.Property(e => e.Expense).HasPrecision(18, 2);
        builder.Property(e => e.ShippingUnitPrice).HasPrecision(18, 2);
        builder.Property(e => e.MinimumShippingFee).HasPrecision(18, 2);
    }
}