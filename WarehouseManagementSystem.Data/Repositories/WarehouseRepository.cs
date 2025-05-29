using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WarehouseManagementSystem.Data.Context;
using WarehouseManagementSystem.Data.Repositories.Base;
using WarehouseManagementSystem.Domain.Models;

namespace WarehouseManagementSystem.Data.Repositories
{
    public class WarehouseRepository : CRUDGeneric<Warehouse>
    {
        #region
            private readonly DbSet<Warehouse> _warehouseSet;
        #endregion

        #region Constructors
        public WarehouseRepository(WarehouseDbContext warehouseDbContext) : base(warehouseDbContext)
        {
            _warehouseSet = warehouseDbContext.Set<Warehouse>();
        }
        #endregion
        #region Methods
        public async Task<List<Warehouse>> GetAllAsyncWithManagerName()
        {
            return await _warehouseSet.Include(w => w.ResponsiblePerson).ToListAsync();
        }
        #endregion
    }
}
