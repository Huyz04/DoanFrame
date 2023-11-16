using Microsoft.AspNetCore.Identity;
using MVC_DOAN.Data;
using MVC_DOAN.Models;
using System.Diagnostics;
using System.Net;

namespace MVC_DOAN.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DoanContext>();

               context.Database.EnsureCreated(); 

                if (!context.Loaisanphams.Any())
                {
                    context.Loaisanphams.AddRange(new List<Loaisanpham>()
                    {
                        new Loaisanpham()
                        {
                            Malsp = "LSP5",
                            Tenlsp = "Kem nền",
                            Tinhtrang = "1",
                        
                         },
                       new Loaisanpham()
                        {
                            Malsp = "LSP6",
                            Tenlsp = "Phấn mắt",
                            Tinhtrang = "1",

                         },
                       new Loaisanpham()
                        {
                            Malsp = "LSP7",
                            Tenlsp = "Dưỡng ẩm",
                            Tinhtrang = "0",

                         },
                       new Loaisanpham()
                        {
                            Malsp = "LSP8",
                            Tenlsp = "Son",
                            Tinhtrang = "1",

                         },
                       new Loaisanpham()
                        {
                            Malsp = "LSP9",
                            Tenlsp = "Nước tẩy trang",
                            Tinhtrang = "0",

                         }
                    });
                    context.SaveChanges();
                }

            }
        }

        //public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        //{
        //    using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        //    {
        //        //Roles
        //        var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        //        if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
        //            await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        //        if (!await roleManager.RoleExistsAsync(UserRoles.User))
        //            await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

        //        //Users
        //        var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
        //        string adminUserEmail = "teddysmithdeveloper@gmail.com";

        //        var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
        //        if (adminUser == null)
        //        {
        //            var newAdminUser = new AppUser()
        //            {
        //                UserName = "teddysmithdev",
        //                Email = adminUserEmail,
        //                EmailConfirmed = true,
        //                Address = new Address()
        //                {
        //                    Street = "123 Main St",
        //                    City = "Charlotte",
        //                    State = "NC"
        //                }
        //            };
        //            await userManager.CreateAsync(newAdminUser, "Coding@1234?");
        //            await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
        //        }

        //        string appUserEmail = "user@etickets.com";

        //        var appUser = await userManager.FindByEmailAsync(appUserEmail);
        //        if (appUser == null)
        //        {
        //            var newAppUser = new AppUser()
        //            {
        //                UserName = "app-user",
        //                Email = appUserEmail,
        //                EmailConfirmed = true,
        //                Address = new Address()
        //                {
        //                    Street = "123 Main St",
        //                    City = "Charlotte",
        //                    State = "NC"
        //                }
        //            };
        //            await userManager.CreateAsync(newAppUser, "Coding@1234?");
        //            await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
        //        }
        //    }
        //}
    }
}