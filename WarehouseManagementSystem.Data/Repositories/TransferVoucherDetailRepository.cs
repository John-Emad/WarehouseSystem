
using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem.Data.Context;
using WarehouseManagementSystem.Data.Repositories.Base;
using WarehouseManagementSystem.Domain.Vouchers;

namespace WarehouseManagementSystem.Data.Repositories
{
    public class TransferVoucherDetailRepository : CRUDGeneric<TransferVoucherDetail>
    {
        #region Fields
        private readonly DbSet<TransferVoucherDetail> _transferVouchersDetail;
        #endregion
        #region Constructors
        public TransferVoucherDetailRepository(WarehouseDbContext dbContext) : base(dbContext)
        {
            _transferVouchersDetail = dbContext.Set<TransferVoucherDetail>();
        }
        #endregion
    }
}
