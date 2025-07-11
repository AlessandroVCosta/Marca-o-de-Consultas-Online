using ClinicaXPTO.DTO.AppointmentRequestItem;
using ClinicaXPTO.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaXPTO.DTO.AppointmentRequest
{
    public class AppointmentRequestReadDto
    {
        public Guid Id { get; set; }
        public DateOnly DataPedido { get; set; }
        public RequestStatus Status { get; set; }
        public Guid? UserId { get; set; }
        public Guid? AnonymousRequestId { get; set; }
        public List<AppointmentRequestItemReadDto> Items { get; set; } = new();

    }
}
