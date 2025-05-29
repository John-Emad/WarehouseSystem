using System.ComponentModel.DataAnnotations;
using WarehouseManagementSystem.Domain.Enums;
using WarehouseManagementSystem.Domain.Vouchers;

namespace WarehouseManagementSystem.Domain.Models
{
    public class Item
    {
        [Key]
        [StringLength(50)]
        public string Code { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        // For storing multiple measurement units as comma-separated string
        [Required]
        public List<MeasurementUnit> MeasurementUnits { get; set; } = new List<MeasurementUnit>();

        public virtual ICollection<InventoryItem> InventoryItems { get; set; }
        public virtual ICollection<ReceiptVoucherDetail> ReceiptVoucherDetails { get; set; }
        public virtual ICollection<IssueVoucherDetail> IssueVoucherDetails { get; set; }
        public virtual ICollection<TransferVoucherDetail> TransferVoucherDetails { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
