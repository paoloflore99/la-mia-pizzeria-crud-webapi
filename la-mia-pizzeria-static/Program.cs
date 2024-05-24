using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using la_mia_pizzeria_static.Areas.Identity.Data;
using la_mia_pizzeria_static.data;
namespace la_mia_pizzeria_static
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
                      //  var connectionString = builder.Configuration.GetConnectionString("PizzeCintestConnection") ?? throw new InvalidOperationException("Connection string 'PizzeCintestConnection' not found.");
                        
                        

             builder.Services.AddDbContext<PizzeCintest>();

             
            
           builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddRoles<IdentityRole>()
             .AddEntityFrameworkStores<PizzeCintest>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

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
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Pizza}/{action=Index}/{id?}");
            app.MapRazorPages();
            app.Run();
        }
    }
}