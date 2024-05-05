using Rent.API.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
Serilog.Log.Logger = logger;

builder.Host.UseSerilog(logger);

builder.Services.Configurar(builder.Configuration);

var app = builder.Build();

app.Configurar();

app.Run();
