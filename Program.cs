using Microsoft.AspNetCore.OpenApi;
using MyProject.Services.Features.Productos;
using MyProject.Services.Features.CaSer;


using MyProject.Infrastructure.Repositories;
using MyProject.Infrastructure.Repositories.c;
using static MyProject.Services.Features.Cliente.ClienteService;
using MyProject.Services.Features.Cliente;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ProductoServices>();
builder.Services.AddScoped<CarritoServices>();

builder.Services.AddScoped<ClienteService>();
builder.Services.AddTransient<ProductRepository>();
builder.Services.AddTransient<CarritoRepositorie>();

builder.Services.AddTransient<ClienteInfoRepository>();
builder.Services.AddTransient<ClienteService>();


builder.Services.AddSingleton<ProductoServices>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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


