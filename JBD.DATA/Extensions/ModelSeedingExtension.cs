using JBD.DATA.Enums;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using JBD.DATA.Models;

namespace JBD.DATA.Extensions;

public static class ModelSeedingExtension
{
    public static Dictionary<string, string> Ids { get; set; } = new()
        {
            { UserRoles.SuperAdmin.ToString(), "fb76a482-3d73-4e28-9155-581a1a2cbea4" },
            { UserRoles.Admin.ToString(), "A7B695C1-E8D7-41A9-814F-28BB7EEF32F4" },
            { UserRoles.Seller.ToString(), "25205E51-C7F6-43E5-927A-8074AF61B966" },
        };

    public static void SeedRoleData(this ModelBuilder builder)
    {
        builder.Entity<IdentityRole>().HasData(
            Ids.Select(i =>
                new IdentityRole
                {
                    Id = i.Value,
                    Name = i.Key,
                    NormalizedName = i.Key.ToUpper(),
                    ConcurrencyStamp = i.Value
                }).ToArray()
        );
    }
    public static void SeedSuperAdminData(this ModelBuilder builder)
    {
        var authorityId = "A0456563-F978-4135-B563-97F23EA02FDA";
        // any guid, but nothing is against to use the same one
   
        var user = new IdentityUser
        {
            Id = authorityId,
            UserName = UserRoles.SuperAdmin.ToString(),
            NormalizedUserName = UserRoles.SuperAdmin.ToString().ToUpper(),
            Email = "Authority@gmail.com",
            NormalizedEmail = "AUTHORITY@GMAIL.COM",
            EmailConfirmed = true,
            LockoutEnabled = true,
            ConcurrencyStamp = authorityId
        };

        var passwordHasher = new PasswordHasher<IdentityUser>();
        user.PasswordHash = passwordHasher.HashPassword(user, "Admin_123");

        builder.Entity<IdentityUser>().HasData(user);

        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = Ids[UserRoles.SuperAdmin.ToString()],
            UserId = authorityId
        });


        builder.Entity<UserRegistration>().HasData(new UserRegistration
        {
            UserRegistrationId = 1,
            UserName = "SuperAdmin",
            Type = UserRoles.SuperAdmin,
            Name = "Super Admin",
        });
    }
}