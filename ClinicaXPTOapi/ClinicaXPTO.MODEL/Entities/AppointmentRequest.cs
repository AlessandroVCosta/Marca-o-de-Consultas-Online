using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaXPTO.MODEL.Enums;

namespace ClinicaXPTO.MODEL.Entities
{
    public class AppointmentRequest
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateOnly DataPedido { get; set; }

        [Required]
        public RequestStatus Status { get; set; }

        public Guid? UserId { get; set; }
        public User? User { get; set; }

        public Guid? AnonymousRequestId { get; set; }
        public AnonymousRequest? AnonymousRequest { get; set; }

        
        public ICollection<AppointmentRequestItem>? Items { get; set; }

    }

}
