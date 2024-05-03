using Rent.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configurar(builder.Configuration);

var app = builder.Build();

app.Configurar();

app.Run();
