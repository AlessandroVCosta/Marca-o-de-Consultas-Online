using ClinicaXPTO.DAL.Context;
using ClinicaXPTO.SHARED.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaXPTO.DAL.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ClinicaContext _clinicaContext;
        public GenericRepository(ClinicaContext clinicaContext)
        {
            _clinicaContext = clinicaContext;
        }

        public async Task<bool> Create(TEntity entity)
        {
            await _clinicaContext.Set<TEntity>().AddAsync(entity);
            return await _clinicaContext.SaveChangesAsync() > 0; //maior que zero significa que houve alterações no banco de dados se for 0, significa que não houve alterações
        }

        public async Task<bool> Delete(TEntity entity)
        {
           _clinicaContext.Set<TEntity>().Remove(entity);
            return await _clinicaContext.SaveChangesAsync() > 0;
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await _clinicaContext.Set<TEntity>().FindAsync(id).AsTask();
        }

        public async Task<List<TEntity>> List()
        {
            return await _clinicaContext.Set<TEntity>().ToListAsync();
        }

        public async Task<bool> Update(TEntity entity)
        {
            _clinicaContext.Entry(entity).State = EntityState.Modified; //marca o estado do entity como modificado
            return await _clinicaContext.SaveChangesAsync() > 0; //salva as alterações no banco de dados
        }
    }


}

