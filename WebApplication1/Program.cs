using Microsoft.EntityFrameworkCore;
using ProductDB;
using FluentValidation.AspNetCore;
using FluentValidation;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Ðåºñòðàö³ÿ IEntityService
builder.Services.AddScoped<IEntityService, Service>();

string connString = builder.Configuration.GetConnectionString("shopdb")!;
builder.Services.AddDbContext<ShopDBcontext>(opt => opt.UseSqlServer(connString));

builder.Services.AddFluentValidationAutoValidation();
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
