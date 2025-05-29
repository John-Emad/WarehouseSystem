using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem.Data.Context;
using WarehouseManagementSystem.Data.Repositories.Base;
using WarehouseManagementSystem.Domain.Models;

namespace WarehouseManagementSystem.Data.Repositories
{
    public class ItemRepository : CRUDGeneric<Item>
    {
        #region Fields
        private readonly DbSet<Item> _ItemSet;
        #endregion

        #region Constructors
        public ItemRepository(WarehouseDbContext dbContext) : base(dbContext)
        {
            _ItemSet = dbContext.Set<Item>();
        }
        #endregion
    }
}
