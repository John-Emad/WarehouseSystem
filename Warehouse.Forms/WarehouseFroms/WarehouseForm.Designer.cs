namespace WarehouseManagmentSystem.WinForms.Forms
{
    partial class WarehouseForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            warehouseDataGridView = new DataGridView();
            WarehouseNameTextBox = new TextBox();
            WarehouseAddressTextBox = new TextBox();
            btnAddWarehouse = new Button();
            WarehouseNameLabel = new Label();
            WarehouseAddressLabel = new Label();
            AssignManagerLabel = new Label();
            WarehouseManagerComboBox = new ComboBox();
            AssignManagerCheckBox = new CheckBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)warehouseDataGridView).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // warehouseDataGridView
            // 
            warehouseDataGridView.AccessibleName = "warehouseDataGridView";
            warehouseDataGridView.AllowUserToAddRows = false;
            warehouseDataGridView.AllowUserToDeleteRows = false;
            warehouseDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            warehouseDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            warehouseDataGridView.Dock = DockStyle.Top;
            warehouseDataGridView.Location = new Point(0, 0);
            warehouseDataGridView.Name = "warehouseDataGridView";
            warehouseDataGridView.RowHeadersWidth = 51;
            warehouseDataGridView.Size = new Size(2313, 418);
            warehouseDataGridView.TabIndex = 0;
            // 
            // WarehouseNameTextBox
            // 
            WarehouseNameTextBox.AccessibleName = "WarehouseNameTextBox";
            WarehouseNameTextBox.Location = new Point(307, 3);
            WarehouseNameTextBox.Name = "WarehouseNameTextBox";
            WarehouseNameTextBox.Size = new Size(302, 30);
            WarehouseNameTextBox.TabIndex = 1;
            // 
            // WarehouseAddressTextBox
            // 
            WarehouseAddressTextBox.AccessibleName = "WarehouseAddressTextBox";
            WarehouseAddressTextBox.Location = new Point(307, 99);
            WarehouseAddressTextBox.Name = "WarehouseAddressTextBox";
            WarehouseAddressTextBox.Size = new Size(302, 30);
            WarehouseAddressTextBox.TabIndex = 2;
            // 
            // btnAddWarehouse
            // 
            btnAddWarehouse.AccessibleName = "btnAddWarehouse";
            btnAddWarehouse.Location = new Point(819, 243);
            btnAddWarehouse.Name = "btnAddWarehouse";
            btnAddWarehouse.Size = new Size(177, 29);
            btnAddWarehouse.TabIndex = 3;
            btnAddWarehouse.Text = "Add Warehouse";
            btnAddWarehouse.UseVisualStyleBackColor = true;
            btnAddWarehouse.Click += btnAddWarehouse_Click;
            // 
            // WarehouseNameLabel
            // 
            WarehouseNameLabel.AccessibleName = "WarehouseNameLabel";
            WarehouseNameLabel.AutoSize = true;
            WarehouseNameLabel.Location = new Point(3, 0);
            WarehouseNameLabel.Name = "WarehouseNameLabel";
            WarehouseNameLabel.Size = new Size(56, 23);
            WarehouseNameLabel.TabIndex = 4;
            WarehouseNameLabel.Text = "Name";
            // 
            // WarehouseAddressLabel
            // 
            WarehouseAddressLabel.AccessibleName = "WarehouseAddressLabel";
            WarehouseAddressLabel.AutoSize = true;
            WarehouseAddressLabel.Location = new Point(3, 96);
            WarehouseAddressLabel.Name = "WarehouseAddressLabel";
            WarehouseAddressLabel.Size = new Size(70, 23);
            WarehouseAddressLabel.TabIndex = 5;
            WarehouseAddressLabel.Text = "Address";
            // 
            // AssignManagerLabel
            // 
            AssignManagerLabel.AccessibleName = "AssignManagerLabel";
            AssignManagerLabel.AutoSize = true;
            AssignManagerLabel.Location = new Point(3, 288);
            AssignManagerLabel.Name = "AssignManagerLabel";
            AssignManagerLabel.Size = new Size(132, 23);
            AssignManagerLabel.TabIndex = 6;
            AssignManagerLabel.Text = "Assign Manager";
            // 
            // WarehouseManagerComboBox
            // 
            WarehouseManagerComboBox.AccessibleName = "WarehouseManagerComboBox";
            WarehouseManagerComboBox.FormattingEnabled = true;
            WarehouseManagerComboBox.Location = new Point(307, 291);
            WarehouseManagerComboBox.Name = "WarehouseManagerComboBox";
            WarehouseManagerComboBox.Size = new Size(302, 31);
            WarehouseManagerComboBox.TabIndex = 7;
            // 
            // AssignManagerCheckBox
            // 
            AssignManagerCheckBox.AutoSize = true;
            AssignManagerCheckBox.Location = new Point(3, 195);
            AssignManagerCheckBox.Name = "AssignManagerCheckBox";
            AssignManagerCheckBox.Size = new Size(154, 27);
            AssignManagerCheckBox.TabIndex = 8;
            AssignManagerCheckBox.Text = "Assign Manager";
            AssignManagerCheckBox.UseVisualStyleBackColor = true;
            AssignManagerCheckBox.CheckStateChanged += AssignManagerCheckBox_CheckStateChanged;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.14996F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.1018753F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.Controls.Add(WarehouseNameLabel, 0, 0);
            tableLayoutPanel1.Controls.Add(WarehouseManagerComboBox, 2, 6);
            tableLayoutPanel1.Controls.Add(AssignManagerCheckBox, 0, 4);
            tableLayoutPanel1.Controls.Add(AssignManagerLabel, 0, 6);
            tableLayoutPanel1.Controls.Add(WarehouseAddressLabel, 0, 2);
            tableLayoutPanel1.Controls.Add(WarehouseNameTextBox, 2, 0);
            tableLayoutPanel1.Controls.Add(btnAddWarehouse, 4, 5);
            tableLayoutPanel1.Controls.Add(WarehouseAddressTextBox, 2, 2);
            tableLayoutPanel1.Font = new Font("Segoe UI", 10F);
            tableLayoutPanel1.Location = new Point(0, 450);
            tableLayoutPanel1.Margin = new Padding(10, 3, 3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.Size = new Size(1227, 389);
            tableLayoutPanel1.TabIndex = 9;
            // 
            // WarehouseForm
            // 
            AccessibleName = "WarehouseForm";
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(2313, 1152);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(warehouseDataGridView);
            Name = "WarehouseForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Warehouse";
            WindowState = FormWindowState.Maximized;
            Load += WarehouseForm_Load;
            ((System.ComponentModel.ISupportInitialize)warehouseDataGridView).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView warehouseDataGridView;
        private TextBox WarehouseNameTextBox;
        private TextBox WarehouseAddressTextBox;
        private Button btnAddWarehouse;
        private Label WarehouseNameLabel;
        private Label WarehouseAddressLabel;
        private Label AssignManagerLabel;
        private ComboBox WarehouseManagerComboBox;
        private CheckBox AssignManagerCheckBox;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
