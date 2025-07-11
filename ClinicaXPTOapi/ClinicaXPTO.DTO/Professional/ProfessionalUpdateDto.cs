using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaXPTO.DTO.Professional
{
    public class ProfessionalUpdateDto
    {
        public Guid Id { get; set; }
        public string NomeCompleto { get; set; } = null!;
        public string? Especialidade { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
    }
}
