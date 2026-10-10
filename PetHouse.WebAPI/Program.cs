using Microsoft.EntityFrameworkCore;
using PetHouse.Application.Profiles;
using PetHouse.Application.Services.Implementations;
using PetHouse.Application.Services.Interfaces;
using PetHouse.Infraestructure.Data;
using PetHouse.Infraestructure.Repositories.Interfaces;
using PetHouse.Infraestructure.Repositories;
using PetHouse.Infraestructure.Repository.Implementations;
using PetHouse.Infraestructure.Repository.Interfaces;
using PetHouse.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Controladores
builder.Services.AddControllers();

// Repositorios
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IRolRepository, RolRepository>();
builder.Services.AddScoped<IProductosRepository, ProductosRepository>();

// Servicios
builder.Services.AddScoped<IUsuariosService, UsuariosService>();
builder.Services.AddScoped<IRolesService, RolesService>();
builder.Services.AddScoped<IProductosService, ProductosService>();

// AutoMapper
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<UsuariosProfile>();
    config.AddProfile<RolesProfile>();
    config.AddProfile<ProductosProfile>();
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