using Common.Infrastructure.Extensions;
using Inventory.IoC;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddOpenApi();

builder.Services.Register(configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(opt =>
    {
        opt.AddServer("http://localhost:4000");
    });
}

app.InitializeDB();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
