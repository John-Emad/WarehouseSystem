using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Domain.Vouchers;

namespace WarehouseManagementSystem.Domain.Models
{
    public class Warehouse
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [ForeignKey("ResponsiblePerson")]
        public int ResponsiblePersonId { get; set; }
        public virtual Person ResponsiblePerson { get; set; }

        public virtual ICollection<InventoryItem> InventoryItems { get; set; }
        public virtual ICollection<ReceiptVoucher> ReceiptVouchers { get; set; }
        public virtual ICollection<IssueVoucher> IssueVouchers { get; set; }

    }
}
