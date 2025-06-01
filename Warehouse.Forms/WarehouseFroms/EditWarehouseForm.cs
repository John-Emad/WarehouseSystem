using System.Data;
using WarehouseManagementSystem.Data.Context;
using WarehouseManagementSystem.Data.Repositories;
using WarehouseManagementSystem.Domain.Models;

namespace WarehouseManagmentSystem.WinForms.WarehouseFroms
{
    public partial class EditWarehouseForm : Form
    {
        #region Fields
        private Warehouse selectedWarehouse = new Warehouse();
        #endregion

        #region Constructors
        public EditWarehouseForm()
        {
            InitializeComponent();
            HideUI();
            UnenableControlsTillSelecting();


            WarehouseManagerComboBox.SelectedIndex = -1;
        }
        #endregion

        #region Methods

        #region UI Controls
        private void HideUI()
        {
            AssignManagerLabel.Visible = false;
            WarehouseManagerComboBox.Visible = false;
        }
        private void UnenableControlsTillSelecting()
        {
            WarehouseNameTextBox.Enabled = false;
            WarehouseAddressTextBox.Enabled = false;
            WarehouseManagerComboBox.Enabled = false;
            btnEditWarehouse.Enabled = false;
            AssignManagerCheckBox.Enabled = false;
        }
        private void EnableControlsWhenSelecting()
        {
            WarehouseNameTextBox.Enabled = true;
            WarehouseAddressTextBox.Enabled = true;
            WarehouseManagerComboBox.Enabled = true;
            btnEditWarehouse.Enabled = true;
            AssignManagerCheckBox.Enabled = true;
        }
        #endregion

        #region Load and Reset Data
        private async Task LoadDataAsync()
        {
            await LoadWarehousesToGridViewAsync();
            await LoadPersonsToComboBox();
        }
        private async Task LoadWarehousesToGridViewAsync()
        {
            using (var context = new WarehouseDbContext())
            {
                var warehouseRepository = new WarehouseRepository(context);
                var warehouses = await warehouseRepository.GetAllAsyncWithManagerName();
                warehouseDataGridView.DataSource = warehouses.Select(w => new
                {
                    w.Id, // Make sure to include Id for selection
                    w.Name,
                    w.Address,
                    ResponsiblePerson = w.ResponsiblePerson?.Name ?? "N/A",
                }).ToList();
                // Hide the Id column if you don't want it visible
                warehouseDataGridView.Columns["Id"].Visible = false;
            }
        }
        private async Task LoadPersonsToComboBox()
        {
            var context = new WarehouseDbContext();
            var personRepository = new PersonRepository(context);
            List<Person> people = new List<Person>();
            people = await personRepository.GetAllAsync();
            WarehouseManagerComboBox.DisplayMember = "Name";
            WarehouseManagerComboBox.ValueMember = "Id";
            WarehouseManagerComboBox.DataSource = people;
        }
        private async void LoadWarehouseData(int warehouseId)
        {
            using var context = new WarehouseDbContext();
            var warehouseRepository = new WarehouseRepository(context);
            selectedWarehouse = await warehouseRepository.GetByPKAsyncWithManagerName(warehouseId);

            if (selectedWarehouse != null)
            {
                WarehouseNameTextBox.Text = selectedWarehouse.Name;
                WarehouseAddressTextBox.Text = selectedWarehouse.Address;

                // Handle manager assignment
                if (selectedWarehouse.ResponsiblePersonId.HasValue)
                {
                    AssignManagerCheckBox.Checked = true;
                    WarehouseManagerComboBox.SelectedValue = selectedWarehouse.ResponsiblePersonId.Value;
                }
                else
                {
                    AssignManagerCheckBox.Checked = false;
                    WarehouseManagerComboBox.SelectedIndex = -1;
                }
            }
        }
        private void ResetEnteredData()
        {
            WarehouseNameTextBox.Clear();
            WarehouseAddressTextBox.Clear();
            WarehouseManagerComboBox.SelectedIndex = -1;
        }
        #endregion

        #region Grid view event handlers
        private void warehouseDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = warehouseDataGridView.Rows[e.RowIndex];
                int warehouseId = (int)selectedRow.Cells["Id"].Value;

                LoadWarehouseData(warehouseId);
                EnableControlsWhenSelecting();
            }
        }
        #endregion

        #region Button and check box event handlers
        private async void btnEditWarehouse_Click(object sender, EventArgs e)
        {
            if (selectedWarehouse == null)
            {
                MessageBox.Show("Please select a warehouse to edit first.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (IsValidForm())
            {
                string message = $"Confirm changes:\n\n" +
                $"Name: {selectedWarehouse.Name} → {WarehouseNameTextBox.Text}\n" +
                $"Address: {selectedWarehouse.Address} → {WarehouseAddressTextBox.Text}\n" +
                $"Manager: {(selectedWarehouse.ResponsiblePerson?.Name ?? "None")} → " +
                $"{(AssignManagerCheckBox.Checked ? WarehouseManagerComboBox.Text : "None")}";

                var result = MessageBox.Show(message, "Confirm Changes",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Update the warehouse
                        selectedWarehouse.Name = WarehouseNameTextBox.Text;
                        selectedWarehouse.Address = WarehouseAddressTextBox.Text;
                        selectedWarehouse.ResponsiblePersonId = AssignManagerCheckBox.Checked
                            ? (int?)WarehouseManagerComboBox.SelectedValue
                            : null;

                        using var context = new WarehouseDbContext();
                        var warehouseRepository = new WarehouseRepository(context);
                        await warehouseRepository.UpdateAsync(selectedWarehouse);
                        await LoadWarehousesToGridViewAsync();

                        MessageBox.Show("Warehouse updated successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating warehouse: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                ResetEnteredData();
                UnenableControlsTillSelecting();
            }
        }


        private void AssignManagerCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            if (AssignManagerCheckBox.Checked)
            {
                AssignManagerLabel.Visible = true;
                WarehouseManagerComboBox.Visible = true;
            }
            else
            {
                AssignManagerLabel.Visible = false;
                WarehouseManagerComboBox.Visible = false;
                WarehouseManagerComboBox.SelectedIndex = -1;
            }
        }
        #endregion

        #region Validation
        private bool IsValidForm()
        {
            if (string.IsNullOrWhiteSpace(WarehouseNameTextBox.Text))
            {
                MessageBox.Show("Warehouse name is required", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(WarehouseAddressTextBox.Text))
            {
                MessageBox.Show("Warehouse Address is required", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (AssignManagerCheckBox.Checked && WarehouseManagerComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Must assign a warehouse manager", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        #endregion


        private async void EditWarehouseForm_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }


        #endregion
    }
}
