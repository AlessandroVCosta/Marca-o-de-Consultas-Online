using ClinicaXPTO.DTO.AnonymousRequest;
using ClinicaXPTO.DTO.AppointmentRequestItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaXPTO.DTO.AppointmentRequest
{
    public class AppointmentRequestAddDto
    {
        public Guid? UserId { get; set; }                        // se for utente registado
        public AnonymousRequestAddDto? AnonymousRequest { get; set; }
        // se for utente anónimo, preenche este objeto
        public List<AppointmentRequestItemAddDto> Items { get; set; } = new();
    }
}
