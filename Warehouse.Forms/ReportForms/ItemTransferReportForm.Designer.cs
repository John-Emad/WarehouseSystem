namespace WarehouseManagmentSystem.WinForms.ReportForms
{
    partial class ItemTransferReportForm
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
            ReportForWarehousesLabel = new Label();
            ReportForWarehousesCheckBoxList = new CheckedListBox();
            ToDateLabel = new Label();
            FromDateLabel = new Label();
            CurrentItemLabel = new Label();
            ActionButton = new Button();
            WithinRangeDateCheckBox = new CheckBox();
            ReportEndDateDatePicker = new DateTimePicker();
            ReportStartDateDatePicker = new DateTimePicker();
            ReportViewGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)ReportViewGridView).BeginInit();
            SuspendLayout();
            // 
            // ReportForWarehousesLabel
            // 
            ReportForWarehousesLabel.AutoSize = true;
            ReportForWarehousesLabel.Location = new Point(21, 674);
            ReportForWarehousesLabel.Name = "ReportForWarehousesLabel";
            ReportForWarehousesLabel.Size = new Size(151, 20);
            ReportForWarehousesLabel.TabIndex = 43;
            ReportForWarehousesLabel.Text = "Choose Warehouse(s)";
            // 
            // ReportForWarehousesCheckBoxList
            // 
            ReportForWarehousesCheckBoxList.FormattingEnabled = true;
            ReportForWarehousesCheckBoxList.Location = new Point(224, 661);
            ReportForWarehousesCheckBoxList.Name = "ReportForWarehousesCheckBoxList";
            ReportForWarehousesCheckBoxList.Size = new Size(308, 180);
            ReportForWarehousesCheckBoxList.TabIndex = 42;
            ReportForWarehousesCheckBoxList.ItemCheck += ReportForWarehousesCheckBoxList_ItemCheck;
            // 
            // ToDateLabel
            // 
            ToDateLabel.AutoSize = true;
            ToDateLabel.Location = new Point(597, 788);
            ToDateLabel.Name = "ToDateLabel";
            ToDateLabel.Size = new Size(32, 20);
            ToDateLabel.TabIndex = 41;
            ToDateLabel.Text = "To: ";
            // 
            // FromDateLabel
            // 
            FromDateLabel.AutoSize = true;
            FromDateLabel.Location = new Point(597, 732);
            FromDateLabel.Name = "FromDateLabel";
            FromDateLabel.Size = new Size(81, 20);
            FromDateLabel.TabIndex = 40;
            FromDateLabel.Text = "Start From:";
            // 
            // CurrentItemLabel
            // 
            CurrentItemLabel.AutoSize = true;
            CurrentItemLabel.Location = new Point(1471, 583);
            CurrentItemLabel.Name = "CurrentItemLabel";
            CurrentItemLabel.Size = new Size(0, 20);
            CurrentItemLabel.TabIndex = 38;
            // 
            // ActionButton
            // 
            ActionButton.Location = new Point(1223, 674);
            ActionButton.Name = "ActionButton";
            ActionButton.Size = new Size(271, 56);
            ActionButton.TabIndex = 36;
            ActionButton.Text = "Search";
            ActionButton.UseVisualStyleBackColor = true;
            ActionButton.Click += ActionButton_Click;
            // 
            // WithinRangeDateCheckBox
            // 
            WithinRangeDateCheckBox.AutoSize = true;
            WithinRangeDateCheckBox.Location = new Point(597, 665);
            WithinRangeDateCheckBox.Name = "WithinRangeDateCheckBox";
            WithinRangeDateCheckBox.Size = new Size(157, 24);
            WithinRangeDateCheckBox.TabIndex = 35;
            WithinRangeDateCheckBox.Text = "Within Time Range";
            WithinRangeDateCheckBox.UseVisualStyleBackColor = true;
            WithinRangeDateCheckBox.CheckStateChanged += WithinRangeDateCheckBox_CheckStateChanged;
            // 
            // ReportEndDateDatePicker
            // 
            ReportEndDateDatePicker.Location = new Point(751, 783);
            ReportEndDateDatePicker.Name = "ReportEndDateDatePicker";
            ReportEndDateDatePicker.Size = new Size(250, 27);
            ReportEndDateDatePicker.TabIndex = 34;
            // 
            // ReportStartDateDatePicker
            // 
            ReportStartDateDatePicker.Location = new Point(751, 727);
            ReportStartDateDatePicker.Name = "ReportStartDateDatePicker";
            ReportStartDateDatePicker.Size = new Size(250, 27);
            ReportStartDateDatePicker.TabIndex = 33;
            // 
            // ReportViewGridView
            // 
            ReportViewGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ReportViewGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ReportViewGridView.Dock = DockStyle.Top;
            ReportViewGridView.Location = new Point(0, 0);
            ReportViewGridView.Name = "ReportViewGridView";
            ReportViewGridView.RowHeadersWidth = 51;
            ReportViewGridView.Size = new Size(2330, 555);
            ReportViewGridView.TabIndex = 32;
            ReportViewGridView.CellFormatting += ReportViewGridView_CellFormatting;
            ReportViewGridView.CellPainting += ReportViewGridView_CellPainting;
            ReportViewGridView.DataError += ReportViewGridView_DataError;
            ReportViewGridView.RowPrePaint += ReportViewGridView_RowPrePaint;
            // 
            // ItemTransferReportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2330, 1144);
            Controls.Add(ReportForWarehousesLabel);
            Controls.Add(ReportForWarehousesCheckBoxList);
            Controls.Add(ToDateLabel);
            Controls.Add(FromDateLabel);
            Controls.Add(CurrentItemLabel);
            Controls.Add(ActionButton);
            Controls.Add(WithinRangeDateCheckBox);
            Controls.Add(ReportEndDateDatePicker);
            Controls.Add(ReportStartDateDatePicker);
            Controls.Add(ReportViewGridView);
            Name = "ItemTransferReportForm";
            Text = "ItemTransferReport";
            Load += ItemTransferReportForm_Load;
            ((System.ComponentModel.ISupportInitialize)ReportViewGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ReportForWarehousesLabel;
        private CheckedListBox ReportForWarehousesCheckBoxList;
        private Label ToDateLabel;
        private Label FromDateLabel;
        private Label CurrentItemLabel;
        private Button ActionButton;
        private CheckBox WithinRangeDateCheckBox;
        private DateTimePicker ReportEndDateDatePicker;
        private DateTimePicker ReportStartDateDatePicker;
        private DataGridView ReportViewGridView;
    }
}