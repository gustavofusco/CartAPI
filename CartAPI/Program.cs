global using CartAPI.Models;
using CartAPI.Services.CartService;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICartService, CartService>();
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
