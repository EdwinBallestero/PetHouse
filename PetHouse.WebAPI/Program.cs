using Microsoft.EntityFrameworkCore;
using PetHouse.Application.Profiles;
using PetHouse.Application.Services.Implementations;
using PetHouse.Application.Services.Interfaces;
using PetHouse.Infraestructure.Data;
using PetHouse.Infraestructure.Repository.Implementations;
using PetHouse.Infraestructure.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Controladores
builder.Services.AddControllers();

// Repositorios
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IRolRepository, RolRepository>();

// Servicios
builder.Services.AddScoped<IUsuariosService, UsuariosService>();
builder.Services.AddScoped<IRolesService, RolesService>();

// AutoMapper
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<UsuariosProfile>();
    config.AddProfile<RolesProfile>();
});

// Base de datos
builder.Services.AddDbContext<PetHouseContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("SqlServerDataBase"));
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();