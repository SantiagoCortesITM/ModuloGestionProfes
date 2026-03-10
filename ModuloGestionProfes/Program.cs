using ModuloGestionProfes.Middleware;
using ModuloGestionProfes.Application.Interfaces;
using ModuloGestionProfes.Application.Services;
using ModuloGestionProfes.Infrastructure.Repositories;
using ModuloGestionProfes.Application.Mappings;
using Microsoft.EntityFrameworkCore;
using ModuloGestionProfes.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(ProfesorProfile));

builder.Services.AddScoped<IProfesorRepository, ProfesorRepository>();
builder.Services.AddScoped<IProfesorService, ProfesorService>();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

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
