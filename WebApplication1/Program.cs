using Microsoft.EntityFrameworkCore;
using ProductDB;
using FluentValidation.AspNetCore;
using FluentValidation;
using WebApplication1.Services;
using Businesslogic.Intefaces;
using Microsoft.AspNetCore.Identity;
using ProductDB.Entities;
using BusinessLogic.Services;
using BusinessLogic.Interfaces;
using WebApplication1;
using Businesslogic.Services;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();




string connString = builder.Configuration.GetConnectionString("shopdb")!;
builder.Services.AddDbContext<ShopDBcontext>(opt => opt.UseSqlServer(connString));

//builder.Services.AddDefaultIdentity<User>
//    (options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ShopDBcontext>();


//builder.Services.AddDefaultIdentity<User>
//    (options => options.SignIn.RequireConfirmedAccount = true)
//    .AddRoles<IdentityRole>()
//    .AddRoleManager<RoleManager<IdentityRole>>()
//    .AddEntityFrameworkStores<ShopDBcontext>();



builder.Services.AddIdentity<User, IdentityRole>()
               .AddDefaultUI()
               .AddDefaultTokenProviders()
               .AddEntityFrameworkStores<ShopDBcontext>();






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

builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IEntityService, ProductService>();

builder.Services.AddScoped<IMailService, MailService>();

builder.Services.AddScoped<ShopDBcontext>();

builder.Services.AddScoped(typeof(DataAccess.Interfaces.IRepository<>), typeof(DataAccess.Repository<>));






var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    Seeder.SeedRoles(scope.ServiceProvider).Wait();
    Seeder.SeedAdmin(scope.ServiceProvider).Wait();
}

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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
