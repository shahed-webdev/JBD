using JBD.DATA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JBD.DATA.EntityConfigurations;

public class SettingProfitRatioConfiguration : IEntityTypeConfiguration<SettingProfitRatio>
{
    public void Configure(EntityTypeBuilder<SettingProfitRatio> builder)
    {
        builder.ToTable("SettingProfitRatio");
        builder.HasKey(e=> e.SettingProfitRatioId);
        builder.Property(e=> e.AmazonSellingPrice).HasPrecision(18, 2);
        builder.Property(e=> e.PercentageWithPriceAndProfit).HasPrecision(18, 2);
        builder.Property(e=> e.PlusAmount).HasPrecision(18, 2);
        builder.Property(e=> e.MinusAmount).HasPrecision(18, 2);
        builder.Property(e=> e.ProfitAmount).HasPrecision(18, 2);

    }
}