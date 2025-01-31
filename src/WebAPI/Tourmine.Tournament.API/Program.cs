using Microsoft.EntityFrameworkCore;
using Tourmine.Tournament.Application.Interface.TournamentManagement;
using Tourmine.Tournament.Application.UseCases.TournamentManagement;
using Tourmine.Tournament.Domain.Interfaces.Repositories;
using Tourmine.Tournament.Infrastructure;
using Tourmine.Tournament.Infrastructure.Context;
using Tourmine.Tournament.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os servi�os necess�rios para Swagger
builder.Services.AddControllers(); // Adiciona o controller
builder.Services.AddEndpointsApiExplorer(); // Adiciona o endpoint no Swagger
builder.Services.AddSwaggerGen();  // Adiciona o Swagger

// Configura��o de CORS
var corsPolicy = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicy,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // Permite Angular consumir a API
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Add Mediator DI
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

// UseCase DI
builder.Services.AddScoped<ICreateTournamentUseCase, CreateTournamentUseCase>();
builder.Services.AddScoped<IGetTournamentByIdUseCase, GetTournamentByIdUseCase>();
builder.Services.AddScoped<IGetTournamentAllUseCase, GetTournamentAllUseCase>();

// Repository DI
builder.Services.AddScoped<ITournamentRepository, TournamentRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString(Settings.ConnectionString)));

var app = builder.Build();

// Configure o pipeline da aplica��o
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Habilita o Swagger
    app.UseSwaggerUI(); // Habilita a interface gr�fica do Swagger UI
}

app.UseHttpsRedirection();

app.UseCors(corsPolicy); 

app.MapControllers(); 

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

app.Run();
