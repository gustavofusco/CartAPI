global using CartAPI.Models;
global using CartAPI.Data;
using CartAPI.Services.ProductService;
using CartAPI.Services.CartService;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
}); //Evitando ciclo infinito

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddDbContext<DataContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder.WithMethods("OPTIONS").AllowAnyHeader().AllowAnyOrigin().WithExposedHeaders("Content-Length"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
