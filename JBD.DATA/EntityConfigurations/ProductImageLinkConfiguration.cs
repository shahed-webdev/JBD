using JBD.DATA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JBD.DATA.EntityConfigurations;

public class ProductImageLinkConfiguration : IEntityTypeConfiguration<ProductImageLink>
{
    public void Configure(EntityTypeBuilder<ProductImageLink> builder)
    {
        builder.ToTable("ProductImageLink");
        builder.HasKey(e=>e.ProductImageLinkId);
        builder.Property(e=>e.ImageLink).IsRequired().HasMaxLength(128);
        builder.HasOne(e=> e.Product)
            .WithMany(e=> e.ProductImageLinks)
            .HasForeignKey(e => e.ProductId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_ProductImageLink_Product");
    }
}