using System.Data;
using WarehouseManagementSystem.Data.Context;
using WarehouseManagementSystem.Data.Repositories;
using WarehouseManagementSystem.Domain.DTOs;
using WarehouseManagementSystem.Domain.Models;

namespace WarehouseManagmentSystem.WinForms.ReportForms
{
    public partial class ItemAtWarehouseDaysTillExpirationReportForm : Form
    {
        #region Fields
        private int DaysPeriod;
        private DateOnly StartReportDate;
        private List<int> SelectedWarehousesIDs = new List<int>();
        #endregion
        public ItemAtWarehouseDaysTillExpirationReportForm()
        {
            InitializeComponent();
            HideUI();
        }

        private async void ItemAtWarehouseDaysTillExpirationReportForm_Load(object sender, EventArgs e)
        {
            await InitializeDataAsync();
        }


        #region Initialize Data
        private async Task InitializeDataAsync()
        {
            await AddWarehousesToCheckBoxList();
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
            FromDateLabel.Visible = false;
            ReportStartDateDatePicker.Visible = false;
        }
        #endregion

        #region Event Handlers (Checkbox, ComboBox, CheckboxList)
        private void ChooseDateCheckBox_ChechStateChanged(object sender, EventArgs e)
        {
            if (ChooseDateInsteadCheckBox.Checked)
            {
                PeriodDaysLabel.Visible = false;
                PeriodDaysTextBox.Visible = false;
                FromDateLabel.Visible = true;
                ReportStartDateDatePicker.Visible = true;
            }
            else
            {
                PeriodDaysLabel.Visible = true;
                PeriodDaysTextBox.Visible = true;
                FromDateLabel.Visible = false;
                ReportStartDateDatePicker.Visible = false;
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

            var items = await _customizedQueriesRepository.GetAllAvailableItemAtWarehouseExpiration(SelectedWarehousesIDs, StartReportDate);
            ReportViewGridView.DataSource = ConfigureReportGridView(items);

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
            StartReportDate = DateOnly.FromDateTime(ReportStartDateDatePicker.Value.Date);

            return true;
        }
        private bool IsValidItemsAtWarehouseSincePeriodReport()
        {

            if (ReportForWarehousesCheckBoxList.CheckedItems.Count == 0)
            {
                MessageBox.Show("At least one warehouse has to been chosen", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (ChooseDateInsteadCheckBox.Checked)
            {
                if (!IsValideDates())
                {
                    return false;
                }
            }
            else
            {
                if (!IsValidPeriodDays())
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsValidPeriodDays()
        {
            if (string.IsNullOrEmpty(PeriodDaysTextBox.Text))
            {
                MessageBox.Show("Must type a period days number", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(PeriodDaysTextBox.Text, out DaysPeriod) || DaysPeriod < 0)
            {
                MessageBox.Show("Must be 0 or more days in a whole number", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            StartReportDate = DateOnly.FromDateTime(DateTime.Now).AddDays(-DaysPeriod);
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

            if (ReportViewGridView.Columns.Contains("ItemName"))
                ReportViewGridView.Columns["ItemName"].Visible = false;

            if (ReportViewGridView.Columns.Contains("WarehouseName"))
                ReportViewGridView.Columns["WarehouseName"].Visible = false;

            if (ReportViewGridView.Columns.Contains("WarehouseId"))
                ReportViewGridView.Columns["WarehouseId"].Visible = false;

            if (ReportViewGridView.Columns.Contains("AvailableQuantity"))
                ReportViewGridView.Columns["AvailableQuantity"].Visible = false;


            if (ReportViewGridView.Columns.Contains("IsSummaryRow"))
                ReportViewGridView.Columns["IsSummaryRow"].Visible = false;


            if (ReportViewGridView.Columns.Contains("IsWarehouseSummary"))
                ReportViewGridView.Columns["IsWarehouseSummary"].Visible = false;
        }
        #endregion

        private void ActionButton_Click(object sender, EventArgs e)
        {
            if (IsValidItemsAtWarehouseSincePeriodReport())
            {
                ReportChosenItemAtChosenWarehouses();
            }
        }

        #region Item Report GridView Event handlers
        private void ReportViewGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 &&
                ReportViewGridView.Rows[e.RowIndex].DataBoundItem is ItemRemainingDaysForExpirationDTO item &&
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
            if (row.DataBoundItem is ItemRemainingDaysForExpirationDTO item && item.IsSummaryRow)
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

            if (row.DataBoundItem is ItemRemainingDaysForExpirationDTO item && item.IsSummaryRow)
            {
                e.Handled = true; // Take over all painting for summary rows

                // Calculate full row width (including hidden columns)
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
                Color backColor = item.IsWarehouseSummary ? Color.FromArgb(220, 230, 241) : Color.FromArgb(234, 242, 252);
                Color borderColor = item.IsWarehouseSummary ? Color.SteelBlue : Color.LightGray;
                Font font = new Font("Segoe UI", item.IsWarehouseSummary ? 10 : 9,
                                   item.IsWarehouseSummary ? FontStyle.Bold : FontStyle.Regular);

                using (Brush backBrush = new SolidBrush(backColor))
                using (Brush textBrush = new SolidBrush(Color.FromArgb(50, 50, 50)))
                using (Pen borderPen = new Pen(borderColor, 1.5f))
                {
                    // Draw background
                    e.Graphics.FillRectangle(backBrush, fullBounds);

                    // Build summary text
                    string summaryText;
                    if (item.IsWarehouseSummary)
                    {
                        summaryText = $"🏭 WAREHOUSE: {item.WarehouseName?.ToUpper()}";
                    }
                    else
                    {
                        string stockInfo = $"📦 {item.AvailableQuantity} in stock";


                        summaryText = $"{item.ItemName} • {stockInfo}";
                    }

                    // Draw text with proper padding
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
        #endregion

        #region Items transfer GridView Data Manipulation
        private List<ItemRemainingDaysForExpirationDTO> ConfigureReportGridView(List<ItemRemainingDaysForExpirationDTO> allData)
        {
            // First group by Warehouse, then by ItemCode, then sort items by ExpiryDate within each group
            var groupedData = allData
                .GroupBy(x => new { x.WarehouseId, x.WarehouseName })  // Primary grouping by Warehouse
                .OrderBy(w => w.Key.WarehouseId)  // Sort warehouses by ID (or Name if preferred)
                .Select(warehouseGroup => new
                {
                    Warehouse = warehouseGroup.Key,
                    Items = warehouseGroup
                        .GroupBy(x => new { x.ItemCode, x.ItemName })  // Secondary grouping by Item
                        .OrderBy(i => i.Key.ItemCode)  // Sort items by Code
                        .Select(itemGroup => new
                        {
                            Item = itemGroup.Key,
                            Entries = itemGroup.OrderBy(e => e.ExpiryDate)  // Sort entries by ExpiryDate
                        })
                })
                .ToList();

            var displayList = new List<ItemRemainingDaysForExpirationDTO>();

            foreach (var warehouseGroup in groupedData)
            {
                // Add Warehouse summary row (optional)
                displayList.Add(new ItemRemainingDaysForExpirationDTO
                {
                    WarehouseId = warehouseGroup.Warehouse.WarehouseId,
                    WarehouseName = warehouseGroup.Warehouse.WarehouseName,
                    IsSummaryRow = true,
                    IsWarehouseSummary = true  // Add this property to your DTO if needed
                });

                foreach (var itemGroup in warehouseGroup.Items)
                {
                    // Add Item summary row
                    displayList.Add(new ItemRemainingDaysForExpirationDTO
                    {
                        ItemCode = itemGroup.Item.ItemCode,
                        ItemName = itemGroup.Item.ItemName,
                        WarehouseId = warehouseGroup.Warehouse.WarehouseId,
                        WarehouseName = warehouseGroup.Warehouse.WarehouseName,
                        AvailableQuantity = itemGroup.Entries.Sum(e => e.AvailableQuantity),
                        IsSummaryRow = true
                    });

                    // Add all entries for this item (sorted by ExpiryDate)
                    displayList.AddRange(itemGroup.Entries);
                }
            }

            return displayList;
        }
        #endregion

    }
}
