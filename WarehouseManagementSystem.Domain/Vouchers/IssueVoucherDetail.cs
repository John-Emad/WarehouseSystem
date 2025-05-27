using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Domain.Models;

namespace WarehouseManagementSystem.Domain.Vouchers
{
    public class IssueVoucherDetail
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Voucher")]
        public int VoucherId { get; set; }

        [StringLength(50)]
        [ForeignKey("Item")]
        public string ItemCode { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Quantity { get; set; }

        [Required]
        [StringLength(20)]
        public string Unit { get; set; }

        [DeleteBehavior(DeleteBehavior.Cascade)]
        public virtual IssueVoucher Voucher { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public virtual Item Item { get; set; }
    }
}
