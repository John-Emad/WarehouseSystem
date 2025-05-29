namespace WarehouseManagmentSystem.WinForms
{
    partial class ReceiptVoucherForm
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
            ReceiptVoucherWarehouseLabel = new Label();
            ReceiptVoucherReceiptDateLabel = new Label();
            ReceiptVoucherSupplierNameLabel = new Label();
            ReceiptVoucherExpiryDateLabel = new Label();
            ReceiptVoucherProductionDateLabel = new Label();
            ReceiptVoucherReceiptDate = new DateTimePicker();
            ReceiptVoucherProductionDate = new DateTimePicker();
            ReceiptVoucherExpiryDate = new DateTimePicker();
            ReceiptVoucherWarehouseComboBox = new ComboBox();
            ReceiptVoucherSupplierComboBox = new ComboBox();
            ReceiptVoucherItemsGridView = new DataGridView();
            ReceiptVoucherItemsLabel = new Label();
            ReceiptVoucherAddToWarehouseButton = new Button();
            ReceiptVoucherItemsComboBox = new ComboBox();
            ReceiptVoucherAddItemButton = new Button();
            ReceiptVoucherQuantityLabel = new Label();
            ReceiptVoucherQuantityTextBox = new TextBox();
            ReceiptVoucherChosenSupplierLabel = new Label();
            ReceiptVoucherChosenWarehouseLabel = new Label();
            UserChosenSupplierViewLabel = new Label();
            UserChosenWarehouseViewLabel = new Label();
            ReceiptVoucherChosenDateLabel = new Label();
            UserChosenViewReceiptDateLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)ReceiptVoucherItemsGridView).BeginInit();
            SuspendLayout();
            // 
            // ReceiptVoucherWarehouseLabel
            // 
            ReceiptVoucherWarehouseLabel.AccessibleName = "ReceiptVoucherWarehouseLabel";
            ReceiptVoucherWarehouseLabel.AutoSize = true;
            ReceiptVoucherWarehouseLabel.Location = new Point(1124, 538);
            ReceiptVoucherWarehouseLabel.Name = "ReceiptVoucherWarehouseLabel";
            ReceiptVoucherWarehouseLabel.Size = new Size(82, 20);
            ReceiptVoucherWarehouseLabel.TabIndex = 0;
            ReceiptVoucherWarehouseLabel.Text = "Warehouse";
            // 
            // ReceiptVoucherReceiptDateLabel
            // 
            ReceiptVoucherReceiptDateLabel.AccessibleName = "ReceiptVoucherReceiptDateLabel";
            ReceiptVoucherReceiptDateLabel.AutoSize = true;
            ReceiptVoucherReceiptDateLabel.Location = new Point(1125, 668);
            ReceiptVoucherReceiptDateLabel.Name = "ReceiptVoucherReceiptDateLabel";
            ReceiptVoucherReceiptDateLabel.Size = new Size(95, 20);
            ReceiptVoucherReceiptDateLabel.TabIndex = 1;
            ReceiptVoucherReceiptDateLabel.Text = "Receipt Date";
            // 
            // ReceiptVoucherSupplierNameLabel
            // 
            ReceiptVoucherSupplierNameLabel.AccessibleName = "ReceiptVoucherSupplierNameLabel";
            ReceiptVoucherSupplierNameLabel.AutoSize = true;
            ReceiptVoucherSupplierNameLabel.Location = new Point(1124, 608);
            ReceiptVoucherSupplierNameLabel.Name = "ReceiptVoucherSupplierNameLabel";
            ReceiptVoucherSupplierNameLabel.Size = new Size(108, 20);
            ReceiptVoucherSupplierNameLabel.TabIndex = 2;
            ReceiptVoucherSupplierNameLabel.Text = "Supplier Name";
            // 
            // ReceiptVoucherExpiryDateLabel
            // 
            ReceiptVoucherExpiryDateLabel.AccessibleName = "ReceiptVoucherExpiryDateLabel";
            ReceiptVoucherExpiryDateLabel.AutoSize = true;
            ReceiptVoucherExpiryDateLabel.Location = new Point(58, 264);
            ReceiptVoucherExpiryDateLabel.Name = "ReceiptVoucherExpiryDateLabel";
            ReceiptVoucherExpiryDateLabel.Size = new Size(83, 20);
            ReceiptVoucherExpiryDateLabel.TabIndex = 3;
            ReceiptVoucherExpiryDateLabel.Text = "Expiry date";
            // 
            // ReceiptVoucherProductionDateLabel
            // 
            ReceiptVoucherProductionDateLabel.AccessibleName = "ReceiptVoucherProductionDateLabel";
            ReceiptVoucherProductionDateLabel.AutoSize = true;
            ReceiptVoucherProductionDateLabel.Location = new Point(58, 198);
            ReceiptVoucherProductionDateLabel.Name = "ReceiptVoucherProductionDateLabel";
            ReceiptVoucherProductionDateLabel.Size = new Size(115, 20);
            ReceiptVoucherProductionDateLabel.TabIndex = 4;
            ReceiptVoucherProductionDateLabel.Text = "Production date";
            // 
            // ReceiptVoucherReceiptDate
            // 
            ReceiptVoucherReceiptDate.AccessibleName = "ReceiptVoucherReceiptDate";
            ReceiptVoucherReceiptDate.Location = new Point(1310, 661);
            ReceiptVoucherReceiptDate.Name = "ReceiptVoucherReceiptDate";
            ReceiptVoucherReceiptDate.Size = new Size(250, 27);
            ReceiptVoucherReceiptDate.TabIndex = 5;
            ReceiptVoucherReceiptDate.ValueChanged += ReceiptVoucherReceiptDate_ValueChanged;
            // 
            // ReceiptVoucherProductionDate
            // 
            ReceiptVoucherProductionDate.AccessibleName = "ReceiptVoucherProductionDate";
            ReceiptVoucherProductionDate.Location = new Point(233, 193);
            ReceiptVoucherProductionDate.Name = "ReceiptVoucherProductionDate";
            ReceiptVoucherProductionDate.Size = new Size(250, 27);
            ReceiptVoucherProductionDate.TabIndex = 6;
            // 
            // ReceiptVoucherExpiryDate
            // 
            ReceiptVoucherExpiryDate.AccessibleName = "ReceiptVoucherExpiryDate";
            ReceiptVoucherExpiryDate.Location = new Point(233, 257);
            ReceiptVoucherExpiryDate.Name = "ReceiptVoucherExpiryDate";
            ReceiptVoucherExpiryDate.Size = new Size(250, 27);
            ReceiptVoucherExpiryDate.TabIndex = 7;
            // 
            // ReceiptVoucherWarehouseComboBox
            // 
            ReceiptVoucherWarehouseComboBox.AccessibleName = "ReceiptVoucherWarehouseComboBox";
            ReceiptVoucherWarehouseComboBox.FormattingEnabled = true;
            ReceiptVoucherWarehouseComboBox.Location = new Point(1309, 530);
            ReceiptVoucherWarehouseComboBox.Name = "ReceiptVoucherWarehouseComboBox";
            ReceiptVoucherWarehouseComboBox.Size = new Size(250, 28);
            ReceiptVoucherWarehouseComboBox.TabIndex = 8;
            ReceiptVoucherWarehouseComboBox.SelectedIndexChanged += ReceiptVoucherWarehouseComboBox_SelectedIndexChanged;
            // 
            // ReceiptVoucherSupplierComboBox
            // 
            ReceiptVoucherSupplierComboBox.AccessibleName = "ReceiptVoucherSupplierComboBox";
            ReceiptVoucherSupplierComboBox.FormattingEnabled = true;
            ReceiptVoucherSupplierComboBox.Location = new Point(1309, 600);
            ReceiptVoucherSupplierComboBox.Name = "ReceiptVoucherSupplierComboBox";
            ReceiptVoucherSupplierComboBox.Size = new Size(250, 28);
            ReceiptVoucherSupplierComboBox.TabIndex = 9;
            ReceiptVoucherSupplierComboBox.SelectedIndexChanged += ReceiptVoucherSupplierComboBox_SelectedIndexChanged;
            // 
            // ReceiptVoucherItemsGridView
            // 
            ReceiptVoucherItemsGridView.AccessibleName = "ReceiptVoucherItemsCheckItemsGridView";
            ReceiptVoucherItemsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ReceiptVoucherItemsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ReceiptVoucherItemsGridView.Location = new Point(1124, 48);
            ReceiptVoucherItemsGridView.Name = "ReceiptVoucherItemsGridView";
            ReceiptVoucherItemsGridView.RowHeadersWidth = 51;
            ReceiptVoucherItemsGridView.Size = new Size(853, 411);
            ReceiptVoucherItemsGridView.TabIndex = 10;
            // 
            // ReceiptVoucherItemsLabel
            // 
            ReceiptVoucherItemsLabel.AccessibleName = "ReceiptVoucherItemsLabel";
            ReceiptVoucherItemsLabel.AutoSize = true;
            ReceiptVoucherItemsLabel.Location = new Point(57, 48);
            ReceiptVoucherItemsLabel.Name = "ReceiptVoucherItemsLabel";
            ReceiptVoucherItemsLabel.Size = new Size(45, 20);
            ReceiptVoucherItemsLabel.TabIndex = 12;
            ReceiptVoucherItemsLabel.Text = "Items";
            // 
            // ReceiptVoucherAddToWarehouseButton
            // 
            ReceiptVoucherAddToWarehouseButton.AccessibleName = "ReceiptVoucherAddToWarehouseButton";
            ReceiptVoucherAddToWarehouseButton.Location = new Point(1776, 717);
            ReceiptVoucherAddToWarehouseButton.Name = "ReceiptVoucherAddToWarehouseButton";
            ReceiptVoucherAddToWarehouseButton.Size = new Size(170, 29);
            ReceiptVoucherAddToWarehouseButton.TabIndex = 13;
            ReceiptVoucherAddToWarehouseButton.Text = "Add to warehouse";
            ReceiptVoucherAddToWarehouseButton.UseVisualStyleBackColor = true;
            ReceiptVoucherAddToWarehouseButton.Click += ReceiptVoucherAddToWarehouseButton_ClickAsync;
            // 
            // ReceiptVoucherItemsComboBox
            // 
            ReceiptVoucherItemsComboBox.AccessibleName = "ReceiptVoucherItemsComboBox";
            ReceiptVoucherItemsComboBox.FormattingEnabled = true;
            ReceiptVoucherItemsComboBox.Location = new Point(233, 40);
            ReceiptVoucherItemsComboBox.Name = "ReceiptVoucherItemsComboBox";
            ReceiptVoucherItemsComboBox.Size = new Size(250, 28);
            ReceiptVoucherItemsComboBox.TabIndex = 14;
            // 
            // ReceiptVoucherAddItemButton
            // 
            ReceiptVoucherAddItemButton.AccessibleName = "ReceiptVoucherAddItemButton";
            ReceiptVoucherAddItemButton.Location = new Point(57, 364);
            ReceiptVoucherAddItemButton.Name = "ReceiptVoucherAddItemButton";
            ReceiptVoucherAddItemButton.Size = new Size(196, 29);
            ReceiptVoucherAddItemButton.TabIndex = 15;
            ReceiptVoucherAddItemButton.Text = "Add to Receipt";
            ReceiptVoucherAddItemButton.UseVisualStyleBackColor = true;
            ReceiptVoucherAddItemButton.Click += ReceiptVoucherAddItemButton_Click;
            // 
            // ReceiptVoucherQuantityLabel
            // 
            ReceiptVoucherQuantityLabel.AccessibleName = "ReceiptVoucherQuantityLabel";
            ReceiptVoucherQuantityLabel.AutoSize = true;
            ReceiptVoucherQuantityLabel.Location = new Point(58, 104);
            ReceiptVoucherQuantityLabel.Name = "ReceiptVoucherQuantityLabel";
            ReceiptVoucherQuantityLabel.Size = new Size(65, 20);
            ReceiptVoucherQuantityLabel.TabIndex = 16;
            ReceiptVoucherQuantityLabel.Text = "Quantity";
            // 
            // ReceiptVoucherQuantityTextBox
            // 
            ReceiptVoucherQuantityTextBox.AccessibleName = "ReceiptVoucherQuantityTextBox";
            ReceiptVoucherQuantityTextBox.Location = new Point(232, 97);
            ReceiptVoucherQuantityTextBox.Name = "ReceiptVoucherQuantityTextBox";
            ReceiptVoucherQuantityTextBox.Size = new Size(251, 27);
            ReceiptVoucherQuantityTextBox.TabIndex = 17;
            // 
            // ReceiptVoucherChosenSupplierLabel
            // 
            ReceiptVoucherChosenSupplierLabel.AccessibleName = "ReceiptVoucherChosenSupplierLabel";
            ReceiptVoucherChosenSupplierLabel.AutoSize = true;
            ReceiptVoucherChosenSupplierLabel.Location = new Point(728, 97);
            ReceiptVoucherChosenSupplierLabel.Name = "ReceiptVoucherChosenSupplierLabel";
            ReceiptVoucherChosenSupplierLabel.Size = new Size(155, 20);
            ReceiptVoucherChosenSupplierLabel.TabIndex = 18;
            ReceiptVoucherChosenSupplierLabel.Text = "Receipt from supplier:";
            // 
            // ReceiptVoucherChosenWarehouseLabel
            // 
            ReceiptVoucherChosenWarehouseLabel.AccessibleName = "ReceiptVoucherChosenWarehouseLabel";
            ReceiptVoucherChosenWarehouseLabel.AutoSize = true;
            ReceiptVoucherChosenWarehouseLabel.Location = new Point(728, 48);
            ReceiptVoucherChosenWarehouseLabel.Name = "ReceiptVoucherChosenWarehouseLabel";
            ReceiptVoucherChosenWarehouseLabel.Size = new Size(155, 20);
            ReceiptVoucherChosenWarehouseLabel.TabIndex = 19;
            ReceiptVoucherChosenWarehouseLabel.Text = "Receipt to warehouse:";
            // 
            // UserChosenSupplierViewLabel
            // 
            UserChosenSupplierViewLabel.AccessibleName = "UserChosenSupplierViewLabel";
            UserChosenSupplierViewLabel.AutoSize = true;
            UserChosenSupplierViewLabel.Location = new Point(925, 97);
            UserChosenSupplierViewLabel.Name = "UserChosenSupplierViewLabel";
            UserChosenSupplierViewLabel.Size = new Size(36, 20);
            UserChosenSupplierViewLabel.TabIndex = 20;
            UserChosenSupplierViewLabel.Text = "N/A";
            // 
            // UserChosenWarehouseViewLabel
            // 
            UserChosenWarehouseViewLabel.AccessibleName = "UserChosenWarehouseViewLabel";
            UserChosenWarehouseViewLabel.AutoSize = true;
            UserChosenWarehouseViewLabel.Location = new Point(925, 48);
            UserChosenWarehouseViewLabel.Name = "UserChosenWarehouseViewLabel";
            UserChosenWarehouseViewLabel.Size = new Size(36, 20);
            UserChosenWarehouseViewLabel.TabIndex = 21;
            UserChosenWarehouseViewLabel.Text = "N/A";
            // 
            // ReceiptVoucherChosenDateLabel
            // 
            ReceiptVoucherChosenDateLabel.AccessibleName = "ReceiptVoucherChosenDateLabel";
            ReceiptVoucherChosenDateLabel.AutoSize = true;
            ReceiptVoucherChosenDateLabel.Location = new Point(728, 157);
            ReceiptVoucherChosenDateLabel.Name = "ReceiptVoucherChosenDateLabel";
            ReceiptVoucherChosenDateLabel.Size = new Size(98, 20);
            ReceiptVoucherChosenDateLabel.TabIndex = 22;
            ReceiptVoucherChosenDateLabel.Text = "Receipt Date:";
            // 
            // UserChosenViewReceiptDateLabel
            // 
            UserChosenViewReceiptDateLabel.AccessibleName = "UserChosenViewReceiptDateLabel";
            UserChosenViewReceiptDateLabel.AutoSize = true;
            UserChosenViewReceiptDateLabel.Location = new Point(925, 157);
            UserChosenViewReceiptDateLabel.Name = "UserChosenViewReceiptDateLabel";
            UserChosenViewReceiptDateLabel.Size = new Size(36, 20);
            UserChosenViewReceiptDateLabel.TabIndex = 23;
            UserChosenViewReceiptDateLabel.Text = "N/A";
            // 
            // ReceiptVoucherForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2303, 1127);
            Controls.Add(UserChosenViewReceiptDateLabel);
            Controls.Add(ReceiptVoucherChosenDateLabel);
            Controls.Add(UserChosenWarehouseViewLabel);
            Controls.Add(UserChosenSupplierViewLabel);
            Controls.Add(ReceiptVoucherChosenWarehouseLabel);
            Controls.Add(ReceiptVoucherChosenSupplierLabel);
            Controls.Add(ReceiptVoucherQuantityTextBox);
            Controls.Add(ReceiptVoucherQuantityLabel);
            Controls.Add(ReceiptVoucherAddItemButton);
            Controls.Add(ReceiptVoucherItemsComboBox);
            Controls.Add(ReceiptVoucherAddToWarehouseButton);
            Controls.Add(ReceiptVoucherItemsLabel);
            Controls.Add(ReceiptVoucherItemsGridView);
            Controls.Add(ReceiptVoucherSupplierComboBox);
            Controls.Add(ReceiptVoucherWarehouseComboBox);
            Controls.Add(ReceiptVoucherExpiryDate);
            Controls.Add(ReceiptVoucherProductionDate);
            Controls.Add(ReceiptVoucherReceiptDate);
            Controls.Add(ReceiptVoucherProductionDateLabel);
            Controls.Add(ReceiptVoucherExpiryDateLabel);
            Controls.Add(ReceiptVoucherSupplierNameLabel);
            Controls.Add(ReceiptVoucherReceiptDateLabel);
            Controls.Add(ReceiptVoucherWarehouseLabel);
            Name = "ReceiptVoucherForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ReceiptVoucherForm";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)ReceiptVoucherItemsGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ReceiptVoucherWarehouseLabel;
        private Label ReceiptVoucherReceiptDateLabel;
        private Label ReceiptVoucherSupplierNameLabel;
        private Label ReceiptVoucherExpiryDateLabel;
        private Label ReceiptVoucherProductionDateLabel;
        private DateTimePicker ReceiptVoucherReceiptDate;
        private DateTimePicker ReceiptVoucherProductionDate;
        private DateTimePicker ReceiptVoucherExpiryDate;
        private ComboBox ReceiptVoucherWarehouseComboBox;
        private ComboBox ReceiptVoucherSupplierComboBox;
        private DataGridView ReceiptVoucherItemsGridView;
        private Label ReceiptVoucherItemsLabel;
        private Button ReceiptVoucherAddToWarehouseButton;
        private ComboBox ReceiptVoucherItemsComboBox;
        private Button ReceiptVoucherAddItemButton;
        private Label ReceiptVoucherQuantityLabel;
        private TextBox ReceiptVoucherQuantityTextBox;
        private Label ReceiptVoucherChosenSupplierLabel;
        private Label ReceiptVoucherChosenWarehouseLabel;
        private Label UserChosenSupplierViewLabel;
        private Label UserChosenWarehouseViewLabel;
        private Label ReceiptVoucherChosenDateLabel;
        private Label UserChosenViewReceiptDateLabel;
    }
}