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
            ((System.ComponentModel.ISupportInitialize)warehouseDataGridView).BeginInit();
            SuspendLayout();
            // 
            // warehouseDataGridView
            // 
            warehouseDataGridView.AccessibleName = "warehouseDataGridView";
            warehouseDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            warehouseDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            warehouseDataGridView.Location = new Point(596, 12);
            warehouseDataGridView.Name = "warehouseDataGridView";
            warehouseDataGridView.RowHeadersWidth = 51;
            warehouseDataGridView.Size = new Size(828, 435);
            warehouseDataGridView.TabIndex = 0;
            // 
            // WarehouseNameTextBox
            // 
            WarehouseNameTextBox.AccessibleName = "WarehouseNameTextBox";
            WarehouseNameTextBox.Location = new Point(191, 65);
            WarehouseNameTextBox.Name = "WarehouseNameTextBox";
            WarehouseNameTextBox.Size = new Size(150, 27);
            WarehouseNameTextBox.TabIndex = 1;
            // 
            // WarehouseAddressTextBox
            // 
            WarehouseAddressTextBox.AccessibleName = "WarehouseAddressTextBox";
            WarehouseAddressTextBox.Location = new Point(191, 161);
            WarehouseAddressTextBox.Name = "WarehouseAddressTextBox";
            WarehouseAddressTextBox.Size = new Size(150, 27);
            WarehouseAddressTextBox.TabIndex = 2;
            // 
            // btnAddWarehouse
            // 
            btnAddWarehouse.AccessibleName = "btnAddWarehouse";
            btnAddWarehouse.Location = new Point(931, 513);
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
            WarehouseNameLabel.Location = new Point(25, 72);
            WarehouseNameLabel.Name = "WarehouseNameLabel";
            WarehouseNameLabel.Size = new Size(49, 20);
            WarehouseNameLabel.TabIndex = 4;
            WarehouseNameLabel.Text = "Name";
            // 
            // WarehouseAddressLabel
            // 
            WarehouseAddressLabel.AccessibleName = "WarehouseAddressLabel";
            WarehouseAddressLabel.AutoSize = true;
            WarehouseAddressLabel.Location = new Point(25, 168);
            WarehouseAddressLabel.Name = "WarehouseAddressLabel";
            WarehouseAddressLabel.Size = new Size(62, 20);
            WarehouseAddressLabel.TabIndex = 5;
            WarehouseAddressLabel.Text = "Address";
            // 
            // AssignManagerLabel
            // 
            AssignManagerLabel.AccessibleName = "AssignManagerLabel";
            AssignManagerLabel.AutoSize = true;
            AssignManagerLabel.Location = new Point(25, 325);
            AssignManagerLabel.Name = "AssignManagerLabel";
            AssignManagerLabel.Size = new Size(115, 20);
            AssignManagerLabel.TabIndex = 6;
            AssignManagerLabel.Text = "Assign Manager";
            // 
            // WarehouseManagerComboBox
            // 
            WarehouseManagerComboBox.AccessibleName = "WarehouseManagerComboBox";
            WarehouseManagerComboBox.FormattingEnabled = true;
            WarehouseManagerComboBox.Location = new Point(191, 325);
            WarehouseManagerComboBox.Name = "WarehouseManagerComboBox";
            WarehouseManagerComboBox.Size = new Size(150, 28);
            WarehouseManagerComboBox.TabIndex = 7;
            // 
            // AssignManagerCheckBox
            // 
            AssignManagerCheckBox.AutoSize = true;
            AssignManagerCheckBox.Location = new Point(25, 282);
            AssignManagerCheckBox.Name = "AssignManagerCheckBox";
            AssignManagerCheckBox.Size = new Size(137, 24);
            AssignManagerCheckBox.TabIndex = 8;
            AssignManagerCheckBox.Text = "Assign Manager";
            AssignManagerCheckBox.UseVisualStyleBackColor = true;
            AssignManagerCheckBox.CheckStateChanged += AssignManagerCheckBox_CheckStateChanged;
            // 
            // WarehouseForm
            // 
            AccessibleName = "WarehouseForm";
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(2313, 1152);
            Controls.Add(AssignManagerCheckBox);
            Controls.Add(WarehouseManagerComboBox);
            Controls.Add(AssignManagerLabel);
            Controls.Add(WarehouseAddressLabel);
            Controls.Add(WarehouseNameLabel);
            Controls.Add(btnAddWarehouse);
            Controls.Add(WarehouseAddressTextBox);
            Controls.Add(WarehouseNameTextBox);
            Controls.Add(warehouseDataGridView);
            Name = "WarehouseForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Warehouses";
            WindowState = FormWindowState.Maximized;
            Load += WarehouseForm_Load;
            ((System.ComponentModel.ISupportInitialize)warehouseDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
    }
}
