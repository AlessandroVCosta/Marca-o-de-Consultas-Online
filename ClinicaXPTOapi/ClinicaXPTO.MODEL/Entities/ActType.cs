using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaXPTO.MODEL.Entities
{
    public class ActType
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; } = null!;

        [MaxLength(500)]
        public string? Descricao { get; set; } // Descrição opcional do tipo de ato médico

        // Relacionamento com AppointmentRequestItem
        public ICollection<AppointmentRequestItem> RequestItems { get; set; }
    }
}
