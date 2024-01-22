using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using olx.Data;

namespace olx
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connStr = builder.Configuration.GetConnectionString("LocalDb");

            // Add services to the container.
            // DI - Dependency Injection
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<OlxShopDbContext>(opts => opts.UseSqlServer(connStr));

            builder.Services.AddFluentValidationAutoValidation();
            // enable client-side validation
            builder.Services.AddFluentValidationClientsideAdapters();
            // Load an assembly reference rather than using a marker type.
            builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

            var app = builder.Build();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}