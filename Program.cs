using CIE.WebApp.Data;
using CIE.WebApp.Profiles;
using CIE.WebApp.Services.Implementacion;
using CIE.WebApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<Profiles>();
});

var connectionString = builder.Configuration.GetConnectionString("CIEDB");
builder.Services.AddDbContext<CiedbContext>(options =>
{
    options.UseSqlServer(connectionString);
});


builder.Services.AddScoped<ICie10Services, Cie10Services>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
