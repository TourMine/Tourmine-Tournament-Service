using Microsoft.EntityFrameworkCore;
using Tourmine.Tournament.Application.Interface.TournamentManagement;
using Tourmine.Tournament.Application.UseCases.TournamentManagement;
using Tourmine.Tournament.Domain.Interfaces.Repositories;
using Tourmine.Tournament.Infrastructure;
using Tourmine.Tournament.Infrastructure.Context;
using Tourmine.Tournament.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços necessários para Swagger
builder.Services.AddControllers(); // Adiciona o controller
builder.Services.AddEndpointsApiExplorer(); // Adiciona o endpoint no swagger
builder.Services.AddSwaggerGen();  // Adiciona o swagger

// Add Mediator DI
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

// UseCase DI
builder.Services.AddScoped<ICreateTournamentUseCase, CreateTournamentUseCase>();

// Repository DI
builder.Services.AddScoped<ITournamentRepository, TournamentRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString(Settings.ConnectionString)));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Habilita o Swagger

    // Habilita a interface gráfica do Swagger UI
    app.UseSwaggerUI();
}

app.MapControllers(); // Mapear os controladores

app.UseHttpsRedirection();

app.Run();
