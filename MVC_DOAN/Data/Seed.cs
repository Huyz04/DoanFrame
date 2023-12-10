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
                            Tenlsp = "Kem nền",
                            Tinhtrang = "1"
                        
                         },
                       new Loaisanpham()
                        {
                            Tenlsp = "Phấn mắt",
                            Tinhtrang = "1"

                         },
                       new Loaisanpham()
                        {
                            Tenlsp = "Dưỡng ẩm",
                            Tinhtrang = "0"

                         },
                       new Loaisanpham()
                        {
                            Tenlsp = "Son",
                            Tinhtrang = "1"

                         },
                       new Loaisanpham()
                        {
                            Tenlsp = "Nước tẩy trang",
                            Tinhtrang = "0"

                         }
                    });
                    context.SaveChanges();
                }

            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<Taikhoan>>();
                string adminUserEmail = "huy@.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new Taikhoan()
                    {
                        UserName = "huy",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        Matkhau = "C@123"
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new Taikhoan()
                    {
                        UserName = "user",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        Matkhau = "C@123"
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}