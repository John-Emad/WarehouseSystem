using WarehouseManagementSystem.Data.Context;
using WarehouseManagementSystem.Data.Repositories;
using WarehouseManagementSystem.Domain.Models;

namespace WarehouseManagmentSystem.WinForms.Forms
{
    public partial class WarehouseForm : Form
    {
        #region Fields
        #endregion

        #region Constructors
        public WarehouseForm()
        {
            InitializeComponent();
            HideUI();
            ApplyAnchorsAndDocking();
        }
        #endregion

        #region Methods

        #region UI
        private void HideUI()
        {
            AssignManagerLabel.Visible = false;
            WarehouseManagerComboBox.Visible = false;
        }

        private void ApplyAnchorsAndDocking()
        {
            // TextBoxes should stretch horizontally
            WarehouseNameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            WarehouseAddressTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // ComboBox should stretch horizontally
            WarehouseManagerComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // CheckBox should stretch horizontallyshould stretch horizontally
            AssignManagerCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // Label should stretch horizontally
            WarehouseNameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            WarehouseAddressLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            AssignManagerLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // Button should stay at the bottom right
            btnAddWarehouse.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            // DataGridView should expand to fill the bottom area
            warehouseDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            using var context = new WarehouseDbContext();
                var warehouseRepository = new WarehouseRepository(context);
                var warehouses = await warehouseRepository.GetAllAsyncWithManagerName();
                var warehousesDTO = warehouses.Select(w => new
                {
                    w.Name,
                    w.Address,
                    ResponsiblePerson = w.ResponsiblePerson?.Name ?? "N/A",
                }).ToList();
                warehouseDataGridView.DataSource = warehousesDTO;
                warehouseDataGridView.Columns["ResponsiblePerson"].HeaderText = "Manager";           
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
        private async void WarehouseForm_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
            WarehouseManagerComboBox.SelectedIndex = -1;
        }
        private void ResetEnteredData()
        {
            WarehouseNameTextBox.Clear();
            WarehouseAddressTextBox.Clear();
            WarehouseManagerComboBox.SelectedIndex = -1;
        }
        #endregion

        #region Button Checkbox event handlers
        private async void btnAddWarehouse_Click(object sender, EventArgs e)
        {
            if (IsValidForm())
            {
                // Create confirmation message
                string message = $"Confirm Adding Warehouse {WarehouseNameTextBox.Text}\n\n" +
                               $"Address: {WarehouseAddressTextBox.Text}\n" +
                               $"Manager: {WarehouseManagerComboBox.Text ?? "None"}";

                var result = MessageBox.Show(message, "Confirm Adding",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        var warehouse = new Warehouse
                        {
                            Name = WarehouseNameTextBox.Text,
                            Address = WarehouseAddressTextBox.Text,
                            ResponsiblePersonId = AssignManagerCheckBox.Checked
                                ? (int?)WarehouseManagerComboBox.SelectedValue
                                : null
                        };

                        using var context = new WarehouseDbContext();
                        var warehouseRepository = new WarehouseRepository(context);
                        await warehouseRepository.AddAsync(warehouse);
                        await LoadWarehousesToGridViewAsync();
                        ResetEnteredData();
                        MessageBox.Show($"Warehouse added successfully!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error adding warehouse: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

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

        #endregion
    }
}