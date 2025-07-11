using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaXPTO.DAL.Context;
using ClinicaXPTO.MODEL.Entities;
using ClinicaXPTO.SHARED.IRepository;
using Microsoft.EntityFrameworkCore;


namespace ClinicaXPTO.DAL.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ClinicaContext _clinicaContext;
        // Construtor que recebe o contexto do banco de dados
        public UserRepository(ClinicaContext clinicaContext) : base(clinicaContext)
        {
            _clinicaContext = clinicaContext;
        }

        public Task<User?> GetByEmailAsync(string email)
        {
            return _clinicaContext.Users
                .AsNoTracking() // Evita o rastreamento de alterações para melhorar a performance
                .FirstOrDefaultAsync(u => u.Email == email); // Busca o usuário pelo email
        }
    }
    
    
}
