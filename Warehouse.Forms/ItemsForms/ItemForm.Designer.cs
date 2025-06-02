namespace WarehouseManagmentSystem.WinForms
{
    partial class ItemForm
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
            ItemsDataGridView = new DataGridView();
            AddItemButton = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            ItemCodeLabel = new Label();
            ItemCodeTextBox = new TextBox();
            ItemNameLabel = new Label();
            ItemNameTextBox = new TextBox();
            ItemMeasuringUnitsLabel = new Label();
            ItemMeasuringUnitsCheckList = new CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)ItemsDataGridView).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // ItemsDataGridView
            // 
            ItemsDataGridView.AccessibleName = "ItemsDataGridView";
            ItemsDataGridView.AllowUserToAddRows = false;
            ItemsDataGridView.AllowUserToDeleteRows = false;
            ItemsDataGridView.AllowUserToOrderColumns = true;
            ItemsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ItemsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ItemsDataGridView.Dock = DockStyle.Top;
            ItemsDataGridView.Location = new Point(0, 0);
            ItemsDataGridView.Name = "ItemsDataGridView";
            ItemsDataGridView.ReadOnly = true;
            ItemsDataGridView.RowHeadersWidth = 51;
            ItemsDataGridView.Size = new Size(2334, 420);
            ItemsDataGridView.TabIndex = 6;
            // 
            // AddItemButton
            // 
            AddItemButton.AccessibleName = "AddItemButton";
            AddItemButton.Location = new Point(867, 240);
            AddItemButton.Name = "AddItemButton";
            AddItemButton.Size = new Size(174, 29);
            AddItemButton.TabIndex = 7;
            AddItemButton.Text = "Add Item";
            AddItemButton.UseVisualStyleBackColor = true;
            AddItemButton.Click += AddItemButton_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 8;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.781694F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.29746437F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21.39765F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.658009F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.29746437F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21.5213356F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.Controls.Add(ItemCodeLabel, 4, 1);
            tableLayoutPanel1.Controls.Add(ItemCodeTextBox, 5, 1);
            tableLayoutPanel1.Controls.Add(AddItemButton, 5, 3);
            tableLayoutPanel1.Controls.Add(ItemNameLabel, 0, 1);
            tableLayoutPanel1.Controls.Add(ItemNameTextBox, 2, 1);
            tableLayoutPanel1.Controls.Add(ItemMeasuringUnitsLabel, 0, 3);
            tableLayoutPanel1.Controls.Add(ItemMeasuringUnitsCheckList, 2, 3);
            tableLayoutPanel1.Font = new Font("Segoe UI", 10F);
            tableLayoutPanel1.Location = new Point(0, 450);
            tableLayoutPanel1.Margin = new Padding(10, 3, 3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 19.4260483F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 47.46137F));
            tableLayoutPanel1.Size = new Size(1617, 453);
            tableLayoutPanel1.TabIndex = 18;
            // 
            // ItemCodeLabel
            // 
            ItemCodeLabel.AccessibleName = "ItemCodeLabel";
            ItemCodeLabel.AutoSize = true;
            ItemCodeLabel.Location = new Point(749, 75);
            ItemCodeLabel.Name = "ItemCodeLabel";
            ItemCodeLabel.Size = new Size(50, 23);
            ItemCodeLabel.TabIndex = 11;
            ItemCodeLabel.Text = "Code";
            // 
            // ItemCodeTextBox
            // 
            ItemCodeTextBox.AccessibleName = "ItemCodeTextBox";
            ItemCodeTextBox.Location = new Point(867, 78);
            ItemCodeTextBox.Name = "ItemCodeTextBox";
            ItemCodeTextBox.Size = new Size(339, 30);
            ItemCodeTextBox.TabIndex = 9;
            // 
            // ItemNameLabel
            // 
            ItemNameLabel.AccessibleName = "ItemNameLabel";
            ItemNameLabel.AutoSize = true;
            ItemNameLabel.Location = new Point(3, 75);
            ItemNameLabel.Name = "ItemNameLabel";
            ItemNameLabel.Size = new Size(56, 23);
            ItemNameLabel.TabIndex = 12;
            ItemNameLabel.Text = "Name";
            // 
            // ItemNameTextBox
            // 
            ItemNameTextBox.AccessibleName = "ItemNameTextBox";
            ItemNameTextBox.Location = new Point(263, 78);
            ItemNameTextBox.Name = "ItemNameTextBox";
            ItemNameTextBox.Size = new Size(340, 30);
            ItemNameTextBox.TabIndex = 10;
            // 
            // ItemMeasuringUnitsLabel
            // 
            ItemMeasuringUnitsLabel.AccessibleName = "ItemMeasuringUnitsLabel";
            ItemMeasuringUnitsLabel.AutoSize = true;
            ItemMeasuringUnitsLabel.Location = new Point(3, 237);
            ItemMeasuringUnitsLabel.Name = "ItemMeasuringUnitsLabel";
            ItemMeasuringUnitsLabel.Size = new Size(134, 23);
            ItemMeasuringUnitsLabel.TabIndex = 13;
            ItemMeasuringUnitsLabel.Text = "Measuring Units";
            // 
            // ItemMeasuringUnitsCheckList
            // 
            ItemMeasuringUnitsCheckList.AccessibleName = "ItemMeasuringUnitsCheckList";
            ItemMeasuringUnitsCheckList.AllowDrop = true;
            ItemMeasuringUnitsCheckList.CheckOnClick = true;
            ItemMeasuringUnitsCheckList.FormattingEnabled = true;
            ItemMeasuringUnitsCheckList.HorizontalScrollbar = true;
            ItemMeasuringUnitsCheckList.Location = new Point(263, 240);
            ItemMeasuringUnitsCheckList.Name = "ItemMeasuringUnitsCheckList";
            ItemMeasuringUnitsCheckList.Size = new Size(340, 204);
            ItemMeasuringUnitsCheckList.TabIndex = 16;
            ItemMeasuringUnitsCheckList.ItemCheck += ItemMeasuringUnitsCheckList_ItemCheck;
            // 
            // ItemForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(2334, 1152);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(ItemsDataGridView);
            Name = "ItemForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Item";
            WindowState = FormWindowState.Maximized;
            Load += ItemForm_Load;
            ((System.ComponentModel.ISupportInitialize)ItemsDataGridView).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView ItemsDataGridView;
        private Button AddItemButton;
        private TableLayoutPanel tableLayoutPanel1;
        private Label ItemCodeLabel;
        private TextBox ItemCodeTextBox;
        private Label ItemNameLabel;
        private TextBox ItemNameTextBox;
        private Label ItemMeasuringUnitsLabel;
        private CheckedListBox ItemMeasuringUnitsCheckList;
    }
}