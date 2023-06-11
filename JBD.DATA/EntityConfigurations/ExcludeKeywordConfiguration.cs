using JBD.DATA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JBD.DATA.EntityConfigurations;

public class ExcludeKeywordConfiguration : IEntityTypeConfiguration<ExcludeKeyword>
{
    public void Configure(EntityTypeBuilder<ExcludeKeyword> builder)
    {
        builder.ToTable("ExcludeKeyword");
       
        builder.HasKey(e => e.ExcludeKeywordId);
        
        builder.Property(e=> e.KeywordType)
            .IsRequired()
            .HasMaxLength(50)
            .HasConversion<string>();
        
        builder.Property(e => e.Keyword)
            .IsRequired()
            .HasMaxLength(128);

    }
}