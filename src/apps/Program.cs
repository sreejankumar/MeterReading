using Api.Core.Commands;
using Api.Core.Data;
using Api.Core.Middleware;
using Logging.Extensions;
using Logging.Interfaces;
using MeterReading.Api.Core.Commands;
using MeterReading.Api.Core.Data.Services;
using MeterReading.Api.Datastore;
using MeterReading.Api.Datastore.Configuration;
using MeterReading.Api.Datastore.Interfaces;
using MeterReading.Api.Datastore.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var services = builder.Services;

services.AddControllers();

services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
services.Configure<DatabaseConfiguration>(builder.Configuration.GetSection(DatabaseConfiguration.DatabaseConfigurationPrefix));

services.AddSingleton<ApplicationDbContext>();


services.AddCommandsFromAssembly();
services.AddScoped<PostMeterReadingCommand>();

services.AddConsoleLogging();
services.AddScoped<IContextLogModel, ApiLogContext>();

services.AddScoped<IUnitOfWork, UnitOfWork>();
services.AddScoped<IAccountDataService, AccountDataService>();
services.AddScoped<IMeterReadingDataService, MeterReadingDataService>();

services.AddScoped<IMeterReadingService, MeterReadingService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
 app.UseMiddleware<ErrorHandlingMiddleware>();


app.Run();
