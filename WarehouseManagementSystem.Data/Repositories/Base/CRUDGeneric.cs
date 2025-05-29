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
        public virtual async Task<T> AddAsync(T entity)
        {
             await _warehouseDbContext.Set<T>().AddAsync(entity);
             await _warehouseDbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task AddRangeAsync(ICollection<T> entities)
        {
            await _warehouseDbContext.Set<T>().AddRangeAsync(entities);
            await _warehouseDbContext.SaveChangesAsync();
        }

        public virtual async Task Delete(T entity)
        {
            _warehouseDbContext.Set<T>().Remove(entity);
            await _warehouseDbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteRangeAsync(ICollection<T> entities)
        {
            foreach (var entity in entities)
            {
                _warehouseDbContext.Entry(entity).State = EntityState.Deleted;
            }
            await _warehouseDbContext.SaveChangesAsync();
            
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _warehouseDbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByPKAsync(object id)
        {
            return await _warehouseDbContext.Set<T>().FindAsync(id);            
        }

        public async Task SaveChangesAsync()
        {
             await Task.FromResult(_warehouseDbContext.SaveChangesAsync());
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _warehouseDbContext.Set<T>().Update(entity);
            await _warehouseDbContext.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(ICollection<T> entities)
        {
            _warehouseDbContext.Set<T>().UpdateRange(entities);
            await _warehouseDbContext.SaveChangesAsync();
        }
        #endregion
    }
}
