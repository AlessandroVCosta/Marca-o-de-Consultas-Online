using ClinicaXPTO.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaXPTO.DTO.AppointmentRequest
{
    public class AppointmentRequestUpdateDto
    {
        public Guid Id { get; set; }
        public RequestStatus Status { get; set; }   // representa enum RequestStatus (0=Pedido,1=Agendado,2=Realizado)

    }
}
