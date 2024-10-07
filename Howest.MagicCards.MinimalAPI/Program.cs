using FluentUtils.MinimalApis.EndpointDefinitions;
using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.DAL.Repositories;
using Howest.MagicCards.MinimalAPI.EndPointDefinitions;
using Howest.MagicCards.Shared.Mappings;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<MongoDbContext>(builder.Configuration.GetSection("Database"));
builder.Services.AddSingleton(provider =>
    provider.GetRequiredService<IOptions<MongoDbContext>>().Value);

builder.Services.AddScoped<IDeckRepository, MdbDeckRepository>();

builder.Services.AddAutoMapper(typeof(DeckProfile));

builder.Services.AddTransient<IEndpointDefinition, DecksEndPoints>();
builder.Services.AddTransient<IEndpointDefinition, SwaggerEndPoints>();

var app = builder.Build();

app.UseHttpsRedirection();

// Apply endpoint definitions
foreach (var definition in app.Services.GetServices<IEndpointDefinition>())
{
    definition.DefineEndpoints(app);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
