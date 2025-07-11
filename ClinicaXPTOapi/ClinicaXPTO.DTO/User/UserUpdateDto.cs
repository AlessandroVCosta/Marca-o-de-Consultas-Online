using ClinicaXPTO.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaXPTO.DTO.User
{
    public class UserUpdateDto
    {
        public Guid Id { get; set; }                     // Precisamos do ID para saber “quem” atualizar
        public string NomeCompleto { get; set; } = null!;
        public DateOnly? DataNascimento { get; set; }
        public Gender? Genero { get; set; }
        public string? FotografiaUrl { get; set; }
        public string? Telefone { get; set; }
        public string? Morada { get; set; }
        public string? NumeroUtenteSaude { get; set; }
        // Normalmente não permitimos a atualização de Email ou Role neste DTO;
    }
}
