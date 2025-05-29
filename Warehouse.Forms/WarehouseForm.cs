using Microsoft.EntityFrameworkCore.Query;
using WarehouseManagementSystem.Data.Context;
using WarehouseManagementSystem.Data.Repositories;
using WarehouseManagementSystem.Domain.Models;

namespace WarehouseManagmentSystem.WinForms.Forms
{
    public partial class WarehouseForm : Form
    {
        #region Fields
        private readonly WarehouseDbContext _context;
        private readonly WarehouseRepository _warehouseRepository;
        private readonly PersonRepository _personRepository;
        #endregion

        #region Constructors
        public WarehouseForm(WarehouseDbContext context)
        {
            _context = context;
            _warehouseRepository = new WarehouseRepository(_context);
            _personRepository = new PersonRepository(_context);
            InitializeComponent();
            LoadDataAsync();
            WarehouseManagerComboBox.SelectedIndex = -1;
        }
        #endregion

        #region Methods
        private async Task LoadDataAsync()
        {
            await LoadWarehousesToGridViewAsync();
            await LoadPersonsToComboBox();
        }
        private async Task LoadWarehousesToGridViewAsync()
        {
            var warehouses = await _warehouseRepository.GetAllAsyncWithManagerName();
            var warehousesDTO = warehouses.Select(w => new
            {
                w.Name,
                w.Address,
                ResponsiblePerson = w.ResponsiblePerson?.Name ?? "N/A",
            }).ToList();
            warehouseDataGridView.DataSource = warehousesDTO;
        }
        private async Task LoadPersonsToComboBox()
        {
            List<Person> people = new List<Person>();
            people = await _personRepository.GetAllAsync();
            WarehouseManagerComboBox.DisplayMember = "Name";
            WarehouseManagerComboBox.ValueMember = "Id";
            WarehouseManagerComboBox.DataSource = people;
        }
        private void ResetEnteredData()
        {
            WarehouseNameTextBox.Clear();
            WarehouseAddressTextBox.Clear();
            WarehouseManagerComboBox.SelectedIndex = -1;
        }
        private async void btnAddWarehouse_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(WarehouseNameTextBox.Text))
            {
                MessageBox.Show("Warehouse name is required", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var warehouse = new Warehouse
                {
                    Name = WarehouseNameTextBox.Text,
                    Address = WarehouseAddressTextBox.Text,
                    ResponsiblePersonId = (int?)WarehouseManagerComboBox.SelectedValue,
                };

                await _warehouseRepository.AddAsync(warehouse);
                await LoadWarehousesToGridViewAsync();
                ResetEnteredData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding warehouse: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

    }
}