using Microsoft.EntityFrameworkCore;
using Tourmine.Tournament.Application.Interface.TournamentManagement;
using Tourmine.Tournament.Application.Interfaces.SubscriptionManagement;
using Tourmine.Tournament.Application.UseCases.SubscriptionManagement;
using Tourmine.Tournament.Application.UseCases.TournamentManagement;
using Tourmine.Tournament.Domain.Entities.TournamentManagement;
using Tourmine.Tournament.Domain.Enums;
using Tourmine.Tournament.Domain.Interfaces.Caching;
using Tourmine.Tournament.Domain.Interfaces.Repositories;
using Tourmine.Tournament.Domain.Interfaces.Services;
using Tourmine.Tournament.Infrastructure;
using Tourmine.Tournament.Infrastructure.Context;
using Tourmine.Tournament.Infrastructure.Persistence.Caching;
using Tourmine.Tournament.Infrastructure.Persistence.Repositories;
using Tourmine.Tournament.Infrastructure.Persistence.Service;

var builder = WebApplication.CreateBuilder(args);

//// Adiciona o appsettings.Docker.json quando rodando no container
//var environment = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER");
//if (!string.IsNullOrEmpty(environment))
//{
//    builder.Configuration.AddJsonFile("appsettings.Docker.json", optional: true);
//}

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

// RabbitMq
builder.Services.AddSingleton<IRabbitMqPublisher, RabbitMqPublisher>();

// UseCase DI
builder.Services.AddScoped<ICreateTournamentUseCase, CreateTournamentUseCase>();
builder.Services.AddScoped<IGetTournamentByIdUseCase, GetTournamentByIdUseCase>();
builder.Services.AddScoped<IUpdateTournamentUseCase, UpdateTournamentUseCase>();
builder.Services.AddScoped<IGetTournamentAllUseCase, GetTournamentAllUseCase>();

builder.Services.AddScoped<ICreateSubscriptionUseCase, CreateSubscriptionUseCase>();
builder.Services.AddScoped<IUpdateSubscriptionUseCase, UpdateSubscriptionUseCase>();
builder.Services.AddScoped<IGetAllSubscriptionByUserIdUseCase, GetAllSubscriptionByUserIdUseCase>();
builder.Services.AddScoped<IGetAllSubscriptionByTournamentIdUseCase, GetAllSubscriptionByTournamentIdUseCase>();
builder.Services.AddScoped<ICancelSubscriptionUseCase, CancelSubscriptionUseCase>();

// Repository DI
builder.Services.AddScoped<ITournamentRepository, TournamentRepository>();
builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(Settings.ConnectionString));


// Redis
var redisConfig = builder.Configuration.GetSection("Redis").Get<RedisConfig>();

builder.Services.AddScoped<ICachingService, CachingService>();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = redisConfig.Configuration; 
    options.InstanceName = redisConfig.InstanceName; 
});


var app = builder.Build();

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Habilita o Swagger
    app.UseSwaggerUI(); // Habilita a interface gráfica do Swagger UI
}

//app.UseHttpsRedirection();

app.UseCors(corsPolicy);

app.MapControllers();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

app.Run();
