using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem.Data.Context;
using WarehouseManagementSystem.Data.Repositories.Base;
using WarehouseManagementSystem.Domain.Vouchers;

namespace WarehouseManagementSystem.Data.Repositories
{
    public class IssueVoucherDetailRepository : CRUDGeneric<IssueVoucherDetail>
    {
        #region Fields
        private readonly DbSet<IssueVoucherDetail> _issueVoucherDetails;
        #endregion

        #region Constructors
        public IssueVoucherDetailRepository(WarehouseDbContext dbContext) : base(dbContext)
        {
            _issueVoucherDetails = dbContext.Set<IssueVoucherDetail>();
        }
        #endregion

        #region Method
        #endregion
    }
}
