using Microsoft.EntityFrameworkCore;
using BairroAlerta.Api.Data;
using BairroAlerta.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// CORS liberado para o front rodando no 5500
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// DB InMemory
builder.Services.AddDbContext<AlertaContext>(opt =>
    opt.UseInMemoryDatabase("BairroAlertaDB"));

builder.Services.AddScoped<IDetectorService, FakeDetectorService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(); // <<< IMPORTANTE

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
