
namespace WarehouseManagementSystem.Domain.DTOs
{
    public class WarehouseItemsStateWithTransfer
    {
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
        public decimal CurrentItemQuantity { get; set; }
        public string PersonName { get; set; }
        public int PersonId { get; set; }
        public DateOnly ProductionDate { get; set; }
        public DateOnly ExpiryDate { get; set; }

        public string State { get; set; }
        public DateOnly? StateDate { get; set; }
        public decimal? StateQuantity { get; set; }

        public bool IsSummaryRow { get; set; } = false;

    }
}
