namespace WarehouseManagmentSystem.WinForms.ReportForms
{
    partial class ItemAtWarehouseSincePeriodReportForm
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
            FromDateLabel = new Label();
            ActionButton = new Button();
            ReportStartDateDatePicker = new DateTimePicker();
            ReportViewGridView = new DataGridView();
            PeriodDaysLabel = new Label();
            PeriodDaysTextBox = new TextBox();
            ChooseDateInsteadCheckBox = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)ReportViewGridView).BeginInit();
            SuspendLayout();
            // 
            // ReportForWarehousesLabel
            // 
            ReportForWarehousesLabel.AutoSize = true;
            ReportForWarehousesLabel.Location = new Point(6, 676);
            ReportForWarehousesLabel.Name = "ReportForWarehousesLabel";
            ReportForWarehousesLabel.Size = new Size(151, 20);
            ReportForWarehousesLabel.TabIndex = 53;
            ReportForWarehousesLabel.Text = "Choose Warehouse(s)";
            // 
            // ReportForWarehousesCheckBoxList
            // 
            ReportForWarehousesCheckBoxList.FormattingEnabled = true;
            ReportForWarehousesCheckBoxList.Location = new Point(209, 663);
            ReportForWarehousesCheckBoxList.Name = "ReportForWarehousesCheckBoxList";
            ReportForWarehousesCheckBoxList.Size = new Size(308, 180);
            ReportForWarehousesCheckBoxList.TabIndex = 52;
            ReportForWarehousesCheckBoxList.ItemCheck += ReportForWarehousesCheckBoxList_ItemCheck;
            // 
            // FromDateLabel
            // 
            FromDateLabel.AutoSize = true;
            FromDateLabel.Location = new Point(582, 821);
            FromDateLabel.Name = "FromDateLabel";
            FromDateLabel.Size = new Size(136, 20);
            FromDateLabel.TabIndex = 50;
            FromDateLabel.Text = "Since Date or after:";
            // 
            // ActionButton
            // 
            ActionButton.Location = new Point(12, 897);
            ActionButton.Name = "ActionButton";
            ActionButton.Size = new Size(271, 56);
            ActionButton.TabIndex = 48;
            ActionButton.Text = "Search";
            ActionButton.UseVisualStyleBackColor = true;
            ActionButton.Click += ActionButton_Click;
            // 
            // ReportStartDateDatePicker
            // 
            ReportStartDateDatePicker.Location = new Point(908, 816);
            ReportStartDateDatePicker.Name = "ReportStartDateDatePicker";
            ReportStartDateDatePicker.Size = new Size(250, 27);
            ReportStartDateDatePicker.TabIndex = 45;
            // 
            // ReportViewGridView
            // 
            ReportViewGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ReportViewGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ReportViewGridView.Dock = DockStyle.Top;
            ReportViewGridView.Location = new Point(0, 0);
            ReportViewGridView.Name = "ReportViewGridView";
            ReportViewGridView.RowHeadersWidth = 51;
            ReportViewGridView.Size = new Size(2335, 555);
            ReportViewGridView.TabIndex = 44;
            ReportViewGridView.CellFormatting += ReportViewGridView_CellFormatting;
            ReportViewGridView.CellPainting += ReportViewGridView_CellPainting;
            ReportViewGridView.DataError += ReportViewGridView_DataError;
            ReportViewGridView.RowPrePaint += ReportViewGridView_RowPrePaint;
            // 
            // PeriodDaysLabel
            // 
            PeriodDaysLabel.AutoSize = true;
            PeriodDaysLabel.Location = new Point(582, 666);
            PeriodDaysLabel.Name = "PeriodDaysLabel";
            PeriodDaysLabel.Size = new Size(157, 20);
            PeriodDaysLabel.TabIndex = 54;
            PeriodDaysLabel.Text = "Maximum Period Days";
            // 
            // PeriodDaysTextBox
            // 
            PeriodDaysTextBox.Location = new Point(908, 663);
            PeriodDaysTextBox.Name = "PeriodDaysTextBox";
            PeriodDaysTextBox.Size = new Size(125, 27);
            PeriodDaysTextBox.TabIndex = 55;
            // 
            // ChooseDateInsteadCheckBox
            // 
            ChooseDateInsteadCheckBox.AutoSize = true;
            ChooseDateInsteadCheckBox.Location = new Point(582, 734);
            ChooseDateInsteadCheckBox.Name = "ChooseDateInsteadCheckBox";
            ChooseDateInsteadCheckBox.Size = new Size(168, 24);
            ChooseDateInsteadCheckBox.TabIndex = 56;
            ChooseDateInsteadCheckBox.Text = "Choose Date Instead";
            ChooseDateInsteadCheckBox.UseVisualStyleBackColor = true;
            ChooseDateInsteadCheckBox.CheckStateChanged += ChooseDateCheckBox_ChechStateChanged;
            // 
            // ItemAtWarehouseSincePeriodReportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2335, 1143);
            Controls.Add(ChooseDateInsteadCheckBox);
            Controls.Add(PeriodDaysTextBox);
            Controls.Add(PeriodDaysLabel);
            Controls.Add(ReportForWarehousesLabel);
            Controls.Add(ReportForWarehousesCheckBoxList);
            Controls.Add(FromDateLabel);
            Controls.Add(ActionButton);
            Controls.Add(ReportStartDateDatePicker);
            Controls.Add(ReportViewGridView);
            Name = "ItemAtWarehouseSincePeriodReportForm";
            Text = "ItemAtWarehouseSincePeriodReportForm";
            Load += ItemAtWarehouseSincePeriodReportForm_Load;
            ((System.ComponentModel.ISupportInitialize)ReportViewGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ReportForWarehousesLabel;
        private CheckedListBox ReportForWarehousesCheckBoxList;
        private Label FromDateLabel;
        private Button ActionButton;
        private DateTimePicker ReportStartDateDatePicker;
        private DataGridView ReportViewGridView;
        private Label PeriodDaysLabel;
        private TextBox PeriodDaysTextBox;
        private CheckBox ChooseDateInsteadCheckBox;
    }
}