using Microsoft.EntityFrameworkCore;
using RecursosHumanos.API.Data;
using RecursosHumanos.API.Repositories;
using RecursosHumanos.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Registrar el DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpClient<IExternalUserService, ExternalUserService>();

// Registrar los repositorios
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IGenderRepository, GenderRepository>();
builder.Services.AddScoped<IStatusRepository, StatusRepository>();

// Registrar los servicios
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IGenderService, GenderService>();
builder.Services.AddScoped<IStatusService, StatusService>();

builder.Services.AddControllers();

// Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Agregar servicios de autorización
builder.Services.AddAuthorization();

// Agregar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:3000")  
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configurar el pipeline de la aplicación
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Habilitar CORS
app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
