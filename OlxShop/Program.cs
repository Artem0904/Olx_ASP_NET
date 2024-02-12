
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using DataAccess.Data;
using DataAccess;
using BusinessLogic.Extensions;
using BusinessLogic.Interfaces;
using OlxShop.Services;
using Microsoft.AspNetCore.Identity;
using DataAccess.Data.Entities;
using OlxShop.Helpers;

namespace OlxShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connStr = builder.Configuration.GetConnectionString("LocalDb")!;

            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext(connStr);

            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
            })
                .AddDefaultTokenProviders()
                .AddDefaultUI()
                .AddEntityFrameworkStores<ShopDbContext>();

            builder.Services.AddAutoMapper();
            builder.Services.AddFluentValidators();

            builder.Services.AddCustomServices();
            builder.Services.AddScoped<ICartService, CartService>();

            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            var app = builder.Build();

            // insert initial roles and admin user
            using (var scope = app.Services.CreateScope())
            {
                Seeder.SeedRoles(scope.ServiceProvider).Wait();
                Seeder.SeedAdmin(scope.ServiceProvider).Wait();
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.MapRazorPages();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
