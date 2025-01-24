using Tourmine.Tournament.Application.Interface.TournamentManagement;
using Tourmine.Tournament.Application.UseCases.TournamentManagement;
using Tourmine.Tournament.Domain.Interfaces.Repositories;
using Tourmine.Tournament.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços necessários para Swagger
builder.Services.AddControllers(); // Adiciona o controller
builder.Services.AddEndpointsApiExplorer(); // Adiciona o endpoint no swagger
builder.Services.AddSwaggerGen();  // Adiciona o swagger

// Add Mediator DI
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

// UseCase DI
builder.Services.AddScoped<ICreateTournamentUseCase, CreateTournamentUseCase>();

// Repository DI
builder.Services.AddScoped<ITournamentRepository, TournamentRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Habilita o Swagger

    // Habilita a interface gráfica do Swagger UI
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
