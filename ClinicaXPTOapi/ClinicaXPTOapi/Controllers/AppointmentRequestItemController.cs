using ClinicaXPTO.DTO.AppointmentRequestItem;
using ClinicaXPTO.SHARED.IService;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaXPTO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentRequestItemController : ControllerBase
    {
        private readonly IAppointmentRequestItemService _service;

        public AppointmentRequestItemController(IAppointmentRequestItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AppointmentRequestItemAddDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] AppointmentRequestItemUpdateDto dto)
        {
            var updated = await _service.UpdateAsync(dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        // Métodos adicionais (opcionalmente)
        [HttpGet("byRequest/{requestId}")]
        public IActionResult GetByRequestId(Guid requestId)
        {
            var items = _service.GetByIdAsync(requestId);
            return Ok(items);
        }

        [HttpGet("byProfessional/{professionalId}")]
        public IActionResult GetByProfessionalId(Guid professionalId)
        {
            var items = _service.GetByProfessionalIdAsync(professionalId);
            return Ok(items);
        }
    }
}
