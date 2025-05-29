using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Domain.Models;

namespace WarehouseManagementSystem.Domain.Vouchers
{
    public class TransferVoucher
    {
        [Key]
        public int Id { get; set; }


        [Required]
        public DateTime Date { get; set; }

        [ForeignKey("FromWarehouse")]
        public int FromWarehouseId { get; set; }

        [ForeignKey("ToWarehouse")]
        public int ToWarehouseId { get; set; }

        [ForeignKey("Supplier")]
        public int? SupplierId { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public virtual Warehouse FromWarehouse { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public virtual Warehouse ToWarehouse { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<TransferVoucherDetail> Details { get; set; }
    }
}
