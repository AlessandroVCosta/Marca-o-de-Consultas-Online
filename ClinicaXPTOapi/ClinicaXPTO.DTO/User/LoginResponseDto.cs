using ClinicaXPTO.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaXPTO.DTO.User
{
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public Guid UserId { get; set; }
    }
}
