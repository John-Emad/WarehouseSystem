
using System.Data;
using WarehouseManagementSystem.Data.Context;
using WarehouseManagementSystem.Data.Repositories;
using WarehouseManagementSystem.Domain.Enums;
using WarehouseManagementSystem.Domain.Models;

namespace WarehouseManagmentSystem.WinForms.ItemsForms
{
    public partial class EditItemForm : Form
    {
        private List<MeasurementUnit> SelectedUnits;
        private Item SelectedItem = new Item();

        #region Constructors
        public EditItemForm()
        {
            SelectedUnits = new List<MeasurementUnit>();
            InitializeComponent();
            UnenableControlsTillSelecting();
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
            EditItemButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            // DataGridView should expand to fill the bottom area
            ItemsDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }
        #endregion

        #region UI Controls
        private void UnenableControlsTillSelecting()
        {
            ItemMeasuringUnitsCheckList.Enabled = false;
            ItemNameTextBox.Enabled = false;
            ItemCodeTextBox.Enabled = false;
            ItemCodeTextBox.ReadOnly = true;
        }
        private void EnableControlsWhenSelecting()
        {
            ItemMeasuringUnitsCheckList.Enabled = true;
            ItemCodeTextBox.Enabled = true;
            ItemNameTextBox.Enabled = true;
        }
        #endregion

        #region Load and reset Data
        private async void LoadItemsToGridView()
        {
            using var context = new WarehouseDbContext();
            var itemRepository = new ItemRepository(context);
            var items = await itemRepository.GetAllAsync();
            ItemsDataGridView.DataSource = items.Select(i => new
            {
                i.Code,
                i.Name,
                MeasurementUnits = string.Join(", ", i.MeasurementUnits),
            }).ToList();
            ItemsDataGridView.Columns["MeasurementUnits"].HeaderText = "Measuring Units";
        }
        private void LoadMeasuringUnitsToCheckBox()
        {
            ItemMeasuringUnitsCheckList.DataSource = Enum.GetValues(typeof(MeasurementUnit));
        }
        private void EditItemForm_Load(object sender, EventArgs e)
        {
            LoadItemsToGridView();
            LoadMeasuringUnitsToCheckBox();
        }
        private async void LoadItemData(string itemCode)
        {
            using var context = new WarehouseDbContext();
            var itemRepository = new ItemRepository(context);
            SelectedItem = await itemRepository.GetByPKAsync(itemCode);

            if (SelectedItem != null)
            {
                ItemCodeTextBox.Text = SelectedItem.Code;
                ItemNameTextBox.Text = SelectedItem.Name;

                SelectedUnits.Clear();

                // Set checked measurement units
                for (int i = 0; i < ItemMeasuringUnitsCheckList.Items.Count; i++)
                {
                    var unit = (MeasurementUnit)ItemMeasuringUnitsCheckList.Items[i];
                    bool isChecked = SelectedItem.MeasurementUnits.Contains(unit);
                    ItemMeasuringUnitsCheckList.SetItemChecked(i, isChecked);

                    if (isChecked)
                    {
                        SelectedUnits.Add(unit);
                    }
                }

                EnableControlsWhenSelecting();
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
            SelectedItem = null;
            UnenableControlsTillSelecting();
        }
        #endregion

        #region Item Grid view event handlers
        private void ItemsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = ItemsDataGridView.Rows[e.RowIndex];
                string itemCode = selectedRow.Cells["Code"].Value.ToString();
                LoadItemData(itemCode);
            }
        }
        #endregion

        #region Button CheckList event handlers
        private async void EditItemButton_Click(object sender, EventArgs e)
        {
            if (SelectedItem == null)
            {
                MessageBox.Show("Please select an item to edit first.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (IsValidForm())
            {
                // Create confirmation message
                string message = $"Confirm changes for item {SelectedItem.Code}:\n\n" +
                               $"Name: {SelectedItem.Name} → {ItemNameTextBox.Text}\n" +
                               $"Units: {string.Join(", ", SelectedItem.MeasurementUnits)} → " +
                               $"{string.Join(", ", SelectedUnits)}";

                var result = MessageBox.Show(message, "Confirm Changes",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Update the item
                        SelectedItem.Name = ItemNameTextBox.Text;
                        SelectedItem.MeasurementUnits = new List<MeasurementUnit>(SelectedUnits);

                        using var context = new WarehouseDbContext();
                        var itemRepository = new ItemRepository(context);
                        await itemRepository.UpdateAsync(SelectedItem);
                        LoadItemsToGridView();

                        MessageBox.Show("Item updated successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ResetEnteredData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating item: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ItemMeasuringUnitsCheckList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                SelectedUnits.Clear();

                foreach (var checkedItem in ItemMeasuringUnitsCheckList.CheckedItems)
                {
                    SelectedUnits.Add((MeasurementUnit)checkedItem);
                }

                // Include the just-checked or unchecked item
                var currentItem = (MeasurementUnit)ItemMeasuringUnitsCheckList.Items[e.Index];
                if (e.NewValue == CheckState.Checked && !SelectedUnits.Contains(currentItem))
                {
                    SelectedUnits.Add(currentItem);
                }
                else if (e.NewValue == CheckState.Unchecked && SelectedUnits.Contains(currentItem))
                {
                    SelectedUnits.Remove(currentItem);
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
