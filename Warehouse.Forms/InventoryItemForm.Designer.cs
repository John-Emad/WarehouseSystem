namespace WarehouseManagmentSystem.WinForms
{
    partial class InventoryItemForm
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
            InventoryItemNameLabel = new Label();
            InventoryItemWarehouseLabel = new Label();
            InventoryItemQuantityLabel = new Label();
            InventoryItemProductionDateLabel = new Label();
            InventoryItemExpiryDateLabel = new Label();
            InventoryItemProductionDatePicker = new DateTimePicker();
            InventoryItemExpiryDatePicker = new DateTimePicker();
            InventoryItemQuantityTextBox = new TextBox();
            InventoryItemDataGridView = new DataGridView();
            InventoryItemAddButton = new Button();
            InventoryItemNameComboBox = new ComboBox();
            InventoryItemWarehouseComboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)InventoryItemDataGridView).BeginInit();
            SuspendLayout();
            // 
            // InventoryItemNameLabel
            // 
            InventoryItemNameLabel.AccessibleName = "InventoryItemNameLabel";
            InventoryItemNameLabel.AutoSize = true;
            InventoryItemNameLabel.Location = new Point(32, 32);
            InventoryItemNameLabel.Name = "InventoryItemNameLabel";
            InventoryItemNameLabel.Size = new Size(83, 20);
            InventoryItemNameLabel.TabIndex = 0;
            InventoryItemNameLabel.Text = "Item Name";
            // 
            // InventoryItemWarehouseLabel
            // 
            InventoryItemWarehouseLabel.AccessibleName = "InventoryItemWarehouseLabel";
            InventoryItemWarehouseLabel.AutoSize = true;
            InventoryItemWarehouseLabel.Location = new Point(32, 130);
            InventoryItemWarehouseLabel.Name = "InventoryItemWarehouseLabel";
            InventoryItemWarehouseLabel.Size = new Size(126, 20);
            InventoryItemWarehouseLabel.TabIndex = 1;
            InventoryItemWarehouseLabel.Text = "Warehouse Name";
            // 
            // InventoryItemQuantityLabel
            // 
            InventoryItemQuantityLabel.AccessibleName = "InventoryItemQuantityLabel";
            InventoryItemQuantityLabel.AutoSize = true;
            InventoryItemQuantityLabel.Location = new Point(32, 234);
            InventoryItemQuantityLabel.Name = "InventoryItemQuantityLabel";
            InventoryItemQuantityLabel.Size = new Size(65, 20);
            InventoryItemQuantityLabel.TabIndex = 2;
            InventoryItemQuantityLabel.Text = "Quantity";
            // 
            // InventoryItemProductionDateLabel
            // 
            InventoryItemProductionDateLabel.AccessibleName = "InventoryItemProductionDateLabel";
            InventoryItemProductionDateLabel.AutoSize = true;
            InventoryItemProductionDateLabel.Location = new Point(32, 360);
            InventoryItemProductionDateLabel.Name = "InventoryItemProductionDateLabel";
            InventoryItemProductionDateLabel.Size = new Size(115, 20);
            InventoryItemProductionDateLabel.TabIndex = 4;
            InventoryItemProductionDateLabel.Text = "Production date";
            // 
            // InventoryItemExpiryDateLabel
            // 
            InventoryItemExpiryDateLabel.AccessibleName = "InventoryItemExpiryDateLabel";
            InventoryItemExpiryDateLabel.AutoSize = true;
            InventoryItemExpiryDateLabel.Location = new Point(32, 418);
            InventoryItemExpiryDateLabel.Name = "InventoryItemExpiryDateLabel";
            InventoryItemExpiryDateLabel.Size = new Size(83, 20);
            InventoryItemExpiryDateLabel.TabIndex = 5;
            InventoryItemExpiryDateLabel.Text = "Expiry date";
            // 
            // InventoryItemProductionDatePicker
            // 
            InventoryItemProductionDatePicker.AccessibleName = "InventoryItemProductionDatePicker";
            InventoryItemProductionDatePicker.Location = new Point(167, 353);
            InventoryItemProductionDatePicker.Name = "InventoryItemProductionDatePicker";
            InventoryItemProductionDatePicker.Size = new Size(250, 27);
            InventoryItemProductionDatePicker.TabIndex = 8;
            // 
            // InventoryItemExpiryDatePicker
            // 
            InventoryItemExpiryDatePicker.AccessibleName = "InventoryItemExpiryDatePicker";
            InventoryItemExpiryDatePicker.Location = new Point(167, 411);
            InventoryItemExpiryDatePicker.Name = "InventoryItemExpiryDatePicker";
            InventoryItemExpiryDatePicker.Size = new Size(250, 27);
            InventoryItemExpiryDatePicker.TabIndex = 9;
            // 
            // InventoryItemQuantityTextBox
            // 
            InventoryItemQuantityTextBox.AccessibleName = "InventoryItemQuantityTextBox";
            InventoryItemQuantityTextBox.Location = new Point(167, 227);
            InventoryItemQuantityTextBox.Name = "InventoryItemQuantityTextBox";
            InventoryItemQuantityTextBox.Size = new Size(150, 27);
            InventoryItemQuantityTextBox.TabIndex = 10;
            // 
            // InventoryItemDataGridView
            // 
            InventoryItemDataGridView.AccessibleName = "InventoryItemDataGridView";
            InventoryItemDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            InventoryItemDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            InventoryItemDataGridView.Location = new Point(490, 12);
            InventoryItemDataGridView.Name = "InventoryItemDataGridView";
            InventoryItemDataGridView.RowHeadersWidth = 51;
            InventoryItemDataGridView.Size = new Size(1177, 488);
            InventoryItemDataGridView.TabIndex = 12;
            // 
            // InventoryItemAddButton
            // 
            InventoryItemAddButton.AccessibleName = "InventoryItemAddButton";
            InventoryItemAddButton.Location = new Point(490, 529);
            InventoryItemAddButton.Name = "InventoryItemAddButton";
            InventoryItemAddButton.Size = new Size(94, 29);
            InventoryItemAddButton.TabIndex = 13;
            InventoryItemAddButton.Text = "AddAsync";
            InventoryItemAddButton.UseVisualStyleBackColor = true;
            InventoryItemAddButton.Click += InventoryItemAddButton_Click;
            // 
            // InventoryItemNameComboBox
            // 
            InventoryItemNameComboBox.AccessibleName = "InventoryItemNameComboBox";
            InventoryItemNameComboBox.FormattingEnabled = true;
            InventoryItemNameComboBox.Location = new Point(167, 32);
            InventoryItemNameComboBox.Name = "InventoryItemNameComboBox";
            InventoryItemNameComboBox.Size = new Size(151, 28);
            InventoryItemNameComboBox.TabIndex = 14;
            // 
            // InventoryItemWarehouseComboBox
            // 
            InventoryItemWarehouseComboBox.AccessibleName = "InventoryItemWarehouseComboBox";
            InventoryItemWarehouseComboBox.FormattingEnabled = true;
            InventoryItemWarehouseComboBox.Location = new Point(167, 130);
            InventoryItemWarehouseComboBox.Name = "InventoryItemWarehouseComboBox";
            InventoryItemWarehouseComboBox.Size = new Size(151, 28);
            InventoryItemWarehouseComboBox.TabIndex = 15;
            // 
            // InventoryItemForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1708, 590);
            Controls.Add(InventoryItemWarehouseComboBox);
            Controls.Add(InventoryItemNameComboBox);
            Controls.Add(InventoryItemAddButton);
            Controls.Add(InventoryItemDataGridView);
            Controls.Add(InventoryItemQuantityTextBox);
            Controls.Add(InventoryItemExpiryDatePicker);
            Controls.Add(InventoryItemProductionDatePicker);
            Controls.Add(InventoryItemExpiryDateLabel);
            Controls.Add(InventoryItemProductionDateLabel);
            Controls.Add(InventoryItemQuantityLabel);
            Controls.Add(InventoryItemWarehouseLabel);
            Controls.Add(InventoryItemNameLabel);
            Name = "InventoryItemForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "InventoryItemViewDTO";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)InventoryItemDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label InventoryItemNameLabel;
        private Label InventoryItemWarehouseLabel;
        private Label InventoryItemQuantityLabel;
        private Label InventoryItemProductionDateLabel;
        private Label InventoryItemExpiryDateLabel;
        private DateTimePicker InventoryItemProductionDatePicker;
        private DateTimePicker InventoryItemExpiryDatePicker;
        private TextBox InventoryItemQuantityTextBox;
        private DataGridView InventoryItemDataGridView;
        private Button InventoryItemAddButton;
        private ComboBox InventoryItemNameComboBox;
        private ComboBox InventoryItemWarehouseComboBox;
    }
}