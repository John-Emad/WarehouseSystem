using WarehouseManagementSystem.Data.Context;
using WarehouseManagementSystem.Data.Repositories;
using WarehouseManagementSystem.Domain.Models;

namespace WarehouseManagmentSystem.WinForms.ReportForms
{
    public partial class ItemReportForm : Form
    {
        #region Fields
        private string SelectedItemCode;
        private DateOnly StartReportDate;
        private DateOnly EndReportDate;
        private List<int> SelectedWarehousesIDs = new List<int>();
        #endregion
        public ItemReportForm()
        {
            InitializeComponent();
            HideUI();
        }

        private async void ItemReportForm_Load(object sender, EventArgs e)
        {
            await InitializeDataAsync();
        }


        #region Initialize Data
        private async Task InitializeDataAsync()
        {
            await AddItemsToComboBoxAsync();
            await AddWarehousesToCheckBoxList();
        }
        private async Task AddItemsToComboBoxAsync()
        {
            using (var context = new WarehouseDbContext())
            {
                var repo = new ItemRepository(context);
                var Items = await repo.GetAllAsync();
                ReportForItemsComboBox.DisplayMember = "Name";
                ReportForItemsComboBox.ValueMember = "Code";
                ReportForItemsComboBox.DataSource = Items;
            }
            ReportForItemsComboBox.SelectedIndex = -1;
        }
        private async Task AddWarehousesToCheckBoxList()
        {
            using (var context = new WarehouseDbContext())
            {
                var repo = new WarehouseRepository(context);
                List<Warehouse> warehouses = new List<Warehouse>();
                warehouses = await repo.GetAllAsync();
                ReportForWarehousesCheckBoxList.DisplayMember = "Name";
                ReportForWarehousesCheckBoxList.ValueMember = "Id";
                ReportForWarehousesCheckBoxList.DataSource = warehouses;
            }
            ReportForWarehousesCheckBoxList.SelectedIndex = -1;
        }
        #endregion

        #region UI
        private void HideUI()
        {
            ReportStartDateDatePicker.Visible = false;
            ReportEndDateDatePicker.Visible = false;
            FromDateLabel.Visible = false;
            ToDateLabel.Visible = false;
            CurrentItemLabel.Visible = false;
        }
        #endregion

        #region Event Handlers (Checkbox, ComboBox, CheckboxList)
        private void WithinRangeDateCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            if (WithinRangeDateCheckBox.Checked)
            {
                ReportEndDateDatePicker.Visible = true;
                ReportEndDateDatePicker.Text = "";
                ReportStartDateDatePicker.Visible = true;
                ReportEndDateDatePicker.Text = "";

                FromDateLabel.Visible = true;
                FromDateLabel.Text = "Start from:";

                ToDateLabel.Visible = true;
                ToDateLabel.Text = "To:";
            }
            else
            {
                ReportStartDateDatePicker.Visible = false;
                ReportEndDateDatePicker.Visible = false;
                FromDateLabel.Visible = false;
                ToDateLabel.Visible = false;
            }
        }
        private void ReportForItemsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ReportForItemsComboBox.SelectedIndex != -1 && ReportForItemsComboBox.SelectedItem is Item selectedItem)
            {
                if (ReportForItemsComboBox.SelectedValue is null) return;


                SelectedItemCode = ReportForItemsComboBox.SelectedValue?.ToString();
            }
        }
        private void ReportForWarehousesCheckBoxList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Delay the update until after the check state is changed
            this.BeginInvoke(new Action(() =>
            {
                SelectedWarehousesIDs.Clear();

                foreach (var item in ReportForWarehousesCheckBoxList.CheckedItems)
                {
                    if (item is Warehouse warehouse)
                    {
                        SelectedWarehousesIDs.Add(warehouse.Id);
                    }
                }
            }));
        }
        #endregion

        private async void ReportChosenItemAtChosenWarehouses()
        {
            using var context = new WarehouseDbContext();
            var _customizedQueriesRepository = new CustomizedQueriesRepositroy(context);
            var items = await _customizedQueriesRepository.GetItemDetailsWithinWarehouses(SelectedItemCode, SelectedWarehousesIDs);
            //var items = await _customizedQueriesRepository.GetItemMovementsReportAsync(SelectedWarehousesIDs, null, null);
            ReportViewGridView.DataSource = items;
            HideUnnecessaryWarehouseDataColumns();
            MessageBox.Show("Searching Done");
        }

        #region Validations
        private bool IsValideDates()
        {
            if (string.IsNullOrWhiteSpace(ReportStartDateDatePicker.Text))
            {
                MessageBox.Show("Must Specify the start date", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(ReportEndDateDatePicker.Text))
            {
                MessageBox.Show("Must Specify the end date", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            StartReportDate = DateOnly.FromDateTime(ReportStartDateDatePicker.Value.Date);
            EndReportDate = DateOnly.FromDateTime(ReportEndDateDatePicker.Value.Date);

            if (StartReportDate >= EndReportDate)
            {
                MessageBox.Show("End Date must be after Start Date", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private bool IsValidWarehouseReport()
        {
            if(ReportForItemsComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("The Item must be Chosen first", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (ReportForWarehousesCheckBoxList.CheckedItems.Count == 0)
            {
                MessageBox.Show("At least one warehouse has to been chosen", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (WithinRangeDateCheckBox.Checked)
            {
                if (!IsValideDates())
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region Hide Columns
        private void HideUnnecessaryWarehouseDataColumns()
        {
            foreach (DataGridViewColumn column in ReportViewGridView.Columns)
            {
                column.ReadOnly = true;
            }

            if (ReportViewGridView.Columns.Contains("ItemCode"))
                ReportViewGridView.Columns["ItemCode"].Visible = false;

            if (ReportViewGridView.Columns.Contains("ToWarehouseId"))
                ReportViewGridView.Columns["ToWarehouseId"].Visible = false;

            if (ReportViewGridView.Columns.Contains("FromWarehouseId"))
                ReportViewGridView.Columns["FromWarehouseId"].Visible = false;

        }
        #endregion

        private void ActionButton_Click(object sender, EventArgs e)
        {
            if(IsValidWarehouseReport())
            {
                ReportChosenItemAtChosenWarehouses();
            }
        }
    }
}
