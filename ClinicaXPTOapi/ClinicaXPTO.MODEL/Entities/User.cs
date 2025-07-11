using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaXPTO.MODEL.Enums;

namespace ClinicaXPTO.MODEL.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; } 

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public UserRole Role { get; set; }

        [Required]
        [MaxLength(150)]
        public string NomeCompleto { get; set; } = null!;

        public DateOnly? DataNascimento { get; set; }
        public Gender? Genero { get; set; }

        [MaxLength(200)]
        public string? FotografiaUrl { get; set; }

        [MaxLength(9)]
        public string? Telefone { get; set; }

        [MaxLength(250)]
        public string? Morada { get; set; }

        [MaxLength(50)]
        public string? NumeroUtenteSaude { get; set; }

        public ICollection<AppointmentRequest>? Requests { get; set; }
    }
}

