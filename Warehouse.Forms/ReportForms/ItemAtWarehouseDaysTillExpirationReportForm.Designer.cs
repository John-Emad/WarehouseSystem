namespace WarehouseManagmentSystem.WinForms.ReportForms
{
    partial class ItemAtWarehouseDaysTillExpirationReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ReportForWarehousesCheckBoxList = new CheckedListBox();
            ActionButton = new Button();
            ReportViewGridView = new DataGridView();
            ReportForWarehousesLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)ReportViewGridView).BeginInit();
            SuspendLayout();
            // 
            // ReportForWarehousesCheckBoxList
            // 
            ReportForWarehousesCheckBoxList.FormattingEnabled = true;
            ReportForWarehousesCheckBoxList.Location = new Point(189, 626);
            ReportForWarehousesCheckBoxList.Name = "ReportForWarehousesCheckBoxList";
            ReportForWarehousesCheckBoxList.Size = new Size(308, 180);
            ReportForWarehousesCheckBoxList.TabIndex = 61;
            ReportForWarehousesCheckBoxList.ItemCheck += ReportForWarehousesCheckBoxList_ItemCheck;
            // 
            // ActionButton
            // 
            ActionButton.Location = new Point(632, 709);
            ActionButton.Name = "ActionButton";
            ActionButton.Size = new Size(271, 56);
            ActionButton.TabIndex = 59;
            ActionButton.Text = "Search";
            ActionButton.UseVisualStyleBackColor = true;
            ActionButton.Click += ActionButton_Click;
            // 
            // ReportViewGridView
            // 
            ReportViewGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ReportViewGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ReportViewGridView.Dock = DockStyle.Top;
            ReportViewGridView.Location = new Point(0, 0);
            ReportViewGridView.Name = "ReportViewGridView";
            ReportViewGridView.RowHeadersWidth = 51;
            ReportViewGridView.Size = new Size(2329, 555);
            ReportViewGridView.TabIndex = 57;
            ReportViewGridView.CellFormatting += ReportViewGridView_CellFormatting;
            ReportViewGridView.CellPainting += ReportViewGridView_CellPainting;
            ReportViewGridView.DataError += ReportViewGridView_DataError;
            ReportViewGridView.RowPrePaint += ReportViewGridView_RowPrePaint;
            // 
            // ReportForWarehousesLabel
            // 
            ReportForWarehousesLabel.AutoSize = true;
            ReportForWarehousesLabel.Location = new Point(12, 633);
            ReportForWarehousesLabel.Name = "ReportForWarehousesLabel";
            ReportForWarehousesLabel.Size = new Size(151, 20);
            ReportForWarehousesLabel.TabIndex = 65;
            ReportForWarehousesLabel.Text = "Choose Warehouse(s)";
            // 
            // ItemAtWarehouseDaysTillExpirationReportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2329, 1142);
            Controls.Add(ReportForWarehousesLabel);
            Controls.Add(ReportForWarehousesCheckBoxList);
            Controls.Add(ActionButton);
            Controls.Add(ReportViewGridView);
            Name = "ItemAtWarehouseDaysTillExpirationReportForm";
            Text = "ItemAtWarehouseDaysTillExpirationReport";
            Load += ItemAtWarehouseDaysTillExpirationReportForm_Load;
            ((System.ComponentModel.ISupportInitialize)ReportViewGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private CheckedListBox ReportForWarehousesCheckBoxList;
        private Button ActionButton;
        private DataGridView ReportViewGridView;
        private Label ReportForWarehousesLabel;
    }
}