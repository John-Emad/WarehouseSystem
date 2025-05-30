using WarehouseManagementSystem.Data.Context;
using WarehouseManagementSystem.Data.Repositories;
using WarehouseManagementSystem.Domain.DTOs;
using WarehouseManagementSystem.Domain.Models;

namespace WarehouseManagmentSystem.WinForms.ReportForms
{
    public partial class WarehousReportForm : Form
    {
        #region Fields
        ReportsEnum reportsEnum;
        private int SelectedWarehouseId;
        private DateOnly StartReportDate;
        private DateOnly EndReportDate;
        #endregion
        public WarehousReportForm()
        {
            InitializeComponent();
            HideUI();
            InitializeWarehouseReportUI();
        }

        private async void WarehousReportForm_LoadAsync(object sender, EventArgs e)
        {
            await InitializeDataAsync();
        }

        #region UI
        private void HideUI()
        {
            ReportStartDateDatePicker.Visible = false;
            ReportEndDateDatePicker.Visible = false;
            FromDateLabel.Visible = false;
            ToDateLabel.Visible = false;
            CurrentWarehouseLabel.Visible = false;
        }
        private void InitializeWarehouseReportUI()
        {
            ReportViewGridView.Visible = true;

            ReportForLabel.Visible = true;
            ReportForLabel.Text = "Choose Warehouse";

            ReportForLabel.Visible = true;
            WithinRangeDateCheckBox.Visible = true;

            ActionButton.Visible = true;
            ActionButton.Text = "Display";
        }

        #endregion
        private async Task InitializeDataAsync()
        {
            await AddWarehousesToComboBoxAsync();
        }

        #region Warehouse ComboBox
        private async Task AddWarehousesToComboBoxAsync()
        {
            using (var context = new WarehouseDbContext())
            {
                var repo = new WarehouseRepository(context);
                List<Warehouse> warehouses = new List<Warehouse>();
                warehouses = await repo.GetAllAsync();
                ReportForComboBox.DisplayMember = "Name";
                ReportForComboBox.ValueMember = "Id";
                ReportForComboBox.DataSource = warehouses;
            }
            ReportForComboBox.SelectedIndex = -1;
        }

        private void ReportForComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (reportsEnum)
            {
                case ReportsEnum.Warehouse:
                    if (ReportForComboBox.SelectedIndex != -1 &&
                ReportForComboBox.SelectedItem is Warehouse selectedWarehouse)
                    {
                        if (ReportForComboBox.SelectedValue == null) return;


                        SelectedWarehouseId = (int)ReportForComboBox.SelectedValue;
                    }
                    break;
            }
        }
        #endregion

        #region Hide Elements
        private void HideUnnecessaryWarehouseDataColumns()
        {
            foreach (DataGridViewColumn column in ReportViewGridView.Columns)
            {
                column.ReadOnly = true;
            }

            if (ReportViewGridView.Columns.Contains("ItemCode"))
                ReportViewGridView.Columns["ItemCode"].Visible = false;

            if (ReportViewGridView.Columns.Contains("SupplierID"))
                ReportViewGridView.Columns["SupplierID"].Visible = false;

            if (ReportViewGridView.Columns.Contains("WarehouseID"))
                ReportViewGridView.Columns["WarehouseID"].Visible = false;



            if (ReportViewGridView.Columns.Contains("WarehouseName"))
                ReportViewGridView.Columns["WarehouseName"].Visible = false;

        }

        private void HideUnnecessaryWarehouseDataWithinDateRangeColumns()
        {
            HideUnnecessaryWarehouseDataColumns();

            if (ReportViewGridView.Columns.Contains("IsSummaryRow"))
                ReportViewGridView.Columns["IsSummaryRow"].Visible = false;

            if (ReportViewGridView.Columns.Contains("ItemName"))
                ReportViewGridView.Columns["ItemName"].Visible = false;

            if (ReportViewGridView.Columns.Contains("CurrentItemQuantity"))
                ReportViewGridView.Columns["CurrentItemQuantity"].Visible = false;

            if (ReportViewGridView.Columns.Contains("ProductionDate"))
                ReportViewGridView.Columns["ProductionDate"].Visible = false;

            if (ReportViewGridView.Columns.Contains("ExpiryDate"))
                ReportViewGridView.Columns["ExpiryDate"].Visible = false;
        }
        #endregion

        #region Warehouse Report GridView Event handlers
        private void ReportViewGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 &&
                ReportViewGridView.Rows[e.RowIndex].DataBoundItem is WarehouseItemsStateWithTransfer item &&
                item.IsSummaryRow)
            {
                // Only show the summary text in the first column (e.g., ItemName or custom one)
                if (e.ColumnIndex != 0)
                {
                    e.Value = null;
                    e.FormattingApplied = true;
                }
            }
        }

        private void ReportViewGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        private void ReportViewGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = ReportViewGridView.Rows[e.RowIndex];
            if (row.DataBoundItem is WarehouseItemsStateWithTransfer item && item.IsSummaryRow)
            {
                row.DefaultCellStyle.BackColor = Color.LightGray;
                row.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            }
        }
        private void ReportViewGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var grid = (DataGridView)sender;
            var row = grid.Rows[e.RowIndex];

            if (row.DataBoundItem is WarehouseItemsStateWithTransfer item && item.IsSummaryRow)
            {
                // Prevent default painting for all cells in summary row
                e.Handled = true;

                if (grid.Columns[e.ColumnIndex].Name == "PersonName")
                {
                    // Calculate the full row width
                    int totalWidth = 0;
                    foreach (DataGridViewColumn col in grid.Columns)
                    {
                        if (col.Visible)
                            totalWidth += grid.GetCellDisplayRectangle(col.Index, e.RowIndex, true).Width;
                    }

                    Rectangle fullBounds = new Rectangle(
                        grid.GetCellDisplayRectangle(0, e.RowIndex, true).X,
                        e.CellBounds.Y,
                        totalWidth,
                        e.CellBounds.Height
                    );

                    using (Brush backBrush = new SolidBrush(Color.LightGray))
                    using (Font boldFont = new Font("Segoe UI", 10, FontStyle.Bold))
                    {
                        e.Graphics.FillRectangle(backBrush, fullBounds);

                        string summaryText = $"📦 {item.ItemName}   |   🏷 Prod: {item.ProductionDate:yyyy-MM-dd}   |   ⏳ Exp: {item.ExpiryDate:yyyy-MM-dd}   |   📦 Total Quantity Available: {item.CurrentItemQuantity:F2}";

                        TextRenderer.DrawText(e.Graphics,
                            summaryText,
                            boldFont,
                            fullBounds,
                            Color.Black,
                            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

                        e.Graphics.DrawLine(Pens.Gray, fullBounds.Left, fullBounds.Bottom - 1, fullBounds.Right, fullBounds.Bottom - 1);
                    }
                }
            }
        }


        #endregion

        #region Within range CheckBox and dates
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
        #endregion

        #region Validations
        private bool IsValidWarehouseReport()
        {
            if (ReportForComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("The warehouse must be chosen first", "Validation Error",
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
        #endregion

        #region Warehouse GridView Data Manipulation
        private List<WarehouseItemsStateWithTransfer> ConfigureReportGridView(List<WarehouseItemsStateWithTransfer> allData)
        {
            var groupedData = allData
                .GroupBy(x => new { x.ItemCode, x.ProductionDate, x.ExpiryDate })
                .ToList();

            var displayList = new List<WarehouseItemsStateWithTransfer>();

            foreach (var group in groupedData)
            {
                displayList.Add(new WarehouseItemsStateWithTransfer
                {
                    ItemName = group.First().ItemName,
                    ItemCode = group.Key.ItemCode,
                    ProductionDate = group.Key.ProductionDate,
                    ExpiryDate = group.Key.ExpiryDate,
                    CurrentItemQuantity = group.First().CurrentItemQuantity,
                    IsSummaryRow = true
                });

                // Add detail rows
                displayList.AddRange(group);

            }
            return displayList;
        }
        private async Task AddWarehouseItemsToReportGridView()
        {
            if (WithinRangeDateCheckBox.Checked)
            {

                using (var context = new WarehouseDbContext())
                {
                    var _customizedQueries = new CustomizedQueriesRepositroy(context);
                    var result = await _customizedQueries.GetAllItemsAtWarehouseWithinTimeRangeAsync(SelectedWarehouseId, StartReportDate, EndReportDate);
                    ReportViewGridView.DataSource = ConfigureReportGridView(result);
                    HideUnnecessaryWarehouseDataWithinDateRangeColumns();
                }
            }
            else
            {
                using (var context = new WarehouseDbContext())
                {
                    var _customizedQueries = new CustomizedQueriesRepositroy(context);
                    ReportViewGridView.DataSource = await _customizedQueries.GetAllItemsAtWarehouseWithSupplierTransferAsync(SelectedWarehouseId);
                    HideUnnecessaryWarehouseDataColumns();
                }
            }
        }
        #endregion

        private async void ActionButton_Click(object sender, EventArgs e)
        {
            switch (reportsEnum)
            {
                case ReportsEnum.Warehouse:
                    if (IsValidWarehouseReport())
                    {
                        await AddWarehouseItemsToReportGridView();
                        CurrentWarehouseLabel.Visible = true;
                        CurrentWarehouseLabel.Text = ReportForComboBox.Text;
                    }
                    break;
            }
        }
    }
}
