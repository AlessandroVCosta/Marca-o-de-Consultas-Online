using ClinicaXPTO.DTO.AnonymousRequest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicaXPTO.SHARED.IService
{
    public interface IAnonymousRequestService
    {
        Task<AnonymousRequestReadDto> CreateAsync(AnonymousRequestAddDto dto);
        Task<AnonymousRequestReadDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<AnonymousRequestReadDto>> GetAllAsync();
        Task<bool> UpdateAsync(AnonymousRequestUpdateDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
