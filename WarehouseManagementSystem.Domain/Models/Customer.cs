using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Domain.Vouchers;

namespace WarehouseManagementSystem.Domain.Models
{
    public class Customer : Person
    {
        public virtual ICollection<IssueVoucher> IssueVouchers { get; set; }
    }
}
