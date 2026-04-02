using WebApplication7.Services;   // <-- Make sure namespace matches your project

namespace WebApplication7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add MVC services
            builder.Services.AddControllersWithViews();

            // Register Contact Service in DI Container
            builder.Services.AddSingleton<IContactService, ContactService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            // Enable static files
            app.UseStaticFiles();  // <-- Required

            app.UseRouting();

            app.UseAuthorization();

            // Default Route updated to Contact/ShowContacts
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Contact}/{action=ShowContacts}/{id?}"
            );

            app.Run();
        }
    }
}