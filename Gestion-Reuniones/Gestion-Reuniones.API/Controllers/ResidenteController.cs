using Gestion_Reuniones.Domain.Entities;
using Gestion_Reuniones.Infrastructure.Exceptions;
using Gestion_Reuniones.Infrastructure.Interfaces;
using Gestion_Reuniones.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Reuniones.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResidenteController : ControllerBase
    {
        private readonly IResidenteRepository _repository;

        public ResidenteController(IResidenteRepository repository) => _repository = repository;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _repository.GetAllAsync();
            return Ok(items.Select(x => new ResidenteModel
            {
                Id = x.Id,
                NombreCompleto = x.NombreCompleto,
                DocumentoIdentidad = x.DocumentoIdentidad,
                Telefono = x.Telefono,
                Correo = x.Correo,
                UnidadVivienda = x.UnidadVivienda,
                Activo = x.Activo
            }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var x = await _repository.GetByIdAsync(id);
            if (x == null) return NotFound();

            return Ok(new ResidenteModel
            {
                Id = x.Id,
                NombreCompleto = x.NombreCompleto,
                DocumentoIdentidad = x.DocumentoIdentidad,
                Telefono = x.Telefono,
                Correo = x.Correo,
                UnidadVivienda = x.UnidadVivienda,
                Activo = x.Activo
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ResidenteModel model)
        {
            try
            {
                var entity = new Residente
                {
                    NombreCompleto = model.NombreCompleto,
                    DocumentoIdentidad = model.DocumentoIdentidad,
                    Telefono = model.Telefono,
                    Correo = model.Correo,
                    UnidadVivienda = model.UnidadVivienda,
                    Activo = model.Activo
                };
                await _repository.AddAsync(entity);
                model.Id = entity.Id;
                return CreatedAtAction(nameof(GetById), new { id = entity.Id }, model);
            }
            catch (ResidenteException ex) { return BadRequest(new { error = ex.Message }); }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ResidenteModel model)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            existing.NombreCompleto = model.NombreCompleto;
            existing.DocumentoIdentidad = model.DocumentoIdentidad;
            existing.Telefono = model.Telefono;
            existing.Correo = model.Correo;
            existing.UnidadVivienda = model.UnidadVivienda;
            existing.Activo = model.Activo;

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