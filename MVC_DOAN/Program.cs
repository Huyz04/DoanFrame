using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC_DOAN.Data;
using MVC_DOAN.Helper;
using MVC_DOAN.Interface;
using MVC_DOAN.Models;
using MVC_DOAN.Repository;
using MVC_DOAN.Service;
using System.Configuration;
using System.Reflection.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MailKit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ILoaiSanPham, ReLoaiSanPham>();
builder.Services.AddScoped<IDashboard, ReDashboard>();
builder.Services.AddScoped<ISanPham, ReSanPham>();
builder.Services.AddScoped<IGioHang, ReGioHang>();
builder.Services.AddScoped<IDiaChi, ReDiaChi>();
builder.Services.AddScoped<IChiTietDon, ReChiTietDon>();
builder.Services.AddScoped<IDonHang, ReDonHang>();
builder.Services.AddScoped<IHoaDon, ReHoaDon>();
builder.Services.AddScoped<IVnPayService, VnPayService>();


builder.Services.AddScoped<IUser, ReUser>();

builder.Services.AddIdentity<Taikhoan, IdentityRole>().AddEntityFrameworkStores<DoanContext>().AddDefaultTokenProviders();
builder.Services.Configure<DataProtectionTokenProviderOptions>(opts => opts.TokenLifespan = TimeSpan.FromHours(10));

builder.Services.AddScoped<IPhotoService, PhotoService>();
builder.Services.AddSession();
builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));
builder.Services.AddDbContext<DoanContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
    //await Seed.SeedUsersAndRolesAsync(app);
    Seed.SeedData(app);
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{Id?}");

app.Run();
