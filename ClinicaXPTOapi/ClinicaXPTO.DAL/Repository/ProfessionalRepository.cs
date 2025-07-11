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
    public class ProfessionalRepository : GenericRepository<Professional>, IProfessionalRepository
    {
        private readonly ClinicaContext _clinicaContext;
        // Construtor que recebe o contexto do banco de dados
        public ProfessionalRepository(ClinicaContext clinicaContext) : base(clinicaContext)
        {
            _clinicaContext = clinicaContext;
        }
        
    }
    
}
