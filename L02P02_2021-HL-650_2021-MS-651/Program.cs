using Microsoft.EntityFrameworkCore;
using L02P02_2021_HL_650_2021_MS_651.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

builder.Services.AddDbContext<usuariosContext>(options =>
		options.UseSqlServer(
				builder.Configuration.GetConnectionString("usuariosDbConnection"))); // Hola

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
