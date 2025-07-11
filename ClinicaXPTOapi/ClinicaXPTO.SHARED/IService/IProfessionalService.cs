using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaXPTO.MODEL.Entities;
using ClinicaXPTO.DTO.Professional;

namespace ClinicaXPTO.SHARED.IService
{
    public interface IProfessionalService
    {
        Task<ProfessionalReadDto> CreateAsync(ProfessionalAddDto dto);
        Task<IEnumerable<ProfessionalReadDto>> GetAllAsync();
        Task<ProfessionalReadDto?> GetByIdAsync(Guid id);
        Task<bool> UpdateAsync(ProfessionalUpdateDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
