using DataAccessLayer;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

 
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

 
app.MapControllers();   

 
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Contact}/{action=ShowContacts}/{id?}"
);

app.Run();