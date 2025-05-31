using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseManagementSystem.Data.Context;
using WarehouseManagementSystem.Data.Repositories;
using WarehouseManagementSystem.Domain.DTOs;
using WarehouseManagementSystem.Domain.Models;

namespace WarehouseManagmentSystem.WinForms.ReportForms
{
    public partial class ItemAtWarehouseSincePeriodReportForm : Form
    {
        #region Fields
        private int DaysPeriod;
        private DateOnly StartReportDate;
        private List<int> SelectedWarehousesIDs = new List<int>();
        #endregion
        public ItemAtWarehouseSincePeriodReportForm()
        {
            InitializeComponent();
            HideUI();
        }

        private async void ItemAtWarehouseSincePeriodReportForm_Load(object sender, EventArgs e)
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

            var items = await _customizedQueriesRepository.GetAllAvailableItemAtWarehouseSincePeriod(SelectedWarehousesIDs, StartReportDate);
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

            if(!int.TryParse(PeriodDaysTextBox.Text, out DaysPeriod) || DaysPeriod < 0)
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
                // Prevent default painting for all cells in summary row
                e.Handled = true;

                if (grid.Columns[e.ColumnIndex].Name == "Quantity")
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

                        string summaryText = $"📦 {item.ItemName}   |   🏭 {item.WarehouseName}   |   Available: {item.AvailableQuantity}";

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


        #region Items transfer GridView Data Manipulation
        private List<ItemAtWarehouseSincePeriodDTO> ConfigureReportGridView(List<ItemAtWarehouseSincePeriodDTO> allData)
        {
            var groupedData = allData
                .GroupBy(x => new { x.ItemCode, x.WarehouseId, x.AvailableQuantity })
                .OrderBy(g => g.Key.ItemCode)
                .OrderBy(f => f.Key.WarehouseId)
                .ToList();

            var displayList = new List<ItemAtWarehouseSincePeriodDTO>();

            foreach (var group in groupedData)
            {
                displayList.Add(new ItemAtWarehouseSincePeriodDTO
                {
                    ItemCode = group.Key.ItemCode,
                    ItemName = group.First().ItemName,
                    WarehouseId = group.Key.WarehouseId,
                    WarehouseName = group.First().WarehouseName,
                    AvailableQuantity = group.Key.AvailableQuantity,
                    IsSummaryRow = true
                });

                // Add detail rows
                displayList.AddRange(group);

            }
            return displayList;
        }
        #endregion

    }
}
