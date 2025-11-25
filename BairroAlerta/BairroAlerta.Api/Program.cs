using Microsoft.EntityFrameworkCore;
using BairroAlerta.Api.Data;
using BairroAlerta.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Libera CORS para qualquer origem
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Banco em memória
builder.Services.AddDbContext<AlertaContext>(opt =>
    opt.UseInMemoryDatabase("BairroAlertaDB"));

// Serviço que gera alertas fake
builder.Services.AddScoped<IDetectorService, FakeDetectorService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(); // Habilita CORS

app.UseSwagger(); // Docs
app.UseSwaggerUI(); // Interface Swagger

app.MapControllers(); // Mapeia rotas

app.Run(); // Inicia API
