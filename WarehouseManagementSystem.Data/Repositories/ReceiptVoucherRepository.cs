using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem.Data.Context;
using WarehouseManagementSystem.Data.Repositories.Base;
using WarehouseManagementSystem.Domain.Vouchers;

namespace WarehouseManagementSystem.Data.Repositories
{
    public class ReceiptVoucherRepository : CRUDGeneric<ReceiptVoucher>
    {
        #region Fields
        private readonly DbSet<ReceiptVoucher> _receiptVouchers;
        #endregion
        #region Constructors
        public ReceiptVoucherRepository(WarehouseDbContext dbContext) : base(dbContext)
        {
            _receiptVouchers = dbContext.Set<ReceiptVoucher>();
        }
        #endregion
    }
}
