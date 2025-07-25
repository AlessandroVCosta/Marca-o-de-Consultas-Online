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
using Microsoft.AspNetCore.Identity;


namespace ClinicaXPTO.SERVICE.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly JwtService _jwtService;


        public UserService(IUserRepository userRepo, IMapper mapper, IPasswordHasher<User> passwordHasher, JwtService jwtService)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
        }


public async Task<UserReadDto> CreateUserAsync(UserAddDto dto)
{
    var existingUser = await _userRepo.GetByEmailAsync(dto.Email);
    if (existingUser != null)
        throw new Exception("Já existe um usuário com este e-mail.");

    var userEntity = _mapper.Map<User>(dto);
    userEntity.PasswordHash = _passwordHasher.HashPassword(userEntity, dto.Password);

    var created = await _userRepo.Create(userEntity);
    if (!created) throw new Exception("Não foi possível criar o usuário.");

    return _mapper.Map<UserReadDto>(userEntity);
}



        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto loginDto)
        {
            var user = await _userRepo.GetByEmailAsync(loginDto.Email);

            if (user == null)
                throw new Exception("Email ou senha inválidos");

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginDto.Password);

            if (result != PasswordVerificationResult.Success)
                throw new Exception("Email ou senha inválidos");

            var token = _jwtService.GenerateToken(user); 

            return new LoginResponseDto
            {
                Token = token,
                Nome = user.NomeCompleto,
                Email = user.Email,
                Role = user.Role.ToString(),
                UserId = user.Id
            };
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
