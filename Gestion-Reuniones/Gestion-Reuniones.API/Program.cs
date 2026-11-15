using Gestion_Reuniones.Infrastructure.Context;
using Gestion_Reuniones.Infrastructure.Interfaces;
using Gestion_Reuniones.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
builder.Services.AddDbContext<GestionReunionesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositorios
builder.Services.AddScoped<IResidenteRepository, ResidenteRepository>();
builder.Services.AddScoped<IReunionRepository, ReunionRepository>();
builder.Services.AddScoped<IAcuerdoRepository, AcuerdoRepository>();
builder.Services.AddScoped<IAsistenciaRepository, AsistenciaRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();