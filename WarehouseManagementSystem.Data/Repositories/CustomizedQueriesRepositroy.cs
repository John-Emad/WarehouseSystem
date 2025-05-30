
using Azure.Identity;
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
        public async Task<List<AvailableItemsAtWarehouseDTO>> GetAllItemsAtWarehouseWithSupplierTransferAsync(int warehouseId)
        {
            using (var warehouseSystemDbContext = new WarehouseDbContext())
            {
                // Query for items with receipt voucher details
                var receiptItemsQuery =
                    from ii in warehouseSystemDbContext.InventoryItems
                    where ii.WarehouseId == warehouseId
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
        public async Task<List<WarehouseItemsStateWithTransfer>> GetAllItemsAtWarehouseWithinTimeRangeAsync(int warehouseId, DateOnly start, DateOnly end)
        {

            using (var context = new WarehouseDbContext())
            {
                // Receipts
                var receipts = from rvd in context.ReceiptVoucherDetails
                               join rv in context.ReceiptVouchers on rvd.VoucherId equals rv.Id
                               join ii in context.InventoryItems on new { rvd.ItemCode, rv.WarehouseId } equals new { ii.ItemCode, ii.WarehouseId }
                               join item in context.Items on ii.ItemCode equals item.Code
                               join s in context.People.OfType<Supplier>() on rv.SupplierId equals s.Id
                               where rv.WarehouseId == warehouseId && rv.Date >= start && rv.Date <= end
                               select new WarehouseItemsStateWithTransfer
                               {
                                   ItemName = item.Name,
                                   ItemCode = ii.ItemCode,
                                   CurrentItemQuantity = ii.Quantity,
                                   PersonName = s.Name,
                                   PersonId = s.Id,
                                   ProductionDate = ii.ProductionDate,
                                   ExpiryDate = ii.ExpiryDate,
                                   State = "Receipt",
                                   StateDate = rv.Date,
                                   StateQuantity = rvd.Quantity
                               };

                // Transfers INTO warehouse
                var transferIn = from tvd in context.TransferVoucherDetails
                                 join tv in context.TransferVouchers on tvd.VoucherId equals tv.Id
                                 join ii in context.InventoryItems on new { tvd.ItemCode, WarehouseId = tv.ToWarehouseId } equals new { ii.ItemCode, ii.WarehouseId }
                                 join item in context.Items on ii.ItemCode equals item.Code
                                 where tv.ToWarehouseId == warehouseId && tv.Date >= start && tv.Date <= end
                                 select new WarehouseItemsStateWithTransfer
                                 {
                                     ItemName = item.Name,
                                     ItemCode = ii.ItemCode,
                                     CurrentItemQuantity = ii.Quantity,
                                     PersonName = tvd.Supplier.Name,
                                     PersonId = (int)tvd.SupplierId,
                                     ProductionDate = ii.ProductionDate,
                                     ExpiryDate = ii.ExpiryDate,
                                     State = "Transfer In",
                                     StateDate = tv.Date,
                                     StateQuantity = tvd.Quantity
                                 };

                // Transfers OUT OF warehouse
                var transferOut = from tvd in context.TransferVoucherDetails
                                  join tv in context.TransferVouchers on tvd.VoucherId equals tv.Id
                                  join ii in context.InventoryItems on new { tvd.ItemCode, WarehouseId = tv.FromWarehouseId } equals new { ii.ItemCode, ii.WarehouseId }
                                  join item in context.Items on ii.ItemCode equals item.Code
                                  where tv.FromWarehouseId == warehouseId && tv.Date >= start && tv.Date <= end
                                  select new WarehouseItemsStateWithTransfer
                                  {
                                      ItemName = item.Name,
                                      ItemCode = ii.ItemCode,
                                      CurrentItemQuantity = ii.Quantity,
                                      PersonName = tvd.Supplier.Name,
                                      PersonId = (int)tvd.SupplierId,
                                      ProductionDate = ii.ProductionDate,
                                      ExpiryDate = ii.ExpiryDate,
                                      State = "TransferOut",
                                      StateDate = tv.Date,
                                      StateQuantity = tvd.Quantity
                                  };

                // Issues
                var issues = from ivd in context.IssueVoucherDetails
                             join iv in context.IssueVouchers on ivd.VoucherId equals iv.Id
                             join ii in context.InventoryItems on new { ivd.ItemCode, iv.WarehouseId } equals new { ii.ItemCode, ii.WarehouseId }
                             join item in context.Items on ii.ItemCode equals item.Code
                             join c in context.People.OfType<Customer>() on iv.CustomerId equals c.Id
                             where iv.WarehouseId == warehouseId && iv.Date >= start && iv.Date <= end
                             select new WarehouseItemsStateWithTransfer
                             {
                                 ItemName = item.Name,
                                 ItemCode = ii.ItemCode,
                                 CurrentItemQuantity = ii.Quantity,
                                 PersonName = c.Name,
                                 PersonId = c.Id,
                                 ProductionDate = ii.ProductionDate,
                                 ExpiryDate = ii.ExpiryDate,
                                 State = "Issue",
                                 StateDate = iv.Date,
                                 StateQuantity = ivd.Quantity
                             };

                return await receipts
                    .Union(transferIn)
                    .Union(transferOut)
                    .Union(issues)
                    .ToListAsync();
            }
            #endregion
        }
    }
}
