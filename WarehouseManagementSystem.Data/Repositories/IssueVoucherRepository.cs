using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem.Data.Context;
using WarehouseManagementSystem.Data.Repositories.Base;
using WarehouseManagementSystem.Domain.Vouchers;

namespace WarehouseManagementSystem.Data.Repositories
{
    public class IssueVoucherRepository : CRUDGeneric<IssueVoucher>
    {
        #region Fields
        private readonly DbSet<IssueVoucher> _issueVouchers;
        #endregion
        #region Constructors
        public IssueVoucherRepository(WarehouseDbContext dbContext) : base(dbContext)
        {
            _issueVouchers = dbContext.Set<IssueVoucher>();
        }
        #endregion
    }
}
