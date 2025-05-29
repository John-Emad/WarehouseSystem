using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem.Data.Context;
using WarehouseManagementSystem.Data.Repositories.Base;
using WarehouseManagementSystem.Domain.Vouchers;

namespace WarehouseManagementSystem.Data.Repositories
{
    public class ReceiptVoucherDetailsRepository : CRUDGeneric<ReceiptVoucherDetail>
    {
        #region Fields
        private readonly DbSet<ReceiptVoucherDetail> _receiptVoucherDetails; 
        #endregion
        #region Constructors
        public ReceiptVoucherDetailsRepository(WarehouseDbContext dbContext) : base(dbContext)
        {
            _receiptVoucherDetails = dbContext.Set<ReceiptVoucherDetail>();
        }
        #endregion
    }
}
