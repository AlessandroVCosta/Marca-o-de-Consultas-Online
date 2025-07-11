using ClinicaXPTO.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaXPTO.DTO.AppointmentRequestItem
{
    public class AppointmentRequestItemAddDto
    {
        public Guid ActTypeId { get; set; }
        public HealthSubsystem Subsystem { get; set; }           // corresponde ao enum HealthSubsystem
        public Guid? ProfessionalId { get; set; }    // opcional
        public DateOnly DataInicioSolicitado { get; set; }
        public DateOnly DataFimSolicitado { get; set; }
        public TimeOnly? HoraSolicitada { get; set; }
        public string? Observacoes { get; set; }
    }
}
