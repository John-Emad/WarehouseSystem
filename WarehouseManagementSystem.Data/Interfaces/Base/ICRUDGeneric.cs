
namespace WarehouseManagementSystem.Data.Interfaces.Base
{
    public interface ICRUDGeneric<T> where T : class
    {
        Task<T> Add(T entity);

        Task AddRange(ICollection<T> entities);

        Task Update(T entity);
        Task UpdateRange(ICollection<T> entities);

        Task<List<T>> GetAll();

        Task<T> GetByPK(object id);

        Task Delete(T entity);

        Task DeleteRange(ICollection<T> entities);

        Task SaveChanges();
    }
}
