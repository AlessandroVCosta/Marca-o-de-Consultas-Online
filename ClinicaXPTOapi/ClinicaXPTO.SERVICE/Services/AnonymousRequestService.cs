using AutoMapper;
using ClinicaXPTO.DTO.ActType;
using ClinicaXPTO.DTO.AnonymousRequest;
using ClinicaXPTO.MODEL.Entities;
using ClinicaXPTO.SHARED.IRepository;
using ClinicaXPTO.SHARED.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaXPTO.SERVICE.Services
{
    public class AnonymousRequestService : IAnonymousRequestService
    {
        private readonly IAnonymousRequestRepository _anonRepo;
        private readonly IMapper _mapper;

        public AnonymousRequestService(IAnonymousRequestRepository anonRepo, IMapper mapper)
        {
            _anonRepo = anonRepo;
            _mapper = mapper;
        }

        public async Task<AnonymousRequestReadDto> CreateAsync(AnonymousRequestAddDto dto)
        {
            var entity = _mapper.Map<AnonymousRequest>(dto);
            entity.Id = Guid.NewGuid();
            var created = await _anonRepo.Create(entity);
            if (!created) throw new Exception("Não foi possível criar o pedido anônimo.");
            return _mapper.Map<AnonymousRequestReadDto>(entity);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _anonRepo.GetById(id);
            if (existing == null) return false;
            return await _anonRepo.Delete(existing);
        }

        public async Task<IEnumerable<AnonymousRequestReadDto>> GetAllAsync()
        {
            var list = await _anonRepo.List();
            return list.Select(a => _mapper.Map<AnonymousRequestReadDto>(a));
        }

        public async Task<AnonymousRequestReadDto?> GetByIdAsync(Guid id)
        {
            var entity = await _anonRepo.GetById(id);
            return entity == null ? null : _mapper.Map<AnonymousRequestReadDto>(entity);
        }

        public async Task<bool> UpdateAsync(AnonymousRequestUpdateDto dto)
        {
            var existing = await _anonRepo.GetById(dto.Id);
            if (existing == null) return false;
            _mapper.Map(dto, existing);
            return await _anonRepo.Update(existing);
        }
    }
}