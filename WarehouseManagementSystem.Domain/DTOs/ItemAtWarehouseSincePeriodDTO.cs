

namespace WarehouseManagementSystem.Domain.DTOs
{
    public class ItemAtWarehouseSincePeriodDTO
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public decimal Quantity { get; set; }

        public DateOnly ProductionDate { get; set; }
        public DateOnly ExpiryDate { get; set; }
        public DateOnly AtWareHouseSinceDate { get; set; }
        public int SinceDays { get; set; }
        public string SupplierName { get; set; }
        public string EnteredBy { get; set; }

        public decimal AvailableQuantity { get; set; } 
        public bool IsSummaryRow { get; set; }
        public bool IsWarehouseSummary {  get; set; }
    }
}
