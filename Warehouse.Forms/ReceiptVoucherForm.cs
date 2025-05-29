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
        private readonly WarehouseDbContext _context;
        private readonly ReceiptVoucherRepository _receiptVoucherRepository;
        private readonly ReceiptVoucherDetailsRepository _receiptVoucherDetailsRepository;
        private readonly InventoryItemRepository _inventoryItemRepository;
        private readonly WarehouseRepository _warehouseRepository;
        private readonly ItemRepository _itemRepository;
        private readonly PersonRepository _personRepository;
        private List<InventoryItemViewDTO> InventoryItemViewDTOList;
        #endregion

        #region Constructors
        public ReceiptVoucherForm(WarehouseDbContext dbContext)
        {
            _context = dbContext;
            _receiptVoucherRepository = new ReceiptVoucherRepository(_context);
            _receiptVoucherDetailsRepository = new ReceiptVoucherDetailsRepository(_context);
            _inventoryItemRepository = new InventoryItemRepository(_context);
            _warehouseRepository = new WarehouseRepository(_context);
            _itemRepository = new ItemRepository(_context);
            _personRepository = new PersonRepository(_context);
            InventoryItemViewDTOList = new List<InventoryItemViewDTO>();
            InitializeComponent();
            LoadData();
            ResetEnteredItemData();
            ResetEnteredReceiptData();
        }
        #endregion

        #region Methods
        private async Task LoadData()
        {
            await LoadWareHousesToComboBox();
            await LoadSuppliersToComboBox();
            await LoadItemsToComboBox();
        }
        private async Task LoadWareHousesToComboBox()
        {
            List<Warehouse> warehouses = new List<Warehouse>();
            warehouses = await _warehouseRepository.GetAllAsync();
            ReceiptVoucherWarehouseComboBox.DisplayMember = "Name";
            ReceiptVoucherWarehouseComboBox.ValueMember = "Id";
            ReceiptVoucherWarehouseComboBox.DataSource = warehouses;
        }
        private async Task LoadSuppliersToComboBox()
        {
            List<Supplier> suppliers = new List<Supplier>();
            suppliers = await _personRepository.GetSuppliersAsync();
            ReceiptVoucherSupplierComboBox.DisplayMember = "Name";
            ReceiptVoucherSupplierComboBox.ValueMember = "Id";
            ReceiptVoucherSupplierComboBox.DataSource = suppliers;
        }
        private async Task LoadItemsToComboBox()
        {
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
                i.Name,
                i.Quantity,
                i.ProductionDate,
                i.ExpiryDate,
            }).ToList();
            ReceiptVoucherItemsGridView.DataSource = viewList;
        }
        private void ResetEnteredItemData()
        {
            ReceiptVoucherProductionDate.Value = DateTime.Now;
            ReceiptVoucherExpiryDate.Value = DateTime.Now;
            ReceiptVoucherItemsComboBox.SelectedIndex = -1;
            ReceiptVoucherQuantityTextBox.Clear();
        }
        private void ResetEnteredReceiptData()
        {
            ReceiptVoucherSupplierComboBox.SelectedIndex = -1;
            ReceiptVoucherWarehouseComboBox.SelectedItem = -1;
            ReceiptVoucherReceiptDate.Value = DateTime.Now;
            UserChosenSupplierViewLabel.Text = "N/A";
            UserChosenWarehouseViewLabel.Text = "N/A";
            UserChosenViewReceiptDateLabel.Text = "N/A";
            InventoryItemViewDTOList.Clear();
            UpdateItemsGridView();
        }
        private async void ReceiptVoucherAddToWarehouseButton_ClickAsync(object sender, EventArgs e)
        {
            if (!IsValidReceipt())
                return;
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
            ResetEnteredReceiptData();

        }
        private async Task AddToReceiptVoucherAndDetailsTables()
        {
            var receiptVoucher = new ReceiptVoucher
            {
                Date = DateOnly.FromDateTime(ReceiptVoucherReceiptDate.Value),
                SupplierId = (int)ReceiptVoucherSupplierComboBox.SelectedValue,
                WarehouseId = (int)ReceiptVoucherWarehouseComboBox.SelectedValue
            };
            await _receiptVoucherRepository.AddAsync(receiptVoucher);

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
        }
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
        private void ReceiptVoucherAddItemButton_Click(object sender, EventArgs e)
        {
            if (!IsValidItemInput())
                return;
            InventoryItemViewDTO inventoryItemViewDTO = new InventoryItemViewDTO();
            inventoryItemViewDTO.ItemCode = (string)ReceiptVoucherItemsComboBox.SelectedValue;
            inventoryItemViewDTO.Name = ReceiptVoucherItemsComboBox.Text;
            inventoryItemViewDTO.Quantity = int.Parse(ReceiptVoucherQuantityTextBox.Text);
            inventoryItemViewDTO.ProductionDate = ReceiptVoucherProductionDate.Value;
            inventoryItemViewDTO.ExpiryDate = ReceiptVoucherExpiryDate.Value;
            InventoryItemViewDTOList.Add(inventoryItemViewDTO);
            UpdateItemsGridView();
            ResetEnteredItemData();
        }
        private void ReceiptVoucherWarehouseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserChosenWarehouseViewLabel.Text = ReceiptVoucherWarehouseComboBox.Text;
        }
        private void ReceiptVoucherSupplierComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserChosenSupplierViewLabel.Text = ReceiptVoucherSupplierComboBox.Text;
        }

        private void ReceiptVoucherReceiptDate_ValueChanged(object sender, EventArgs e)
        {
            UserChosenViewReceiptDateLabel.Text = ReceiptVoucherReceiptDate.Text;
        }
        #endregion
    }
}
