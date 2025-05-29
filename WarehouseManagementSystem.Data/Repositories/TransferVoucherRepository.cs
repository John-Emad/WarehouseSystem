
using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem.Data.Context;
using WarehouseManagementSystem.Data.Repositories.Base;
using WarehouseManagementSystem.Domain.Vouchers;

namespace WarehouseManagementSystem.Data.Repositories
{
    public class TransferVoucherRepository : CRUDGeneric<TransferVoucher>
    {
        #region Fields
        private readonly DbSet<TransferVoucher> _transferVouchers;
        #endregion
        #region Constructors
        public TransferVoucherRepository(WarehouseDbContext dbContext) : base(dbContext)
        {
            _transferVouchers = dbContext.Set<TransferVoucher>();
        }

        #endregion
    }
}
