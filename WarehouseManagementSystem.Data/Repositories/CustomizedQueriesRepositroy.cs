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








        public async Task<List<ItemMovementReportDTO>> GetItemDetailsWithinWarehouses(string itemCode, List<int> warehouseIds)
        {
            using var context = new WarehouseDbContext();

            // Receipts query (items coming INTO warehouses)
            var receiptsQuery =
                from rv in context.ReceiptVouchers
                join rvd in context.ReceiptVoucherDetails on rv.Id equals rvd.VoucherId
                join ii in context.InventoryItems on new { rvd.ItemCode, rv.WarehouseId } equals new { ii.ItemCode, ii.WarehouseId }
                where rvd.ItemCode == itemCode && warehouseIds.Contains(rv.WarehouseId)
                join supplier in context.Suppliers on rv.SupplierId equals supplier.Id
                select new ItemMovementReportDTO
                {
                    ItemCode = itemCode,
                    ItemName = rvd.Item.Name,
                    Warehouse = ii.Warehouse.Name,
                    CurrentQuantity = ii.Quantity, // Directly from joined inventory
                    ProductionDate = ii.ProductionDate,
                    ExpiryDate = ii.ExpiryDate,
                    MovementType = "Receipt",
                    Date = rv.Date,
                    FromWarehouseId = null,
                    FromWarehouseName = "N/A",
                    ToWarehouseId = rv.WarehouseId,
                    ToWarehouseName = rv.Warehouse.Name,
                    RelatedPerson = supplier.Name,
                    Quantity = rvd.Quantity,
                };

            // Outgoing Transfers (items moving FROM selected warehouses)
            var outgoingTransfersQuery =
                from tv in context.TransferVouchers
                join tvd in context.TransferVoucherDetails on tv.Id equals tvd.VoucherId
                join ii in context.InventoryItems on
                    new { ItemCode = tvd.ItemCode, WarehouseId = tv.FromWarehouseId } equals
                    new { ItemCode = ii.ItemCode, WarehouseId = ii.WarehouseId }
                where tvd.ItemCode == itemCode && warehouseIds.Contains(tv.FromWarehouseId)
                join fromWh in context.Warehouses on tv.FromWarehouseId equals fromWh.Id
                join toWh in context.Warehouses on tv.ToWarehouseId equals toWh.Id
                select new ItemMovementReportDTO
                {
                    ItemCode = itemCode,
                    ItemName = tvd.Item.Name,
                    Warehouse = ii.Warehouse.Name,
                    CurrentQuantity = ii.Quantity,
                    ProductionDate = ii.ProductionDate,
                    ExpiryDate = ii.ExpiryDate,
                    MovementType = "Transfer Out",
                    Date = tv.Date,
                    FromWarehouseId = tv.FromWarehouseId,
                    FromWarehouseName = fromWh.Name,
                    ToWarehouseId = tv.ToWarehouseId,
                    ToWarehouseName = toWh.Name,
                    RelatedPerson = tvd.Supplier.Name,
                    Quantity = tvd.Quantity,
                };

            // Incoming Transfers (items moving TO selected warehouses)
            var incomingTransfersQuery =
                        from tv in context.TransferVouchers
                        join tvd in context.TransferVoucherDetails on tv.Id equals tvd.VoucherId
                        join ii in context.InventoryItems on
                            new { ItemCode = tvd.ItemCode, WarehouseId = tv.ToWarehouseId } equals
                            new { ItemCode = ii.ItemCode, WarehouseId = ii.WarehouseId }
                        where tvd.ItemCode == itemCode && warehouseIds.Contains(tv.ToWarehouseId)
                        join fromWh in context.Warehouses on tv.FromWarehouseId equals fromWh.Id
                        join toWh in context.Warehouses on tv.ToWarehouseId equals toWh.Id
                        select new ItemMovementReportDTO
                        {
                            ItemCode = itemCode,
                            ItemName = tvd.Item.Name,
                            Warehouse = ii.Warehouse.Name,
                            CurrentQuantity = ii.Quantity,
                            ProductionDate = ii.ProductionDate,
                            ExpiryDate = ii.ExpiryDate,
                            MovementType = "Transfer In",
                            Date = tv.Date,
                            FromWarehouseId = tv.FromWarehouseId,
                            FromWarehouseName = fromWh.Name,
                            ToWarehouseId = tv.ToWarehouseId,
                            ToWarehouseName = toWh.Name,
                            RelatedPerson = tvd.Supplier.Name,
                            Quantity = tvd.Quantity,
                        };

            // Issues query (items leaving warehouses)
            var issuesQuery =
                from iv in context.IssueVouchers
                join ivd in context.IssueVoucherDetails on iv.Id equals ivd.VoucherId
                join ii in context.InventoryItems on new { ivd.ItemCode, iv.WarehouseId } equals new { ii.ItemCode, ii.WarehouseId }
                where ivd.ItemCode == itemCode && warehouseIds.Contains(iv.WarehouseId)
                join customer in context.Customers on iv.CustomerId equals customer.Id
                select new ItemMovementReportDTO
                {
                    ItemCode = itemCode,
                    ItemName = ivd.Item.Name,
                    Warehouse = ii.Warehouse.Name,
                    CurrentQuantity = ii.Quantity,
                    ProductionDate = ii.ProductionDate,
                    ExpiryDate = ii.ExpiryDate,
                    MovementType = "Issue",
                    Date = iv.Date,
                    FromWarehouseId = iv.WarehouseId,
                    FromWarehouseName = iv.Warehouse.Name,
                    ToWarehouseId = null,
                    ToWarehouseName = "N/A",
                    RelatedPerson = customer.Name,
                    Quantity = ivd.Quantity,
                };

            // Execute all queries in parallel
            var receipts = await receiptsQuery.ToListAsync();
            var outgoingTransfers = await outgoingTransfersQuery.ToListAsync();
            var incomingTransfers = await incomingTransfersQuery.ToListAsync();
            var issues = await issuesQuery.ToListAsync();


            var results = receipts
                .Concat(outgoingTransfers)
                .Concat(incomingTransfers)
                .Concat(issues)
                .OrderBy(x => x.Date)
                .ToList();
            return results;
        }
        public async Task<List<ItemMovementReportDTO>> GetItemMovementsReportAsync(
                                                                                    List<int> warehouseIds,
                                                                                    DateOnly? StartDate,
                                                                                    DateOnly? EndDate)
        {
            using var context = new WarehouseDbContext();
            // Receipts (items coming INTO warehouses)
            var receipts =
                from rv in context.ReceiptVouchers
                where warehouseIds.Contains(rv.WarehouseId)
                              && (!StartDate.HasValue || rv.Date >= StartDate)
                                && (!EndDate.HasValue || rv.Date <= EndDate)
                join rvd in context.ReceiptVoucherDetails on rv.Id equals rvd.VoucherId
                join item in context.Items on rvd.ItemCode equals item.Code
                join supplier in context.Suppliers on rv.SupplierId equals supplier.Id
                join fromWarehouse in context.Warehouses on rv.SupplierId equals fromWarehouse.Id into temp
                from fw in temp.DefaultIfEmpty() // Supplier may not be a warehouse
                select new ItemMovementReportDTO
                {
                    ItemCode = rvd.ItemCode,
                    ItemName = item.Name,
                    Quantity = rvd.Quantity,
                    MovementType = "Receipt",
                    Date = rv.Date,
                    FromWarehouseId = null, // Receipts typically come from suppliers
                    FromWarehouseName = "N/A",
                    ToWarehouseId = rv.WarehouseId,
                    ToWarehouseName = rv.Warehouse.Name,
                    RelatedPerson = supplier.Name,
                    CurrentQuantity = context.InventoryItems
                        .Where(ii => ii.ItemCode == rvd.ItemCode && ii.WarehouseId == rv.WarehouseId)
                        .Select(ii => ii.Quantity)
                        .FirstOrDefault()
                };

            // Transfers (items moving BETWEEN warehouses)
            var transfers =
                from tv in context.TransferVouchers
                where (warehouseIds.Contains(tv.FromWarehouseId) ||
                      (warehouseIds.Contains(tv.ToWarehouseId))
                              && (!StartDate.HasValue || tv.Date >= StartDate)
                              && (!EndDate.HasValue || tv.Date <= EndDate))
                join tvd in context.TransferVoucherDetails on tv.Id equals tvd.VoucherId
                join item in context.Items on tvd.ItemCode equals item.Code
                join fromWh in context.Warehouses on tv.FromWarehouseId equals fromWh.Id
                join toWh in context.Warehouses on tv.ToWarehouseId equals toWh.Id
                select new ItemMovementReportDTO
                {
                    ItemCode = tvd.ItemCode,
                    ItemName = item.Name,
                    Quantity = tvd.Quantity,
                    MovementType = "Transfer",
                    Date = tv.Date,
                    FromWarehouseId = tv.FromWarehouseId,
                    FromWarehouseName = fromWh.Name,
                    ToWarehouseId = tv.ToWarehouseId,
                    ToWarehouseName = toWh.Name,
                    RelatedPerson = null,
                    CurrentQuantity = context.InventoryItems
                        .Where(ii => ii.ItemCode == tvd.ItemCode &&
                                   (ii.WarehouseId == tv.FromWarehouseId ||
                                    ii.WarehouseId == tv.ToWarehouseId))
                        .Sum(ii => ii.Quantity)
                };

            // Issues (items leaving warehouses)
            var issues =
                from iv in context.IssueVouchers
                where warehouseIds.Contains(iv.WarehouseId)
                            && (!StartDate.HasValue || iv.Date >= StartDate)
                                && (!EndDate.HasValue || iv.Date <= EndDate)
                join ivd in context.IssueVoucherDetails on iv.Id equals ivd.VoucherId
                join item in context.Items on ivd.ItemCode equals item.Code
                join customer in context.Customers on iv.CustomerId equals customer.Id
                select new ItemMovementReportDTO
                {
                    ItemCode = ivd.ItemCode,
                    ItemName = item.Name,
                    Quantity = ivd.Quantity,
                    MovementType = "Issue",
                    Date = iv.Date,
                    FromWarehouseId = iv.WarehouseId,
                    FromWarehouseName = iv.Warehouse.Name,
                    ToWarehouseId = null,
                    ToWarehouseName = "Customer",
                    RelatedPerson = customer.Name,
                    CurrentQuantity = context.InventoryItems
                        .Where(ii => ii.ItemCode == ivd.ItemCode && ii.WarehouseId == iv.WarehouseId)
                        .Select(ii => ii.Quantity)
                        .FirstOrDefault()
                };

            return await receipts
                .Concat(transfers)
                .Concat(issues)
                .OrderBy(x => x.Date)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
