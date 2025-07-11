using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaXPTO.MODEL.Enums;

namespace ClinicaXPTO.MODEL.Entities
{
    public class AnonymousRequest
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string NumeroUtente { get; set; } = null!;

        [Required]
        [MaxLength(150)]
        public string NomeCompleto { get; set; } = null!;

        [Required]
        public DateOnly DataNascimento { get; set; }

        [Required]
        public Gender Genero { get; set; }

        [MaxLength(200)]
        public string? FotografiaUrl { get; set; }

        [Required]
        [MaxLength(9)]
        public string Telefone { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = null!;

        [MaxLength(250)]
        public string? Morada { get; set; }

        public ICollection<AppointmentRequest>? Requests { get; set; }
    }
}
