using AutoMapper;
using GeekShop.ProductAPI.Config;
using GeekShop.ProductAPI.Model.Context;
using GeekShop.ProductAPI.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
    string connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];

    var conn = builder.Services.AddDbContext<MySQLContext>(
        options => options.UseMySql(connection, new MySqlServerVersion(new Version(15, 1)))
    );

    // The Mapper Object to Entity
    IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
    builder.Services.AddSingleton(mapper);
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    // Injects ProductRepository to application
    builder.Services.AddScoped<IProductRepository, ProductRepository>();


builder.Services.AddControllers();
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
