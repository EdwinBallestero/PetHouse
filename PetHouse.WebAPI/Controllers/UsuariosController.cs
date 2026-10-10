using Microsoft.AspNetCore.Mvc;
using PetHouse.Application.DTOs;
using PetHouse.Application.Services.Interfaces;

namespace PetHouse.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosService _usuariosService;

        public UsuariosController(IUsuariosService usuariosService)
        {
            _usuariosService = usuariosService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<UsuariosDTO>>> GetAll()
        {
            var usuarios = await _usuariosService.GetAllAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UsuariosDTO>> GetById(int id)
        {
            var usuario = await _usuariosService.GetByIdAsync(id);
            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuariosDTO>> Create([FromBody] UsuariosDTO dto)
        {
            try
            {
                var created = await _usuariosService.InsertAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = created.UsuarioId }, created);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UsuariosDTO dto)
        {
            if (id != dto.UsuarioId)
                return BadRequest(new { mensaje = "El id de la ruta no coincide con el del cuerpo." });

            try
            {
                var updated = await _usuariosService.UpdateAsync(dto);
                if (updated == null)
                    return NotFound();

                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<UsuariosDTO>> Login([FromBody] UsuariosDTO dto)
        {
            var usuario = await _usuariosService.LoginAsync(dto);
            if (usuario == null)
                return Unauthorized(new { mensaje = "Correo o contraseña incorrectos." });

            return Ok(usuario);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _usuariosService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}