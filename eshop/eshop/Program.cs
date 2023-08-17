
using eshop.Data;
using eshop.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserService, UserService>();

//1. Session nesnesini ekleyeceğiz:
builder.Services.AddSession();
//Önce ortam değerlerinden bağlantı cümlesi:
var connectionString = builder.Configuration.GetConnectionString("db");
//DbContext nesnesini ekle:
builder.Services.AddDbContext<AkbankDbContext>(option => option.UseSqlServer(connectionString));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.LoginPath = "/Users/Login";
                    option.ReturnUrlParameter = "gidilecekSayfa";
                    option.AccessDeniedPath = "/Users/AccessDenied";
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
//HttpRequest üzerinde session aktif olsun:
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
