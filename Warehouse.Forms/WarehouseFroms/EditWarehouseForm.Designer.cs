namespace WarehouseManagmentSystem.WinForms.WarehouseFroms
{
    partial class EditWarehouseForm
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
            AssignManagerCheckBox = new CheckBox();
            WarehouseManagerComboBox = new ComboBox();
            AssignManagerLabel = new Label();
            WarehouseAddressLabel = new Label();
            WarehouseNameLabel = new Label();
            btnEditWarehouse = new Button();
            WarehouseAddressTextBox = new TextBox();
            WarehouseNameTextBox = new TextBox();
            warehouseDataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)warehouseDataGridView).BeginInit();
            SuspendLayout();
            // 
            // AssignManagerCheckBox
            // 
            AssignManagerCheckBox.AutoSize = true;
            AssignManagerCheckBox.Location = new Point(7, 278);
            AssignManagerCheckBox.Name = "AssignManagerCheckBox";
            AssignManagerCheckBox.Size = new Size(137, 24);
            AssignManagerCheckBox.TabIndex = 17;
            AssignManagerCheckBox.Text = "Assign Manager";
            AssignManagerCheckBox.UseVisualStyleBackColor = true;
            AssignManagerCheckBox.CheckStateChanged += AssignManagerCheckBox_CheckStateChanged;
            // 
            // WarehouseManagerComboBox
            // 
            WarehouseManagerComboBox.AccessibleName = "WarehouseManagerComboBox";
            WarehouseManagerComboBox.FormattingEnabled = true;
            WarehouseManagerComboBox.Location = new Point(173, 321);
            WarehouseManagerComboBox.Name = "WarehouseManagerComboBox";
            WarehouseManagerComboBox.Size = new Size(150, 28);
            WarehouseManagerComboBox.TabIndex = 16;
            // 
            // AssignManagerLabel
            // 
            AssignManagerLabel.AccessibleName = "AssignManagerLabel";
            AssignManagerLabel.AutoSize = true;
            AssignManagerLabel.Location = new Point(7, 321);
            AssignManagerLabel.Name = "AssignManagerLabel";
            AssignManagerLabel.Size = new Size(115, 20);
            AssignManagerLabel.TabIndex = 15;
            AssignManagerLabel.Text = "Assign Manager";
            // 
            // WarehouseAddressLabel
            // 
            WarehouseAddressLabel.AccessibleName = "WarehouseAddressLabel";
            WarehouseAddressLabel.AutoSize = true;
            WarehouseAddressLabel.Location = new Point(7, 164);
            WarehouseAddressLabel.Name = "WarehouseAddressLabel";
            WarehouseAddressLabel.Size = new Size(62, 20);
            WarehouseAddressLabel.TabIndex = 14;
            WarehouseAddressLabel.Text = "Address";
            // 
            // WarehouseNameLabel
            // 
            WarehouseNameLabel.AccessibleName = "WarehouseNameLabel";
            WarehouseNameLabel.AutoSize = true;
            WarehouseNameLabel.Location = new Point(7, 68);
            WarehouseNameLabel.Name = "WarehouseNameLabel";
            WarehouseNameLabel.Size = new Size(49, 20);
            WarehouseNameLabel.TabIndex = 13;
            WarehouseNameLabel.Text = "Name";
            // 
            // btnEditWarehouse
            // 
            btnEditWarehouse.AccessibleName = "btnEditWarehouse";
            btnEditWarehouse.Location = new Point(913, 509);
            btnEditWarehouse.Name = "btnEditWarehouse";
            btnEditWarehouse.Size = new Size(177, 29);
            btnEditWarehouse.TabIndex = 12;
            btnEditWarehouse.Text = "Edit Warehouse";
            btnEditWarehouse.UseVisualStyleBackColor = true;
            btnEditWarehouse.Click += btnEditWarehouse_Click;
            // 
            // WarehouseAddressTextBox
            // 
            WarehouseAddressTextBox.AccessibleName = "WarehouseAddressTextBox";
            WarehouseAddressTextBox.Location = new Point(173, 157);
            WarehouseAddressTextBox.Name = "WarehouseAddressTextBox";
            WarehouseAddressTextBox.Size = new Size(150, 27);
            WarehouseAddressTextBox.TabIndex = 11;
            // 
            // WarehouseNameTextBox
            // 
            WarehouseNameTextBox.AccessibleName = "WarehouseNameTextBox";
            WarehouseNameTextBox.Location = new Point(173, 61);
            WarehouseNameTextBox.Name = "WarehouseNameTextBox";
            WarehouseNameTextBox.Size = new Size(150, 27);
            WarehouseNameTextBox.TabIndex = 10;
            // 
            // warehouseDataGridView
            // 
            warehouseDataGridView.AccessibleName = "warehouseDataGridView";
            warehouseDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            warehouseDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            warehouseDataGridView.Location = new Point(578, 8);
            warehouseDataGridView.Name = "warehouseDataGridView";
            warehouseDataGridView.RowHeadersWidth = 51;
            warehouseDataGridView.Size = new Size(828, 435);
            warehouseDataGridView.TabIndex = 9;
            warehouseDataGridView.CellDoubleClick += warehouseDataGridView_CellDoubleClick;
            // 
            // EditWarehouseForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1412, 546);
            Controls.Add(AssignManagerCheckBox);
            Controls.Add(WarehouseManagerComboBox);
            Controls.Add(AssignManagerLabel);
            Controls.Add(WarehouseAddressLabel);
            Controls.Add(WarehouseNameLabel);
            Controls.Add(btnEditWarehouse);
            Controls.Add(WarehouseAddressTextBox);
            Controls.Add(WarehouseNameTextBox);
            Controls.Add(warehouseDataGridView);
            Name = "EditWarehouseForm";
            Text = "EditWarehouseForm";
            Load += EditWarehouseForm_Load;
            ((System.ComponentModel.ISupportInitialize)warehouseDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox AssignManagerCheckBox;
        private ComboBox WarehouseManagerComboBox;
        private Label AssignManagerLabel;
        private Label WarehouseAddressLabel;
        private Label WarehouseNameLabel;
        private Button btnEditWarehouse;
        private TextBox WarehouseAddressTextBox;
        private TextBox WarehouseNameTextBox;
        private DataGridView warehouseDataGridView;
    }
}