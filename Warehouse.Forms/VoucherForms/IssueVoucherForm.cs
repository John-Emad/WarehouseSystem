using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;
using WarehouseManagementSystem.Data.Context;
using WarehouseManagementSystem.Data.Repositories;
using WarehouseManagementSystem.Domain.DTOs;
using WarehouseManagementSystem.Domain.Models;
using WarehouseManagementSystem.Domain.Vouchers;

namespace WarehouseManagmentSystem.WinForms
{
    public partial class IssueVoucherForm : Form
    {
        #region Fields
        private List<AvailableItemsAtWarehouseDTO> AvailableItemsAtWarehouseList;
        private List<AvailableItemsAtWarehouseDTO> SelectedItemsList;
        private bool isFormLoading = false;
        private int warehouseId;
        #endregion

        #region Constructors
        public IssueVoucherForm()
        {
            AvailableItemsAtWarehouseList = new List<AvailableItemsAtWarehouseDTO>();
            SelectedItemsList = new List<AvailableItemsAtWarehouseDTO>();
            InitializeComponent();
            IssueSelectedItemsGridView.KeyDown += IssueSelectedItemsGridView_KeyDown;
        }
        #endregion


        #region Methods

        #region Initialize Load data
        private async void IssueVoucherForm_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadData();
                IssueVoucherCustomerComboBox.SelectedIndex = -1;
                IssueVoucherWarehouseComboBox.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task LoadData()
        {
            await LoadWareHousesToComboBox();
            await LoadCustomersToComboBox();
        }
        private async Task LoadWareHousesToComboBox()
        {
            isFormLoading = true;
            using var context = new WarehouseDbContext();
            var _warehouseRepository = new WarehouseRepository(context);
            List<Warehouse> warehouses = new List<Warehouse>();
            warehouses = await _warehouseRepository.GetAllAsync();
            IssueVoucherWarehouseComboBox.DisplayMember = "Name";
            IssueVoucherWarehouseComboBox.ValueMember = "Id";
            IssueVoucherWarehouseComboBox.DataSource = warehouses;
            isFormLoading = false;
        }
        private async Task LoadCustomersToComboBox()
        {
            using var context = new WarehouseDbContext();
            var repo = new PersonRepository(context);
            var customers = await repo.GetCustomersAsync();
            IssueVoucherCustomerComboBox.DisplayMember = "Name";
            IssueVoucherCustomerComboBox.ValueMember = "Id";
            IssueVoucherCustomerComboBox.DataSource = customers;
        }
        #endregion

        #region Issue Voucher Items Methods and Event handlers
        private async Task LoadInventoryItemsToIssueVoucherItemsGridView(int WareHouseId)
        {
            using var context = new WarehouseDbContext();
            var _customizedQueriesRepositroy = new CustomizedQueriesRepositroy(context);
            AvailableItemsAtWarehouseList = await _customizedQueriesRepositroy.GetAvailableItemsAtWarehouseWithSupplierTransferAsync(WareHouseId);
            IssueVoucherItemsGridView.DataSource = AvailableItemsAtWarehouseList;

            EditIssueVoucherItemsGridViewColumns();

        }
        private void EditIssueVoucherItemsGridViewColumns()
        {

            if (IssueSelectedItemsGridView.Columns.Contains("ItemQuantity"))
            {
                IssueSelectedItemsGridView.Columns["ItemQuantity"].ReadOnly = false;
            }

            #region Hide
            if (IssueVoucherItemsGridView.Columns.Contains("ItemCode"))
                IssueVoucherItemsGridView.Columns["ItemCode"].Visible = false;

            if (IssueVoucherItemsGridView.Columns.Contains("WarehouseName"))
                IssueVoucherItemsGridView.Columns["WarehouseName"].Visible = false;

            if (IssueVoucherItemsGridView.Columns.Contains("WarehouseId"))
                IssueVoucherItemsGridView.Columns["WarehouseId"].Visible = false;

            if (IssueVoucherItemsGridView.Columns.Contains("SupplierId"))
                IssueVoucherItemsGridView.Columns["SupplierId"].Visible = false;
            #endregion

            #region Rename Columns
            // Rename
            if (IssueVoucherItemsGridView.Columns.Contains("ItemName"))
                IssueVoucherItemsGridView.Columns["ItemName"].HeaderText = "Item";

            if (IssueVoucherItemsGridView.Columns.Contains("SupplierName"))
                IssueVoucherItemsGridView.Columns["SupplierName"].HeaderText = "Supplier";

            if (IssueVoucherItemsGridView.Columns.Contains("ItemQuantity"))
                IssueVoucherItemsGridView.Columns["ItemQuantity"].HeaderText = "In Stock";

            if (IssueVoucherItemsGridView.Columns.Contains("ProductionDate"))
                IssueVoucherItemsGridView.Columns["ProductionDate"].HeaderText = "Prod Date";

            if (IssueVoucherItemsGridView.Columns.Contains("ExpiryDate"))
                IssueVoucherItemsGridView.Columns["ExpiryDate"].HeaderText = "Exp Date";
            #endregion
        }
        private void IssueVoucherItemsGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < IssueVoucherItemsGridView.Rows.Count)
            {
                var selectedRow = IssueVoucherItemsGridView.Rows[e.RowIndex];

                // Get the bound item from the DataGridView
                var selectedItem = (AvailableItemsAtWarehouseDTO)IssueVoucherItemsGridView.Rows[e.RowIndex].DataBoundItem;

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
                IssueSelectedItemsGridView.DataSource = null;
                IssueSelectedItemsGridView.DataSource = SelectedItemsList;

                EditIssueSelectedItemsGridViewColumns();

                selectedRow.DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }
        private async void IssueVoucherRemoveFromWarehouseButton_Click(object sender, EventArgs e)
        {
            if (IsValidIssue())
            {
                // Create confirmation message
                string message = $"Confirm Issue From Warehouse\n\n" +
                               $"Warehouse: {IssueVoucherWarehouseComboBox.Text}\n" +
                               $"Issue Date: {IssueVoucherIssueDate.Text}\n" +
                               $"Issue Customer: {IssueVoucherCustomerComboBox.Text}\n" +
                               $"Issue Items:\n{string.Join("\n", SelectedItemsList)}";

                var result = MessageBox.Show(message, "Confirm Issue",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using var context = new WarehouseDbContext();
                    var transaction = await context.Database.BeginTransactionAsync();
                    try
                    {
                        await AddToIssueVoucherAndDetailsTable();
                        await UpdateQuantites();
                        await transaction.CommitAsync();
                        MessageBox.Show("Voucher created successfully!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        await transaction.RollbackAsync();
                        MessageBox.Show("Voucher Failed!", "Fail",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    ResetIssueForm();
                }
            }

        }
        #endregion

        #region Selected Items Grid view Methods and events
        private void EditIssueSelectedItemsGridViewColumns()
        {
            #region Hide
            if (IssueSelectedItemsGridView.Columns.Contains("ItemCode"))
                IssueSelectedItemsGridView.Columns["ItemCode"].Visible = false;

            if (IssueSelectedItemsGridView.Columns.Contains("WarehouseName"))
                IssueSelectedItemsGridView.Columns["WarehouseName"].Visible = false;

            if (IssueSelectedItemsGridView.Columns.Contains("WarehouseId"))
                IssueSelectedItemsGridView.Columns["WarehouseId"].Visible = false;

            if (IssueSelectedItemsGridView.Columns.Contains("SupplierId"))
                IssueSelectedItemsGridView.Columns["SupplierId"].Visible = false;
            #endregion

            #region Rename Columns
            // Rename
            if (IssueSelectedItemsGridView.Columns.Contains("ItemName"))
                IssueSelectedItemsGridView.Columns["ItemName"].HeaderText = "Item";

            if (IssueSelectedItemsGridView.Columns.Contains("SupplierName"))
                IssueSelectedItemsGridView.Columns["SupplierName"].HeaderText = "Supplier";

            if (IssueSelectedItemsGridView.Columns.Contains("ItemQuantity"))
                IssueSelectedItemsGridView.Columns["ItemQuantity"].HeaderText = "Checkout Quantity";

            if (IssueSelectedItemsGridView.Columns.Contains("ProductionDate"))
                IssueSelectedItemsGridView.Columns["ProductionDate"].HeaderText = "Prod Date";

            if (IssueSelectedItemsGridView.Columns.Contains("ExpiryDate"))
                IssueSelectedItemsGridView.Columns["ExpiryDate"].HeaderText = "Exp Date";
            #endregion
        }
        private void IssueSelectedItemsGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < IssueSelectedItemsGridView.Rows.Count)
            {
                var grid = IssueSelectedItemsGridView;
                DataGridViewRow editedRow = grid.Rows[e.RowIndex];

                string itemCode = editedRow.Cells["ItemCode"].Value?.ToString();
                DateOnly? productionDate = editedRow.Cells["ProductionDate"].Value as DateOnly?;
                DateOnly? expiryDate = editedRow.Cells["ExpiryDate"].Value as DateOnly?;
                string editedValue = editedRow.Cells["ItemQuantity"].Value?.ToString();

                if (string.IsNullOrEmpty(itemCode) || !productionDate.HasValue || !expiryDate.HasValue)
                    return;

                if (decimal.TryParse(editedValue, out decimal newQuantity))
                {
                    decimal availableQuantity = 0;

                    foreach (DataGridViewRow originalRow in IssueVoucherItemsGridView.Rows)
                    {
                        if (originalRow.DataBoundItem is AvailableItemsAtWarehouseDTO originalItem &&
                            originalItem.ItemCode == itemCode &&
                            originalItem.ProductionDate == productionDate &&
                            originalItem.ExpiryDate == expiryDate)
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

        
        private void IssueSelectedItemsGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (IssueSelectedItemsGridView.Columns[e.ColumnIndex].Name != "ItemQuantity")
            {
                e.Cancel = true; // Prevent editing in all columns except "ItemQuantity"
            }
        }
        private void IssueSelectedItemsGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (IssueSelectedItemsGridView.CurrentRow != null)
                {
                    int rowIndex = IssueSelectedItemsGridView.CurrentRow.Index;

                    if (rowIndex >= 0 && rowIndex < SelectedItemsList.Count)
                    {
                        var itemToRemove = (AvailableItemsAtWarehouseDTO)IssueSelectedItemsGridView.Rows[rowIndex].DataBoundItem;

                        var confirmResult = MessageBox.Show("Are you sure to delete this item?",
                                                             "Confirm Delete",
                                                             MessageBoxButtons.YesNo,
                                                             MessageBoxIcon.Question);

                        if (confirmResult == DialogResult.Yes)
                        {
                            SelectedItemsList.Remove(itemToRemove);

                            // Reset row color in the main grid
                            foreach (DataGridViewRow row in IssueVoucherItemsGridView.Rows)
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
                            IssueSelectedItemsGridView.DataSource = null;
                            IssueSelectedItemsGridView.DataSource = SelectedItemsList;
                            EditIssueSelectedItemsGridViewColumns();
                        }
                    }
                }
            }
        }
        private void IssueDeleteSelectedItemButton_Click(object sender, EventArgs e)
        {
            if (IssueSelectedItemsGridView.CurrentRow != null)
            {
                int rowIndex = IssueSelectedItemsGridView.CurrentRow.Index;

                if (rowIndex >= 0 && rowIndex < SelectedItemsList.Count)
                {
                    var itemToRemove = (AvailableItemsAtWarehouseDTO)IssueSelectedItemsGridView.Rows[rowIndex].DataBoundItem;

                    var confirmResult = MessageBox.Show("Are you sure you want to remove this item?",
                                                         "Confirm Removal",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        SelectedItemsList.Remove(itemToRemove);

                        // Reset the color in the original grid
                        foreach (DataGridViewRow row in IssueVoucherItemsGridView.Rows)
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
                        IssueSelectedItemsGridView.DataSource = null;
                        IssueSelectedItemsGridView.DataSource = SelectedItemsList;
                        EditIssueSelectedItemsGridViewColumns();
                    }
                }
            }
        }
        #endregion

        #region Warehouse ComboBox event handler
        private async void IssueVoucherWarehouseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isFormLoading) return;
            if (IssueVoucherWarehouseComboBox.SelectedValue == null) return;
            warehouseId = (int)IssueVoucherWarehouseComboBox.SelectedValue;

            // Clear previously selected items
            SelectedItemsList.Clear();
            ResetSelectedItemsGridView();
            await LoadInventoryItemsToIssueVoucherItemsGridView(warehouseId);
        }
        #endregion

        #region Reset Methods
        private void ResetIssueForm()
        {
            SelectedItemsList.Clear();
            AvailableItemsAtWarehouseList.Clear();
            IssueVoucherWarehouseComboBox.SelectedIndex = -1;
            IssueVoucherCustomerComboBox.SelectedIndex = -1;
            IssueVoucherIssueDate.Text = "";

            IssueSelectedItemsGridView.DataSource = null;
            IssueSelectedItemsGridView.Refresh();

            IssueVoucherItemsGridView.DataSource = null;
            IssueVoucherItemsGridView.Refresh();
        }
        private void ResetSelectedItemsGridView()
        {
            IssueSelectedItemsGridView.DataSource = null;
            IssueSelectedItemsGridView.Refresh();

            // Make all columns read-only except "ItemQuantity"
            foreach (DataGridViewColumn column in IssueSelectedItemsGridView.Columns)
            {
                column.ReadOnly = column.Name != "ItemQuantity";
            }

            if (IssueSelectedItemsGridView.Columns.Contains("ItemCode"))
                IssueSelectedItemsGridView.Columns["ItemCode"].Visible = false;

            if (IssueSelectedItemsGridView.Columns.Contains("WarehouseName"))
                IssueSelectedItemsGridView.Columns["WarehouseName"].Visible = false;

            if (IssueSelectedItemsGridView.Columns.Contains("WarehouseId"))
                IssueSelectedItemsGridView.Columns["WarehouseId"].Visible = false;

            if (IssueSelectedItemsGridView.Columns.Contains("SupplierId"))
                IssueSelectedItemsGridView.Columns["SupplierId"].Visible = false;

            if (IssueSelectedItemsGridView.Columns.Contains("ProductionDate"))
                IssueSelectedItemsGridView.Columns["ProductionDate"].Visible = false;

            if (IssueSelectedItemsGridView.Columns.Contains("ExpiryDate"))
                IssueSelectedItemsGridView.Columns["ExpiryDate"].Visible = false;

        }
        #endregion

        #region DataBase Operations methods
        private async Task UpdateQuantites()
        {
            foreach (var selectedItem in SelectedItemsList)
            {
                // Find the existing tracked entity
                using var context = new WarehouseDbContext();
                var _inventoryItemRepository = new InventoryItemRepository(context);
                var existingItem = await context.InventoryItems
                    .FirstOrDefaultAsync(i =>
                        i.WarehouseId == selectedItem.WarehouseId &&
                        i.ItemCode == selectedItem.ItemCode &&
                        i.ProductionDate == selectedItem.ProductionDate &&
                        i.ExpiryDate == selectedItem.ExpiryDate);

                if (existingItem != null)
                {
                    // Update the existing entity
                    existingItem.Quantity -= selectedItem.ItemQuantity;
                    await _inventoryItemRepository.UpdateAsync(existingItem);
                }
            }
        }
        private async Task AddToIssueVoucherAndDetailsTable()
        {
            using var context = new WarehouseDbContext();
            var _issueVoucherRepository = new IssueVoucherRepository(context);
            var _issueVoucherDetailsRepository = new IssueVoucherDetailRepository(context);
            var issueVoucher = new IssueVoucher
            {
                Date = DateOnly.FromDateTime(IssueVoucherIssueDate.Value),
                CustomerId = (int)IssueVoucherCustomerComboBox.SelectedValue,
                WarehouseId = (int)IssueVoucherWarehouseComboBox.SelectedValue
            };
            await _issueVoucherRepository.AddAsync(issueVoucher);

            foreach (var item in SelectedItemsList)
            {
                var detail = new IssueVoucherDetail
                {
                    VoucherId = issueVoucher.Id,
                    ItemCode = item.ItemCode,
                    Quantity = item.ItemQuantity,
                    ProductionDate = item.ProductionDate,
                    ExpiryDate = item.ExpiryDate,
                };

                await _issueVoucherDetailsRepository.AddAsync(detail);
            }
        }
        #endregion

        #region Validation Methods
        private bool IsValidIssue()
        {
            if (SelectedItemsList.Count == 0)
            {
                MessageBox.Show("Must Choose at least one item", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(IssueVoucherIssueDate.Text))
            {
                MessageBox.Show("Must Specify the Issue Voucher date", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (IssueVoucherCustomerComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("The Customer must be chosen first", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        #endregion

        #endregion

    }
}

