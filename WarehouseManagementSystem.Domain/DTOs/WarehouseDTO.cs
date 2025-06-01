
namespace WarehouseManagementSystem.Domain.DTOs
{
    public class WarehouseDTO
    {
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }

        public string WarehouseAddress { get; set; }
        public int? ManagerId { get; set; }
        public string ManagerName { get; set; }
    }
}
