using WarehouseManagementSystem.Data.Context;
using WarehouseManagementSystem.Data.Repositories;
using WarehouseManagementSystem.Domain.Enums;
using WarehouseManagementSystem.Domain.Models;

namespace WarehouseManagmentSystem.WinForms
{
    public partial class ItemForm : Form
    {
        #region Fields
        private List<MeasurementUnit> SelectedUnits;
        #endregion

        #region Constructors
        public ItemForm()
        {
            SelectedUnits = new List<MeasurementUnit>();
            InitializeComponent();
            ApplyAnchorsAndDocking();

        }
        #endregion

        #region Methods

        #region UI 
        private void ApplyAnchorsAndDocking()
        {
            // TextBoxes should stretch horizontally
            ItemNameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ItemCodeTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ItemMeasuringUnitsCheckList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // Label should stretch horizontally
            ItemNameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ItemCodeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ItemMeasuringUnitsLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // Button should stay at the bottom right
            AddItemButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            // DataGridView should expand to fill the bottom area
            ItemsDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }
        #endregion

        #region Load and Reset Data
        private async void LoadItemsToGridView()
        {
            using var context = new WarehouseDbContext();
            var itemRepository = new ItemRepository(context);
            var items = await itemRepository.GetAllAsync();
            var itemsDTO = items.Select(i => new
            {
                i.Code,
                i.Name,
                MeasurementUnits = string.Join(", ", i.MeasurementUnits),
            }).ToList();
            ItemsDataGridView.DataSource = itemsDTO;
            ItemsDataGridView.Columns["MeasurementUnits"].HeaderText = "Measuring Units";
        }
        private void LoadMeasuringUnitsToCheckBox()
        {
            ItemMeasuringUnitsCheckList.DataSource = Enum.GetValues(typeof(MeasurementUnit));
        }
        private void ItemForm_Load(object sender, EventArgs e)
        {
            LoadItemsToGridView();
            LoadMeasuringUnitsToCheckBox();
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
        #endregion

        #region Button CheckBoxList Event Handlers
        private async void AddItemButton_Click(object sender, EventArgs e)
        {
            if (IsValidForm())
            {
                // Create confirmation message
                string message = $"Confirm changes for item {ItemNameTextBox.Text}\n\n" +
                               $"Code: {ItemCodeTextBox.Text}\n" +
                               $"Units: {string.Join(", ", SelectedUnits)}";

                var result = MessageBox.Show(message, "Confirm Adding",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
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
                        MessageBox.Show($"Item added successfully!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error adding Item: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }

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

        #region Validations
        private bool IsValidForm()
        {
            if (string.IsNullOrWhiteSpace(ItemCodeTextBox.Text))
            {
                MessageBox.Show("Item Code is required", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(ItemNameTextBox.Text))
            {
                MessageBox.Show("Item name is required", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (SelectedUnits.Count == 0)
            {
                MessageBox.Show("At least one item unit must be selected", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        #endregion
        #endregion

    }
}
