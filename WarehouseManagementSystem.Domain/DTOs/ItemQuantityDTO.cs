
namespace WarehouseManagementSystem.Domain.DTOs
{
    public class ItemQuantityDTO
    {
        public string ItemCode { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; } = 1;

        public override bool Equals(object obj)
        {
            return obj is ItemQuantityDTO dto && dto.Name == this.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
