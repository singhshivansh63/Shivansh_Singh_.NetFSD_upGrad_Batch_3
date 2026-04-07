using WebApplication12.Repository;
using WebApplication12.Services;

var builder = WebApplication.CreateBuilder(args);

// Add MVC 
builder.Services.AddControllersWithViews();

// Add Repository & Service (Scoped is correct for DB usage)
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IContactService, ContactService>();

// Add SQL Connection String (Dapper will use this)
builder.Services.AddScoped<System.Data.IDbConnection>(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    string connString = config.GetConnectionString("DefaultConnection");

    return new System.Data.SqlClient.SqlConnection(connString);
});

var app = builder.Build();

// For development debugging
app.UseDeveloperExceptionPage();

// Static files
app.UseStaticFiles();

app.UseRouting();

// Default MVC Route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Contact}/{action=Index}/{id?}");

app.Run();