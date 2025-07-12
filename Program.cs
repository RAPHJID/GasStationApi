using GasStationApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models; 
using GasStationApi.Mappings;
using GasStationApi.Services;
using GasStationApi.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ICustomer, CustomerService>();
builder.Services.AddScoped<ICylinder, CylinderService>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Gas Station API",
        Version = "v1"
    });
});

//automapper
builder.Services.AddAutoMapper(typeof(MappingProfile));


// EF Core
builder.Services.AddDbContext<GasDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
