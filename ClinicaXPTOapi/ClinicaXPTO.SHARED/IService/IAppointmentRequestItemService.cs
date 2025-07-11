using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaXPTO.DTO.AppointmentRequestItem;

namespace ClinicaXPTO.SHARED.IService
{
    public interface IAppointmentRequestItemService
    {
        Task<AppointmentRequestItemReadDto> CreateAsync(AppointmentRequestItemAddDto dto);
        Task<AppointmentRequestItemReadDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<AppointmentRequestItemReadDto>> GetAllAsync();
        Task<IEnumerable<AppointmentRequestItemReadDto>> GetByRequestIdAsync(Guid requestId);
        Task<IEnumerable<AppointmentRequestItemReadDto>> GetByProfessionalIdAsync(Guid professionalId);
        Task<IEnumerable<AppointmentRequestItemReadDto>> GetByStatusAsync(int status);
        Task<bool> UpdateAsync(AppointmentRequestItemUpdateDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
