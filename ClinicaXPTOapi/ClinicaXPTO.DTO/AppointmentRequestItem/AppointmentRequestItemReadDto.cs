using ClinicaXPTO.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaXPTO.DTO.AppointmentRequestItem
{
    public class AppointmentRequestItemReadDto
    {
        public Guid Id { get; set; }
        public Guid AppointmentRequestId { get; set; }
        public Guid ActTypeId { get; set; }
        public HealthSubsystem Subsystem { get; set; }
        public Guid? ProfessionalId { get; set; }
        public DateOnly DataInicioSolicitado { get; set; }
        public DateOnly DataFimSolicitado { get; set; }
        public TimeOnly? HoraSolicitada { get; set; }
        public string? Observacoes { get; set; }
        public DateOnly? DataAgendada { get; set; }
        public TimeOnly? HoraAgendada { get; set; }

    }
}
