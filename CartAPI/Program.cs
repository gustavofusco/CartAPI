global using CartAPI.Models;
global using CartAPI.Data;
using CartAPI.Services.ProductService;
using CartAPI.Services.CartService;
using System.Text.Json.Serialization;
using CartAPI.Services.UserService;
using CartAPI.Services.CupomService;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
}); //Evitando ciclo infinito

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CartAPI", Version = "v1" });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICupomService, CupomService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddDbContext<DataContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
    });
    app.UseSwaggerUI(opt =>
    {
        opt.SwaggerEndpoint("/swagger/v1/swagger.json", "CartAPI v1");
    });
}

app.UseCors(builder => builder.WithMethods("OPTIONS").AllowAnyHeader().AllowAnyOrigin().WithExposedHeaders("Content-Length"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
