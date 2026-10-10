
using PetHouse.web.Services;

var builder = WebApplication.CreateBuilder(args);

// MVC: controladores y vistas
builder.Services.AddControllersWithViews();

// Cliente HTTP para consumir PetHouse.WebAPI
var apiBaseUrl = builder.Configuration["ApiSettings:BaseUrl"];

if (string.IsNullOrWhiteSpace(apiBaseUrl))
{
    throw new InvalidOperationException(
        "No se configuró ApiSettings:BaseUrl en appsettings.json.");
}

builder.Services.AddHttpClient<UsuarioApiService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});

var app = builder.Build();

// Manejo de errores
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Ruta MVC predeterminada
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
