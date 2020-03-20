using FoodApp.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.Domain.Interfaces
{
    public interface IGenericRepository<TEntity>
         where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetById(Guid id);
        Task Create(TEntity entity);
        Task Update(Guid id, TEntity entity);
        Task Delete(Guid id);
    }
}
