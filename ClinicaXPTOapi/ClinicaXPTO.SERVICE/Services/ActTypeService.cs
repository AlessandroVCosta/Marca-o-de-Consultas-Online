using AutoMapper;
using ClinicaXPTO.DTO.ActType;
using ClinicaXPTO.MODEL.Entities;
using ClinicaXPTO.SHARED.IRepository;
using ClinicaXPTO.SHARED.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaXPTO.SERVICE.Services
{
    public class ActTypeService : IActTypeService
    {
        private readonly IActTypeRepository _repo;
        private readonly IMapper _mapper;

        public ActTypeService(IActTypeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ActTypeReadDto> CreateAsync(ActTypeAddDto dto)
        {
            var entity = _mapper.Map<ActType>(dto);
            entity.Id = Guid.NewGuid();
            var created = await _repo.Create(entity);
            if (!created) throw new Exception("Não foi possível criar o tipo de ato.");
            return _mapper.Map<ActTypeReadDto>(entity);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _repo.GetById(id);
            if (existing == null) return false;
            return await _repo.Delete(existing);
        }

        public async Task<IEnumerable<ActTypeReadDto>> GetAllAsync()
        {
            var list = await _repo.List();
            return list.Select(a => _mapper.Map<ActTypeReadDto>(a));
        }

        public async Task<ActTypeReadDto?> GetByIdAsync(Guid id)
        {
            var entity = await _repo.GetById(id);
            return entity == null ? null : _mapper.Map<ActTypeReadDto>(entity);
        }

        public async Task<bool> UpdateAsync(ActTypeUpdateDto dto)
        {
            var existing = await _repo.GetById(dto.Id);
            if (existing == null) return false;
            existing.Nome = dto.Nome;
            existing.Descricao = dto.Descricao;
            return await _repo.Update(existing);
        }
    }
}