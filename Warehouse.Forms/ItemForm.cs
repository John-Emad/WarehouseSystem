using WarehouseManagementSystem.Data.Context;
using WarehouseManagementSystem.Data.Repositories;
using WarehouseManagementSystem.Domain.Enums;
using WarehouseManagementSystem.Domain.Models;

namespace WarehouseManagmentSystem.WinForms
{
    public partial class ItemForm : Form
    {
        private List<MeasurementUnit> SelectedUnits;

        #region Constructors
        public ItemForm()
        {
            SelectedUnits = new List<MeasurementUnit>();
            InitializeComponent();
            LoadItemsToGridView();
            LoadMeasuringUnitsToCheckBox();
        }
        #endregion

        #region Methods
        private async void LoadItemsToGridView()
        {
            using (var context = new WarehouseDbContext())
            {
                var itemRepository = new ItemRepository(context);
                var items = await itemRepository.GetAllAsync();
                var itemsDTO = items.Select(i => new
                {
                    i.Code,
                    i.Name,
                    MeasurementUnits = string.Join(", ", i.MeasurementUnits),
                }).ToList();
                ItemsDataGridView.DataSource = itemsDTO; 
            }
        }
        private void LoadMeasuringUnitsToCheckBox()
        {
            ItemMeasuringUnitsCheckList.DataSource = Enum.GetValues(typeof(MeasurementUnit));
        }
        private async void AddItemButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ItemCodeTextBox.Text))
            {
                MessageBox.Show("Item Code is required", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(ItemNameTextBox.Text))
            {
                MessageBox.Show("Item name is required", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (SelectedUnits.Count == 0)
            {
                MessageBox.Show("At least one item unit must be selected", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var Item = new Item
                {
                    Name = ItemNameTextBox.Text,
                    Code = ItemCodeTextBox.Text,
                    MeasurementUnits = new List<MeasurementUnit>(SelectedUnits)
                };

                using (var context = new WarehouseDbContext())
                {
                    var itemRepository = new ItemRepository(context);
                    await itemRepository.AddAsync(Item); 
                }
                LoadItemsToGridView();
                ResetEnteredData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding Item: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ResetEnteredData()
        {
            ItemCodeTextBox.Clear();
            ItemNameTextBox.Clear();
            for (int i = 0; i < ItemMeasuringUnitsCheckList.Items.Count; i++)
            {
                ItemMeasuringUnitsCheckList.SetItemChecked(i, false);
            }
            SelectedUnits.Clear();
        }
        private void ItemMeasuringUnitsCheckList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)(() =>
            {
                MeasurementUnit unit = (MeasurementUnit)ItemMeasuringUnitsCheckList.Items[e.Index];

                if (e.NewValue == CheckState.Checked)
                {
                    if (!SelectedUnits.Contains(unit))
                        SelectedUnits.Add(unit);
                }
                else
                {
                    SelectedUnits.Remove(unit);
                }
            }));
        }
        #endregion
    }
}
