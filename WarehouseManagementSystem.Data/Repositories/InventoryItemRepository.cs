using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem.Data.Context;
using WarehouseManagementSystem.Data.Repositories.Base;
using WarehouseManagementSystem.Domain.Models;

namespace WarehouseManagementSystem.Data.Repositories
{
    public class InventoryItemRepository : CRUDGeneric<InventoryItem>
    {
        #region Fields
        private readonly DbSet<InventoryItem> _inventoryItemsSet;
        #endregion
        #region Constructor
        public InventoryItemRepository(WarehouseDbContext dbContext) : base(dbContext)
        {
            _inventoryItemsSet = dbContext.Set<InventoryItem>();
        }
        #endregion

        #region Methods

        #endregion
    }
}
