using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem.Data.Context;
using WarehouseManagementSystem.Data.Repositories;
using WarehouseManagementSystem.Domain.DTOs;
using WarehouseManagementSystem.Domain.Models;
using WarehouseManagementSystem.Domain.Vouchers;

namespace WarehouseManagmentSystem.WinForms
{
    public partial class TransferVoucherForm : Form
    {
        #region Fields
        List<AvailableItemsAtWarehouseDTO> AvailableItemsAtWarehouseList;
        private List<AvailableItemsAtWarehouseDTO> SelectedItemsList;
        private bool isFormLoading = false;
        private int fromWarehouseId;
        private int toWarehouseId;
        #endregion

        #region Constructors
        public TransferVoucherForm()
        {
            AvailableItemsAtWarehouseList = new List<AvailableItemsAtWarehouseDTO>();
            SelectedItemsList = new List<AvailableItemsAtWarehouseDTO>();
            InitializeComponent();
            TransferToWarehouseGridView.KeyDown += TransferToWarehouseGridView_KeyDown;
            this.Load += TransferVoucherForm_LoadAsync;
            InitializeControllers();
        }
        #endregion

        #region Load and Initialize Form Methods
        private async void TransferVoucherForm_LoadAsync(object? sender, EventArgs e)
        {
            await LoadTransferFromWarehousesComboBox();
        }
        private void InitializeControllers()
        {
            TransferToWarehouseComboBox.Enabled = false;
            TransferToWarehouseComboBox.SelectedIndex = -1;
            TransferFromWarehouseComboBox.SelectedIndex = -1;
        }
        private async Task LoadTransferFromWarehousesComboBox()
        {
            isFormLoading = true;
            using (var context = new WarehouseDbContext())
            {
                var repo = new WarehouseRepository(context);
                List<Warehouse> warehouses = new List<Warehouse>();
                warehouses = await repo.GetAllAsync();
                TransferFromWarehouseComboBox.DisplayMember = "Name";
                TransferFromWarehouseComboBox.ValueMember = "Id";
                TransferFromWarehouseComboBox.DataSource = warehouses;
            }
            TransferFromWarehouseComboBox.SelectedIndex = -1;
            isFormLoading = false;
        }

        #endregion

        #region ComboBoxes EventHandlers
        private async void TransferFromWarehouseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isFormLoading) return;

            if (TransferFromWarehouseComboBox.SelectedIndex != -1 &&
                TransferFromWarehouseComboBox.SelectedItem is Warehouse selectedWarehouse)
            {
                if (TransferFromWarehouseComboBox.SelectedValue == null) return;
                TransferToWarehouseComboBox.Enabled = true;
                fromWarehouseId = (int)TransferFromWarehouseComboBox.SelectedValue;
                await UpdateTransferToComboBoxAsync();
                SelectedItemsList.Clear();
                ResetTransferToWarehouseGridView();
                await AddWarehouseInventoryItemsToTransferFromGridView();
            }
            else
            {
                TransferToWarehouseComboBox.Enabled = false;
                TransferToWarehouseComboBox.DataSource = null;
            }
        }
        private void TransferToWarehouseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TransferToWarehouseComboBox.SelectedValue == null) return;
            toWarehouseId = (int)TransferToWarehouseComboBox.SelectedValue;
        }

        private async Task UpdateTransferToComboBoxAsync()
        {
            using var context = new WarehouseDbContext();
            var repo = new WarehouseRepository(context);
            var allWarehouses = await repo.GetAllAsync();

            // Filter out the selected "from" warehouse
            var filteredWarehouses = allWarehouses
                .Where(w => w.Id != fromWarehouseId)
                .ToList();

            TransferToWarehouseComboBox.DisplayMember = "Name";
            TransferToWarehouseComboBox.ValueMember = "Id";
            TransferToWarehouseComboBox.DataSource = filteredWarehouses;
            TransferToWarehouseComboBox.SelectedIndex = -1;
        }
        #endregion

        #region Transfer From Warehouse GridView
        private async Task AddWarehouseInventoryItemsToTransferFromGridView()
        {
            using var context = new WarehouseDbContext();
            var _customizedQueriesRepositroy = new CustomizedQueriesRepositroy(context);
            AvailableItemsAtWarehouseList.Clear();
            AvailableItemsAtWarehouseList = await _customizedQueriesRepositroy.GetAvailableItemsAtWarehouseWithSupplierTransferAsync(fromWarehouseId);
            TransferFromWarehouseGridView.DataSource = AvailableItemsAtWarehouseList;
            EditTransferFromGridViewColumns();
        }

        private void EditTransferFromGridViewColumns()
        {

            #region Hide columns
            // Hide
            if (TransferFromWarehouseGridView.Columns.Contains("ItemCode"))
                TransferFromWarehouseGridView.Columns["ItemCode"].Visible = false;

            if (TransferFromWarehouseGridView.Columns.Contains("WarehouseName"))
                TransferFromWarehouseGridView.Columns["WarehouseName"].Visible = false;

            if (TransferFromWarehouseGridView.Columns.Contains("WarehouseId"))
                TransferFromWarehouseGridView.Columns["WarehouseId"].Visible = false;

            if (TransferFromWarehouseGridView.Columns.Contains("SupplierId"))
                TransferFromWarehouseGridView.Columns["SupplierId"].Visible = false;

            if (TransferFromWarehouseGridView.Columns.Contains("ItemCode"))
                TransferFromWarehouseGridView.Columns["ItemCode"].Visible = false;
            #endregion

            #region Rename Columns
            // Rename
            if (TransferFromWarehouseGridView.Columns.Contains("ItemName"))
                TransferFromWarehouseGridView.Columns["ItemName"].HeaderText = "Item";

            if (TransferFromWarehouseGridView.Columns.Contains("SupplierName"))
                TransferFromWarehouseGridView.Columns["SupplierName"].HeaderText = "Supplier";

            if (TransferFromWarehouseGridView.Columns.Contains("ItemQuantity"))
                TransferFromWarehouseGridView.Columns["ItemQuantity"].HeaderText = "In Stock";

            if (TransferFromWarehouseGridView.Columns.Contains("ProductionDate"))
                TransferFromWarehouseGridView.Columns["ProductionDate"].HeaderText = "Prod Date";

            if (TransferFromWarehouseGridView.Columns.Contains("ExpiryDate"))
                TransferFromWarehouseGridView.Columns["ExpiryDate"].HeaderText = "Exp Date"; 
            #endregion
        }

        private void TransferFromWarehouseGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < TransferFromWarehouseGridView.Rows.Count)
            {
                var selectedRow = TransferFromWarehouseGridView.Rows[e.RowIndex];

                // Get the bound item from the DataGridView
                var selectedItem = (AvailableItemsAtWarehouseDTO)TransferFromWarehouseGridView.Rows[e.RowIndex].DataBoundItem;

                // Check if already added (based on ItemCode and WarehouseId for uniqueness)
                if (selectedRow.DefaultCellStyle.BackColor == Color.LightGreen)
                {
                    MessageBox.Show("This item has already been selected.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var copiedItem = new AvailableItemsAtWarehouseDTO
                {
                    ItemName = selectedItem.ItemName,
                    ItemCode = selectedItem.ItemCode,
                    ItemQuantity = selectedItem.ItemQuantity,
                    WarehouseId = selectedItem.WarehouseId,
                    WarehouseName = selectedItem.WarehouseName,
                    SupplierName = selectedItem.SupplierName,
                    SupplierId = selectedItem.SupplierId,
                    ProductionDate = selectedItem.ProductionDate,
                    ExpiryDate = selectedItem.ExpiryDate,
                };

                SelectedItemsList.Add(copiedItem);

                // Refresh the second grid
                TransferToWarehouseGridView.DataSource = null;
                TransferToWarehouseGridView.DataSource = SelectedItemsList;

                EditTransferToGridViewColumns();

                selectedRow.DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }

        #endregion

        #region Transfer To Warehouse GridView
        private void EditTransferToGridViewColumns()
        {
            #region Hide Columns
            if (TransferToWarehouseGridView.Columns.Contains("ItemCode"))
                TransferToWarehouseGridView.Columns["ItemCode"].Visible = false;

            if (TransferToWarehouseGridView.Columns.Contains("WarehouseName"))
                TransferToWarehouseGridView.Columns["WarehouseName"].Visible = false;

            if (TransferToWarehouseGridView.Columns.Contains("WarehouseId"))
                TransferToWarehouseGridView.Columns["WarehouseId"].Visible = false;

            if (TransferToWarehouseGridView.Columns.Contains("SupplierId"))
                TransferToWarehouseGridView.Columns["SupplierId"].Visible = false; 
            #endregion

            #region Rename Columns
            // Rename
            if (TransferToWarehouseGridView.Columns.Contains("ItemName"))
                TransferToWarehouseGridView.Columns["ItemName"].HeaderText = "Item";

            if (TransferToWarehouseGridView.Columns.Contains("SupplierName"))
                TransferToWarehouseGridView.Columns["SupplierName"].HeaderText = "Supplier";

            if (TransferToWarehouseGridView.Columns.Contains("ItemQuantity"))
                TransferToWarehouseGridView.Columns["ItemQuantity"].HeaderText = "Transfer Quantity";

            if (TransferToWarehouseGridView.Columns.Contains("ProductionDate"))
                TransferToWarehouseGridView.Columns["ProductionDate"].HeaderText = "Prod Date";

            if (TransferToWarehouseGridView.Columns.Contains("ExpiryDate"))
                TransferToWarehouseGridView.Columns["ExpiryDate"].HeaderText = "Exp Date";
            #endregion
        }
        private void ResetTransferToWarehouseGridView()
        {
            TransferToWarehouseGridView.DataSource = null;
            TransferToWarehouseGridView.Refresh();

            // Make all columns read-only except "ItemQuantity"
            foreach (DataGridViewColumn column in TransferToWarehouseGridView.Columns)
            {
                column.ReadOnly = column.Name != "ItemQuantity";
            }
            EditTransferToGridViewColumns();
        }

        private void TransferToWarehouseGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (TransferToWarehouseGridView.Columns[e.ColumnIndex].Name != "ItemQuantity")
            {
                e.Cancel = true; // Prevent editing in all columns except "ItemQuantity"
            }
        }

        private void TransferToWarehouseGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= TransferToWarehouseGridView.Rows.Count)
            {
                var grid = TransferToWarehouseGridView;

                DataGridViewRow editedRow = grid.Rows[e.RowIndex];
                string itemCode = editedRow.Cells["ItemCode"].Value?.ToString();
                string editedValue = editedRow.Cells["ItemQuantity"].Value?.ToString();

                if (decimal.TryParse(editedValue, out decimal newQuantity))
                {
                    // Lookup the original available quantity from the IssueVoucherItemsGridView
                    decimal availableQuantity = 0;
                    foreach (DataGridViewRow originalRow in TransferFromWarehouseGridView.Rows)
                    {
                        if (originalRow.DataBoundItem is AvailableItemsAtWarehouseDTO originalItem
                            && originalItem.ItemCode == itemCode)
                        {
                            availableQuantity = originalItem.ItemQuantity;
                            break;
                        }
                    }

                    if (newQuantity <= 0)
                    {
                        MessageBox.Show("Quantity must be greater than 0.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        editedRow.Cells["ItemQuantity"].Value = availableQuantity;
                    }
                    else if (newQuantity > availableQuantity)
                    {
                        MessageBox.Show($"Quantity cannot exceed available stock of {availableQuantity}.", "Stock Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        editedRow.Cells["ItemQuantity"].Value = availableQuantity;
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid numeric quantity.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    editedRow.Cells["ItemQuantity"].Value = 1; // Default reset
                }

            }
        }

        private void TransferToWarehouseGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (TransferToWarehouseGridView.CurrentRow != null)
                {
                    int rowIndex = TransferToWarehouseGridView.CurrentRow.Index;

                    if (rowIndex >= 0 && rowIndex < SelectedItemsList.Count)
                    {
                        var itemToRemove = (AvailableItemsAtWarehouseDTO)TransferToWarehouseGridView.Rows[rowIndex].DataBoundItem;

                        var confirmResult = MessageBox.Show("Are you sure to delete this item?",
                                                             "Confirm Delete",
                                                             MessageBoxButtons.YesNo,
                                                             MessageBoxIcon.Question);

                        if (confirmResult == DialogResult.Yes)
                        {
                            SelectedItemsList.Remove(itemToRemove);

                            // Reset row color in the main grid
                            foreach (DataGridViewRow row in TransferFromWarehouseGridView.Rows)
                            {
                                if (row.DataBoundItem is AvailableItemsAtWarehouseDTO item &&
                                    item.ItemCode == itemToRemove.ItemCode &&
                                    item.WarehouseId == itemToRemove.WarehouseId &&
                                    item.ProductionDate == itemToRemove.ProductionDate &&
                                    item.ExpiryDate == itemToRemove.ExpiryDate)
                                {
                                    row.DefaultCellStyle.BackColor = Color.White; // Or Color.Empty
                                    break;
                                }
                            }

                            // Refresh grid
                            TransferToWarehouseGridView.DataSource = null;
                            TransferToWarehouseGridView.DataSource = SelectedItemsList;
                            EditTransferToGridViewColumns();
                        }
                    }
                }
            }


        }
        private void TransferToDeleteSelectedItemButton_Click(object sender, EventArgs e)
        {
            if (TransferToWarehouseGridView.CurrentRow != null)
            {
                int rowIndex = TransferToWarehouseGridView.CurrentRow.Index;

                if (rowIndex >= 0 && rowIndex < SelectedItemsList.Count)
                {
                    var itemToRemove = (AvailableItemsAtWarehouseDTO)TransferToWarehouseGridView.Rows[rowIndex].DataBoundItem;

                    var confirmResult = MessageBox.Show("Are you sure you want to remove this item?",
                                                         "Confirm Removal",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        SelectedItemsList.Remove(itemToRemove);

                        // Reset the color in the original grid
                        foreach (DataGridViewRow row in TransferFromWarehouseGridView.Rows)
                        {
                            if (row.DataBoundItem is AvailableItemsAtWarehouseDTO item &&
                                item.ItemCode == itemToRemove.ItemCode &&
                                item.WarehouseId == itemToRemove.WarehouseId &&
                                item.ProductionDate == itemToRemove.ProductionDate &&
                                item.ExpiryDate == itemToRemove.ExpiryDate)
                            {
                                row.DefaultCellStyle.BackColor = Color.White; // or Color.Empty
                                break;
                            }
                        }

                        // Refresh selection grid
                        TransferToWarehouseGridView.DataSource = null;
                        TransferToWarehouseGridView.DataSource = SelectedItemsList;
                        EditTransferToGridViewColumns();
                    }
                }
            }

        }
        #endregion

        #region Reset Form
        private void ResetTransferForm()
        {
            SelectedItemsList.Clear();
            AvailableItemsAtWarehouseList.Clear();
            TransferFromWarehouseComboBox.SelectedIndex = -1;
            TransferToWarehouseComboBox.SelectedIndex = -1;
            TransferToWarehouseComboBox.Enabled = false;
            TransferDateDatePicker.Text = "";

            TransferFromWarehouseGridView.DataSource = null;
            TransferFromWarehouseGridView.Refresh();

            TransferToWarehouseGridView.DataSource = null;
            TransferToWarehouseGridView.Refresh();
        }
        #endregion

        #region Database Operations Methods
        private async Task UpdateQuantitiesAsync()
        {
            using var context = new WarehouseDbContext();
            var _inventoryItemRepository = new InventoryItemRepository(context);
            foreach (var selectedItem in SelectedItemsList)
            {
                // SUBTRACT from source warehouse
                var sourceItem = await context.InventoryItems
                    .FirstOrDefaultAsync(i =>
                        i.WarehouseId == selectedItem.WarehouseId &&
                        i.ItemCode == selectedItem.ItemCode &&
                        i.ProductionDate == selectedItem.ProductionDate &&
                        i.ExpiryDate == selectedItem.ExpiryDate);

                if (sourceItem != null)
                {
                    sourceItem.Quantity -= selectedItem.ItemQuantity;
                    await _inventoryItemRepository.UpdateAsync(sourceItem);
                }

                // ADD to destination warehouse
                var destinationItem = await context.InventoryItems
                    .FirstOrDefaultAsync(i =>
                        i.WarehouseId == toWarehouseId &&
                        i.ItemCode == selectedItem.ItemCode &&
                        i.ProductionDate == selectedItem.ProductionDate &&
                        i.ExpiryDate == selectedItem.ExpiryDate);

                if (destinationItem != null)
                {
                    // If exists, increase the quantity
                    destinationItem.Quantity += selectedItem.ItemQuantity;
                    await _inventoryItemRepository.UpdateAsync(destinationItem);
                }
                else
                {
                    // If not exists, insert new inventory item
                    var newItem = new InventoryItem
                    {
                        ItemCode = selectedItem.ItemCode,
                        WarehouseId = toWarehouseId,
                        Quantity = selectedItem.ItemQuantity,
                        ProductionDate = selectedItem.ProductionDate,
                        ExpiryDate = selectedItem.ExpiryDate,
                    };
                    await _inventoryItemRepository.AddAsync(newItem);
                }
            }
        }

        private async Task AddToTransferVoucherAndDetailsTable()
        {
            using var context = new WarehouseDbContext();
            var _transferVoucherRepository = new TransferVoucherRepository(context);
            var _transferVoucherDetailsRepository = new TransferVoucherDetailRepository(context);
            // 1. Create a new TransferVoucher record
            var transferVoucher = new TransferVoucher
            {
                Date = DateOnly.FromDateTime(DateTime.Now), // Or use a DateTimePicker.Value if available
                FromWarehouseId = fromWarehouseId,
                ToWarehouseId = toWarehouseId,
            };

            await _transferVoucherRepository.AddAsync(transferVoucher);
            await context.SaveChangesAsync(); // Make sure the ID is generated

            // 2. Add corresponding TransferVoucherDetail records
            foreach (var item in SelectedItemsList)
            {
                var detail = new TransferVoucherDetail
                {
                    VoucherId = transferVoucher.Id,
                    ItemCode = item.ItemCode,
                    Quantity = item.ItemQuantity,
                    ProductionDate = item.ProductionDate,
                    ExpiryDate = item.ExpiryDate,
                    SupplierId = item.SupplierId,
                };

                await _transferVoucherDetailsRepository.AddAsync(detail);
            }

            await context.SaveChangesAsync();
        }

        #endregion

        #region Validation
        private bool IsValidTransfer()
        {
            if (SelectedItemsList.Count == 0)
            {
                MessageBox.Show("Must Choose at least one item", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(TransferDateDatePicker.Text))
            {
                MessageBox.Show("Must Specify the Issue Voucher date", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //if (TransferSupplierComboBox.SelectedIndex == -1)
            //{
            //    MessageBox.Show("The supplier must be chosen first", "Validation Error",
            //        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}

            if (TransferToWarehouseComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("The destination warehouse must be chosen first", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        #endregion

        private async void TransferCreateVoucherButton_ClickAsync(object sender, EventArgs e)
        {
            if (IsValidTransfer())
            {
                using var context = new WarehouseDbContext();
                var transaction = await context.Database.BeginTransactionAsync();
                string message = $"Confirm Transfer Items\n\n" +
                              $"From Warehouse: {TransferFromWarehouseComboBox.Text}\n" +
                              $"To Warehouse: {TransferToWarehouseComboBox.Text}\n" +
                              $"Transfer Date: {TransferDateDatePicker.Text}\n" +
                              $"Transfer Items:\n{string.Join("\n", SelectedItemsList)}";

                var result = MessageBox.Show(message, "Confirm Transfer",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        await UpdateQuantitiesAsync();
                        await AddToTransferVoucherAndDetailsTable();
                        await transaction.CommitAsync();
                        MessageBox.Show("Voucher created successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        await transaction.RollbackAsync();
                        MessageBox.Show("Voucher Failed", "Fail",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    ResetTransferForm();
                }
            }
        }
    }
}
