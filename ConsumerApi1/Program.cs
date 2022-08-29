using MediatR;
using Messaging.Common;
using Microsoft.OpenApi.Models;
using ConsumerApi1.Core.Repository;
using ConsumerApi1.Infrastructure.Mongo.Document;
using ConsumerApi1.Infrastructure.Mongo.Repositories;
using ConsumerApi1.Service;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMediatR(typeof(Program));
builder.Services.Configure<ConsumerDatabaseSettings>(
    builder.Configuration.GetSection("Consumer1Db"));
builder.Services.AddSingleton<IConsumerRepository, ConsumerRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Add services to the container.
builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .AddUserSecrets<Program>()
    .AddCommandLine(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Consumer1",
        Version = "v1.0",
        Description = "Consumer to communicate with RabbitMQ"
    });

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.SetUpRabbitMq(builder.Configuration);
builder.Services.AddHostedService<ConsumerService>();


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
