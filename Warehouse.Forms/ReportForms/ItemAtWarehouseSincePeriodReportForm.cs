using System.Data;
using WarehouseManagementSystem.Data.Context;
using WarehouseManagementSystem.Data.Repositories;
using WarehouseManagementSystem.Domain.DTOs;
using WarehouseManagementSystem.Domain.Models;

namespace WarehouseManagmentSystem.WinForms.ReportForms
{
    public partial class ItemAtWarehouseSincePeriodReportForm : Form
    {
        #region Fields
        //private int DaysPeriod;
        //private DateOnly StartReportDate;
        private List<int> SelectedWarehousesIDs = new List<int>();
        #endregion


        #region Constructor
        public ItemAtWarehouseSincePeriodReportForm()
        {
            InitializeComponent();
        } 
        #endregion


        #region  Data
        private async void ItemAtWarehouseSincePeriodReportForm_Load(object sender, EventArgs e)
        {
            await InitializeDataAsync();
        }
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
        private async void ReportChosenItemAtChosenWarehouses()
        {
            using var context = new WarehouseDbContext();
            var _customizedQueriesRepository = new CustomizedQueriesRepositroy(context);

            var items = await _customizedQueriesRepository.GetAllAvailableItemAtWarehouseSincePeriod(SelectedWarehousesIDs);
            ReportViewGridView.DataSource = ConfigureReportGridView(items);

            EditWarehouseGridViewDataColumns();
            MessageBox.Show("Searching Done");
        }
        #endregion

        #region Event Handlers (Button, CheckboxList)
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

        private void ActionButton_Click(object sender, EventArgs e)
        {
            if (IsValidItemsAtWarehouseSincePeriodReport())
            {
                ReportChosenItemAtChosenWarehouses();
            }
        }
        #endregion

        #region Validations
        private bool IsValidItemsAtWarehouseSincePeriodReport()
        {
            if (ReportForWarehousesCheckBoxList.CheckedItems.Count == 0)
            {
                MessageBox.Show("At least one warehouse has to been chosen", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        #endregion

        #region Edit Columns
        private void EditWarehouseGridViewDataColumns()
        {
            #region Hide
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
            #endregion

            #region Rename Columns
            // Rename
            if (ReportViewGridView.Columns.Contains("SupplierName"))
                ReportViewGridView.Columns["SupplierName"].HeaderText = "Supplier";

            if (ReportViewGridView.Columns.Contains("ItemQuantity"))
                ReportViewGridView.Columns["ItemQuantity"].HeaderText = "Transfer Quantity";

            if (ReportViewGridView.Columns.Contains("ProductionDate"))
                ReportViewGridView.Columns["ProductionDate"].HeaderText = "Prod Date";

            if (ReportViewGridView.Columns.Contains("ExpiryDate"))
                ReportViewGridView.Columns["ExpiryDate"].HeaderText = "Exp Date";

            if (ReportViewGridView.Columns.Contains("Quantity"))
                ReportViewGridView.Columns["Quantity"].HeaderText = "Supplied Quantity";

            if (ReportViewGridView.Columns.Contains("AtWareHouseSinceDate"))
                ReportViewGridView.Columns["AtWareHouseSinceDate"].HeaderText = "Entered warehouse at";


            if (ReportViewGridView.Columns.Contains("SinceDays"))
                ReportViewGridView.Columns["SinceDays"].HeaderText = "Entered since (Days)";

            if (ReportViewGridView.Columns.Contains("EnteredBy"))
                ReportViewGridView.Columns["EnteredBy"].HeaderText = "Entering method";
            #endregion
        }
        #endregion


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

            if (row.DataBoundItem is ItemAtWarehouseSincePeriodDTO item && item.IsSummaryRow)
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
        private List<ItemAtWarehouseSincePeriodDTO> ConfigureReportGridView(List<ItemAtWarehouseSincePeriodDTO> allData)
        {
            var displayList = new List<ItemAtWarehouseSincePeriodDTO>();

            // First group by warehouse
            var warehouseGroups = allData
                .Where(x => x.WarehouseId != null) // Filter out NULL entries
                .GroupBy(x => new { x.WarehouseId, x.WarehouseName })
                .OrderBy(g => g.Key.WarehouseId)
                .ToList();

            foreach (var warehouseGroup in warehouseGroups)
            {
                // Add warehouse summary row
                displayList.Add(new ItemAtWarehouseSincePeriodDTO
                {
                    WarehouseId = warehouseGroup.Key.WarehouseId,
                    WarehouseName = warehouseGroup.First().WarehouseName,
                    IsSummaryRow = true,
                    IsWarehouseSummary = true
                });

                // Then group items within this warehouse
                var itemGroups = warehouseGroup
                    .GroupBy(x => new { x.ItemCode, x.ItemName, x.ProductionDate, x.ExpiryDate })
                    .OrderBy(g => g.Key.ItemCode)
                    .ToList();

                foreach (var itemGroup in itemGroups)
                {
                    // Add item summary row (showing total quantity for the item in this warehouse)
                    displayList.Add(new ItemAtWarehouseSincePeriodDTO
                    {
                        ItemCode = itemGroup.Key.ItemCode,
                        ItemName = itemGroup.Key.ItemName,
                        AvailableQuantity = itemGroup.First().AvailableQuantity,
                        IsSummaryRow = true
                    });

                    // Add detailed rows (grouped by production/expiry batches)
                    var batchGroups = itemGroup
                        .GroupBy(x => new { x.ProductionDate, x.ExpiryDate })
                        .OrderBy(g => g.Key.ExpiryDate); // Sort batches by expiry date

                    foreach (var batchGroup in batchGroups)
                    {
                        displayList.AddRange(batchGroup);
                    }
                }
            }

            return displayList;
        }
        #endregion

    }
}
