using ClinicaXPTO.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaXPTO.DTO.AnonymousRequest
{
    public class AnonymousRequestReadDto
    {
        public Guid Id { get; set; }
        public string NumeroUtente { get; set; } = null!;
        public string NomeCompleto { get; set; } = null!;
        public DateOnly DataNascimento { get; set; }
        public Gender Genero { get; set; }
        public string? FotografiaUrl { get; set; }
        public string Telefone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Morada { get; set; }
    }
}
