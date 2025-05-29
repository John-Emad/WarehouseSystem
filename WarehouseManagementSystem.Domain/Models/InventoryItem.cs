using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagementSystem.Domain.Models
{
    public class InventoryItem
    {
        [StringLength(50)]
        [ForeignKey("Item")]
        public string ItemCode { get; set; }

        [ForeignKey("Warehouse")]
        public int WarehouseId { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Quantity { get; set; }

        public DateTime ProductionDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public virtual Item Item { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}