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
            Item = new GroupBox();
            ReceiptDeleteButton = new Button();
            Vocher = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)ReceiptVoucherItemsGridView).BeginInit();
            Item.SuspendLayout();
            Vocher.SuspendLayout();
            SuspendLayout();
            // 
            // ReceiptVoucherWarehouseLabel
            // 
            ReceiptVoucherWarehouseLabel.AccessibleName = "ReceiptVoucherWarehouseLabel";
            ReceiptVoucherWarehouseLabel.AutoSize = true;
            ReceiptVoucherWarehouseLabel.Location = new Point(40, 81);
            ReceiptVoucherWarehouseLabel.Name = "ReceiptVoucherWarehouseLabel";
            ReceiptVoucherWarehouseLabel.Size = new Size(117, 23);
            ReceiptVoucherWarehouseLabel.TabIndex = 0;
            ReceiptVoucherWarehouseLabel.Text = "To Warehouse";
            // 
            // ReceiptVoucherReceiptDateLabel
            // 
            ReceiptVoucherReceiptDateLabel.AccessibleName = "ReceiptVoucherReceiptDateLabel";
            ReceiptVoucherReceiptDateLabel.AutoSize = true;
            ReceiptVoucherReceiptDateLabel.Location = new Point(40, 241);
            ReceiptVoucherReceiptDateLabel.Name = "ReceiptVoucherReceiptDateLabel";
            ReceiptVoucherReceiptDateLabel.Size = new Size(107, 23);
            ReceiptVoucherReceiptDateLabel.TabIndex = 1;
            ReceiptVoucherReceiptDateLabel.Text = "Receipt Date";
            // 
            // ReceiptVoucherSupplierNameLabel
            // 
            ReceiptVoucherSupplierNameLabel.AccessibleName = "ReceiptVoucherSupplierNameLabel";
            ReceiptVoucherSupplierNameLabel.AutoSize = true;
            ReceiptVoucherSupplierNameLabel.Location = new Point(40, 165);
            ReceiptVoucherSupplierNameLabel.Name = "ReceiptVoucherSupplierNameLabel";
            ReceiptVoucherSupplierNameLabel.Size = new Size(123, 23);
            ReceiptVoucherSupplierNameLabel.TabIndex = 2;
            ReceiptVoucherSupplierNameLabel.Text = "Supplier Name";
            // 
            // ReceiptVoucherExpiryDateLabel
            // 
            ReceiptVoucherExpiryDateLabel.AccessibleName = "ReceiptVoucherExpiryDateLabel";
            ReceiptVoucherExpiryDateLabel.AutoSize = true;
            ReceiptVoucherExpiryDateLabel.Location = new Point(40, 328);
            ReceiptVoucherExpiryDateLabel.Name = "ReceiptVoucherExpiryDateLabel";
            ReceiptVoucherExpiryDateLabel.Size = new Size(94, 23);
            ReceiptVoucherExpiryDateLabel.TabIndex = 3;
            ReceiptVoucherExpiryDateLabel.Text = "Expiry date";
            // 
            // ReceiptVoucherProductionDateLabel
            // 
            ReceiptVoucherProductionDateLabel.AccessibleName = "ReceiptVoucherProductionDateLabel";
            ReceiptVoucherProductionDateLabel.AutoSize = true;
            ReceiptVoucherProductionDateLabel.Location = new Point(40, 252);
            ReceiptVoucherProductionDateLabel.Name = "ReceiptVoucherProductionDateLabel";
            ReceiptVoucherProductionDateLabel.Size = new Size(133, 23);
            ReceiptVoucherProductionDateLabel.TabIndex = 4;
            ReceiptVoucherProductionDateLabel.Text = "Production date";
            // 
            // ReceiptVoucherReceiptDate
            // 
            ReceiptVoucherReceiptDate.AccessibleName = "ReceiptVoucherReceiptDate";
            ReceiptVoucherReceiptDate.Location = new Point(250, 235);
            ReceiptVoucherReceiptDate.Name = "ReceiptVoucherReceiptDate";
            ReceiptVoucherReceiptDate.Size = new Size(281, 30);
            ReceiptVoucherReceiptDate.TabIndex = 5;
            ReceiptVoucherReceiptDate.ValueChanged += ReceiptVoucherReceiptDate_ValueChanged;
            // 
            // ReceiptVoucherProductionDate
            // 
            ReceiptVoucherProductionDate.AccessibleName = "ReceiptVoucherProductionDate";
            ReceiptVoucherProductionDate.Location = new Point(250, 246);
            ReceiptVoucherProductionDate.Name = "ReceiptVoucherProductionDate";
            ReceiptVoucherProductionDate.Size = new Size(281, 30);
            ReceiptVoucherProductionDate.TabIndex = 6;
            // 
            // ReceiptVoucherExpiryDate
            // 
            ReceiptVoucherExpiryDate.AccessibleName = "ReceiptVoucherExpiryDate";
            ReceiptVoucherExpiryDate.Location = new Point(250, 322);
            ReceiptVoucherExpiryDate.Name = "ReceiptVoucherExpiryDate";
            ReceiptVoucherExpiryDate.Size = new Size(281, 30);
            ReceiptVoucherExpiryDate.TabIndex = 7;
            // 
            // ReceiptVoucherWarehouseComboBox
            // 
            ReceiptVoucherWarehouseComboBox.AccessibleName = "ReceiptVoucherWarehouseComboBox";
            ReceiptVoucherWarehouseComboBox.FormattingEnabled = true;
            ReceiptVoucherWarehouseComboBox.Location = new Point(250, 78);
            ReceiptVoucherWarehouseComboBox.Name = "ReceiptVoucherWarehouseComboBox";
            ReceiptVoucherWarehouseComboBox.Size = new Size(281, 31);
            ReceiptVoucherWarehouseComboBox.TabIndex = 8;
            ReceiptVoucherWarehouseComboBox.SelectedIndexChanged += ReceiptVoucherWarehouseComboBox_SelectedIndexChanged;
            // 
            // ReceiptVoucherSupplierComboBox
            // 
            ReceiptVoucherSupplierComboBox.AccessibleName = "ReceiptVoucherSupplierComboBox";
            ReceiptVoucherSupplierComboBox.FormattingEnabled = true;
            ReceiptVoucherSupplierComboBox.Location = new Point(250, 162);
            ReceiptVoucherSupplierComboBox.Name = "ReceiptVoucherSupplierComboBox";
            ReceiptVoucherSupplierComboBox.Size = new Size(281, 31);
            ReceiptVoucherSupplierComboBox.TabIndex = 9;
            ReceiptVoucherSupplierComboBox.SelectedIndexChanged += ReceiptVoucherSupplierComboBox_SelectedIndexChanged;
            // 
            // ReceiptVoucherItemsGridView
            // 
            ReceiptVoucherItemsGridView.AccessibleName = "ReceiptVoucherItemsCheckItemsGridView";
            ReceiptVoucherItemsGridView.AllowUserToAddRows = false;
            ReceiptVoucherItemsGridView.AllowUserToDeleteRows = false;
            ReceiptVoucherItemsGridView.AllowUserToOrderColumns = true;
            ReceiptVoucherItemsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ReceiptVoucherItemsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ReceiptVoucherItemsGridView.Dock = DockStyle.Right;
            ReceiptVoucherItemsGridView.Location = new Point(1549, 0);
            ReceiptVoucherItemsGridView.Name = "ReceiptVoucherItemsGridView";
            ReceiptVoucherItemsGridView.ReadOnly = true;
            ReceiptVoucherItemsGridView.RowHeadersWidth = 51;
            ReceiptVoucherItemsGridView.Size = new Size(761, 1145);
            ReceiptVoucherItemsGridView.TabIndex = 10;
            ReceiptVoucherItemsGridView.CellClick += ReceiptVoucherItemsGridView_CellClick;
            ReceiptVoucherItemsGridView.KeyDown += ReceiptVoucherItemsGridView_KeyDown;
            // 
            // ReceiptVoucherItemsLabel
            // 
            ReceiptVoucherItemsLabel.AccessibleName = "ReceiptVoucherItemsLabel";
            ReceiptVoucherItemsLabel.AutoSize = true;
            ReceiptVoucherItemsLabel.Location = new Point(40, 93);
            ReceiptVoucherItemsLabel.Name = "ReceiptVoucherItemsLabel";
            ReceiptVoucherItemsLabel.Size = new Size(45, 23);
            ReceiptVoucherItemsLabel.TabIndex = 12;
            ReceiptVoucherItemsLabel.Text = "Item";
            // 
            // ReceiptVoucherAddToWarehouseButton
            // 
            ReceiptVoucherAddToWarehouseButton.AccessibleName = "ReceiptVoucherAddToWarehouseButton";
            ReceiptVoucherAddToWarehouseButton.Location = new Point(432, 325);
            ReceiptVoucherAddToWarehouseButton.Name = "ReceiptVoucherAddToWarehouseButton";
            ReceiptVoucherAddToWarehouseButton.Size = new Size(191, 33);
            ReceiptVoucherAddToWarehouseButton.TabIndex = 13;
            ReceiptVoucherAddToWarehouseButton.Text = "Create Voucher";
            ReceiptVoucherAddToWarehouseButton.UseVisualStyleBackColor = true;
            ReceiptVoucherAddToWarehouseButton.Click += ReceiptVoucherAddToWarehouseButton_ClickAsync;
            // 
            // ReceiptVoucherItemsComboBox
            // 
            ReceiptVoucherItemsComboBox.AccessibleName = "ReceiptVoucherItemsComboBox";
            ReceiptVoucherItemsComboBox.FormattingEnabled = true;
            ReceiptVoucherItemsComboBox.Location = new Point(250, 90);
            ReceiptVoucherItemsComboBox.Name = "ReceiptVoucherItemsComboBox";
            ReceiptVoucherItemsComboBox.Size = new Size(281, 31);
            ReceiptVoucherItemsComboBox.TabIndex = 14;
            // 
            // ReceiptVoucherAddItemButton
            // 
            ReceiptVoucherAddItemButton.AccessibleName = "ReceiptVoucherAddItemButton";
            ReceiptVoucherAddItemButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ReceiptVoucherAddItemButton.Location = new Point(650, 214);
            ReceiptVoucherAddItemButton.Name = "ReceiptVoucherAddItemButton";
            ReceiptVoucherAddItemButton.Size = new Size(220, 33);
            ReceiptVoucherAddItemButton.TabIndex = 15;
            ReceiptVoucherAddItemButton.Text = "Add Item To Receipt";
            ReceiptVoucherAddItemButton.UseVisualStyleBackColor = true;
            ReceiptVoucherAddItemButton.Click += ReceiptVoucherAddItemButton_Click;
            // 
            // ReceiptVoucherQuantityLabel
            // 
            ReceiptVoucherQuantityLabel.AccessibleName = "ReceiptVoucherQuantityLabel";
            ReceiptVoucherQuantityLabel.AutoSize = true;
            ReceiptVoucherQuantityLabel.Location = new Point(40, 168);
            ReceiptVoucherQuantityLabel.Name = "ReceiptVoucherQuantityLabel";
            ReceiptVoucherQuantityLabel.Size = new Size(76, 23);
            ReceiptVoucherQuantityLabel.TabIndex = 16;
            ReceiptVoucherQuantityLabel.Text = "Quantity";
            // 
            // ReceiptVoucherQuantityTextBox
            // 
            ReceiptVoucherQuantityTextBox.AccessibleName = "ReceiptVoucherQuantityTextBox";
            ReceiptVoucherQuantityTextBox.Location = new Point(250, 165);
            ReceiptVoucherQuantityTextBox.Name = "ReceiptVoucherQuantityTextBox";
            ReceiptVoucherQuantityTextBox.Size = new Size(282, 30);
            ReceiptVoucherQuantityTextBox.TabIndex = 17;
            // 
            // ReceiptVoucherChosenSupplierLabel
            // 
            ReceiptVoucherChosenSupplierLabel.AccessibleName = "ReceiptVoucherChosenSupplierLabel";
            ReceiptVoucherChosenSupplierLabel.AutoSize = true;
            ReceiptVoucherChosenSupplierLabel.Location = new Point(638, 165);
            ReceiptVoucherChosenSupplierLabel.Name = "ReceiptVoucherChosenSupplierLabel";
            ReceiptVoucherChosenSupplierLabel.Size = new Size(176, 23);
            ReceiptVoucherChosenSupplierLabel.TabIndex = 18;
            ReceiptVoucherChosenSupplierLabel.Text = "Receipt from supplier:";
            // 
            // ReceiptVoucherChosenWarehouseLabel
            // 
            ReceiptVoucherChosenWarehouseLabel.AccessibleName = "ReceiptVoucherChosenWarehouseLabel";
            ReceiptVoucherChosenWarehouseLabel.AutoSize = true;
            ReceiptVoucherChosenWarehouseLabel.Location = new Point(638, 81);
            ReceiptVoucherChosenWarehouseLabel.Name = "ReceiptVoucherChosenWarehouseLabel";
            ReceiptVoucherChosenWarehouseLabel.Size = new Size(178, 23);
            ReceiptVoucherChosenWarehouseLabel.TabIndex = 19;
            ReceiptVoucherChosenWarehouseLabel.Text = "Receipt to warehouse:";
            // 
            // UserChosenSupplierViewLabel
            // 
            UserChosenSupplierViewLabel.AccessibleName = "UserChosenSupplierViewLabel";
            UserChosenSupplierViewLabel.AutoSize = true;
            UserChosenSupplierViewLabel.Location = new Point(838, 165);
            UserChosenSupplierViewLabel.Name = "UserChosenSupplierViewLabel";
            UserChosenSupplierViewLabel.Size = new Size(41, 23);
            UserChosenSupplierViewLabel.TabIndex = 20;
            UserChosenSupplierViewLabel.Text = "N/A";
            // 
            // UserChosenWarehouseViewLabel
            // 
            UserChosenWarehouseViewLabel.AccessibleName = "UserChosenWarehouseViewLabel";
            UserChosenWarehouseViewLabel.AutoSize = true;
            UserChosenWarehouseViewLabel.Location = new Point(838, 81);
            UserChosenWarehouseViewLabel.Name = "UserChosenWarehouseViewLabel";
            UserChosenWarehouseViewLabel.Size = new Size(41, 23);
            UserChosenWarehouseViewLabel.TabIndex = 21;
            UserChosenWarehouseViewLabel.Text = "N/A";
            // 
            // ReceiptVoucherChosenDateLabel
            // 
            ReceiptVoucherChosenDateLabel.AccessibleName = "ReceiptVoucherChosenDateLabel";
            ReceiptVoucherChosenDateLabel.AutoSize = true;
            ReceiptVoucherChosenDateLabel.Location = new Point(638, 241);
            ReceiptVoucherChosenDateLabel.Name = "ReceiptVoucherChosenDateLabel";
            ReceiptVoucherChosenDateLabel.Size = new Size(111, 23);
            ReceiptVoucherChosenDateLabel.TabIndex = 22;
            ReceiptVoucherChosenDateLabel.Text = "Receipt Date:";
            // 
            // UserChosenViewReceiptDateLabel
            // 
            UserChosenViewReceiptDateLabel.AccessibleName = "UserChosenViewReceiptDateLabel";
            UserChosenViewReceiptDateLabel.AutoSize = true;
            UserChosenViewReceiptDateLabel.Location = new Point(838, 241);
            UserChosenViewReceiptDateLabel.Name = "UserChosenViewReceiptDateLabel";
            UserChosenViewReceiptDateLabel.Size = new Size(41, 23);
            UserChosenViewReceiptDateLabel.TabIndex = 23;
            UserChosenViewReceiptDateLabel.Text = "N/A";
            // 
            // Item
            // 
            Item.BackColor = SystemColors.ControlLight;
            Item.Controls.Add(ReceiptDeleteButton);
            Item.Controls.Add(ReceiptVoucherAddItemButton);
            Item.Controls.Add(ReceiptVoucherExpiryDateLabel);
            Item.Controls.Add(ReceiptVoucherProductionDateLabel);
            Item.Controls.Add(ReceiptVoucherQuantityLabel);
            Item.Controls.Add(ReceiptVoucherItemsLabel);
            Item.Controls.Add(ReceiptVoucherExpiryDate);
            Item.Controls.Add(ReceiptVoucherItemsComboBox);
            Item.Controls.Add(ReceiptVoucherQuantityTextBox);
            Item.Controls.Add(ReceiptVoucherProductionDate);
            Item.Font = new Font("Segoe UI", 10F);
            Item.Location = new Point(37, 31);
            Item.Name = "Item";
            Item.Size = new Size(904, 397);
            Item.TabIndex = 24;
            Item.TabStop = false;
            Item.Text = "--Item--";
            // 
            // ReceiptDeleteButton
            // 
            ReceiptDeleteButton.AccessibleName = "ReceiptDeleteButton";
            ReceiptDeleteButton.Location = new Point(650, 318);
            ReceiptDeleteButton.Name = "ReceiptDeleteButton";
            ReceiptDeleteButton.Size = new Size(220, 33);
            ReceiptDeleteButton.TabIndex = 25;
            ReceiptDeleteButton.Text = "Delete Selected Item";
            ReceiptDeleteButton.UseVisualStyleBackColor = true;
            ReceiptDeleteButton.Click += ReceiptDeleteButton_Click;
            // 
            // Vocher
            // 
            Vocher.BackColor = SystemColors.ControlLight;
            Vocher.Controls.Add(UserChosenViewReceiptDateLabel);
            Vocher.Controls.Add(ReceiptVoucherWarehouseLabel);
            Vocher.Controls.Add(ReceiptVoucherChosenDateLabel);
            Vocher.Controls.Add(ReceiptVoucherSupplierNameLabel);
            Vocher.Controls.Add(UserChosenWarehouseViewLabel);
            Vocher.Controls.Add(ReceiptVoucherReceiptDateLabel);
            Vocher.Controls.Add(UserChosenSupplierViewLabel);
            Vocher.Controls.Add(ReceiptVoucherReceiptDate);
            Vocher.Controls.Add(ReceiptVoucherChosenWarehouseLabel);
            Vocher.Controls.Add(ReceiptVoucherSupplierComboBox);
            Vocher.Controls.Add(ReceiptVoucherChosenSupplierLabel);
            Vocher.Controls.Add(ReceiptVoucherWarehouseComboBox);
            Vocher.Controls.Add(ReceiptVoucherAddToWarehouseButton);
            Vocher.Location = new Point(37, 539);
            Vocher.Name = "Vocher";
            Vocher.Size = new Size(1113, 382);
            Vocher.TabIndex = 18;
            Vocher.TabStop = false;
            Vocher.Text = "--Voucher--";
            // 
            // ReceiptVoucherForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(2310, 1145);
            Controls.Add(ReceiptVoucherItemsGridView);
            Controls.Add(Item);
            Controls.Add(Vocher);
            Font = new Font("Segoe UI", 10F);
            Name = "ReceiptVoucherForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Receipt Voucher";
            WindowState = FormWindowState.Maximized;
            Load += ReceiptVoucherForm_Load;
            ((System.ComponentModel.ISupportInitialize)ReceiptVoucherItemsGridView).EndInit();
            Item.ResumeLayout(false);
            Item.PerformLayout();
            Vocher.ResumeLayout(false);
            Vocher.PerformLayout();
            ResumeLayout(false);
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
        private GroupBox Item;
        private GroupBox Vocher;
        private Button ReceiptDeleteButton;
    }
}