using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Type = Howest.MagicCards.DAL.Models.Type;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.

builder.Services.AddControllers();
//Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MtgContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ICardRepository, SqlCardRepository>();
builder.Services.AddScoped<ISetRepository, SqlSetRepository>();
builder.Services.AddScoped<IRarityRepository, SqlRarityRepository>();

builder.Services.AddAutoMapper(new System.Type[] { typeof(Howest.MagicCards.Shared.Mappings.CardProfile) });
builder.Services.AddAutoMapper(new System.Type[] { typeof(Howest.MagicCards.Shared.Mappings.SetProfile) });
builder.Services.AddAutoMapper(new System.Type[] { typeof(Howest.MagicCards.Shared.Mappings.RarityProfile) });

var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
