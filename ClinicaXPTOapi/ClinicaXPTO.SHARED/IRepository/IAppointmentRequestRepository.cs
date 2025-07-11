using ClinicaXPTO.MODEL.Entities;
using ClinicaXPTO.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaXPTO.SHARED.IRepository
{
    public interface IAppointmentRequestRepository : IGenericRepository<AppointmentRequest>
    {
        // — GetByUserId(Guid userId)
        IEnumerable<AppointmentRequest> GetByUserId(Guid userId);

        // — GetByStatus(RequestStatus status)
        IEnumerable<AppointmentRequest> GetByStatus(RequestStatus status);

        Task<AppointmentRequest?> GetWithItemsAsync(Guid id);
        Task<List<AppointmentRequest>> GetAllWithItemsAsync();
    }
}
