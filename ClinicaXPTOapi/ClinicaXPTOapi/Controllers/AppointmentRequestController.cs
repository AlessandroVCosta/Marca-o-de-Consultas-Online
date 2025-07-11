using ClinicaXPTO.DTO.AppointmentRequest;
using ClinicaXPTO.SHARED.IService;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaXPTO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentRequestController : ControllerBase
    {
        private readonly IAppointmentRequestService _appointmentRequestService;

        public AppointmentRequestController(IAppointmentRequestService appointmentRequestService)
        {
            _appointmentRequestService = appointmentRequestService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _appointmentRequestService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _appointmentRequestService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]

        public async Task<IActionResult> Add([FromBody] AppointmentRequestAddDto dto)

        {
            var result = await _appointmentRequestService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] AppointmentRequestUpdateDto dto)
        {
            var updated = await _appointmentRequestService.UpdateAsync( dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _appointmentRequestService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
