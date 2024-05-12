using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.DAL.Repositories;
using Howest.MagicCards.GraphQL.Schemas;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Get the configuration from the builder
var configuration = builder.Configuration;

// Build the connection string
var connectionString = configuration.GetConnectionString("DefaultConnection");

// Register the DbContext
builder.Services.AddDbContext<MtgContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<ICardRepository, SqlCardRepository>();

builder.Services.AddScoped<RootSchema>();
builder.Services.AddGraphQL()
    .AddGraphTypes(typeof(RootSchema), ServiceLifetime.Scoped)
    .AddDataLoader()
    .AddSystemTextJson();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseGraphQL<RootSchema>();
app.UseGraphQLPlayground(options: new GraphQLPlaygroundOptions());

app.Run();