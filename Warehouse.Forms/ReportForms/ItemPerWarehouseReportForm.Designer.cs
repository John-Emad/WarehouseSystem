namespace WarehouseManagmentSystem.WinForms.ReportForms
{
    partial class ItemPerWarehouseReportForm
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
            CurrentItemLabel = new Label();
            ReportForItemsComboBox = new ComboBox();
            ActionButton = new Button();
            WithinRangeDateCheckBox = new CheckBox();
            ReportEndDateDatePicker = new DateTimePicker();
            ReportStartDateDatePicker = new DateTimePicker();
            ReportViewGridView = new DataGridView();
            ReportForItemsLabel = new Label();
            FromDateLabel = new Label();
            ToDateLabel = new Label();
            ReportForWarehousesCheckBoxList = new CheckedListBox();
            ReportForWarehousesLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)ReportViewGridView).BeginInit();
            SuspendLayout();
            // 
            // CurrentItemLabel
            // 
            CurrentItemLabel.AutoSize = true;
            CurrentItemLabel.Location = new Point(1569, 629);
            CurrentItemLabel.Name = "CurrentItemLabel";
            CurrentItemLabel.Size = new Size(0, 20);
            CurrentItemLabel.TabIndex = 26;
            // 
            // ReportForItemsComboBox
            // 
            ReportForItemsComboBox.FormattingEnabled = true;
            ReportForItemsComboBox.Location = new Point(825, 731);
            ReportForItemsComboBox.Name = "ReportForItemsComboBox";
            ReportForItemsComboBox.Size = new Size(250, 28);
            ReportForItemsComboBox.TabIndex = 25;
            ReportForItemsComboBox.SelectedIndexChanged += ReportForItemsComboBox_SelectedIndexChanged;
            // 
            // ActionButton
            // 
            ActionButton.Location = new Point(1309, 883);
            ActionButton.Name = "ActionButton";
            ActionButton.Size = new Size(271, 56);
            ActionButton.TabIndex = 24;
            ActionButton.Text = "Search";
            ActionButton.UseVisualStyleBackColor = true;
            ActionButton.Click += ActionButton_Click;
            // 
            // WithinRangeDateCheckBox
            // 
            WithinRangeDateCheckBox.AutoSize = true;
            WithinRangeDateCheckBox.Location = new Point(707, 788);
            WithinRangeDateCheckBox.Name = "WithinRangeDateCheckBox";
            WithinRangeDateCheckBox.Size = new Size(157, 24);
            WithinRangeDateCheckBox.TabIndex = 23;
            WithinRangeDateCheckBox.Text = "Within Time Range";
            WithinRangeDateCheckBox.UseVisualStyleBackColor = true;
            WithinRangeDateCheckBox.CheckStateChanged += WithinRangeDateCheckBox_CheckStateChanged;
            // 
            // ReportEndDateDatePicker
            // 
            ReportEndDateDatePicker.Location = new Point(825, 897);
            ReportEndDateDatePicker.Name = "ReportEndDateDatePicker";
            ReportEndDateDatePicker.Size = new Size(250, 27);
            ReportEndDateDatePicker.TabIndex = 22;
            // 
            // ReportStartDateDatePicker
            // 
            ReportStartDateDatePicker.Location = new Point(825, 841);
            ReportStartDateDatePicker.Name = "ReportStartDateDatePicker";
            ReportStartDateDatePicker.Size = new Size(250, 27);
            ReportStartDateDatePicker.TabIndex = 21;
            // 
            // ReportViewGridView
            // 
            ReportViewGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ReportViewGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ReportViewGridView.Dock = DockStyle.Top;
            ReportViewGridView.Location = new Point(0, 0);
            ReportViewGridView.Name = "ReportViewGridView";
            ReportViewGridView.RowHeadersWidth = 51;
            ReportViewGridView.Size = new Size(2319, 659);
            ReportViewGridView.TabIndex = 20;
            ReportViewGridView.CellFormatting += ReportViewGridView_CellFormatting;
            ReportViewGridView.CellPainting += ReportViewGridView_CellPainting;
            ReportViewGridView.DataError += ReportViewGridView_DataError;
            ReportViewGridView.RowPrePaint += ReportViewGridView_RowPrePaint;
            // 
            // ReportForItemsLabel
            // 
            ReportForItemsLabel.AutoSize = true;
            ReportForItemsLabel.Location = new Point(707, 734);
            ReportForItemsLabel.Name = "ReportForItemsLabel";
            ReportForItemsLabel.Size = new Size(39, 20);
            ReportForItemsLabel.TabIndex = 27;
            ReportForItemsLabel.Text = "Item";
            // 
            // FromDateLabel
            // 
            FromDateLabel.AutoSize = true;
            FromDateLabel.Location = new Point(707, 846);
            FromDateLabel.Name = "FromDateLabel";
            FromDateLabel.Size = new Size(81, 20);
            FromDateLabel.TabIndex = 28;
            FromDateLabel.Text = "Start From:";
            // 
            // ToDateLabel
            // 
            ToDateLabel.AutoSize = true;
            ToDateLabel.Location = new Point(707, 902);
            ToDateLabel.Name = "ToDateLabel";
            ToDateLabel.Size = new Size(32, 20);
            ToDateLabel.TabIndex = 29;
            ToDateLabel.Text = "To: ";
            // 
            // ReportForWarehousesCheckBoxList
            // 
            ReportForWarehousesCheckBoxList.FormattingEnabled = true;
            ReportForWarehousesCheckBoxList.Location = new Point(199, 727);
            ReportForWarehousesCheckBoxList.Name = "ReportForWarehousesCheckBoxList";
            ReportForWarehousesCheckBoxList.Size = new Size(308, 180);
            ReportForWarehousesCheckBoxList.TabIndex = 30;
            ReportForWarehousesCheckBoxList.ItemCheck += ReportForWarehousesCheckBoxList_ItemCheck;
            // 
            // ReportForWarehousesLabel
            // 
            ReportForWarehousesLabel.AutoSize = true;
            ReportForWarehousesLabel.Location = new Point(22, 734);
            ReportForWarehousesLabel.Name = "ReportForWarehousesLabel";
            ReportForWarehousesLabel.Size = new Size(151, 20);
            ReportForWarehousesLabel.TabIndex = 31;
            ReportForWarehousesLabel.Text = "Choose Warehouse(s)";
            // 
            // ItemReportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2319, 1131);
            Controls.Add(ReportForWarehousesLabel);
            Controls.Add(ReportForWarehousesCheckBoxList);
            Controls.Add(ToDateLabel);
            Controls.Add(FromDateLabel);
            Controls.Add(ReportForItemsLabel);
            Controls.Add(CurrentItemLabel);
            Controls.Add(ReportForItemsComboBox);
            Controls.Add(ActionButton);
            Controls.Add(WithinRangeDateCheckBox);
            Controls.Add(ReportEndDateDatePicker);
            Controls.Add(ReportStartDateDatePicker);
            Controls.Add(ReportViewGridView);
            Name = "ItemReportForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Item per warehouse";
            WindowState = FormWindowState.Maximized;
            Load += ItemReportForm_Load;
            ((System.ComponentModel.ISupportInitialize)ReportViewGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label CurrentItemLabel;
        private ComboBox ReportForItemsComboBox;
        private Button ActionButton;
        private CheckBox WithinRangeDateCheckBox;
        private DateTimePicker ReportEndDateDatePicker;
        private DateTimePicker ReportStartDateDatePicker;
        private DataGridView ReportViewGridView;
        private Label ReportForItemsLabel;
        private Label FromDateLabel;
        private Label ToDateLabel;
        private CheckedListBox ReportForWarehousesCheckBoxList;
        private Label ReportForWarehousesLabel;
    }
}