
using Microsoft.AspNetCore.Mvc;
using PetHouse.Application.DTOs;
using PetHouse.web.Services;

namespace PetHouse.web.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ProductoApiService _productoApiService;

        public ProductosController(
            ProductoApiService productoApiService)
        {
            _productoApiService = productoApiService;
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            try
            {
                var productos =
                    await _productoApiService.GetAllAsync();

                return View(productos);
            }
            catch (HttpRequestException)
            {
                ViewBag.Error =
                    "No se pudo conectar con PetHouse.WebAPI. " +
                    "Verificá que la API esté ejecutándose.";

                return View(new List<ProductosDTO>());
            }
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var producto =
                    await _productoApiService.GetByIdAsync(id);

                if (producto == null)
                    return NotFound();

                return View(producto);
            }
            catch (HttpRequestException)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Productos/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View(new ProductosDTO
            {
                Activo = true,
                Stock = 0,
                StockMinimo = 0,
                Precio = 0
            });
        }

        // POST: Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductosDTO producto)
        {
            if (!ModelState.IsValid)
                return View(producto);

            try
            {
                var creado =
                    await _productoApiService.CreateAsync(producto);

                if (creado == null)
                {
                    ModelState.AddModelError(
                        string.Empty,
                        "No fue posible registrar el producto.");

                    return View(producto);
                }

                TempData["Success"] =
                    "Producto registrado correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (HttpRequestException)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "No se pudo conectar con PetHouse.WebAPI.");

                return View(producto);
            }
        }

        // GET: Productos/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var producto =
                    await _productoApiService.GetByIdAsync(id);

                if (producto == null)
                    return NotFound();

                return View(producto);
            }
            catch (HttpRequestException)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Productos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id, ProductosDTO producto)
        {
            if (id != producto.ProductoId)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(producto);

            try
            {
                var actualizado =
                    await _productoApiService.UpdateAsync(
                        id, producto);

                if (!actualizado)
                {
                    ModelState.AddModelError(
                        string.Empty,
                        "No fue posible actualizar el producto.");

                    return View(producto);
                }

                TempData["Success"] =
                    "Producto actualizado correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (HttpRequestException)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "No se pudo conectar con PetHouse.WebAPI.");

                return View(producto);
            }
        }

        // GET: Productos/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var producto =
                    await _productoApiService.GetByIdAsync(id);

                if (producto == null)
                    return NotFound();

                return View(producto);
            }
            catch (HttpRequestException)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var eliminado =
                    await _productoApiService.DeleteAsync(id);

                if (!eliminado)
                {
                    TempData["Error"] =
                        "No fue posible eliminar el producto.";
                }
                else
                {
                    TempData["Success"] =
                        "Producto eliminado correctamente.";
                }

                return RedirectToAction(nameof(Index));
            }
            catch (HttpRequestException)
            {
                TempData["Error"] =
                    "No se pudo conectar con PetHouse.WebAPI.";

                return RedirectToAction(nameof(Index));
            }
        }
    }
}
