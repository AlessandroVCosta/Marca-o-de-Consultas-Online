using ClinicaXPTO.DTO.User;
using ClinicaXPTO.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaXPTO.SHARED.IService
{
    public interface IUserService
    {
        Task<UserReadDto> CreateUserAsync(UserAddDto dto);
        Task<bool> UpdateUserAsync(UserUpdateDto dto);
        Task<bool> DeleteUserAsync(Guid id);
        Task<UserReadDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<UserReadDto>> GetAllAsync();
        Task<UserReadDto?> GetByEmailAsync(string email);
        Task<LoginResponseDto> LoginAsync(LoginRequestDto loginDto);


    }
}
