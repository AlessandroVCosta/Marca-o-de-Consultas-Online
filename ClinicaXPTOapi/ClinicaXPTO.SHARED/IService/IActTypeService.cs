using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaXPTO.MODEL.Entities;
using ClinicaXPTO.DTO.ActType;

namespace ClinicaXPTO.SHARED.IService
{
    public interface IActTypeService
    {
        Task<ActTypeReadDto> CreateAsync(ActTypeAddDto dto);
        Task<IEnumerable<ActTypeReadDto>> GetAllAsync();
        Task<ActTypeReadDto?> GetByIdAsync(Guid id);
        Task<bool> UpdateAsync(ActTypeUpdateDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
