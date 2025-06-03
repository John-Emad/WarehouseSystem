
namespace WarehouseManagementSystem.Domain.DTOs
{
    public class InventoryItemViewDTO
    {
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
        public Decimal Quantity { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public override string ToString()
        {
            return $"Item: {ItemName} - Quantity: {Quantity}";
        }

    }

}
