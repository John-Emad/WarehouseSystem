using WarehouseManagementSystem.Data.Context;
using WarehouseManagementSystem.Data.Repositories;
using WarehouseManagementSystem.Domain.Models;

namespace WarehouseManagmentSystem.WinForms
{

    public partial class InventoryItemForm : Form
    {
        #region Fields
        private readonly WarehouseDbContext _context;
        private readonly InventoryItemRepository _inventoryItemRepository;
        private readonly WarehouseRepository _warehouseRepository;
        private readonly ItemRepository _itemRepository;
        #endregion

        #region Constructors
        public InventoryItemForm(WarehouseDbContext context)
        {
            _context = context;
            _inventoryItemRepository = new InventoryItemRepository(_context);
            _warehouseRepository = new WarehouseRepository(_context);
            _itemRepository = new ItemRepository(_context);
            InitializeComponent();
            LoadInventoryItemsToGridViewAsync();
            LoadWareHousesToComboBox();
            LoadItemToComboBox();
        }
        #endregion

        #region Methods
        private async void LoadInventoryItemsToGridViewAsync()
        {
            var inventoryItems = await _inventoryItemRepository.GetAllAsync();
            InventoryItemDataGridView.DataSource = inventoryItems;
        }
        private async void LoadWareHousesToComboBox()
        {
            List<Warehouse> warehouses = new List<Warehouse>();
            warehouses = await _warehouseRepository.GetAllAsyncWithManagerName();
            InventoryItemWarehouseComboBox.DisplayMember = "Name";
            InventoryItemWarehouseComboBox.ValueMember = "Id";
            InventoryItemWarehouseComboBox.DataSource = warehouses;
        }
        private async void LoadItemToComboBox()
        {
            List<Item> items = new List<Item>();
            items = await _itemRepository.GetAllAsync();
            InventoryItemNameComboBox.DisplayMember = "Name";
            InventoryItemNameComboBox.ValueMember = "Code";
            InventoryItemNameComboBox.DataSource = items;
        }
        private void InventoryItemAddButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(InventoryItemQuantityTextBox.Text))
            {
                MessageBox.Show("Must Specify the Quantity to be Added", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (string.IsNullOrWhiteSpace(InventoryItemProductionDatePicker.Text))
            {
                MessageBox.Show("Must Specify the Production date of the product", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(InventoryItemExpiryDatePicker.Text))
            {
                MessageBox.Show("Must Specify the Expiry date of the product", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime productionDate = InventoryItemProductionDatePicker.Value.Date;
            DateTime expiryDate = InventoryItemExpiryDatePicker.Value.Date;
            if (productionDate >= expiryDate)
            {
                MessageBox.Show("Expiry Date must be after Production Date.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var inventoryItem = new WarehouseManagementSystem.Domain.Models.InventoryItem
                {
                    Quantity = decimal.Parse(InventoryItemQuantityTextBox.Text),
                    ProductionDate = productionDate,
                    ExpiryDate = expiryDate,
                    WarehouseId = (int)InventoryItemWarehouseComboBox.SelectedValue,
                    ItemCode = (string)InventoryItemNameComboBox.SelectedValue,
                };
                _inventoryItemRepository.AddAsync(inventoryItem);

                LoadInventoryItemsToGridViewAsync();
                ResetEnteredData();
            }
            catch (FormatException)
            {
                MessageBox.Show("Quantity must be a valid number.", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding Inventory Item: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetEnteredData()
        {
            InventoryItemQuantityTextBox.Clear();
            InventoryItemProductionDatePicker.Value = DateTime.Today;
            InventoryItemExpiryDatePicker.Value = DateTime.Today;
            InventoryItemWarehouseComboBox.SelectedIndex = -1;
            InventoryItemNameComboBox.SelectedIndex = -1;
        }
        #endregion

    }
}
