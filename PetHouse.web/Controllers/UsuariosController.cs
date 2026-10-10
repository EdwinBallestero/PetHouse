
using Microsoft.AspNetCore.Mvc;
using PetHouse.web.Services;

namespace PetHouse.web.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly UsuarioApiService _usuarioApiService;

        public UsuariosController(UsuarioApiService usuarioApiService)
        {
            _usuarioApiService = usuarioApiService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var usuarios = await _usuarioApiService.GetAllAsync();
                return View(usuarios);
            }
            catch (HttpRequestException)
            {
                ViewBag.Error = "No se pudo conectar con PetHouse.WebAPI. Verificá que la API esté ejecutándose.";
                return View(new List<PetHouse.Application.DTOs.UsuariosDTO>());
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            var usuario = await _usuarioApiService.GetByIdAsync(id);

            if (usuario == null)
                return NotFound();

            return View(usuario);
        }
    }
}
