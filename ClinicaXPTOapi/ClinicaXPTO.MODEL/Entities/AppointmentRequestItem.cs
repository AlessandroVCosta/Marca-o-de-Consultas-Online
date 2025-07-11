using ClinicaXPTO.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaXPTO.MODEL.Entities
{
    public class AppointmentRequestItem
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid AppointmentRequestId { get; set; }
        public AppointmentRequest AppointmentRequest { get; set; } = null!;

        [Required]
        public Guid ActTypeId { get; set; } // tipo de ato médico
        public ActType ActType { get; set; } = null!;

        [Required]
        public HealthSubsystem Subsystem { get; set; } // sub-sistema de saúde

        public Guid? ProfessionalId { get; set; } // médico responsável

        [ForeignKey("ProfessionalId")]
        public Professional? Professional { get; set; }

        [Required]
        public DateOnly DataInicioSolicitado { get; set; }

        public DateOnly DataFimSolicitado { get; set; }

        public TimeOnly? HoraSolicitada { get; set; }

        [MaxLength(500)]
        public string? Observacoes { get; set; }

        public DateOnly? DataAgendada { get; set; }

        public TimeOnly? HoraAgendada { get; set; }
    }

}
