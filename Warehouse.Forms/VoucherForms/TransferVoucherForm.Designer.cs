
namespace WarehouseManagmentSystem.WinForms
{
    partial class TransferVoucherForm
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
            TransferFromWarehouseGridView = new DataGridView();
            TransferFromWarehouseLabel = new Label();
            TransferDateLabel = new Label();
            TransferDateDatePicker = new DateTimePicker();
            TransferFromWarehouseComboBox = new ComboBox();
            TransferCreateVoucherButton = new Button();
            UserChosenWarehouseViewLabel = new Label();
            TransferMoveToWarehouseLabel = new Label();
            TransferToWarehouseGridView = new DataGridView();
            TransferToDeleteSelectedItemButton = new Button();
            TransferToWarehouseLabel = new Label();
            TransferToWarehouseComboBox = new ComboBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)TransferFromWarehouseGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TransferToWarehouseGridView).BeginInit();
            SuspendLayout();
            // 
            // TransferFromWarehouseGridView
            // 
            TransferFromWarehouseGridView.AccessibleName = "TransferFromWarehouseGridView";
            TransferFromWarehouseGridView.AccessibleRole = AccessibleRole.None;
            TransferFromWarehouseGridView.AllowUserToAddRows = false;
            TransferFromWarehouseGridView.AllowUserToDeleteRows = false;
            TransferFromWarehouseGridView.AllowUserToOrderColumns = true;
            TransferFromWarehouseGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            TransferFromWarehouseGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TransferFromWarehouseGridView.Location = new Point(33, 154);
            TransferFromWarehouseGridView.Name = "TransferFromWarehouseGridView";
            TransferFromWarehouseGridView.ReadOnly = true;
            TransferFromWarehouseGridView.RowHeadersWidth = 51;
            TransferFromWarehouseGridView.Size = new Size(866, 473);
            TransferFromWarehouseGridView.TabIndex = 34;
            TransferFromWarehouseGridView.CellDoubleClick += TransferFromWarehouseGridView_CellDoubleClick;
            // 
            // TransferFromWarehouseLabel
            // 
            TransferFromWarehouseLabel.AccessibleName = "TransferFromWarehouseLabel";
            TransferFromWarehouseLabel.AutoSize = true;
            TransferFromWarehouseLabel.Location = new Point(99, 52);
            TransferFromWarehouseLabel.Name = "TransferFromWarehouseLabel";
            TransferFromWarehouseLabel.Size = new Size(139, 23);
            TransferFromWarehouseLabel.TabIndex = 24;
            TransferFromWarehouseLabel.Text = "From Warehouse";
            // 
            // TransferDateLabel
            // 
            TransferDateLabel.AccessibleName = "TransferDateLabel";
            TransferDateLabel.AutoSize = true;
            TransferDateLabel.Location = new Point(58, 677);
            TransferDateLabel.Name = "TransferDateLabel";
            TransferDateLabel.Size = new Size(111, 23);
            TransferDateLabel.TabIndex = 25;
            TransferDateLabel.Text = "Transfer Date";
            // 
            // TransferDateDatePicker
            // 
            TransferDateDatePicker.AccessibleName = "TransferDateDatePicker";
            TransferDateDatePicker.Location = new Point(266, 669);
            TransferDateDatePicker.Name = "TransferDateDatePicker";
            TransferDateDatePicker.Size = new Size(281, 30);
            TransferDateDatePicker.TabIndex = 29;
            // 
            // TransferFromWarehouseComboBox
            // 
            TransferFromWarehouseComboBox.AccessibleName = "TransferFromWarehouseComboBox";
            TransferFromWarehouseComboBox.FormattingEnabled = true;
            TransferFromWarehouseComboBox.Location = new Point(307, 42);
            TransferFromWarehouseComboBox.Name = "TransferFromWarehouseComboBox";
            TransferFromWarehouseComboBox.Size = new Size(281, 31);
            TransferFromWarehouseComboBox.TabIndex = 32;
            TransferFromWarehouseComboBox.SelectedIndexChanged += TransferFromWarehouseComboBox_SelectedIndexChanged;
            // 
            // TransferCreateVoucherButton
            // 
            TransferCreateVoucherButton.AccessibleName = "TransferCreateVoucherButton";
            TransferCreateVoucherButton.Location = new Point(832, 814);
            TransferCreateVoucherButton.Name = "TransferCreateVoucherButton";
            TransferCreateVoucherButton.Size = new Size(240, 92);
            TransferCreateVoucherButton.TabIndex = 36;
            TransferCreateVoucherButton.Text = "Create Voucher";
            TransferCreateVoucherButton.UseVisualStyleBackColor = true;
            TransferCreateVoucherButton.Click += TransferCreateVoucherButton_ClickAsync;
            // 
            // UserChosenWarehouseViewLabel
            // 
            UserChosenWarehouseViewLabel.AccessibleName = "UserChosenWarehouseViewLabel";
            UserChosenWarehouseViewLabel.AutoSize = true;
            UserChosenWarehouseViewLabel.Location = new Point(298, 110);
            UserChosenWarehouseViewLabel.Name = "UserChosenWarehouseViewLabel";
            UserChosenWarehouseViewLabel.Size = new Size(219, 23);
            UserChosenWarehouseViewLabel.TabIndex = 44;
            UserChosenWarehouseViewLabel.Text = "Items at Source Warehouse";
            // 
            // TransferMoveToWarehouseLabel
            // 
            TransferMoveToWarehouseLabel.AccessibleName = "TransferMoveToWarehouseLabel";
            TransferMoveToWarehouseLabel.AutoSize = true;
            TransferMoveToWarehouseLabel.Location = new Point(1301, 724);
            TransferMoveToWarehouseLabel.Name = "TransferMoveToWarehouseLabel";
            TransferMoveToWarehouseLabel.Size = new Size(331, 69);
            TransferMoveToWarehouseLabel.TabIndex = 46;
            TransferMoveToWarehouseLabel.Text = "Selected Items To Transfer\r\nDefault quantity is the maximum available\r\nyou can edit it";
            TransferMoveToWarehouseLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TransferToWarehouseGridView
            // 
            TransferToWarehouseGridView.AccessibleName = "TransferToWarehouseGridView";
            TransferToWarehouseGridView.AllowUserToAddRows = false;
            TransferToWarehouseGridView.AllowUserToDeleteRows = false;
            TransferToWarehouseGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            TransferToWarehouseGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TransferToWarehouseGridView.Location = new Point(1030, 154);
            TransferToWarehouseGridView.Name = "TransferToWarehouseGridView";
            TransferToWarehouseGridView.RowHeadersWidth = 51;
            TransferToWarehouseGridView.Size = new Size(866, 473);
            TransferToWarehouseGridView.TabIndex = 47;
            TransferToWarehouseGridView.CellBeginEdit += TransferToWarehouseGridView_CellBeginEdit;
            TransferToWarehouseGridView.CellEndEdit += TransferToWarehouseGridView_CellEndEdit;
            // 
            // TransferToDeleteSelectedItemButton
            // 
            TransferToDeleteSelectedItemButton.AccessibleName = "TransferToDeleteSelectedItemButton";
            TransferToDeleteSelectedItemButton.Location = new Point(1301, 652);
            TransferToDeleteSelectedItemButton.Name = "TransferToDeleteSelectedItemButton";
            TransferToDeleteSelectedItemButton.Size = new Size(331, 33);
            TransferToDeleteSelectedItemButton.TabIndex = 48;
            TransferToDeleteSelectedItemButton.Text = "Delete Selected Item";
            TransferToDeleteSelectedItemButton.UseVisualStyleBackColor = true;
            TransferToDeleteSelectedItemButton.Click += TransferToDeleteSelectedItemButton_Click;
            // 
            // TransferToWarehouseLabel
            // 
            TransferToWarehouseLabel.AccessibleName = "TransferToWarehouseLabel";
            TransferToWarehouseLabel.AutoSize = true;
            TransferToWarehouseLabel.Location = new Point(1211, 52);
            TransferToWarehouseLabel.Name = "TransferToWarehouseLabel";
            TransferToWarehouseLabel.Size = new Size(117, 23);
            TransferToWarehouseLabel.TabIndex = 49;
            TransferToWarehouseLabel.Text = "To Warehouse";
            // 
            // TransferToWarehouseComboBox
            // 
            TransferToWarehouseComboBox.AccessibleName = "TransferToWarehouseComboBox";
            TransferToWarehouseComboBox.FormattingEnabled = true;
            TransferToWarehouseComboBox.Location = new Point(1421, 42);
            TransferToWarehouseComboBox.Name = "TransferToWarehouseComboBox";
            TransferToWarehouseComboBox.Size = new Size(281, 31);
            TransferToWarehouseComboBox.TabIndex = 50;
            TransferToWarehouseComboBox.SelectedIndexChanged += TransferToWarehouseComboBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AccessibleName = "UserChosenWarehouseViewLabel";
            label1.AutoSize = true;
            label1.Location = new Point(1301, 110);
            label1.Name = "label1";
            label1.Size = new Size(353, 23);
            label1.TabIndex = 51;
            label1.Text = "Items to be added to Destination Warehouse";
            // 
            // TransferVoucherForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(2330, 1148);
            Controls.Add(label1);
            Controls.Add(TransferToWarehouseLabel);
            Controls.Add(TransferToWarehouseComboBox);
            Controls.Add(TransferToDeleteSelectedItemButton);
            Controls.Add(TransferFromWarehouseGridView);
            Controls.Add(TransferToWarehouseGridView);
            Controls.Add(TransferFromWarehouseLabel);
            Controls.Add(TransferMoveToWarehouseLabel);
            Controls.Add(TransferDateLabel);
            Controls.Add(UserChosenWarehouseViewLabel);
            Controls.Add(TransferDateDatePicker);
            Controls.Add(TransferFromWarehouseComboBox);
            Controls.Add(TransferCreateVoucherButton);
            Font = new Font("Segoe UI", 10F);
            Name = "TransferVoucherForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Transfer between warehouses voucher";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)TransferFromWarehouseGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)TransferToWarehouseGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView TransferFromWarehouseGridView;
        private Label TransferFromWarehouseLabel;
        private Label TransferDateLabel;
        private DateTimePicker TransferDateDatePicker;
        private ComboBox TransferFromWarehouseComboBox;
        private Button TransferCreateVoucherButton;
        private Label UserChosenWarehouseViewLabel;
        private Label TransferMoveToWarehouseLabel;
        private DataGridView TransferToWarehouseGridView;
        private Button TransferToDeleteSelectedItemButton;
        private Label TransferToWarehouseLabel;
        private ComboBox TransferToWarehouseComboBox;
        private Label label1;
    }
}