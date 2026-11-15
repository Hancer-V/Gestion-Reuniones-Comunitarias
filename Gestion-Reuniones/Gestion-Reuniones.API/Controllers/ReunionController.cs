using Gestion_Reuniones.Domain.Entities;
using Gestion_Reuniones.Infrastructure.Exceptions;
using Gestion_Reuniones.Infrastructure.Interfaces;
using Gestion_Reuniones.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Reuniones.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReunionController : ControllerBase
    {
        private readonly IReunionRepository _repository;

        public ReunionController(IReunionRepository repository) => _repository = repository;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _repository.GetAllAsync();
            return Ok(items.Select(x => new ReunionModel
            {
                Id = x.Id,
                Titulo = x.Titulo,
                Descripcion = x.Descripcion,
                FechaHora = x.FechaHora,
                Lugar = x.Lugar,
                Estado = x.Estado
            }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var x = await _repository.GetByIdAsync(id);
            if (x == null) return NotFound();

            return Ok(new ReunionModel
            {
                Id = x.Id,
                Titulo = x.Titulo,
                Descripcion = x.Descripcion,
                FechaHora = x.FechaHora,
                Lugar = x.Lugar,
                Estado = x.Estado
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ReunionModel model)
        {
            try
            {
                var entity = new Reunion
                {
                    Titulo = model.Titulo,
                    Descripcion = model.Descripcion,
                    FechaHora = model.FechaHora,
                    Lugar = model.Lugar,
                    Estado = model.Estado
                };
                await _repository.AddAsync(entity);
                model.Id = entity.Id;
                return CreatedAtAction(nameof(GetById), new { id = entity.Id }, model);
            }
            catch (ReunionException ex) { return BadRequest(new { error = ex.Message }); }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ReunionModel model)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            existing.Titulo = model.Titulo;
            existing.Descripcion = model.Descripcion;
            existing.FechaHora = model.FechaHora;
            existing.Lugar = model.Lugar;
            existing.Estado = model.Estado;

            await _repository.UpdateAsync(existing);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}