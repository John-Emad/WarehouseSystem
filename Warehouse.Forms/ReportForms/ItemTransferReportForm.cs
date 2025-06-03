
using System.Data;
using WarehouseManagementSystem.Data.Context;
using WarehouseManagementSystem.Data.Repositories;
using WarehouseManagementSystem.Domain.DTOs;
using WarehouseManagementSystem.Domain.Models;

namespace WarehouseManagmentSystem.WinForms.ReportForms
{
    public partial class ItemTransferReportForm : Form
    {
        #region Fields
        private DateOnly StartReportDate;
        private DateOnly EndReportDate;
        private List<int> SelectedWarehousesIDs = new List<int>();
        #endregion
        public ItemTransferReportForm()
        {
            InitializeComponent();
            HideUI();
        }

        private async void ItemTransferReportForm_Load(object sender, EventArgs e)
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
            if (WithinRangeDateCheckBox.Checked)
            {
                var items = await _customizedQueriesRepository.GetAllItemDetailsWithinWarehousesWithinDateRange(SelectedWarehousesIDs, StartReportDate, EndReportDate);
                ReportViewGridView.DataSource = ConfigureReportGridView(items);
            }
            else
            {
                var items = await _customizedQueriesRepository.GetAllItemDetailsWithinWarehouses(SelectedWarehousesIDs);
                ReportViewGridView.DataSource = ConfigureReportGridView(items);
            }

            EditWarehouseDataGridViewColumns();
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
        private bool IsValidItemsTransferReport()
        {

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

        #region Edit Columns
        private void EditWarehouseDataGridViewColumns()
        {
            #region Hide
            if (ReportViewGridView.Columns.Contains("ItemCode"))
                ReportViewGridView.Columns["ItemCode"].Visible = false;

            if (ReportViewGridView.Columns.Contains("ItemName"))
                ReportViewGridView.Columns["ItemName"].Visible = false;

            if (ReportViewGridView.Columns.Contains("ToWarehouseId"))
                ReportViewGridView.Columns["ToWarehouseId"].Visible = false;

            if (ReportViewGridView.Columns.Contains("FromWarehouseId"))
                ReportViewGridView.Columns["FromWarehouseId"].Visible = false;


            if (ReportViewGridView.Columns.Contains("Warehouse"))
                ReportViewGridView.Columns["Warehouse"].Visible = false;

            if (ReportViewGridView.Columns.Contains("CurrentQuantity"))
                ReportViewGridView.Columns["CurrentQuantity"].Visible = false;


            if (ReportViewGridView.Columns.Contains("IsSummaryRow"))
                ReportViewGridView.Columns["IsSummaryRow"].Visible = false;

            if (ReportViewGridView.Columns.Contains("IsWarehouseSummary"))
                ReportViewGridView.Columns["IsWarehouseSummary"].Visible = false;
            #endregion

            #region Rename
            if (ReportViewGridView.Columns.Contains("ProductionDate"))
                ReportViewGridView.Columns["ProductionDate"].HeaderText = "Prod Date";

            if (ReportViewGridView.Columns.Contains("ExpiryDate"))
                ReportViewGridView.Columns["ExpiryDate"].HeaderText = "Exp Date";

            if (ReportViewGridView.Columns.Contains("MovementType"))
                ReportViewGridView.Columns["MovementType"].HeaderText = "Movement";


            if (ReportViewGridView.Columns.Contains("FromWarehouseName"))
                ReportViewGridView.Columns["FromWarehouseName"].HeaderText = "From Warehouse";

            if (ReportViewGridView.Columns.Contains("ToWarehouseName"))
                ReportViewGridView.Columns["ToWarehouseName"].HeaderText = "To Warehouse";

            if (ReportViewGridView.Columns.Contains("Quantity"))
                ReportViewGridView.Columns["Quantity"].HeaderText = "Quantity Moved";

            if (ReportViewGridView.Columns.Contains("RelatedPerson"))
                ReportViewGridView.Columns["RelatedPerson"].HeaderText = "Related Person (Supp-Cust)";
            #endregion
        }
        #endregion

        private void ActionButton_Click(object sender, EventArgs e)
        {
            if (IsValidItemsTransferReport())
            {
                ReportChosenItemAtChosenWarehouses();
            }
        }

        #region Item Report GridView Event handlers
        private void ReportViewGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 &&
                ReportViewGridView.Rows[e.RowIndex].DataBoundItem is ItemMovementReportDTO item &&
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
            if (row.DataBoundItem is ItemMovementReportDTO item && item.IsSummaryRow)
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

            if (row.DataBoundItem is ItemMovementReportDTO item && item.IsSummaryRow)
            {
                // Prevent default painting for all cells in summary row
                e.Handled = true;

                if (grid.Columns[e.ColumnIndex].Name == "Quantity")
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

                        string summaryText;

                        if (item.IsWarehouseSummary)
                        {
                            summaryText = $"🏭 WAREHOUSE: {item.Warehouse.ToUpper()}";
                        }
                        else
                        {

                            summaryText = $"📦 {item.ItemName}";
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


        #region Items transfer GridView Data Manipulation
        private List<ItemMovementReportDTO> ConfigureReportGridView(List<ItemMovementReportDTO> allData)
        {
            var groupedByWarehouse = allData
                .GroupBy(x => x.Warehouse)
                .OrderBy(g => g.Key)
                .ToList();

            var displayList = new List<ItemMovementReportDTO>();

            foreach (var warehouseGroup in groupedByWarehouse)
            {
                // Warehouse header row
                displayList.Add(new ItemMovementReportDTO
                {
                    Warehouse = warehouseGroup.Key,
                    IsSummaryRow = true,
                    IsWarehouseSummary = true
                });

                var groupedByItem = warehouseGroup
                    .GroupBy(x => new { x.ItemCode, x.ItemName })
                    .OrderBy(g => g.Key.ItemName);

                foreach (var itemGroup in groupedByItem)
                {
                    // Item header row
                    displayList.Add(new ItemMovementReportDTO
                    {
                        ItemCode = itemGroup.Key.ItemCode,
                        ItemName = itemGroup.Key.ItemName,
                        Warehouse = warehouseGroup.Key,
                        IsSummaryRow = true,
                    });

                    // Add detailed rows
                    displayList.AddRange(itemGroup);
                }
            }

            return displayList;
        }

        #endregion
    }
}

