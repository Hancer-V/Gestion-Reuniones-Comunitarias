using Gestion_Reuniones.Domain.Entities;
using Gestion_Reuniones.Infrastructure.Exceptions;
using Gestion_Reuniones.Infrastructure.Interfaces;
using Gestion_Reuniones.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Reuniones.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsistenciaController : ControllerBase
    {
        private readonly IAsistenciaRepository _repository;

        public AsistenciaController(IAsistenciaRepository repository) => _repository = repository;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _repository.GetAllAsync();
            return Ok(items.Select(x => new AsistenciaModel
            {
                Id = x.Id,
                ReunionId = x.ReunionId,
                ResidenteId = x.ResidenteId,
                Asistio = x.Asistio,
                HoraLlegada = x.HoraLlegada,
                Observaciones = x.Observaciones
            }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var x = await _repository.GetByIdAsync(id);
            if (x == null) return NotFound();

            return Ok(new AsistenciaModel
            {
                Id = x.Id,
                ReunionId = x.ReunionId,
                ResidenteId = x.ResidenteId,
                Asistio = x.Asistio,
                HoraLlegada = x.HoraLlegada,
                Observaciones = x.Observaciones
            });
        }

        [HttpGet("reunion/{reunionId}")]
        public async Task<IActionResult> GetByReunion(int reunionId)
        {
            var items = await _repository.GetByReunionIdAsync(reunionId);
            return Ok(items.Select(x => new AsistenciaModel
            {
                Id = x.Id,
                ReunionId = x.ReunionId,
                ResidenteId = x.ResidenteId,
                Asistio = x.Asistio,
                HoraLlegada = x.HoraLlegada,
                Observaciones = x.Observaciones
            }));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AsistenciaModel model)
        {
            try
            {
                var entity = new Asistencia
                {
                    ReunionId = model.ReunionId,
                    ResidenteId = model.ResidenteId,
                    Asistio = model.Asistio,
                    HoraLlegada = model.HoraLlegada,
                    Observaciones = model.Observaciones
                };
                await _repository.AddAsync(entity);
                model.Id = entity.Id;
                return CreatedAtAction(nameof(GetById), new { id = entity.Id }, model);
            }
            catch (AsistenciaException ex) { return BadRequest(new { error = ex.Message }); }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AsistenciaModel model)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            existing.ReunionId = model.ReunionId;
            existing.ResidenteId = model.ResidenteId;
            existing.Asistio = model.Asistio;
            existing.HoraLlegada = model.HoraLlegada;
            existing.Observaciones = model.Observaciones;

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