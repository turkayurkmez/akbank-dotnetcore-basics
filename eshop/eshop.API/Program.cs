using eshop.Application.Services;
using eshop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddCors(option => option.AddPolicy("allow", builder =>
{
    builder.AllowAnyOrigin();
    builder.AllowAnyMethod();
    builder.AllowAnyHeader();

}));


//Önce ortam değerlerinden bağlantı cümlesi:
var connectionString = builder.Configuration.GetConnectionString("db");
//DbContext nesnesini ekle:
builder.Services.AddDbContext<AkbankDbContext>(option => option.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("allow");
app.UseHttpsRedirection();


app.UseAuthorization();


app.MapControllers();

app.Run();
