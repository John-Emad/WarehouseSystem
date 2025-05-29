using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Domain.Models;

namespace WarehouseManagementSystem.Domain.Vouchers
{
    //Header-Detail pattern.
    public class ReceiptVoucher
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateOnly Date { get; set; }

        [ForeignKey("Warehouse")]
        public int WarehouseId { get; set; }

        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public virtual Warehouse Warehouse { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<ReceiptVoucherDetail> Details { get; set; }
    }
}
