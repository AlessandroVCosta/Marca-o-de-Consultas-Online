using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaXPTO.DTO.AppointmentRequest;

namespace ClinicaXPTO.SHARED.IService
{
    public interface IAppointmentRequestService
    {
        Task<AppointmentRequestReadDto> CreateAsync(AppointmentRequestAddDto dto);
        Task<AppointmentRequestReadDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<AppointmentRequestReadDto>> GetAllAsync();
        Task<IEnumerable<AppointmentRequestReadDto>> GetByUserIdAsync(Guid userId);
        Task<IEnumerable<AppointmentRequestReadDto>> GetByStatusAsync(int status); // status = enum RequestStatus
        Task<bool> UpdateAsync(AppointmentRequestUpdateDto dto);
        Task<bool> DeleteAsync(Guid id);
        Task<byte[]> ExportToPdfAsync(Guid id);    // Para gerar PDF do pedido
    }
}
