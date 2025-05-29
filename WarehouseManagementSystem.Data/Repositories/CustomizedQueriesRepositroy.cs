
using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem.Data.Context;
using WarehouseManagementSystem.Domain.DTOs;
using WarehouseManagementSystem.Domain.Models;

namespace WarehouseManagementSystem.Data.Repositories
{
    public class CustomizedQueriesRepositroy
    {
        #region Fields
        private readonly WarehouseDbContext _warehouseSystemDbContext;
        #endregion

        #region Constructors
        public CustomizedQueriesRepositroy(WarehouseDbContext dbContext)
        {
            _warehouseSystemDbContext = dbContext;
        }
        #endregion

        #region Queries

        public async Task<List<AvailableItemsAtWarehouseDTO>> GetAvailableItemsAtWarehouseWithSupplierAsync(int warehouseId)
        {
            using (var warehouseSystemDbContext = new WarehouseDbContext())
            {
                var query =
                        from ii in warehouseSystemDbContext.InventoryItems
                        where ii.WarehouseId == warehouseId && ii.Quantity > 0
                        join i in warehouseSystemDbContext.Items on ii.ItemCode equals i.Code
                        join w in warehouseSystemDbContext.Warehouses on ii.WarehouseId equals w.Id
                        join rvd in warehouseSystemDbContext.ReceiptVoucherDetails on
                            new { ii.ItemCode, ii.WarehouseId } equals
                            new { rvd.ItemCode, WarehouseId = rvd.Voucher.WarehouseId }
                        join rv in warehouseSystemDbContext.ReceiptVouchers on rvd.VoucherId equals rv.Id
                        join s in warehouseSystemDbContext.People.OfType<Supplier>() on rv.SupplierId equals s.Id
                        select new AvailableItemsAtWarehouseDTO
                        {
                            ItemName = i.Name,
                            ItemCode = ii.ItemCode,
                            ItemQuantity = ii.Quantity,
                            WarehouseId = ii.WarehouseId,
                            WarehouseName = w.Name,
                            SupplierName = s.Name,
                            SupplierId = rv.SupplierId,
                            ProductionDate = ii.ProductionDate,
                            ExpiryDate = ii.ExpiryDate
                        };

                return await query
                    .Distinct()
                    .ToListAsync(); 
            }
        }

        public async Task<List<AvailableItemsAtWarehouseDTO>> GetAvailableItemsAtWarehouseWithSupplierTransferAsync(int warehouseId)
        {
            using (var warehouseSystemDbContext = new WarehouseDbContext())
            {
                // Query for items with receipt voucher details
                var receiptItemsQuery =
                    from ii in warehouseSystemDbContext.InventoryItems
                    where ii.WarehouseId == warehouseId && ii.Quantity > 0
                    join i in warehouseSystemDbContext.Items on ii.ItemCode equals i.Code
                    join w in warehouseSystemDbContext.Warehouses on ii.WarehouseId equals w.Id
                    join rvd in warehouseSystemDbContext.ReceiptVoucherDetails on
                        new { ii.ItemCode, ii.WarehouseId } equals
                        new { rvd.ItemCode, WarehouseId = rvd.Voucher.WarehouseId }
                    join rv in warehouseSystemDbContext.ReceiptVouchers on rvd.VoucherId equals rv.Id
                    join s in warehouseSystemDbContext.People.OfType<Supplier>() on rv.SupplierId equals s.Id
                    select new AvailableItemsAtWarehouseDTO
                    {
                        ItemName = i.Name,
                        ItemCode = ii.ItemCode,
                        ItemQuantity = ii.Quantity,
                        WarehouseId = ii.WarehouseId,
                        WarehouseName = w.Name,
                        SupplierName = s.Name,
                        SupplierId = rv.SupplierId,
                        ProductionDate = ii.ProductionDate,
                        ExpiryDate = ii.ExpiryDate,
                    };

                // Query for items with transfer voucher details
                var transferItemsQuery =
                    from ii in warehouseSystemDbContext.InventoryItems
                    where ii.WarehouseId == warehouseId && ii.Quantity > 0
                    join i in warehouseSystemDbContext.Items on ii.ItemCode equals i.Code
                    join w in warehouseSystemDbContext.Warehouses on ii.WarehouseId equals w.Id
                    join tvd in warehouseSystemDbContext.TransferVoucherDetails on
                        new { ii.ItemCode, ii.WarehouseId } equals
                        new { tvd.ItemCode, WarehouseId = tvd.Voucher.ToWarehouseId }
                    join tv in warehouseSystemDbContext.TransferVouchers on tvd.VoucherId equals tv.Id
                    join s in warehouseSystemDbContext.People.OfType<Supplier>() on tvd.SupplierId equals s.Id into suppliers
                    from s in suppliers.DefaultIfEmpty() // Left join in case supplier is null
                    select new AvailableItemsAtWarehouseDTO
                    {
                        ItemName = i.Name,
                        ItemCode = ii.ItemCode,
                        ItemQuantity = ii.Quantity,
                        WarehouseId = ii.WarehouseId,
                        WarehouseName = w.Name,
                        SupplierName = s.Name,
                        SupplierId = (int)tvd.SupplierId,
                        ProductionDate = ii.ProductionDate,
                        ExpiryDate = ii.ExpiryDate,
                    };

                // Combine both queries and return distinct items
                return await receiptItemsQuery
                    .Union(transferItemsQuery)
                    .Distinct()
                    .ToListAsync();
            }
        }
        #endregion
    }
}
