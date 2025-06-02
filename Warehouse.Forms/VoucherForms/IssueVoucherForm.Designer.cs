namespace WarehouseManagmentSystem.WinForms
{
    partial class IssueVoucherForm
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
            IssueDeleteSelectedItemButton = new Button();
            IssueSelectedItemsGridView = new DataGridView();
            IssueVoucherMoveToIssueLabel = new Label();
            UserChosenWarehouseViewLabel = new Label();
            IssueVoucherChosenCustomerLabel = new Label();
            IssueVoucherRemoveFromWarehouseButton = new Button();
            IssueVoucherCustomerComboBox = new ComboBox();
            IssueVoucherWarehouseComboBox = new ComboBox();
            IssueVoucherIssueDate = new DateTimePicker();
            IssueVoucherIssueDateLabel = new Label();
            IssueVoucherWarehouseLabel = new Label();
            IssueVoucherItemsGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)IssueSelectedItemsGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)IssueVoucherItemsGridView).BeginInit();
            SuspendLayout();
            // 
            // IssueDeleteSelectedItemButton
            // 
            IssueDeleteSelectedItemButton.AccessibleName = "IssueDeleteSelectedItemButton";
            IssueDeleteSelectedItemButton.Location = new Point(1303, 644);
            IssueDeleteSelectedItemButton.Name = "IssueDeleteSelectedItemButton";
            IssueDeleteSelectedItemButton.Size = new Size(331, 33);
            IssueDeleteSelectedItemButton.TabIndex = 48;
            IssueDeleteSelectedItemButton.Text = "Delete Selected Item";
            IssueDeleteSelectedItemButton.UseVisualStyleBackColor = true;
            IssueDeleteSelectedItemButton.Click += IssueDeleteSelectedItemButton_Click;
            // 
            // IssueSelectedItemsGridView
            // 
            IssueSelectedItemsGridView.AccessibleName = "IssueSelectedItemsGridView";
            IssueSelectedItemsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            IssueSelectedItemsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            IssueSelectedItemsGridView.Location = new Point(1030, 154);
            IssueSelectedItemsGridView.Name = "IssueSelectedItemsGridView";
            IssueSelectedItemsGridView.RowHeadersWidth = 51;
            IssueSelectedItemsGridView.Size = new Size(866, 473);
            IssueSelectedItemsGridView.TabIndex = 47;
            IssueSelectedItemsGridView.CellBeginEdit += IssueSelectedItemsGridView_CellBeginEdit;
            IssueSelectedItemsGridView.CellEndEdit += IssueSelectedItemsGridView_CellEndEdit;
            // 
            // IssueVoucherMoveToIssueLabel
            // 
            IssueVoucherMoveToIssueLabel.AccessibleName = "IssueVoucherMoveToIssueLabel";
            IssueVoucherMoveToIssueLabel.AutoSize = true;
            IssueVoucherMoveToIssueLabel.Location = new Point(1303, 52);
            IssueVoucherMoveToIssueLabel.Name = "IssueVoucherMoveToIssueLabel";
            IssueVoucherMoveToIssueLabel.Size = new Size(331, 92);
            IssueVoucherMoveToIssueLabel.TabIndex = 46;
            IssueVoucherMoveToIssueLabel.Text = "Selected Items To Issue\r\nDefault quantity is the maximum available\r\nyou can edit it\r\n\r\n";
            IssueVoucherMoveToIssueLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UserChosenWarehouseViewLabel
            // 
            UserChosenWarehouseViewLabel.AccessibleName = "UserChosenWarehouseViewLabel";
            UserChosenWarehouseViewLabel.AutoSize = true;
            UserChosenWarehouseViewLabel.Location = new Point(323, 114);
            UserChosenWarehouseViewLabel.Name = "UserChosenWarehouseViewLabel";
            UserChosenWarehouseViewLabel.Size = new Size(224, 23);
            UserChosenWarehouseViewLabel.TabIndex = 44;
            UserChosenWarehouseViewLabel.Text = "Items at Chosen Warehouse";
            // 
            // IssueVoucherChosenCustomerLabel
            // 
            IssueVoucherChosenCustomerLabel.AccessibleName = "IssueVoucherChosenCustomerLabel";
            IssueVoucherChosenCustomerLabel.AutoSize = true;
            IssueVoucherChosenCustomerLabel.Location = new Point(56, 748);
            IssueVoucherChosenCustomerLabel.Name = "IssueVoucherChosenCustomerLabel";
            IssueVoucherChosenCustomerLabel.Size = new Size(148, 23);
            IssueVoucherChosenCustomerLabel.TabIndex = 41;
            IssueVoucherChosenCustomerLabel.Text = "Issue to Customer";
            // 
            // IssueVoucherRemoveFromWarehouseButton
            // 
            IssueVoucherRemoveFromWarehouseButton.AccessibleName = "IssueVoucherRemoveFromWarehouseButton";
            IssueVoucherRemoveFromWarehouseButton.Location = new Point(832, 814);
            IssueVoucherRemoveFromWarehouseButton.Name = "IssueVoucherRemoveFromWarehouseButton";
            IssueVoucherRemoveFromWarehouseButton.Size = new Size(240, 92);
            IssueVoucherRemoveFromWarehouseButton.TabIndex = 36;
            IssueVoucherRemoveFromWarehouseButton.Text = "Create Voucher";
            IssueVoucherRemoveFromWarehouseButton.UseVisualStyleBackColor = true;
            IssueVoucherRemoveFromWarehouseButton.Click += this.IssueVoucherRemoveFromWarehouseButton_Click;
            // 
            // IssueVoucherCustomerComboBox
            // 
            IssueVoucherCustomerComboBox.AccessibleName = "IssueVoucherCustomerComboBox";
            IssueVoucherCustomerComboBox.FormattingEnabled = true;
            IssueVoucherCustomerComboBox.Location = new Point(266, 748);
            IssueVoucherCustomerComboBox.Name = "IssueVoucherCustomerComboBox";
            IssueVoucherCustomerComboBox.Size = new Size(281, 31);
            IssueVoucherCustomerComboBox.TabIndex = 33;
            // 
            // IssueVoucherWarehouseComboBox
            // 
            IssueVoucherWarehouseComboBox.AccessibleName = "IssueVoucherWarehouseComboBox";
            IssueVoucherWarehouseComboBox.FormattingEnabled = true;
            IssueVoucherWarehouseComboBox.Location = new Point(307, 42);
            IssueVoucherWarehouseComboBox.Name = "IssueVoucherWarehouseComboBox";
            IssueVoucherWarehouseComboBox.Size = new Size(281, 31);
            IssueVoucherWarehouseComboBox.TabIndex = 32;
            IssueVoucherWarehouseComboBox.SelectedIndexChanged += IssueVoucherWarehouseComboBox_SelectedIndexChanged;
            // 
            // IssueVoucherIssueDate
            // 
            IssueVoucherIssueDate.AccessibleName = "IssueVoucherIssueDate";
            IssueVoucherIssueDate.Location = new Point(266, 669);
            IssueVoucherIssueDate.Name = "IssueVoucherIssueDate";
            IssueVoucherIssueDate.Size = new Size(281, 30);
            IssueVoucherIssueDate.TabIndex = 29;
            // 
            // IssueVoucherIssueDateLabel
            // 
            IssueVoucherIssueDateLabel.AccessibleName = "IssueVoucherIssueDateLabel";
            IssueVoucherIssueDateLabel.AutoSize = true;
            IssueVoucherIssueDateLabel.Location = new Point(58, 677);
            IssueVoucherIssueDateLabel.Name = "IssueVoucherIssueDateLabel";
            IssueVoucherIssueDateLabel.Size = new Size(89, 23);
            IssueVoucherIssueDateLabel.TabIndex = 25;
            IssueVoucherIssueDateLabel.Text = "Issue Date";
            // 
            // IssueVoucherWarehouseLabel
            // 
            IssueVoucherWarehouseLabel.AccessibleName = "IssueVoucherWarehouseLabel";
            IssueVoucherWarehouseLabel.AutoSize = true;
            IssueVoucherWarehouseLabel.Location = new Point(99, 52);
            IssueVoucherWarehouseLabel.Name = "IssueVoucherWarehouseLabel";
            IssueVoucherWarehouseLabel.Size = new Size(139, 23);
            IssueVoucherWarehouseLabel.TabIndex = 24;
            IssueVoucherWarehouseLabel.Text = "From Warehouse";
            // 
            // IssueVoucherItemsGridView
            // 
            IssueVoucherItemsGridView.AccessibleName = "IssueVoucherItemsCheckItemsGridView";
            IssueVoucherItemsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            IssueVoucherItemsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            IssueVoucherItemsGridView.Location = new Point(33, 154);
            IssueVoucherItemsGridView.Name = "IssueVoucherItemsGridView";
            IssueVoucherItemsGridView.ReadOnly = true;
            IssueVoucherItemsGridView.RowHeadersWidth = 51;
            IssueVoucherItemsGridView.Size = new Size(866, 473);
            IssueVoucherItemsGridView.TabIndex = 34;
            IssueVoucherItemsGridView.CellDoubleClick += IssueVoucherItemsGridView_CellDoubleClick;
            // 
            // IssueVoucherForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(2594, 1325);
            Controls.Add(IssueDeleteSelectedItemButton);
            Controls.Add(IssueSelectedItemsGridView);
            Controls.Add(IssueVoucherMoveToIssueLabel);
            Controls.Add(UserChosenWarehouseViewLabel);
            Controls.Add(IssueVoucherChosenCustomerLabel);
            Controls.Add(IssueVoucherRemoveFromWarehouseButton);
            Controls.Add(IssueVoucherItemsGridView);
            Controls.Add(IssueVoucherCustomerComboBox);
            Controls.Add(IssueVoucherWarehouseComboBox);
            Controls.Add(IssueVoucherIssueDate);
            Controls.Add(IssueVoucherIssueDateLabel);
            Controls.Add(IssueVoucherWarehouseLabel);
            Font = new Font("Segoe UI", 10F);
            Name = "IssueVoucherForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Issue Voucher";
            WindowState = FormWindowState.Maximized;
            Load += IssueVoucherForm_Load;
            ((System.ComponentModel.ISupportInitialize)IssueSelectedItemsGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)IssueVoucherItemsGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button IssueDeleteSelectedItemButton;
        private DataGridView IssueSelectedItemsGridView;
        private Label IssueVoucherMoveToIssueLabel;
        private Label UserChosenWarehouseViewLabel;
        private Label IssueVoucherChosenCustomerLabel;
        private Button IssueVoucherRemoveFromWarehouseButton;
        private ComboBox IssueVoucherCustomerComboBox;
        private ComboBox IssueVoucherWarehouseComboBox;
        private DateTimePicker IssueVoucherIssueDate;
        private Label IssueVoucherIssueDateLabel;
        private Label IssueVoucherWarehouseLabel;
        private DataGridView IssueVoucherItemsGridView;
    }
}