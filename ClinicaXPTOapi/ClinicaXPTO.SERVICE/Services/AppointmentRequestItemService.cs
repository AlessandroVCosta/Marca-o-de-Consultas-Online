using AutoMapper;
using ClinicaXPTO.DTO.AppointmentRequestItem;
using ClinicaXPTO.MODEL.Entities;
using ClinicaXPTO.MODEL.Enums;
using ClinicaXPTO.SHARED.IRepository;
using ClinicaXPTO.SHARED.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaXPTO.SERVICE.Services
{
    public class AppointmentRequestItemService : IAppointmentRequestItemService
    {
        private readonly IAppointmentRequestItemRepository _repo;
        private readonly IMapper _mapper;

        public AppointmentRequestItemService(
            IAppointmentRequestItemRepository repo,
            IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<AppointmentRequestItemReadDto> CreateAsync(AppointmentRequestItemAddDto dto)
        {
            var entity = _mapper.Map<AppointmentRequestItem>(dto);
            entity.Id = Guid.NewGuid();
            var created = await _repo.Create(entity);
            if (!created) throw new Exception("Não foi possível criar o item de requisição.");
            return _mapper.Map<AppointmentRequestItemReadDto>(entity);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _repo.GetById(id);
            if (existing == null) return false;
            return await _repo.Delete(existing);
        }

        public async Task<IEnumerable<AppointmentRequestItemReadDto>> GetAllAsync()
        {
            var list = await _repo.List();
            return list.Select(i => _mapper.Map<AppointmentRequestItemReadDto>(i));
        }

        public async Task<AppointmentRequestItemReadDto?> GetByIdAsync(Guid id)
        {
            var entity = await _repo.GetById(id);
            return entity == null ? null : _mapper.Map<AppointmentRequestItemReadDto>(entity);
        }

        public async Task<IEnumerable<AppointmentRequestItemReadDto>> GetByRequestIdAsync(Guid requestId)
        {
            var items = _repo.GetByRequestId(requestId);
            return items.Select(i => _mapper.Map<AppointmentRequestItemReadDto>(i));
        }

        public async Task<IEnumerable<AppointmentRequestItemReadDto>> GetByProfessionalIdAsync(Guid professionalId)
        {
            var items = _repo.GetByProfessionalId(professionalId);
            return items.Select(i => _mapper.Map<AppointmentRequestItemReadDto>(i));
        }

        public async Task<IEnumerable<AppointmentRequestItemReadDto>> GetByStatusAsync(int status)
        {
            var items = _repo.GetByStatus((RequestStatus)status);
            return items.Select(i => _mapper.Map<AppointmentRequestItemReadDto>(i));
        }


        public async Task<bool> UpdateAsync(AppointmentRequestItemUpdateDto dto)
        {
            var existing = await _repo.GetById(dto.Id);
            if (existing == null) return false;
            existing.ActTypeId = dto.ActTypeId;
            existing.Subsystem = (HealthSubsystem)dto.Subsystem;
            existing.ProfessionalId = dto.ProfessionalId;
            existing.DataInicioSolicitado = dto.DataInicioSolicitado;
            existing.DataFimSolicitado = dto.DataFimSolicitado;
            existing.HoraSolicitada = dto.HoraSolicitada;
            existing.Observacoes = dto.Observacoes;
            existing.DataAgendada = dto.DataAgendada;
            existing.HoraAgendada = dto.HoraAgendada;
            return await _repo.Update(existing);
        }
    }
}