using AppPost.Models;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DataPostu;

namespace AppPost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
                        var connectionString = builder.Configuration.GetConnectionString("AppDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AppDbContextConnection' not found.");

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddControllersWithViews();
            builder.Services.AddSingleton<IPostService, MemoryPostService>();
            builder.Services.AddDbContext<DataPostu.AppDbContext>();
            builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<DataPostu.AppDbContext>();
            //builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<AppDbContext>();
            builder.Services.AddTransient<IPostService, EFPostService>();
            builder.Services.AddMemoryCache();                        // dodaæ
            builder.Services.AddSession();

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
            app.UseAuthentication();                                 // dodaæ
            app.UseAuthorization();                                  // dodaæ
            app.UseSession();                                        // dodaæ 
            app.MapRazorPages();                                     // dodaæ
      

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}