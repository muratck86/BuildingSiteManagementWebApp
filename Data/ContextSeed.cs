using BuildingSiteManagementWebApp.Business.Abstracts;
using BuildingSiteManagementWebApp.Data.Entities;
using BuildingSiteManagementWebApp.Common.Constants;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using BuildingSiteManagementWebApp.Common.Enums;

namespace BuildingSiteManagementWebApp.Data
{
    public class ContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            foreach (var role in Enum.GetValues(typeof(Roles)))
            {
                await roleManager.CreateAsync(new IdentityRole(role.ToString()));
            }
        }

        public static async Task SeedHomeTypesAsync(IHomeTypeManager homeTypeManager)
        {
            //foreach (var type in Enum.GetValues(typeof(HomeTypes)))
            //{
            //    await homeTypeManager.AddAsync(type.ToString());
            //}
            foreach (var c in typeof(HomeTypes).GetFields())
            {
                if (c.IsLiteral && !c.IsInitOnly)
                    await homeTypeManager.AddAsync((string)c.GetValue(null));
            }
        }
        public static async Task SeedSuperAdminAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var superAdmin = new AppUser
            {
                UserName = "SuperAdmin",
                NationalId = "60923687528",
                Name = "Super",
                LastName = "Admin",
                Email = "superadmin@mail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            if(userManager.Users.All(u => u.Id != superAdmin.Id))
            {
                var user = await userManager.FindByEmailAsync(superAdmin.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(superAdmin, "123Pa$$word.");
                    await userManager.AddToRolesAsync(superAdmin, roleManager.Roles.Select(r => r.Name));
                }
            }
        }
        public static async Task SeedAdminAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var admin = new AppUser
            {
                UserName = "Admin",
                NationalId = "39797145038",
                Name = "Site",
                LastName = "Yöneticisi",
                Email = "admin@mail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            if (userManager.Users.All(u => u.Id != admin.Id))
            {
                var user = await userManager.FindByEmailAsync(admin.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(admin, "123Pa$$word.");
                    await userManager.AddToRolesAsync(admin, roleManager.Roles.Select(r => r.Name).Where(n => n == "Admin" || n == "User"));
                }
            }
        }
        public static async Task SeedUserAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var user = new AppUser
            {
                UserName = "User",
                NationalId = "96411137282",
                Name = "Normal",
                LastName = "Kullanıcı",
                Email = "user@mail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            if (userManager.Users.All(u => u.Id != user.Id))
            {
                var u = await userManager.FindByEmailAsync(user.Email);
                if (u == null)
                {
                    await userManager.CreateAsync(user, "123Pa$$word.");
                    await userManager.AddToRolesAsync(user, roleManager.Roles.Select(r => r.Name).Where(n => n == "User"));
                }
            }
        }
    }
}