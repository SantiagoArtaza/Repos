using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Xnacion1.Repos;
using Xnacion1.Repository;
using Xnacion1.Service;

var builder = WebApplication.CreateBuilder(args);


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.AllowAnyOrigin();
                      });
});



// Add services to the container.
builder.Services.AddDbContext<DbEnviosFinalContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Dbdd")));
//builder.Services.AddDbContext<EnviosDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDefault")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddFluentValidation((options) => options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));


builder.Services.AddScoped<IService, Service>();
builder.Services.AddScoped<IRepository, Repository>();




var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);
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
