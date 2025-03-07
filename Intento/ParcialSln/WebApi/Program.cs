using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Repository;
using WebApi.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EnviosDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDefault")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//inyeccion de dependencias
builder.Services.AddScoped<IEnvioRepository, EnvioRepository>();
builder.Services.AddScoped<IEnvioService, EnvioService>();

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
