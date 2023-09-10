using Online.Shopping.Application;
using Online.Shopping.Persistence;
using Online.Shopping.Infrastructure;
using Online.Shopping.Api.Extensions;
using Online.Shopping.Api.Middleware;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
     .AddJwtBearer(options =>
     {
         options.Authority = builder.Configuration.GetSection("AuthSettings:Authority").Value;
         options.Audience = builder.Configuration.GetSection("AuthSettings:Audience").Value;
     });

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Online Shopping");
        c.OAuthClientId(builder.Configuration.GetSection("AuthSettings:ClientId").Value);
        c.OAuthClientSecret(builder.Configuration.GetSection("AuthSettings:ClientSecret").Value);
        c.OAuthUsePkce();
    });
    app.ApplyMigrations();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapControllers();

app.Run();

public partial class Program { }