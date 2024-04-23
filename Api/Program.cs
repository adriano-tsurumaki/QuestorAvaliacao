using Api;
using Infrastructure.Context;
using Infrastructure.Map;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Inject();

var configuration = builder.Configuration;

var connDb = configuration.GetConnectionString("Fatura");

builder.Services.AddDbContext<BancoContext>(options => options.UseNpgsql(connDb));


var mapProfile = new MappingProfile();

builder.Services.AddAutoMapper(map => map.AddProfile(mapProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
