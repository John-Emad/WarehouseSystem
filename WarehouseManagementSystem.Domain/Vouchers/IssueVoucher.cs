using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Domain.Models;

namespace WarehouseManagementSystem.Domain.Vouchers
{
    public class IssueVoucher
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [ForeignKey("Warehouse")]
        public int WarehouseId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public virtual Warehouse Warehouse { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public virtual Customer Customer { get; set; }
        public virtual ICollection<IssueVoucherDetail> Details { get; set; }
    }
}
