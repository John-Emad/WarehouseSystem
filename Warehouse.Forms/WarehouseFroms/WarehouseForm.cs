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

            WarehouseManagerComboBox.SelectedIndex = -1;
        }
        #endregion

        #region Methods

        private void HideUI()
        {
            AssignManagerLabel.Visible = false;
            WarehouseManagerComboBox.Visible = false;
        }

        #region Load Data
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
                var warehousesDTO = warehouses.Select(w => new
                {
                    w.Name,
                    w.Address,
                    ResponsiblePerson = w.ResponsiblePerson?.Name ?? "N/A",
                }).ToList();
                warehouseDataGridView.DataSource = warehousesDTO;
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
        #endregion
        private void ResetEnteredData()
        {
            WarehouseNameTextBox.Clear();
            WarehouseAddressTextBox.Clear();
            WarehouseManagerComboBox.SelectedIndex = -1;
        }
        private async void btnAddWarehouse_Click(object sender, EventArgs e)
        {
            if(IsValidForm())
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding warehouse: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        #endregion

        private async void WarehouseForm_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
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
    }
}