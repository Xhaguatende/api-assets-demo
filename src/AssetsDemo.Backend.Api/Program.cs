using System.Reflection;
using System.Text.Json.Serialization;
using AssetsDemo.Backend.Api.Handlers;
using AssetsDemo.Backend.Application.Extensions;
using AssetsDemo.Backend.Infrastructure.Extensions;
using AssetsDemo.Backend.Infrastructure.Settings;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseKestrel(options =>
{
    options.AddServerHeader = false;
}).ConfigureAppConfiguration((_, configuration) =>
{
    configuration.AddEnvironmentVariables();
});

var services = builder.Services;

services.AddOptions<SqlServerSettings>()
    .Bind(builder.Configuration.GetSection(nameof(SqlServerSettings)));

services.AddControllers(
        options =>
        {
            options.SuppressAsyncSuffixInActionNames = false;
        }).ConfigureApiBehaviorOptions(
        options => { options.SuppressModelStateInvalidFilter = true; })
    .AddJsonOptions(
        options =>
        {
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        });

services.AddRouting(options => { options.LowercaseUrls = true; });

services.AddExceptionHandler<NotFoundExceptionHandler>();
services.AddExceptionHandler<GlobalExceptionHandler>();
services.AddProblemDetails();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen(
    options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo { Title = "API Assets Demo", Version = "v1" });
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        options.IncludeXmlComments(xmlPath);
        options.EnableAnnotations();
    });

services.RegisterApplication();
services.RegisterInfrastructure();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();