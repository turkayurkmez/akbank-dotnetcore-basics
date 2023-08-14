var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();


app.MapControllerRoute(name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//Convention over Configuration



app.Run();
