using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;   // Correct namespace for DbContext

namespace WebApplication4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Enable MVC
            builder.Services.AddControllersWithViews();

            // Register Entity Framework Core DbContext
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                ));

            var app = builder.Build();

            // Error handling for Production
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // Middlewares
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            // ✔ FIXED ROUTE (Your project has ProductsController, not ContactController)
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Products}/{action=Index}/{id?}"
            );

            app.Run();
        }
    }
}