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
            if (ReportForComboBox.SelectedIndex != -1 && ReportForComboBox.SelectedItem is Warehouse selectedWarehouse)
            {
                if (ReportForComboBox.SelectedValue == null) return;


                SelectedWarehouseId = (int)ReportForComboBox.SelectedValue;
            }
        }
        #endregion

        #region Edit Columns
        private void EditWarehouseDataGridViewColumns()
        {
            #region Hide
            if (ReportViewGridView.Columns.Contains("ItemName"))
                ReportViewGridView.Columns["ItemName"].Visible = false;

            if (ReportViewGridView.Columns.Contains("ItemCode"))
                ReportViewGridView.Columns["ItemCode"].Visible = false;

            if (ReportViewGridView.Columns.Contains("CurrentItemQuantity"))
                ReportViewGridView.Columns["CurrentItemQuantity"].Visible = false;

            if (ReportViewGridView.Columns.Contains("PersonID"))
                ReportViewGridView.Columns["PersonID"].Visible = false;

            if (ReportViewGridView.Columns.Contains("ProductionDate"))
                ReportViewGridView.Columns["ProductionDate"].Visible = false;

            if (ReportViewGridView.Columns.Contains("ExpiryDate"))
                ReportViewGridView.Columns["ExpiryDate"].Visible = false;

            if (ReportViewGridView.Columns.Contains("IsSummaryRow"))
                ReportViewGridView.Columns["IsSummaryRow"].Visible = false;

            if (ReportViewGridView.Columns.Contains("IsItemRow"))
                ReportViewGridView.Columns["IsItemRow"].Visible = false;
            #endregion

            #region Rename
            if (ReportViewGridView.Columns.Contains("PersonName"))
                ReportViewGridView.Columns["PersonName"].HeaderText = "Supplier Name";

            if (ReportViewGridView.Columns.Contains("StateDate"))
                ReportViewGridView.Columns["StateDate"].HeaderText = "State Date";

            if (ReportViewGridView.Columns.Contains("StateQuantity"))
                ReportViewGridView.Columns["StateQuantity"].HeaderText = "State Quantity";
            #endregion
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
                    int totalWidth = grid.Columns
                    .Cast<DataGridViewColumn>()
                    .Where(c => c.Visible)
                    .Sum(c => grid.GetColumnDisplayRectangle(c.Index, false).Width);

                    Rectangle fullBounds = new Rectangle(
                        grid.GetCellDisplayRectangle(0, e.RowIndex, true).X,
                        e.CellBounds.Y,
                        totalWidth,
                        e.CellBounds.Height
                    );

                    // Determine styling based on summary level
                    Color backColor = item.IsSummaryRow ? Color.FromArgb(220, 230, 241) : Color.FromArgb(234, 242, 252);
                    Color borderColor = item.IsSummaryRow ? Color.SteelBlue : Color.LightGray;
                    Font font = new Font("Segoe UI", item.IsSummaryRow ? 10 : 9,
                                       item.IsSummaryRow ? FontStyle.Bold : FontStyle.Regular);

                    using (Brush backBrush = new SolidBrush(backColor))
                    using (Brush textBrush = new SolidBrush(Color.FromArgb(50, 50, 50)))
                    using (Pen borderPen = new Pen(borderColor, 1.5f))
                    {
                        e.Graphics.FillRectangle(backBrush, fullBounds);

                        //string summaryText = $"📦 {item.ItemName} • {item.CurrentItemQuantity:F2} in Stock   |   🏷 Prod: {item.ProductionDate:yyyy-MM-dd}   |   ⏳ Exp: {item.ExpiryDate:yyyy-MM-dd}";
                        string summaryText;
                        if (item.IsItemRow)
                        {
                            summaryText = $"📦 ITEM: {item.ItemName.ToUpper()}";
                        }
                        else
                        {
                            summaryText = $"📦 {item.CurrentItemQuantity:F2} in Stock   |   🏷 Prod: {item.ProductionDate:yyyy-MM-dd}   |   ⏳ Exp: {item.ExpiryDate:yyyy-MM-dd}";
                        }

                        Rectangle textBounds = new Rectangle(
                            fullBounds.X + 10,
                            fullBounds.Y,
                            fullBounds.Width - 20,
                            fullBounds.Height
                        );

                        TextRenderer.DrawText(e.Graphics,
                            summaryText,
                            font,
                            textBounds,
                            Color.Black,
                            TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

                        // Draw borders
                        e.Graphics.DrawLine(borderPen, fullBounds.Left, fullBounds.Top, fullBounds.Right, fullBounds.Top);
                        e.Graphics.DrawLine(borderPen, fullBounds.Left, fullBounds.Bottom - 1, fullBounds.Right, fullBounds.Bottom - 1);
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
            var itemGroups = allData
                .GroupBy(x => new { x.ItemCode, x.ItemName })
                .ToList();

            var displayList = new List<WarehouseItemsStateWithTransfer>();

            foreach (var itemGroup in itemGroups)
            {
                // Add Item Header (once per item)
                displayList.Add(new WarehouseItemsStateWithTransfer
                {
                    ItemCode = itemGroup.Key.ItemCode,
                    ItemName = itemGroup.Key.ItemName,
                    IsItemRow = true,
                    IsSummaryRow = true
                });

                // Then group by production & expiry date for this item
                var dateGroups = itemGroup
                    .GroupBy(x => new { x.ProductionDate, x.ExpiryDate });

                foreach (var dateGroup in dateGroups)
                {
                    // Add summary row for batch
                    displayList.Add(new WarehouseItemsStateWithTransfer
                    {
                        ItemCode = itemGroup.Key.ItemCode,
                        ItemName = itemGroup.Key.ItemName,
                        ProductionDate = dateGroup.Key.ProductionDate,
                        ExpiryDate = dateGroup.Key.ExpiryDate,
                        CurrentItemQuantity = dateGroup.First().CurrentItemQuantity,
                        IsSummaryRow = true
                    });

                    // Add detail rows
                    displayList.AddRange(dateGroup);
                }
            }

            return displayList;
        }

        private async Task AddWarehouseItemsToReportGridView()
        {
            using var context = new WarehouseDbContext();
            var _customizedQueries = new CustomizedQueriesRepositroy(context);
            if (WithinRangeDateCheckBox.Checked)
            {
                var result = await _customizedQueries.GetAllItemsAtWarehouseWithinTimeRangeAsync(SelectedWarehouseId, StartReportDate, EndReportDate);
                ReportViewGridView.DataSource = ConfigureReportGridView(result);
            }
            else
            {
                var result = await _customizedQueries.GetAllItemsAtWarehouseWithSupplierTransferAsync(SelectedWarehouseId);
                ReportViewGridView.DataSource = ConfigureReportGridView(result);
            }
            EditWarehouseDataGridViewColumns();
        }
        #endregion

        private async void ActionButton_Click(object sender, EventArgs e)
        {

            if (IsValidWarehouseReport())
            {
                await AddWarehouseItemsToReportGridView();
                CurrentWarehouseLabel.Visible = true;
                CurrentWarehouseLabel.Text = ReportForComboBox.Text;
            }
            ResetForm();
        }

        private void ResetForm()
        {
            ReportForComboBox.SelectedIndex = -1;
            WithinRangeDateCheckBox.Checked = false;
            ReportStartDateDatePicker.Text = "";
            ReportEndDateDatePicker.Text = "";


        }
    }
}
