
using Microsoft.AspNetCore.Mvc;
using PetHouse.Application.DTOs;
using PetHouse.Application.Services.Interfaces;

namespace PetHouse.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductosService _productosService;

        public ProductosController(
            IProductosService productosService)
        {
            _productosService = productosService;
        }

        // GET: api/Productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductosDTO>>>
            GetAll()
        {
            var productos =
                await _productosService.GetAllAsync();

            return Ok(productos);
        }

        // GET: api/Productos/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductosDTO>>
            GetById(int id)
        {
            var producto =
                await _productosService.GetByIdAsync(id);

            if (producto == null)
                return NotFound(new
                {
                    mensaje = "El producto no existe."
                });

            return Ok(producto);
        }

        // POST: api/Productos
        [HttpPost]
        public async Task<ActionResult<ProductosDTO>>
            Create([FromBody] ProductosDTO dto)
        {
            var creado =
                await _productosService.InsertAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = creado.ProductoId },
                creado);
        }

        // PUT: api/Productos/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult>
            Update(int id, [FromBody] ProductosDTO dto)
        {
            if (id != dto.ProductoId)
            {
                return BadRequest(new
                {
                    mensaje =
                        "El ID de la ruta no coincide con el del producto."
                });
            }

            var actualizado =
                await _productosService.UpdateAsync(dto);

            if (actualizado == null)
            {
                return NotFound(new
                {
                    mensaje = "El producto no existe."
                });
            }

            return Ok(actualizado);
        }

        // DELETE: api/Productos/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado =
                await _productosService.DeleteAsync(id);

            if (!eliminado)
            {
                return NotFound(new
                {
                    mensaje = "El producto no existe."
                });
            }

            return NoContent();
        }
    }
}
