using Microsoft.Extensions.DependencyInjection;
using WebApplicationAPI;
using WebApplicationAPI.Controllers;
using WebApplicationAPI.Middlewares;
using WebApplicationAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ------> CONEXION CON ENTITY FRAMEWORK <-------
builder.Services.AddSqlServer<TareaContext>("Data Source=JUAND; Initial Catalog=TareasApi; Integrated Security=True; Encrypt=false; TrustServerCertificate=True;");

//INYECCION DE DEPENDENCIAS 
//builder.Services.AddScoped<IHolaMundoService, HolaMundoService>();
builder.Services.AddScoped<IHolaMundoService>(x => new HolaMundoService());
builder.Services.AddScoped<ICategoriaServices,CategoriaService>();
builder.Services.AddScoped<ITareasService,TareasService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseWelcomePage();

//app.UseTimeMiddleware();


app.MapControllers();

app.Run();
