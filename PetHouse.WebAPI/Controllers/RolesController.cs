using Microsoft.AspNetCore.Mvc;
using PetHouse.Application.DTOs;
using PetHouse.Application.Services.Interfaces;

namespace PetHouse.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRolesService _rolesService;

        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<RolesDTO>>> GetAll()
        {
            var roles = await _rolesService.GetAllAsync();
            return Ok(roles);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<RolesDTO>> GetById(int id)
        {
            var rol = await _rolesService.GetByIdAsync(id);
            if (rol == null)
                return NotFound();

            return Ok(rol);
        }

        [HttpPost]
        public async Task<ActionResult<RolesDTO>> Create([FromBody] RolesDTO dto)
        {
            var created = await _rolesService.InsertAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.RoleId }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] RolesDTO dto)
        {
            if (id != dto.RoleId)
                return BadRequest("El id de la ruta no coincide con el del cuerpo.");

            var updated = await _rolesService.UpdateAsync(dto);
            if (updated == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _rolesService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}