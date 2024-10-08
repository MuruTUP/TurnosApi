using Microsoft.EntityFrameworkCore;
using PeluqueriaServiciosApi.Data.Models;
using PeluqueriaServiciosApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<PeluqueriaDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaConexion")));

builder.Services.AddScoped<ITurnosRepository, TurnosRepository>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
