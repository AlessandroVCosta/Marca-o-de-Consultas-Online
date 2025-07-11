using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaXPTO.MODEL.Entities
{
    public class Professional
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string NomeCompleto { get; set; } = null!;

        [MaxLength(150)]
        public string? Especialidade { get; set; } // Especialidade do profissional (opcional)

        [MaxLength(100)]
        public string? Email { get; set; } // Email do profissional (opcional)

        [MaxLength(9)]
        public string? Telefone { get; set; } // Telefone do profissional (opcional)

        public ICollection<AppointmentRequestItem>? RequestItemsSolicitados { get; set; } // Relacionamento com AppointmentRequestItem onde o profissional foi solicitado
       
    }
}
