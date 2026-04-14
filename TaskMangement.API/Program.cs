using TaskMangement.API.Extensions;
using TaskMangement.Data.Configurations;
using TaskMangement.Service.Configurations;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Data Layer
builder.Services.AddProjectDataLayer(builder.Configuration);

// Business Layer (Services Layer)
builder.Services.AddApplicationServices();

// API Layer
builder.Services.AddApiLayer(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
//{
    app.MapOpenApi();
    app.MapScalarApiReference();
    //app.WebHost.UseUrls("http://0.0.0.0:7072");
//}

app.UseCors("TaskMangementAPI");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();