
global using SuperHeroApi;
global using SuperHeroApi.Models;
global using SuperHeroApi.Data;
using SuperHeroApi.Services;
using SuperHeroApi.Services.SuperHeroService;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// register service here yourself or interface wont work
builder.Services.AddScoped<ISuperHeroService, SuperHeroService>();


//register DataContext here + configure/register the sql database here and tell to use sqlite
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
//DefaultConnection is name of connection string created in appsetting.json





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

