
namespace WarehouseManagementSystem.Data.Interfaces.Base
{
    public interface ICRUDGeneric<T> where T : class
    {
        Task<T> AddAsync(T entity);

        Task AddRangeAsync(ICollection<T> entities);

        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(ICollection<T> entities);

        Task<List<T>> GetAllAsync();

        Task<T> GetByPKAsync(object id);

        Task Delete(T entity);

        Task DeleteRangeAsync(ICollection<T> entities);

        Task SaveChangesAsync();
    }
}
