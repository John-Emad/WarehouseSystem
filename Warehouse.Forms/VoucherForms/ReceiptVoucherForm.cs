using WarehouseManagementSystem.Data.Context;
using WarehouseManagementSystem.Data.Repositories;
using WarehouseManagementSystem.Domain.DTOs;
using WarehouseManagementSystem.Domain.Models;
using WarehouseManagementSystem.Domain.Vouchers;

namespace WarehouseManagmentSystem.WinForms
{
    public partial class ReceiptVoucherForm : Form
    {
        #region Fields
        private List<InventoryItemViewDTO> InventoryItemViewDTOList;
        private bool isFormLoading = false;
        #endregion

        #region Constructors
        public ReceiptVoucherForm()
        {
            isFormLoading = true;
            InventoryItemViewDTOList = new List<InventoryItemViewDTO>();
            InitializeComponent();
            isFormLoading = false;

        }
        #endregion

        #region Methods

        #region Load data
        private async void ReceiptVoucherForm_Load(object sender, EventArgs e)
        {
            await LoadData();
            ResetEnteredItemData();
            ResetEnteredReceiptData();
        }
        private async Task LoadData()
        {
            isFormLoading = true;
            try
            {
                await LoadWareHousesToComboBox();
                await LoadSuppliersToComboBox();
                await LoadItemsToComboBox();
            }
            finally
            {
                isFormLoading = false;
            }
        }
        private async Task LoadWareHousesToComboBox()
        {
            isFormLoading = true;
            using var context = new WarehouseDbContext();
            var _warehouseRepository = new WarehouseRepository(context);
            List<Warehouse> warehouses = new List<Warehouse>();
            warehouses = await _warehouseRepository.GetAllAsync();
            ReceiptVoucherWarehouseComboBox.DisplayMember = "Name";
            ReceiptVoucherWarehouseComboBox.ValueMember = "Id";
            ReceiptVoucherWarehouseComboBox.DataSource = warehouses;
            isFormLoading = false;
        }
        private async Task LoadSuppliersToComboBox()
        {
            using var context = new WarehouseDbContext();
            var _personRepository = new PersonRepository(context);
            List<Supplier> suppliers = new List<Supplier>();
            suppliers = await _personRepository.GetSuppliersAsync();
            ReceiptVoucherSupplierComboBox.DisplayMember = "Name";
            ReceiptVoucherSupplierComboBox.ValueMember = "Id";
            ReceiptVoucherSupplierComboBox.DataSource = suppliers;
        }
        private async Task LoadItemsToComboBox()
        {
            using var context = new WarehouseDbContext();
            var _itemRepository = new ItemRepository(context);
            List<Item> items = new List<Item>();
            items = await _itemRepository.GetAllAsync();
            ReceiptVoucherItemsComboBox.DisplayMember = "Name";
            ReceiptVoucherItemsComboBox.ValueMember = "Code";
            ReceiptVoucherItemsComboBox.DataSource = items;
        }
        private void UpdateItemsGridView()
        {
            var viewList = InventoryItemViewDTOList.Select(i => new
            {
                i.ItemName,
                i.Quantity,
                i.ProductionDate,
                i.ExpiryDate,
            }).ToList();
            ReceiptVoucherItemsGridView.DataSource = viewList;

            if (ReceiptVoucherItemsGridView.Columns.Contains("ProductionDate"))
                ReceiptVoucherItemsGridView.Columns["ProductionDate"].HeaderText = "Prod Date";

            if (ReceiptVoucherItemsGridView.Columns.Contains("ExpiryDate"))
                ReceiptVoucherItemsGridView.Columns["ExpiryDate"].HeaderText = "Exp Date";

        }
        #endregion

        #region Reset Form
        private void ResetEnteredItemData()
        {
            isFormLoading = true;
            try
            {
                ReceiptVoucherProductionDate.Text = "";
                ReceiptVoucherExpiryDate.Text = "";
                ReceiptVoucherItemsComboBox.SelectedIndex = -1;
                ReceiptVoucherQuantityTextBox.Clear();
            }
            finally
            {
                isFormLoading = false;
            }
        }
        private void ResetEnteredReceiptData()
        {
            isFormLoading = true;
            try
            {
                ReceiptVoucherSupplierComboBox.SelectedIndex = -1;
                ReceiptVoucherWarehouseComboBox.SelectedIndex = -1;
                ReceiptVoucherReceiptDate.Text = "";
                UserChosenSupplierViewLabel.Text = "N/A";
                UserChosenWarehouseViewLabel.Text = "N/A";
                UserChosenViewReceiptDateLabel.Text = "N/A";
                InventoryItemViewDTOList.Clear();
                UpdateItemsGridView();
            }
            finally
            {
                isFormLoading = false;
            }
        }
        #endregion

        #region Data
        private async Task AddToReceiptVoucherAndDetailsTables()
        {
            using var context = new WarehouseDbContext();
            await using var transaction = await context.Database.BeginTransactionAsync();

            try
            {
                // Create and add the main receipt voucher
                var _receiptVoucherRepository = new ReceiptVoucherRepository(context);
                var receiptVoucher = new ReceiptVoucher
                {
                    Date = DateOnly.FromDateTime(ReceiptVoucherReceiptDate.Value),
                    SupplierId = (int)ReceiptVoucherSupplierComboBox.SelectedValue,
                    WarehouseId = (int)ReceiptVoucherWarehouseComboBox.SelectedValue
                };
                await _receiptVoucherRepository.AddAsync(receiptVoucher);

                // Add all voucher details
                var _receiptVoucherDetailsRepository = new ReceiptVoucherDetailsRepository(context);
                foreach (var dto in InventoryItemViewDTOList)
                {
                    var detail = new ReceiptVoucherDetail
                    {
                        VoucherId = receiptVoucher.Id,
                        ItemCode = dto.ItemCode,
                        Quantity = dto.Quantity,
                        ProductionDate = DateOnly.FromDateTime(dto.ProductionDate),
                        ExpiryDate = DateOnly.FromDateTime(dto.ExpiryDate)
                    };
                    await _receiptVoucherDetailsRepository.AddAsync(detail);
                }

                // Commit transaction if everything succeeds
                await transaction.CommitAsync();

            }
            catch (Exception ex)
            {
                // Rollback transaction if any error occurs
                await transaction.RollbackAsync();
                throw;
            }
        }
        #endregion

        #region Validations
        private bool IsValidReceipt()
        {
            if (string.IsNullOrWhiteSpace(ReceiptVoucherReceiptDate.Text))
            {
                MessageBox.Show("Must Specify the Receipt Voucher date", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (ReceiptVoucherWarehouseComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("The Warehouse must be chosen first", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (ReceiptVoucherSupplierComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("The Supplier must be chosen first", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private bool IsValidItemInput()
        {
            if (ReceiptVoucherItemsComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Must Choose item to add to receipt", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(ReceiptVoucherProductionDate.Text))
            {
                MessageBox.Show("Must Specify the Production date of the product", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(ReceiptVoucherExpiryDate.Text))
            {
                MessageBox.Show("Must Specify the Expiry date of the product", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(ReceiptVoucherQuantityTextBox.Text))
            {
                MessageBox.Show("Must Specify the Product Quantity", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validate quantity is positive decimal
            if (!decimal.TryParse(ReceiptVoucherQuantityTextBox.Text, out decimal quantity) || quantity <= 0)
            {
                MessageBox.Show("Quantity must be a positive number", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            DateTime productionDate = ReceiptVoucherProductionDate.Value.Date;
            DateTime expiryDate = ReceiptVoucherExpiryDate.Value.Date;

            if (productionDate >= expiryDate)
            {
                MessageBox.Show("Expiry Date must be after Production Date", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;

        }
        #endregion

        #region Comboboxes and Dates Event Handler
        private void ReceiptVoucherWarehouseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isFormLoading) return;

            if (ReceiptVoucherWarehouseComboBox.SelectedIndex > 0)
            {
                UserChosenWarehouseViewLabel.Text = ReceiptVoucherWarehouseComboBox.Text;
            }
            else
            {
                UserChosenWarehouseViewLabel.Text = "N/A";
            }
        }

        private void ReceiptVoucherSupplierComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isFormLoading) return;

            if (ReceiptVoucherSupplierComboBox.SelectedIndex != -1)
            {
                UserChosenSupplierViewLabel.Text = ReceiptVoucherSupplierComboBox.Text;
            }
            else
            {
                UserChosenSupplierViewLabel.Text = "N/A";
            }
        }

        private void ReceiptVoucherReceiptDate_ValueChanged(object sender, EventArgs e)
        {
            if (isFormLoading) return;
            UserChosenViewReceiptDateLabel.Text = ReceiptVoucherReceiptDate.Text;
        }
        #endregion

        #region Buttons Event handlers
        private void ReceiptVoucherAddItemButton_Click(object sender, EventArgs e)
        {
            if (IsValidItemInput())
            {
                InventoryItemViewDTO inventoryItemViewDTO = new InventoryItemViewDTO();
                inventoryItemViewDTO.ItemCode = (string)ReceiptVoucherItemsComboBox.SelectedValue;
                inventoryItemViewDTO.ItemName = ReceiptVoucherItemsComboBox.Text;
                inventoryItemViewDTO.Quantity = int.Parse(ReceiptVoucherQuantityTextBox.Text);
                inventoryItemViewDTO.ProductionDate = ReceiptVoucherProductionDate.Value;
                inventoryItemViewDTO.ExpiryDate = ReceiptVoucherExpiryDate.Value;
                InventoryItemViewDTOList.Add(inventoryItemViewDTO);
                UpdateItemsGridView();
                ResetEnteredItemData();
            }
        }
        private async void ReceiptVoucherAddToWarehouseButton_ClickAsync(object sender, EventArgs e)
        {
            if (IsValidReceipt())
            {
                using var context = new WarehouseDbContext();
                var _inventoryItemRepository = new InventoryItemRepository(context);

                // Create confirmation message
                string message = $"Confirm Receipt To Warehouse\n\n" +
                               $"Warehouse: {ReceiptVoucherWarehouseComboBox.Text}\n" +
                               $"Receipt Date: {ReceiptVoucherReceiptDate.Text}\n" +
                               $"Receipt Supplier: {ReceiptVoucherSupplierComboBox.Text}\n" +
                               $"Receipt Items:\n{string.Join("\n", InventoryItemViewDTOList)}";

                var result = MessageBox.Show(message, "Confirm Receipt",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using var transaction = await context.Database.BeginTransactionAsync();

                    try
                    {
                        var warehouseId = (int)ReceiptVoucherWarehouseComboBox.SelectedValue;
                        var existingItems = await _inventoryItemRepository.GetAllAsync();

                        // Adding item to Inventory item and increase quantity if found with same PK
                        foreach (var item in InventoryItemViewDTOList)
                        {
                            var existing = existingItems.FirstOrDefault(i =>
                                i.ItemCode == item.ItemCode &&
                                i.WarehouseId == warehouseId &&
                                i.ProductionDate == DateOnly.FromDateTime(item.ProductionDate.Date) &&
                                i.ExpiryDate == DateOnly.FromDateTime(item.ExpiryDate.Date));

                            if (existing != null)
                            {
                                existing.Quantity += item.Quantity;
                                await _inventoryItemRepository.UpdateAsync(existing);
                            }
                            else
                            {
                                var inventoryItem = new InventoryItem
                                {
                                    ItemCode = item.ItemCode,
                                    WarehouseId = warehouseId,
                                    ProductionDate = DateOnly.FromDateTime(item.ProductionDate),
                                    ExpiryDate = DateOnly.FromDateTime(item.ExpiryDate),
                                    Quantity = item.Quantity
                                };
                                await _inventoryItemRepository.AddAsync(inventoryItem);
                            }
                        }

                        await AddToReceiptVoucherAndDetailsTables();
                        await transaction.CommitAsync();

                        MessageBox.Show("Receipt voucher processed successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ResetEnteredReceiptData();
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        MessageBox.Show($"Error processing receipt voucher: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void ReceiptDeleteButton_Click(object sender, EventArgs e)
        {
            // Ensure the user has clicked a valid cell
            if (ReceiptVoucherItemsGridView.CurrentCell != null)
            {
                int rowIndex = ReceiptVoucherItemsGridView.CurrentCell.RowIndex;

                // Make sure index is valid
                if (rowIndex >= 0 && rowIndex < InventoryItemViewDTOList.Count)
                {
                    // Get the selected item's name (adjust column name as needed)
                    var selectedItemName = ReceiptVoucherItemsGridView.Rows[rowIndex].Cells["Name"].Value?.ToString();

                    // Confirm deletion
                    var result = MessageBox.Show($"Delete '{selectedItemName}' from receipt?",
                                                 "Confirm Deletion",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Remove from the list
                        InventoryItemViewDTOList.RemoveAt(rowIndex);

                        // Refresh the grid view
                        UpdateItemsGridView();

                        MessageBox.Show("Item removed from receipt", "Success",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please click on an item row to delete.", "Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }


        private void ReceiptVoucherItemsGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= InventoryItemViewDTOList.Count) return;

            // Get the selected item from your source list
            var selectedItem = InventoryItemViewDTOList[e.RowIndex];

            // Prevent events from firing while we update controls
            isFormLoading = true;
            try
            {
                // Find and select the item in the ComboBox
                foreach (Item item in ReceiptVoucherItemsComboBox.Items)
                {
                    if (item.Code == selectedItem.ItemCode)
                    {
                        ReceiptVoucherItemsComboBox.SelectedItem = item;
                        break;
                    }
                }

                // Update other controls
                ReceiptVoucherQuantityTextBox.Text = selectedItem.Quantity.ToString();
                ReceiptVoucherProductionDate.Value = selectedItem.ProductionDate;
                ReceiptVoucherExpiryDate.Value = selectedItem.ExpiryDate;

                // Store the index of the selected row for potential update/delete
                ReceiptVoucherItemsGridView.Tag = e.RowIndex;
            }
            finally
            {
                isFormLoading = false;
            }
        }
        private void ReceiptVoucherItemsGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                ReceiptDeleteButton_Click(sender, e);
            }
        }
        #endregion

        #endregion

    }
}
