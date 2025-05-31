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
            ChooseDateInsteadCheckBox = new CheckBox();
            PeriodDaysTextBox = new TextBox();
            PeriodDaysLabel = new Label();
            ReportForWarehousesCheckBoxList = new CheckedListBox();
            FromDateLabel = new Label();
            ActionButton = new Button();
            ReportStartDateDatePicker = new DateTimePicker();
            ReportViewGridView = new DataGridView();
            ReportForWarehousesLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)ReportViewGridView).BeginInit();
            SuspendLayout();
            // 
            // ChooseDateInsteadCheckBox
            // 
            ChooseDateInsteadCheckBox.AutoSize = true;
            ChooseDateInsteadCheckBox.Location = new Point(562, 697);
            ChooseDateInsteadCheckBox.Name = "ChooseDateInsteadCheckBox";
            ChooseDateInsteadCheckBox.Size = new Size(168, 24);
            ChooseDateInsteadCheckBox.TabIndex = 64;
            ChooseDateInsteadCheckBox.Text = "Choose Date Instead";
            ChooseDateInsteadCheckBox.UseVisualStyleBackColor = true;
            ChooseDateInsteadCheckBox.CheckStateChanged += ChooseDateCheckBox_ChechStateChanged;
            // 
            // PeriodDaysTextBox
            // 
            PeriodDaysTextBox.Location = new Point(888, 626);
            PeriodDaysTextBox.Name = "PeriodDaysTextBox";
            PeriodDaysTextBox.Size = new Size(125, 27);
            PeriodDaysTextBox.TabIndex = 63;
            // 
            // PeriodDaysLabel
            // 
            PeriodDaysLabel.AutoSize = true;
            PeriodDaysLabel.Location = new Point(562, 629);
            PeriodDaysLabel.Name = "PeriodDaysLabel";
            PeriodDaysLabel.Size = new Size(157, 20);
            PeriodDaysLabel.TabIndex = 62;
            PeriodDaysLabel.Text = "Maximum Period Days";
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
            // FromDateLabel
            // 
            FromDateLabel.AutoSize = true;
            FromDateLabel.Location = new Point(562, 784);
            FromDateLabel.Name = "FromDateLabel";
            FromDateLabel.Size = new Size(136, 20);
            FromDateLabel.TabIndex = 60;
            FromDateLabel.Text = "Since Date or after:";
            // 
            // ActionButton
            // 
            ActionButton.Location = new Point(189, 905);
            ActionButton.Name = "ActionButton";
            ActionButton.Size = new Size(271, 56);
            ActionButton.TabIndex = 59;
            ActionButton.Text = "Search";
            ActionButton.UseVisualStyleBackColor = true;
            ActionButton.Click += ActionButton_Click;
            // 
            // ReportStartDateDatePicker
            // 
            ReportStartDateDatePicker.Location = new Point(888, 779);
            ReportStartDateDatePicker.Name = "ReportStartDateDatePicker";
            ReportStartDateDatePicker.Size = new Size(250, 27);
            ReportStartDateDatePicker.TabIndex = 58;
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
            Controls.Add(ChooseDateInsteadCheckBox);
            Controls.Add(PeriodDaysTextBox);
            Controls.Add(PeriodDaysLabel);
            Controls.Add(ReportForWarehousesCheckBoxList);
            Controls.Add(FromDateLabel);
            Controls.Add(ActionButton);
            Controls.Add(ReportStartDateDatePicker);
            Controls.Add(ReportViewGridView);
            Name = "ItemAtWarehouseDaysTillExpirationReportForm";
            Text = "ItemAtWarehouseDaysTillExpirationReport";
            Load += ItemAtWarehouseDaysTillExpirationReportForm_Load;
            ((System.ComponentModel.ISupportInitialize)ReportViewGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox ChooseDateInsteadCheckBox;
        private TextBox PeriodDaysTextBox;
        private Label PeriodDaysLabel;
        private CheckedListBox ReportForWarehousesCheckBoxList;
        private Label FromDateLabel;
        private Button ActionButton;
        private DateTimePicker ReportStartDateDatePicker;
        private DataGridView ReportViewGridView;
        private Label ReportForWarehousesLabel;
    }
}