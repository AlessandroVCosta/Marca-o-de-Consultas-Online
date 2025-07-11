using AutoMapper;
using ClinicaXPTO.DTO.Professional;
using ClinicaXPTO.MODEL.Entities;
using ClinicaXPTO.SHARED.IRepository;
using ClinicaXPTO.SHARED.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaXPTO.SERVICE.Services
{
    public class ProfessionalService : IProfessionalService
    {
        private readonly IProfessionalRepository _repo;
        private readonly IMapper _mapper;

        public ProfessionalService(IProfessionalRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ProfessionalReadDto> CreateAsync(ProfessionalAddDto dto)
        {
            var entity = _mapper.Map<Professional>(dto);
            entity.Id = Guid.NewGuid();
            var created = await _repo.Create(entity);
            if (!created) throw new Exception("Não foi possível criar o profissional.");
            return _mapper.Map<ProfessionalReadDto>(entity);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _repo.GetById(id);
            if (existing == null) return false;
            return await _repo.Delete(existing);
        }

        public async Task<IEnumerable<ProfessionalReadDto>> GetAllAsync()
        {
            var list = await _repo.List();
            return list.Select(p => _mapper.Map<ProfessionalReadDto>(p));
        }

        public async Task<ProfessionalReadDto?> GetByIdAsync(Guid id)
        {
            var entity = await _repo.GetById(id);
            return entity == null ? null : _mapper.Map<ProfessionalReadDto>(entity);
        }

        public async Task<bool> UpdateAsync(ProfessionalUpdateDto dto)
        {
            var existing = await _repo.GetById(dto.Id);
            if (existing == null) return false;
            existing.NomeCompleto = dto.NomeCompleto;
            existing.Especialidade = dto.Especialidade;
            existing.Email = dto.Email;
            existing.Telefone = dto.Telefone;
            return await _repo.Update(existing);
        }
    }
}
