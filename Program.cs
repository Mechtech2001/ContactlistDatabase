
using ContactlistDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactlistDatabase
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRouting(options => {
                options.LowercaseUrls = true; options.AppendTrailingSlash = true;
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //dependency injection
            builder.Services.AddDbContext<ContactsContext>(
                options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("ContactsContext"),sqlo => sqlo.EnableRetryOnFailure());
                    
                });

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
            //updated pattern to include slug
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");

            app.Run();
        }
    }
}
