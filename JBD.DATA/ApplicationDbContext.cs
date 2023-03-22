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

        public virtual DbSet<UserRegistration> UserRegistration { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserRegistrationConfiguration());
            base.OnModelCreating(builder);
            builder.SeedRoleData();
            builder.SeedSuperAdminData();
        }
    }
}