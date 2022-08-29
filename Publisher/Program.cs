using MediatR;
using Messaging.Common;
using Microsoft.OpenApi.Models;
using Publisher.Core.Repository;
using Publisher.Infrastructure.Mongo.Document;
using Publisher.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(typeof(Program));
builder.Services.Configure<PublisherDatabaseSettings>(
    builder.Configuration.GetSection("PublisherDb"));
builder.Services.AddSingleton<IPublisherRepository, PublisherRepository>();
//builder.Services.AddSingleton<IRabbitMQPublisherRepository, RabbitMQPublisherRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .AddUserSecrets<Program>()
    .AddCommandLine(args);

builder.Services.SetUpRabbitMq(builder.Configuration);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Publisher",
        Version = "v1.0",
        Description = "Publisher to communicate with RabbitMQ"
    });

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.SetUpRabbitMq(builder.Configuration);
builder.Services.AddSingleton<RabbitMQPublisherRepository>();

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