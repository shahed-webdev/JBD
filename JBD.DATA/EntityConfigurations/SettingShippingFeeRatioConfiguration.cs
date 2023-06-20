using JBD.DATA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JBD.DATA.EntityConfigurations;

public class SettingShippingFeeRatioConfiguration:IEntityTypeConfiguration<SettingShippingFeeRatio>
{
    public void Configure(EntityTypeBuilder<SettingShippingFeeRatio> builder)
    {
        builder.ToTable("SettingShippingFeeRation");
        builder.HasKey(e => e.SettingShippingFeeRatioId);
        builder.Property(e => e.Size).HasPrecision(18, 2);
        builder.Property(e => e.Weight).HasPrecision(18, 2);
        builder.Property(e => e.Amount).HasPrecision(18, 2);
    }
}