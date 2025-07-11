using AutoMapper;
using ClinicaXPTO.DTO.User;
using ClinicaXPTO.MODEL.Entities;
using ClinicaXPTO.SHARED.IRepository;
using ClinicaXPTO.SHARED.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaXPTO.SERVICE.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<UserReadDto> CreateUserAsync(UserAddDto dto)
        {
            var hashedPassword = HashPassword(dto.Password);

            var userEntity = _mapper.Map<User>(dto);
            userEntity.PasswordHash = hashedPassword;
            

            var created = await _userRepo.Create(userEntity);
            if (!created) throw new Exception("Não foi possível criar o usuário.");

            return _mapper.Map<UserReadDto>(userEntity);
        }

        public string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var hash = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hash);
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var existing = await _userRepo.GetById(id);
            if (existing == null) return false;
            return await _userRepo.Delete(existing);
        }

        public async Task<IEnumerable<UserReadDto>> GetAllAsync()
        {
            var users = await _userRepo.List();
            return users.Select(u => _mapper.Map<UserReadDto>(u));
        }

        public async Task<UserReadDto?> GetByEmailAsync(string email)
        {
            // Exemplo de método específico: buscar por e-mail (você pode implementar no repositorio)
            var allUsers = await _userRepo.List();
            var user = allUsers.FirstOrDefault(u => u.Email == email);
            return user == null ? null : _mapper.Map<UserReadDto>(user);
        }

        public async Task<UserReadDto?> GetByIdAsync(Guid id)
        {
            var user = await _userRepo.GetById(id);
            return user == null ? null : _mapper.Map<UserReadDto>(user);
        }

        public async Task<bool> UpdateUserAsync(UserUpdateDto dto)
        {
            var existing = await _userRepo.GetById(dto.Id);
            if (existing == null) return false;

            // Mapear somente campos permitidos
            existing.NomeCompleto = dto.NomeCompleto;
            existing.DataNascimento = dto.DataNascimento;
            existing.Genero = (MODEL.Enums.Gender?)dto.Genero;
            existing.FotografiaUrl = dto.FotografiaUrl;
            existing.Telefone = dto.Telefone;
            existing.Morada = dto.Morada;
            existing.NumeroUtenteSaude = dto.NumeroUtenteSaude;

            return await _userRepo.Update(existing);
        }
    }
}
