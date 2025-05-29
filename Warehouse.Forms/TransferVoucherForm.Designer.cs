
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
            ((System.ComponentModel.ISupportInitialize)TransferFromWarehouseGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TransferToWarehouseGridView).BeginInit();
            SuspendLayout();
            // 
            // TransferFromWarehouseGridView
            // 
            TransferFromWarehouseGridView.AccessibleName = "TransferFromWarehouseGridView";
            TransferFromWarehouseGridView.AccessibleRole = AccessibleRole.None;
            TransferFromWarehouseGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            TransferFromWarehouseGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TransferFromWarehouseGridView.Location = new Point(15, 184);
            TransferFromWarehouseGridView.Name = "TransferFromWarehouseGridView";
            TransferFromWarehouseGridView.ReadOnly = true;
            TransferFromWarehouseGridView.RowHeadersWidth = 51;
            TransferFromWarehouseGridView.Size = new Size(805, 411);
            TransferFromWarehouseGridView.TabIndex = 34;
            TransferFromWarehouseGridView.CellDoubleClick += TransferFromWarehouseGridView_CellDoubleClick;
            // 
            // TransferFromWarehouseLabel
            // 
            TransferFromWarehouseLabel.AccessibleName = "TransferFromWarehouseLabel";
            TransferFromWarehouseLabel.AutoSize = true;
            TransferFromWarehouseLabel.Location = new Point(30, 38);
            TransferFromWarehouseLabel.Name = "TransferFromWarehouseLabel";
            TransferFromWarehouseLabel.Size = new Size(120, 20);
            TransferFromWarehouseLabel.TabIndex = 24;
            TransferFromWarehouseLabel.Text = "From Warehouse";
            // 
            // TransferDateLabel
            // 
            TransferDateLabel.AccessibleName = "TransferDateLabel";
            TransferDateLabel.AutoSize = true;
            TransferDateLabel.Location = new Point(29, 659);
            TransferDateLabel.Name = "TransferDateLabel";
            TransferDateLabel.Size = new Size(97, 20);
            TransferDateLabel.TabIndex = 25;
            TransferDateLabel.Text = "Transfer Date";
            // 
            // TransferDateDatePicker
            // 
            TransferDateDatePicker.AccessibleName = "TransferDateDatePicker";
            TransferDateDatePicker.Location = new Point(214, 652);
            TransferDateDatePicker.Name = "TransferDateDatePicker";
            TransferDateDatePicker.Size = new Size(250, 27);
            TransferDateDatePicker.TabIndex = 29;
            // 
            // TransferFromWarehouseComboBox
            // 
            TransferFromWarehouseComboBox.AccessibleName = "TransferFromWarehouseComboBox";
            TransferFromWarehouseComboBox.FormattingEnabled = true;
            TransferFromWarehouseComboBox.Location = new Point(215, 30);
            TransferFromWarehouseComboBox.Name = "TransferFromWarehouseComboBox";
            TransferFromWarehouseComboBox.Size = new Size(250, 28);
            TransferFromWarehouseComboBox.TabIndex = 32;
            TransferFromWarehouseComboBox.SelectedIndexChanged += TransferFromWarehouseComboBox_SelectedIndexChanged;
            // 
            // TransferCreateVoucherButton
            // 
            TransferCreateVoucherButton.AccessibleName = "TransferCreateVoucherButton";
            TransferCreateVoucherButton.Location = new Point(808, 728);
            TransferCreateVoucherButton.Name = "TransferCreateVoucherButton";
            TransferCreateVoucherButton.Size = new Size(213, 80);
            TransferCreateVoucherButton.TabIndex = 36;
            TransferCreateVoucherButton.Text = "Create Voucher";
            TransferCreateVoucherButton.UseVisualStyleBackColor = true;
            TransferCreateVoucherButton.Click += TransferCreateVoucherButton_ClickAsync;
            // 
            // UserChosenWarehouseViewLabel
            // 
            UserChosenWarehouseViewLabel.AccessibleName = "UserChosenWarehouseViewLabel";
            UserChosenWarehouseViewLabel.AutoSize = true;
            UserChosenWarehouseViewLabel.Location = new Point(273, 149);
            UserChosenWarehouseViewLabel.Name = "UserChosenWarehouseViewLabel";
            UserChosenWarehouseViewLabel.Size = new Size(191, 20);
            UserChosenWarehouseViewLabel.TabIndex = 44;
            UserChosenWarehouseViewLabel.Text = "Items at Chosen Warehouse";
            // 
            // TransferMoveToWarehouseLabel
            // 
            TransferMoveToWarehouseLabel.AccessibleName = "TransferMoveToWarehouseLabel";
            TransferMoveToWarehouseLabel.AutoSize = true;
            TransferMoveToWarehouseLabel.Location = new Point(1250, 119);
            TransferMoveToWarehouseLabel.Name = "TransferMoveToWarehouseLabel";
            TransferMoveToWarehouseLabel.Size = new Size(289, 60);
            TransferMoveToWarehouseLabel.TabIndex = 46;
            TransferMoveToWarehouseLabel.Text = "Selected Items To Transfer\r\nDefault quantity is the maximum available\r\nyou can edit it";
            TransferMoveToWarehouseLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TransferToWarehouseGridView
            // 
            TransferToWarehouseGridView.AccessibleName = "TransferToWarehouseGridView";
            TransferToWarehouseGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            TransferToWarehouseGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TransferToWarehouseGridView.Location = new Point(1002, 184);
            TransferToWarehouseGridView.Name = "TransferToWarehouseGridView";
            TransferToWarehouseGridView.RowHeadersWidth = 51;
            TransferToWarehouseGridView.Size = new Size(805, 411);
            TransferToWarehouseGridView.TabIndex = 47;
            TransferToWarehouseGridView.CellBeginEdit += TransferToWarehouseGridView_CellBeginEdit;
            TransferToWarehouseGridView.CellEndEdit += TransferToWarehouseGridView_CellEndEdit;
            // 
            // TransferToDeleteSelectedItemButton
            // 
            TransferToDeleteSelectedItemButton.AccessibleName = "TransferToDeleteSelectedItemButton";
            TransferToDeleteSelectedItemButton.Location = new Point(1263, 618);
            TransferToDeleteSelectedItemButton.Name = "TransferToDeleteSelectedItemButton";
            TransferToDeleteSelectedItemButton.Size = new Size(267, 29);
            TransferToDeleteSelectedItemButton.TabIndex = 48;
            TransferToDeleteSelectedItemButton.Text = "Delete Selected Item";
            TransferToDeleteSelectedItemButton.UseVisualStyleBackColor = true;
            TransferToDeleteSelectedItemButton.Click += TransferToDeleteSelectedItemButton_Click;
            // 
            // TransferToWarehouseLabel
            // 
            TransferToWarehouseLabel.AccessibleName = "TransferToWarehouseLabel";
            TransferToWarehouseLabel.AutoSize = true;
            TransferToWarehouseLabel.Location = new Point(1053, 43);
            TransferToWarehouseLabel.Name = "TransferToWarehouseLabel";
            TransferToWarehouseLabel.Size = new Size(102, 20);
            TransferToWarehouseLabel.TabIndex = 49;
            TransferToWarehouseLabel.Text = "To Warehouse";
            // 
            // TransferToWarehouseComboBox
            // 
            TransferToWarehouseComboBox.AccessibleName = "TransferToWarehouseComboBox";
            TransferToWarehouseComboBox.FormattingEnabled = true;
            TransferToWarehouseComboBox.Location = new Point(1263, 30);
            TransferToWarehouseComboBox.Name = "TransferToWarehouseComboBox";
            TransferToWarehouseComboBox.Size = new Size(250, 28);
            TransferToWarehouseComboBox.TabIndex = 50;
            TransferToWarehouseComboBox.SelectedIndexChanged += TransferToWarehouseComboBox_SelectedIndexChanged;
            // 
            // TransferVoucherForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1879, 932);
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
            Name = "TransferVoucherForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TransferVoucherForm";
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
    }
}