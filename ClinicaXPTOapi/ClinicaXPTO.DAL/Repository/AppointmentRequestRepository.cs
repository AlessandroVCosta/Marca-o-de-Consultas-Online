using System.Text;
using System.Threading.Tasks;
using ClinicaXPTO.DAL.Context;
using ClinicaXPTO.MODEL.Entities;
using ClinicaXPTO.SHARED.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using ClinicaXPTO.MODEL.Enums;

namespace ClinicaXPTO.DAL.Repository
{
    public class AppointmentRequestRepository : GenericRepository<AppointmentRequest>, IAppointmentRequestRepository
    {
        private readonly ClinicaContext _clinicaContext;
        public AppointmentRequestRepository(ClinicaContext clinicaContext) : base(clinicaContext)
        {
            _clinicaContext = clinicaContext;
        }

        public IEnumerable<AppointmentRequest> GetByStatus(RequestStatus status)
        {
            return _clinicaContext.AppointmentRequests
                .AsNoTracking()
                .Where(r => r.Status == status)
                .ToList();
        }

        public IEnumerable<AppointmentRequest> GetByUserId(Guid userId)
        {
            return _clinicaContext.AppointmentRequests
               .AsNoTracking()
               .Where(r => r.UserId == userId)
               .ToList();
        }

        public async Task<AppointmentRequest?> GetWithItemsAsync(Guid id)
        {
            return await _clinicaContext.AppointmentRequests
                .Include(r => r.Items)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<AppointmentRequest>> GetAllWithItemsAsync()
        {
            return await _clinicaContext.AppointmentRequests
                .Include(r => r.Items)
                .AsNoTracking()
                .ToListAsync();
        }


    }

}
