using Microsoft.EntityFrameworkCore;
using ProductDB;
using FluentValidation.AspNetCore;
using FluentValidation;
using WebApplication1.Services;
using Businesslogic.Intefaces;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Ðåºñòðàö³ÿ IEntityService
builder.Services.AddScoped<IEntityService, Service>();

string connString = builder.Configuration.GetConnectionString("shopdb")!;
builder.Services.AddDbContext<ShopDBcontext>(opt => opt.UseSqlServer(connString));

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSession(options =>
{
    //options.IdleTimeout = TimeSpan.FromDays(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IProductService, Service>();


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
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
