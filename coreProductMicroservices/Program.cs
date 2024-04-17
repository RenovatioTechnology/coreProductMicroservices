using Microsoft.EntityFrameworkCore;
using coreProductMicroservices.Models;
using coreMicroserviceProject.Repository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
/* commenting Ctrl C + K or Ctrl + Shift / */
builder.Services.AddDbContext<ProductDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("ProductDB")
    ));

builder.Services.AddTransient<IProductRepository, ProductReposity>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();