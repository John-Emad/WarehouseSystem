using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem.Data.Context;
using WarehouseManagementSystem.Data.Interfaces.Base;

namespace WarehouseManagementSystem.Data.Repositories.Base
{
    public class CRUDGeneric<T> : ICRUDGeneric<T> where T : class
    {
        #region Fields
        protected readonly WarehouseDbContext _warehouseDbContext;
        #endregion

        #region Constructors
        public CRUDGeneric(WarehouseDbContext dbContext)
        {
            _warehouseDbContext = dbContext;
        }
        #endregion

        #region Methods
        public virtual Task<T> Add(T entity)
        {
            _warehouseDbContext.Set<T>().Add(entity);
            _warehouseDbContext.SaveChanges();
            return Task.FromResult(entity);
        }

        public virtual Task AddRange(ICollection<T> entities)
        {
            _warehouseDbContext.Set<T>().AddRange(entities);
            _warehouseDbContext.SaveChanges();
            return Task.FromResult(entities);
        }

        public virtual Task Delete(T entity)
        {

            _warehouseDbContext.Set<T>().Remove(entity);
            _warehouseDbContext.SaveChanges();
            return Task.FromResult(entity);
        }

        public virtual Task DeleteRange(ICollection<T> entities)
        {
            foreach (var entity in entities)
            {
                _warehouseDbContext.Entry(entity).State = EntityState.Deleted;
            }
            _warehouseDbContext.SaveChanges();
            return Task.FromResult(entities);
        }

        public virtual Task<List<T>> GetAll()
        {
            return Task.FromResult(_warehouseDbContext.Set<T>().ToList());
        }


        public virtual Task<T> GetByPK(object id)
        {
            return Task.FromResult(_warehouseDbContext.Set<T>().Find(id));
        }

        public Task SaveChanges()
        {
            return Task.FromResult(_warehouseDbContext.SaveChanges());
        }

        public virtual Task Update(T entity)
        {
            _warehouseDbContext.Set<T>().Update(entity);
            _warehouseDbContext.SaveChanges();
            return Task.FromResult(entity);
        }

        public Task UpdateRange(ICollection<T> entities)
        {
            _warehouseDbContext.Set<T>().UpdateRange(entities);
            _warehouseDbContext.SaveChanges();
            return Task.FromResult(entities);
        }
        #endregion
    }
}
