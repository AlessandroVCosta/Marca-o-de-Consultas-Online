using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaXPTO.DAL.Context;
using ClinicaXPTO.MODEL.Entities;
using ClinicaXPTO.MODEL.Enums;
using ClinicaXPTO.SHARED.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ClinicaXPTO.DAL.Repository
{
    public class AppointmentRequestItemRepository : GenericRepository<AppointmentRequestItem>, IAppointmentRequestItemRepository
    {
        private readonly ClinicaContext _clinicaContext;
        public AppointmentRequestItemRepository(ClinicaContext clinicaContext) : base(clinicaContext)
        {
            _clinicaContext = clinicaContext;
        }

        /* public IEnumerable<AppointmentRequestItem> GetByActTypeId(Guid actTypeId)
        {
            return _clinicaContext.AppointmentRequestItems
            .AsNoTracking()
            .Where(i => i.ActTypeId == actTypeId)
            .ToList();
        }
        */

        public IEnumerable<AppointmentRequestItem> GetByProfessionalId(Guid professionalId)
        {
            return _clinicaContext.AppointmentRequestItems
                .AsNoTracking()
                .Where(i => i.ProfessionalId == professionalId)
                .ToList();
        }

        public IEnumerable<AppointmentRequestItem> GetByRequestId(Guid requestId)
        {
            return _clinicaContext.AppointmentRequestItems
                .AsNoTracking()
                .Where(i => i.AppointmentRequestId == requestId)
                .ToList();
        }

        public IEnumerable<AppointmentRequestItem> GetByStatus(RequestStatus status)
        {
            return _clinicaContext.AppointmentRequestItems
            .AsNoTracking()
            .Where(i => i.AppointmentRequest.Status == status)
            .ToList();
        }

        public IEnumerable<AppointmentRequestItem> GetByUserId(Guid userId)
        {
            return _clinicaContext.AppointmentRequestItems
            .AsNoTracking()
            .Where(i => i.AppointmentRequest.UserId == userId)
            .ToList();
        }
        
    }
   
}
