using Microsoft.EntityFrameworkCore;
using Tourmine.Tournament.Application.Interface.TournamentManagement;
using Tourmine.Tournament.Application.Interfaces.SubscriptionManagement;
using Tourmine.Tournament.Application.UseCases.SubscriptionManagement;
using Tourmine.Tournament.Application.UseCases.TournamentManagement;
using Tourmine.Tournament.Domain.Entities.TournamentManagement;
using Tourmine.Tournament.Domain.Enums;
using Tourmine.Tournament.Domain.Interfaces.Repositories;
using Tourmine.Tournament.Infrastructure;
using Tourmine.Tournament.Infrastructure.Context;
using Tourmine.Tournament.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o appsettings.Docker.json quando rodando no container
var environment = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER");
if (!string.IsNullOrEmpty(environment))
{
    builder.Configuration.AddJsonFile("appsettings.Docker.json", optional: true);
}

// Adiciona os serviços necessários para Swagger
builder.Services.AddControllers(); // Adiciona o controller
builder.Services.AddEndpointsApiExplorer(); // Adiciona o endpoint no Swagger
builder.Services.AddSwaggerGen();  // Adiciona o Swagger

// Configuração de CORS
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
builder.Services.AddScoped<IUpdateTournamentUseCase, UpdateTournamentUseCase>();
builder.Services.AddScoped<IGetTournamentAllUseCase, GetTournamentAllUseCase>();

builder.Services.AddScoped<ICreateSubscriptionUseCase, CreateSubscriptionUseCase>();
builder.Services.AddScoped<IUpdateSubscriptionUseCase, UpdateSubscriptionUseCase>();
builder.Services.AddScoped<IGetAllSubscriptionByUserIdUseCase, GetAllSubscriptionByUserIdUseCase>();
builder.Services.AddScoped<IGetAllSubscriptionByTournamentIdUseCase, GetAllSubscriptionByTournamentIdUseCase>();

// Repository DI
builder.Services.AddScoped<ITournamentRepository, TournamentRepository>();
builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseNpgsql(builder.Configuration.GetConnectionString(Settings.ConnectionString)));

var app = builder.Build();

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Habilita o Swagger
    app.UseSwaggerUI(); // Habilita a interface gráfica do Swagger UI
}

//app.UseHttpsRedirection();


using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();

    if (!context.Tournaments.Any())
    {
        context.Tournaments.AddRange(
           new Tournament
           {
               UserId = Guid.NewGuid(),
               Name = "Tournament 1",
               Game = "Game 1",
               Plataform = EPlataforms.PC,
               MaxTeams = 16,
               TeamsType = EParticipantsType.DUO,
               StartDate = DateTime.Now.AddMonths(1),
               EndDate = DateTime.Now.AddMonths(1).AddDays(7),
               Prize = "1000 USD",
               SubscriptionType = ESubscriptionType.FREE,
               Status = ETournamentStatus.Open,
               Description = "This is the first tournament for Game 1"
           },
           new Tournament
           {
               UserId = Guid.NewGuid(),
               Name = "Tournament 2",
               Game = "Game 2",
               Plataform = EPlataforms.PC,
               MaxTeams = 16,
               TeamsType = EParticipantsType.DUO,
               StartDate = DateTime.Now.AddMonths(1),
               EndDate = DateTime.Now.AddMonths(1).AddDays(7),
               Prize = "1000 USD",
               SubscriptionType = ESubscriptionType.FREE,
               Status = ETournamentStatus.Open,
               Description = "This is the first tournament for Game 1"
           }
        );
    }
}

app.UseCors(corsPolicy);

app.MapControllers();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

app.Run();
