using System.Data;
using System.Reflection.Emit;
using System.Security.Principal;
using JBD.DATA.EntityConfigurations;
using JBD.DATA.Extensions;
using JBD.DATA.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JBD.DATA
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserRegistration> UserRegistrations { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;

        public virtual DbSet<ProductImageLink> ProductImageLinks { get; set; } = null!;

        //public virtual DbSet<ProductCategory> ProductCategories { get; set; } = null!;
       
        public virtual DbSet<ExcludeKeyword> ExcludeKeywords { get; set; } = null!;

        public virtual DbSet<YahooStoreSetting> YahooStoreSettings { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserRegistrationConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ProductImageLinkConfiguration());
            builder.ApplyConfiguration(new ExcludeKeywordConfiguration());
            builder.ApplyConfiguration(new YahooStoreSettingConfiguration());

            base.OnModelCreating(builder);
            builder.SeedRoleData();
            builder.SeedSuperAdminData();
        }
    }
}