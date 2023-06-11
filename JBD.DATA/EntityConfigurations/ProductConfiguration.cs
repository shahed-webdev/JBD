using JBD.DATA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JBD.DATA.EntityConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");
        builder.HasKey(p => p.ProductId);
        builder.Property(e => e.Asin).IsRequired().HasMaxLength(50);
        builder.Property(e=> e.ProductCode).IsRequired().HasMaxLength(50);
        builder.Property(e=> e.Brand).HasMaxLength(128);
        builder.Property(e=> e.ProductName).IsRequired().HasMaxLength(256);
        builder.Property(e=> e.ProductDescription).HasMaxLength(500);
        builder.Property(e=> e.ProductInformation).HasMaxLength(500);
        builder.Property(e=> e.GrossProfit).HasPrecision(18, 2);
        builder.Property(e=> e.PurchasePrice).HasPrecision(18, 2);
        builder.Property(e=> e.SalesPrice).HasPrecision(18, 2);
        builder.Property(e=> e.ShippingFee).HasPrecision(18, 2);
        builder.Property(e=> e.Size).HasPrecision(18, 2);
        builder.Property(e=> e.Weight).HasPrecision(18, 2);
       
        builder.Property(e => e.CreatedAt)
            .HasColumnType("datetime")
            .HasDefaultValueSql("getutcdate()");
    }
}