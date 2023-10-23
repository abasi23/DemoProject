using MediatR;
using Microsoft.EntityFrameworkCore;
using RA.Application.CQRS.ProductCommandQuery.Command;
using RA.Config;
using RA.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
DIConfig.Init(builder.Services);
builder.Services.AddDatabaseSetup(builder.Configuration);
builder.Services.AddMediatR(typeof(AddProductCommandRequest));
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

app.Run();
