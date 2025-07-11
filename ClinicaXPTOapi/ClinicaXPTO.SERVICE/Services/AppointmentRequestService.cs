using AutoMapper;
using ClinicaXPTO.DAL.Context;
using ClinicaXPTO.DTO.AppointmentRequest;
using ClinicaXPTO.MODEL.Entities;
using ClinicaXPTO.MODEL.Enums;
using ClinicaXPTO.SHARED.IRepository;
using ClinicaXPTO.SHARED.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaXPTO.SERVICE.Services
{
    public class AppointmentRequestService : IAppointmentRequestService
    {
        private readonly IAppointmentRequestRepository _repo;
        private readonly IAppointmentRequestItemRepository _itemRepo;
        private readonly IUserRepository _userRepo;
        private readonly IAnonymousRequestRepository _anonRepo;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public AppointmentRequestService(
            IAppointmentRequestRepository repo,
            IAppointmentRequestItemRepository itemRepo,
            IUserRepository userRepo,
            IAnonymousRequestRepository anonRepo,
            IMapper mapper,
            IEmailService emailService
            )
        {
            _repo = repo;
            _itemRepo = itemRepo;
            _userRepo = userRepo;
            _anonRepo = anonRepo;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<AppointmentRequestReadDto> CreateAsync(AppointmentRequestAddDto dto)
        {
            var entity = new AppointmentRequest
            {
                Id = Guid.NewGuid(),
                DataPedido = DateOnly.FromDateTime(DateTime.UtcNow),
                Status = RequestStatus.Pedido,
                UserId = dto.UserId
            };

            if (dto.AnonymousRequest != null)
            {
                var anon = _mapper.Map<AnonymousRequest>(dto.AnonymousRequest);
                anon.Id = Guid.NewGuid();
                await _anonRepo.Create(anon);
                entity.AnonymousRequestId = anon.Id;
            }

            await _repo.Create(entity);

            foreach (var itemDto in dto.Items)
            {
                var item = _mapper.Map<AppointmentRequestItem>(itemDto);
                item.Id = Guid.NewGuid();
                item.AppointmentRequestId = entity.Id;
                await _itemRepo.Create(item);
            }

            var entityWithItems = await _repo.GetWithItemsAsync(entity.Id);

            return _mapper.Map<AppointmentRequestReadDto>(entityWithItems);
        }



        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _repo.GetById(id);
            if (existing == null) return false;
            return await _repo.Delete(existing);
        }

        public async Task<IEnumerable<AppointmentRequestReadDto>> GetAllAsync()
        {
            var list = await _repo.List();
            return list.Select(r => _mapper.Map<AppointmentRequestReadDto>(r));
        }

        public async Task<AppointmentRequestReadDto?> GetByIdAsync(Guid id)
        {
            var r = await _repo.GetById(id);
            return r == null ? null : _mapper.Map<AppointmentRequestReadDto>(r);
        }

        public async Task<IEnumerable<AppointmentRequestReadDto>> GetByStatusAsync(int status)
        {
            var items = _repo.GetByStatus((RequestStatus)status);
            return items.Select(r => _mapper.Map<AppointmentRequestReadDto>(r));
        }

        public async Task<IEnumerable<AppointmentRequestReadDto>> GetByUserIdAsync(Guid userId)
        {
            var items = _repo.GetByUserId(userId);
            return items.Select(r => _mapper.Map<AppointmentRequestReadDto>(r));
        }

        public async Task<bool> UpdateAsync(AppointmentRequestUpdateDto dto)
        {
            var existing = await _repo.GetById(dto.Id);
            if (existing == null) return false;

            var novoStatus = (RequestStatus)dto.Status;
            bool mudouParaAgendado = existing.Status != RequestStatus.Agendado && novoStatus == RequestStatus.Agendado;
            existing.Status = novoStatus;

            var updated = await _repo.Update(existing);
            if (updated && mudouParaAgendado)
            {
                // Determinar destinatário e nome
                string email = existing.UserId != null
                    ? (await _userRepo.GetById(existing.UserId.Value))!.Email
                    : (await _anonRepo.GetById(existing.AnonymousRequestId!.Value))!.Email;
                string nome = existing.UserId != null
                    ? (await _userRepo.GetById(existing.UserId.Value))!.NomeCompleto
                    : (await _anonRepo.GetById(existing.AnonymousRequestId!.Value))!.NomeCompleto;

                // Montar corpo HTML
                string body = $@"
            <h1>Marcação Agendada</h1>
            <p>Olá, {nome},</p>
            <p>Sua marcação foi confirmada para <strong>{existing.DataPedido:yyyy-MM-dd}</strong> às <strong>{DateTime.Now:HH:mm}</strong>.</p>
            <p>Obrigado pela confiança,<br/>Clínica XPTO</p>";

                await _emailService.SendEmailAsync(email, "Sua marcação na Clínica XPTO", body);
            }

            return updated;
        }


        public Task<byte[]> ExportToPdfAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AppointmentRequest>> GetAllWithItemsAsync()
        {
            return await _repo.GetAllWithItemsAsync();
        }



    }
}
