
namespace WarehouseManagementSystem.Domain.DTOs
{
    public class ItemReportDTO
    {
        public string ItemName {  get; set; }
        public string CurrentWarehouseName { get; set; }
        public string StateWarehouseName { get; set; }

        public string State { get; set; }

        public decimal StateQuantity { get; set; }

        public DateOnly StateDate { get; set; }

        public string PersonName { get; set; }

        public decimal CurrentQuantity { get; set; }

        public DateOnly ProductionDate { get; set; }
        public DateOnly ExpiryDate { get; set; }

    }
}
