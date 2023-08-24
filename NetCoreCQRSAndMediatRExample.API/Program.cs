using NetCoreCQRSAndMediatRExample.Infrastructure;
using NetCoreCQRSAndMediatRExample.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// application ve Infrastructure katman�nda bulunan Service Collection classlar�m�z� tan�ml�yoruz.
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.ApplicationServiceCollection();

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
