using JBD.DATA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JBD.DATA.EntityConfigurations;

public class UserRegistrationConfiguration : IEntityTypeConfiguration<UserRegistration>
{
    public void Configure(EntityTypeBuilder<UserRegistration> builder)
    {
        builder.ToTable("UserRegistration");

        builder.HasKey(e => e.UserRegistrationId);

        builder.Property(e => e.Address).HasMaxLength(1000);

        builder.Property(e => e.Email).HasMaxLength(50);

        builder.Property(e => e.CreatedAt)
            .HasColumnType("datetime")
            .HasDefaultValueSql("getutcdate()");

        builder.Property(e => e.Name).HasMaxLength(128);

        builder.Property(e => e.Phone).HasMaxLength(50);

        builder.Property(e => e.Type)
            .IsRequired()
            .HasMaxLength(50)
            .HasConversion<string>();

        builder.Property(e => e.UserName).HasMaxLength(50);

        builder.Property(e => e.Validation)
            .IsRequired()
            .HasDefaultValueSql("((1))");
    }
}