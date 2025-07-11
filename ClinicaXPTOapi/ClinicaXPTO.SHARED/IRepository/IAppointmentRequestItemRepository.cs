using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaXPTO.MODEL.Entities;
using ClinicaXPTO.MODEL.Enums;

namespace ClinicaXPTO.SHARED.IRepository
{
    public interface IAppointmentRequestItemRepository : IGenericRepository<AppointmentRequestItem>
    {
        // Podemos querer buscar todos os itens de um pedido:
        IEnumerable<AppointmentRequestItem> GetByRequestId(Guid requestId);

        // Ou GetByProfessionalId(Guid professionalId)
        IEnumerable<AppointmentRequestItem> GetByProfessionalId(Guid professionalId);
        // Ou GetByActTypeId(Guid actTypeId)
       // IEnumerable<AppointmentRequestItem> GetByActTypeId(Guid actTypeId);
        // Ou GetByStatus(RequestStatus status)
        IEnumerable<AppointmentRequestItem> GetByStatus(RequestStatus status);
        
        // Ou GetByUserId(Guid userId)
        IEnumerable<AppointmentRequestItem> GetByUserId(Guid userId);

    }
}
