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
    public class ActTypeRepository : GenericRepository<ActType>, IActTypeRepository
    {
        private readonly ClinicaContext _clinicaContext;
        // Construtor que recebe o contexto do banco de dados
        public ActTypeRepository(ClinicaContext clinicaContext) : base(clinicaContext)
        {
            _clinicaContext = clinicaContext;
        }
        
    }
}
