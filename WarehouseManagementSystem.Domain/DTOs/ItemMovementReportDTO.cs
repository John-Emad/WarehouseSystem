
namespace WarehouseManagementSystem.Domain.DTOs
{
    public class ItemMovementReportDTO
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string? Warehouse { get; set; }
        public decimal CurrentQuantity { get; set; }
        public DateOnly ProductionDate { get; set; }
        public DateOnly ExpiryDate { get; set; }
        public string MovementType { get; set; } // "Receipt", "Transfer", "Issue"
        public DateOnly Date { get; set; }

        public int? FromWarehouseId { get; set; }
        public string FromWarehouseName { get; set; }

        public int? ToWarehouseId { get; set; }
        public string ToWarehouseName { get; set; }
        public decimal Quantity { get; set; }
        public string RelatedPerson { get; set; } // Supplier/Customer name

        public bool IsSummaryRow {  get; set; }

    }
}
