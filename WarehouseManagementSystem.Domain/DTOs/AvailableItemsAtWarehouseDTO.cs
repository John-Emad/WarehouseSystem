using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Domain.DTOs
{
    public class AvailableItemsAtWarehouseDTO
    {
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
        public decimal ItemQuantity { get; set; }
        public string WarehouseName { get; set; }
        public int WarehouseId { get; set; }
        public string SupplierName { get; set; }
        public int SupplierId { get; set; }
        public DateOnly ProductionDate { get; set; }
        public DateOnly ExpiryDate { get; set; }

        public override string ToString()
        {
            return $"Item: {ItemName} - Quantity: {ItemQuantity}";
        }
    }
}