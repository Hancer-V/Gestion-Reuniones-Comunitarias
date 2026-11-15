using Gestion_Reuniones.Domain.Entities;
using Gestion_Reuniones.Infrastructure.Exceptions;
using Gestion_Reuniones.Infrastructure.Interfaces;
using Gestion_Reuniones.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Reuniones.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcuerdoController : ControllerBase
    {
        private readonly IAcuerdoRepository _repository;

        public AcuerdoController(IAcuerdoRepository repository) => _repository = repository;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _repository.GetAllAsync();
            return Ok(items.Select(x => new AcuerdoModel
            {
                Id = x.Id,
                ReunionId = x.ReunionId,
                ResidenteResponsableId = x.ResidenteResponsableId,
                Titulo = x.Titulo,
                Descripcion = x.Descripcion,
                FechaLimite = x.FechaLimite,
                EstadoSeguimiento = x.EstadoSeguimiento
            }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var x = await _repository.GetByIdAsync(id);
            if (x == null) return NotFound();

            return Ok(new AcuerdoModel
            {
                Id = x.Id,
                ReunionId = x.ReunionId,
                ResidenteResponsableId = x.ResidenteResponsableId,
                Titulo = x.Titulo,
                Descripcion = x.Descripcion,
                FechaLimite = x.FechaLimite,
                EstadoSeguimiento = x.EstadoSeguimiento
            });
        }

        [HttpGet("reunion/{reunionId}")]
        public async Task<IActionResult> GetByReunion(int reunionId)
        {
            var items = await _repository.GetByReunionIdAsync(reunionId);
            return Ok(items.Select(x => new AcuerdoModel
            {
                Id = x.Id,
                ReunionId = x.ReunionId,
                ResidenteResponsableId = x.ResidenteResponsableId,
                Titulo = x.Titulo,
                Descripcion = x.Descripcion,
                FechaLimite = x.FechaLimite,
                EstadoSeguimiento = x.EstadoSeguimiento
            }));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AcuerdoModel model)
        {
            try
            {
                var entity = new Acuerdo
                {
                    ReunionId = model.ReunionId,
                    ResidenteResponsableId = model.ResidenteResponsableId,
                    Titulo = model.Titulo,
                    Descripcion = model.Descripcion,
                    FechaLimite = model.FechaLimite,
                    EstadoSeguimiento = model.EstadoSeguimiento
                };
                await _repository.AddAsync(entity);
                model.Id = entity.Id;
                return CreatedAtAction(nameof(GetById), new { id = entity.Id }, model);
            }
            catch (AcuerdoException ex) { return BadRequest(new { error = ex.Message }); }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AcuerdoModel model)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            existing.ReunionId = model.ReunionId;
            existing.ResidenteResponsableId = model.ResidenteResponsableId;
            existing.Titulo = model.Titulo;
            existing.Descripcion = model.Descripcion;
            existing.FechaLimite = model.FechaLimite;
            existing.EstadoSeguimiento = model.EstadoSeguimiento;

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