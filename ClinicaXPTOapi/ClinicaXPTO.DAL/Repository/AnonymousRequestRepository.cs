using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaXPTO.DAL.Context;
using ClinicaXPTO.MODEL.Entities;
using ClinicaXPTO.SHARED.IRepository;

namespace ClinicaXPTO.DAL.Repository
{
    public class AnonymousRequestRepository : GenericRepository<AnonymousRequest>, IAnonymousRequestRepository
    {
        private readonly ClinicaContext _clinicaContext;
        public AnonymousRequestRepository(ClinicaContext clinicaContext) : base(clinicaContext)
        {
            _clinicaContext = clinicaContext;
        }
    }
}
