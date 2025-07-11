using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ClinicaXPTO.SHARED.IRepository;
using Microsoft.EntityFrameworkCore;


namespace ClinicaXPTO.SHARED.IRepository
{
    public interface IGenericRepository<TEntity>
    {
        Task<TEntity> GetById(Guid id); //Procurar pelo ID
        Task<bool> Create(TEntity entity); //Criar registro //salvar
        Task<bool> Update(TEntity entity); //actualizar um registro
        Task<bool> Delete(TEntity entity); //excluir um regstro
        Task<List<TEntity>> List(); //listar todos os registros

    }
}
