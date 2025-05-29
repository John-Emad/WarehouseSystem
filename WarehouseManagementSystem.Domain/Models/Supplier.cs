using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Domain.Vouchers;

namespace WarehouseManagementSystem.Domain.Models
{
    public class Supplier : Person
    {
        public virtual ICollection<ReceiptVoucher> ReceiptVouchers { get; set; }
    }
}
