using Carter;
using Dionysus.Server.Application;
using Dionysus.Server.Application.Catalogues.Commands;
using Dionysus.Server.Infrastructure;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddCarter();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/catalogues", async ([FromBody] CreateProduct command, [FromServices] ISender mediator, CancellationToken cancellationToken = default) => await mediator.Send(command, cancellationToken))
.WithName("CreateProduct")
.WithOpenApi();

app.MapCarter();
await app.RunAsync();
