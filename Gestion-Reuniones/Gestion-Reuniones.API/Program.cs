<<<<<<< HEAD
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

=======
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

>>>>>>> a96f69715b83a79c03e42d579bc9579206f6c8b5
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

<<<<<<< HEAD
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
=======

app.MapControllers();

app.Run();
>>>>>>> a96f69715b83a79c03e42d579bc9579206f6c8b5
