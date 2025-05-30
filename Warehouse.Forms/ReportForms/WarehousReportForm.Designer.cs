namespace WarehouseManagmentSystem.WinForms.ReportForms
{
    partial class WarehousReportForm
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
            ReportForComboBox = new ComboBox();
            ActionButton = new Button();
            WithinRangeDateCheckBox = new CheckBox();
            ReportEndDateDatePicker = new DateTimePicker();
            ReportStartDateDatePicker = new DateTimePicker();
            ToDateLabel = new Label();
            ReportForLabel = new Label();
            FromDateLabel = new Label();
            ReportViewGridView = new DataGridView();
            CurrentWarehouseLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)ReportViewGridView).BeginInit();
            SuspendLayout();
            // 
            // ReportForComboBox
            // 
            ReportForComboBox.FormattingEnabled = true;
            ReportForComboBox.Location = new Point(225, 669);
            ReportForComboBox.Name = "ReportForComboBox";
            ReportForComboBox.Size = new Size(250, 28);
            ReportForComboBox.TabIndex = 18;
            ReportForComboBox.SelectedIndexChanged += ReportForComboBox_SelectedIndexChanged;
            // 
            // ActionButton
            // 
            ActionButton.Location = new Point(1129, 879);
            ActionButton.Name = "ActionButton";
            ActionButton.Size = new Size(271, 56);
            ActionButton.TabIndex = 17;
            ActionButton.Text = "Display";
            ActionButton.UseVisualStyleBackColor = true;
            ActionButton.Click += ActionButton_Click;
            // 
            // WithinRangeDateCheckBox
            // 
            WithinRangeDateCheckBox.AutoSize = true;
            WithinRangeDateCheckBox.Location = new Point(71, 744);
            WithinRangeDateCheckBox.Name = "WithinRangeDateCheckBox";
            WithinRangeDateCheckBox.Size = new Size(157, 24);
            WithinRangeDateCheckBox.TabIndex = 16;
            WithinRangeDateCheckBox.Text = "Within Time Range";
            WithinRangeDateCheckBox.UseVisualStyleBackColor = true;
            WithinRangeDateCheckBox.CheckedChanged += WithinRangeDateCheckBox_CheckStateChanged;
            // 
            // ReportEndDateDatePicker
            // 
            ReportEndDateDatePicker.Location = new Point(225, 862);
            ReportEndDateDatePicker.Name = "ReportEndDateDatePicker";
            ReportEndDateDatePicker.Size = new Size(250, 27);
            ReportEndDateDatePicker.TabIndex = 15;
            // 
            // ReportStartDateDatePicker
            // 
            ReportStartDateDatePicker.Location = new Point(225, 806);
            ReportStartDateDatePicker.Name = "ReportStartDateDatePicker";
            ReportStartDateDatePicker.Size = new Size(250, 27);
            ReportStartDateDatePicker.TabIndex = 14;
            // 
            // ToDateLabel
            // 
            ToDateLabel.AutoSize = true;
            ToDateLabel.Location = new Point(71, 867);
            ToDateLabel.Name = "ToDateLabel";
            ToDateLabel.Size = new Size(28, 20);
            ToDateLabel.TabIndex = 13;
            ToDateLabel.Text = "To:";
            // 
            // ReportForLabel
            // 
            ReportForLabel.AutoSize = true;
            ReportForLabel.Location = new Point(71, 672);
            ReportForLabel.Name = "ReportForLabel";
            ReportForLabel.Size = new Size(82, 20);
            ReportForLabel.TabIndex = 12;
            ReportForLabel.Text = "Warehouse";
            // 
            // FromDateLabel
            // 
            FromDateLabel.AutoSize = true;
            FromDateLabel.Location = new Point(71, 811);
            FromDateLabel.Name = "FromDateLabel";
            FromDateLabel.Size = new Size(77, 20);
            FromDateLabel.TabIndex = 11;
            FromDateLabel.Text = "Start date:";
            // 
            // ReportViewGridView
            // 
            ReportViewGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ReportViewGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ReportViewGridView.Dock = DockStyle.Top;
            ReportViewGridView.Location = new Point(0, 0);
            ReportViewGridView.Name = "ReportViewGridView";
            ReportViewGridView.RowHeadersWidth = 51;
            ReportViewGridView.Size = new Size(2322, 555);
            ReportViewGridView.TabIndex = 10;
            ReportViewGridView.CellFormatting += ReportViewGridView_CellFormatting;
            ReportViewGridView.CellPainting += ReportViewGridView_CellPainting;
            ReportViewGridView.DataError += ReportViewGridView_DataError;
            ReportViewGridView.RowPrePaint += ReportViewGridView_RowPrePaint;
            // 
            // CurrentWarehouseLabel
            // 
            CurrentWarehouseLabel.AutoSize = true;
            CurrentWarehouseLabel.Location = new Point(1056, 703);
            CurrentWarehouseLabel.Name = "CurrentWarehouseLabel";
            CurrentWarehouseLabel.Size = new Size(0, 20);
            CurrentWarehouseLabel.TabIndex = 19;
            // 
            // WarehousReportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(2322, 1106);
            Controls.Add(CurrentWarehouseLabel);
            Controls.Add(ReportForComboBox);
            Controls.Add(ActionButton);
            Controls.Add(WithinRangeDateCheckBox);
            Controls.Add(ReportEndDateDatePicker);
            Controls.Add(ReportStartDateDatePicker);
            Controls.Add(ToDateLabel);
            Controls.Add(ReportForLabel);
            Controls.Add(FromDateLabel);
            Controls.Add(ReportViewGridView);
            Name = "WarehousReportForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WarehousReportForm";
            WindowState = FormWindowState.Maximized;
            Load += WarehousReportForm_LoadAsync;
            ((System.ComponentModel.ISupportInitialize)ReportViewGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label CurrentWarehouseLabel;
        private ComboBox ReportForComboBox;
        private Button ActionButton;
        private CheckBox WithinRangeDateCheckBox;
        private DateTimePicker ReportEndDateDatePicker;
        private DateTimePicker ReportStartDateDatePicker;
        private Label ToDateLabel;
        private Label ReportForLabel;
        private Label FromDateLabel;
        private DataGridView ReportViewGridView;
    }
}