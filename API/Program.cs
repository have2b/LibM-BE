using API.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

{
    builder.Services.ConfigureSwagger();
    builder.Services.ConfigureSqlContext(builder.Configuration);
    builder.Services.ConfigureRepositoryManager();
    builder.Services.ConfigureServiceManager();
    builder.Services.ConfigureJWT(builder.Configuration);
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();

app.Run();