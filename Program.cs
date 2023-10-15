using AutoMapper;
using GestionFrancaApi.Application;
using GestionFrancaApi.Application.Interface;
using GestionFrancaApi.DataAccess.Context;
using GestionFrancaApi.Domain;
using GestionFrancaApi.Domain.Interface;
using GestionFrancaApi.Helpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyeccion de dependencias de Aplication
builder.Services.AddScoped<IGenericApplication, GenericApplication>();
builder.Services.AddScoped<ITechnicianApplication, TechnicianApplication>();

//Inyeccion de dependencias de Domain
builder.Services.AddScoped<IGenericDomainService, GenericDomainService>();
builder.Services.AddScoped<ITechnicianDomainService, TechnicianDomainService>();

// Configuracion Automapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutomapperConfig());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var stringconnectionBD = builder.Configuration.GetConnectionString("SQLDefaultConnection");
builder.Services.AddDbContext<GestionFrancaContext>(options => options.UseSqlServer(stringconnectionBD));

//Configuracion de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PoliticaCORS", x =>
    {
        x.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Habilitacion de politicas CORS
app.UseCors("PoliticaCORS");

app.UseAuthorization();

app.MapControllers();

app.Run();
