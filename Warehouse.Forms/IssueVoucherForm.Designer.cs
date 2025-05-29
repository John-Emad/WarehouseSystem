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
            IssueVoucherAddToWarehouseButton = new Button();
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
            IssueDeleteSelectedItemButton.Location = new Point(1419, 599);
            IssueDeleteSelectedItemButton.Name = "IssueDeleteSelectedItemButton";
            IssueDeleteSelectedItemButton.Size = new Size(267, 29);
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
            IssueSelectedItemsGridView.Location = new Point(1158, 165);
            IssueSelectedItemsGridView.Name = "IssueSelectedItemsGridView";
            IssueSelectedItemsGridView.RowHeadersWidth = 51;
            IssueSelectedItemsGridView.Size = new Size(805, 411);
            IssueSelectedItemsGridView.TabIndex = 47;
            IssueSelectedItemsGridView.CellBeginEdit += IssueSelectedItemsGridView_CellBeginEdit;
            IssueSelectedItemsGridView.CellEndEdit += IssueSelectedItemsGridView_CellEndEdit;
            // 
            // IssueVoucherMoveToIssueLabel
            // 
            IssueVoucherMoveToIssueLabel.AccessibleName = "IssueVoucherMoveToIssueLabel";
            IssueVoucherMoveToIssueLabel.AutoSize = true;
            IssueVoucherMoveToIssueLabel.Location = new Point(1447, 82);
            IssueVoucherMoveToIssueLabel.Name = "IssueVoucherMoveToIssueLabel";
            IssueVoucherMoveToIssueLabel.Size = new Size(289, 80);
            IssueVoucherMoveToIssueLabel.TabIndex = 46;
            IssueVoucherMoveToIssueLabel.Text = "Selected Items To Issue\r\nDefault quantity is the maximum available\r\nyou can edit it\r\n\r\n";
            IssueVoucherMoveToIssueLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UserChosenWarehouseViewLabel
            // 
            UserChosenWarehouseViewLabel.AccessibleName = "UserChosenWarehouseViewLabel";
            UserChosenWarehouseViewLabel.AutoSize = true;
            UserChosenWarehouseViewLabel.Location = new Point(288, 130);
            UserChosenWarehouseViewLabel.Name = "UserChosenWarehouseViewLabel";
            UserChosenWarehouseViewLabel.Size = new Size(191, 20);
            UserChosenWarehouseViewLabel.TabIndex = 44;
            UserChosenWarehouseViewLabel.Text = "Items at Chosen Warehouse";
            // 
            // IssueVoucherChosenCustomerLabel
            // 
            IssueVoucherChosenCustomerLabel.AccessibleName = "IssueVoucherChosenCustomerLabel";
            IssueVoucherChosenCustomerLabel.AutoSize = true;
            IssueVoucherChosenCustomerLabel.Location = new Point(43, 702);
            IssueVoucherChosenCustomerLabel.Name = "IssueVoucherChosenCustomerLabel";
            IssueVoucherChosenCustomerLabel.Size = new Size(129, 20);
            IssueVoucherChosenCustomerLabel.TabIndex = 41;
            IssueVoucherChosenCustomerLabel.Text = "Issue to Customer:";
            // 
            // IssueVoucherAddToWarehouseButton
            // 
            IssueVoucherAddToWarehouseButton.AccessibleName = "IssueVoucherAddToWarehouseButton";
            IssueVoucherAddToWarehouseButton.Location = new Point(1026, 866);
            IssueVoucherAddToWarehouseButton.Name = "IssueVoucherAddToWarehouseButton";
            IssueVoucherAddToWarehouseButton.Size = new Size(213, 80);
            IssueVoucherAddToWarehouseButton.TabIndex = 36;
            IssueVoucherAddToWarehouseButton.Text = "Create Voucher";
            IssueVoucherAddToWarehouseButton.UseVisualStyleBackColor = true;
            IssueVoucherAddToWarehouseButton.Click += IssueVoucherAddToWarehouseButton_Click;
            // 
            // IssueVoucherCustomerComboBox
            // 
            IssueVoucherCustomerComboBox.AccessibleName = "IssueVoucherCustomerComboBox";
            IssueVoucherCustomerComboBox.FormattingEnabled = true;
            IssueVoucherCustomerComboBox.Location = new Point(229, 702);
            IssueVoucherCustomerComboBox.Name = "IssueVoucherCustomerComboBox";
            IssueVoucherCustomerComboBox.Size = new Size(250, 28);
            IssueVoucherCustomerComboBox.TabIndex = 33;
            // 
            // IssueVoucherWarehouseComboBox
            // 
            IssueVoucherWarehouseComboBox.AccessibleName = "IssueVoucherWarehouseComboBox";
            IssueVoucherWarehouseComboBox.FormattingEnabled = true;
            IssueVoucherWarehouseComboBox.Location = new Point(215, 70);
            IssueVoucherWarehouseComboBox.Name = "IssueVoucherWarehouseComboBox";
            IssueVoucherWarehouseComboBox.Size = new Size(250, 28);
            IssueVoucherWarehouseComboBox.TabIndex = 32;
            IssueVoucherWarehouseComboBox.SelectedIndexChanged += IssueVoucherWarehouseComboBox_SelectedIndexChanged;
            // 
            // IssueVoucherIssueDate
            // 
            IssueVoucherIssueDate.AccessibleName = "IssueVoucherIssueDate";
            IssueVoucherIssueDate.Location = new Point(229, 633);
            IssueVoucherIssueDate.Name = "IssueVoucherIssueDate";
            IssueVoucherIssueDate.Size = new Size(250, 27);
            IssueVoucherIssueDate.TabIndex = 29;
            // 
            // IssueVoucherIssueDateLabel
            // 
            IssueVoucherIssueDateLabel.AccessibleName = "IssueVoucherIssueDateLabel";
            IssueVoucherIssueDateLabel.AutoSize = true;
            IssueVoucherIssueDateLabel.Location = new Point(44, 640);
            IssueVoucherIssueDateLabel.Name = "IssueVoucherIssueDateLabel";
            IssueVoucherIssueDateLabel.Size = new Size(77, 20);
            IssueVoucherIssueDateLabel.TabIndex = 25;
            IssueVoucherIssueDateLabel.Text = "Issue Date";
            // 
            // IssueVoucherWarehouseLabel
            // 
            IssueVoucherWarehouseLabel.AccessibleName = "IssueVoucherWarehouseLabel";
            IssueVoucherWarehouseLabel.AutoSize = true;
            IssueVoucherWarehouseLabel.Location = new Point(30, 78);
            IssueVoucherWarehouseLabel.Name = "IssueVoucherWarehouseLabel";
            IssueVoucherWarehouseLabel.Size = new Size(82, 20);
            IssueVoucherWarehouseLabel.TabIndex = 24;
            IssueVoucherWarehouseLabel.Text = "Warehouse";
            // 
            // IssueVoucherItemsGridView
            // 
            IssueVoucherItemsGridView.AccessibleName = "IssueVoucherItemsCheckItemsGridView";
            IssueVoucherItemsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            IssueVoucherItemsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            IssueVoucherItemsGridView.Location = new Point(30, 165);
            IssueVoucherItemsGridView.Name = "IssueVoucherItemsGridView";
            IssueVoucherItemsGridView.ReadOnly = true;
            IssueVoucherItemsGridView.RowHeadersWidth = 51;
            IssueVoucherItemsGridView.Size = new Size(805, 411);
            IssueVoucherItemsGridView.TabIndex = 34;
            IssueVoucherItemsGridView.CellDoubleClick += IssueVoucherItemsGridView_CellDoubleClick;
            // 
            // IssueVoucherForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(2191, 1118);
            Controls.Add(IssueDeleteSelectedItemButton);
            Controls.Add(IssueSelectedItemsGridView);
            Controls.Add(IssueVoucherMoveToIssueLabel);
            Controls.Add(UserChosenWarehouseViewLabel);
            Controls.Add(IssueVoucherChosenCustomerLabel);
            Controls.Add(IssueVoucherAddToWarehouseButton);
            Controls.Add(IssueVoucherItemsGridView);
            Controls.Add(IssueVoucherCustomerComboBox);
            Controls.Add(IssueVoucherWarehouseComboBox);
            Controls.Add(IssueVoucherIssueDate);
            Controls.Add(IssueVoucherIssueDateLabel);
            Controls.Add(IssueVoucherWarehouseLabel);
            Name = "IssueVoucherForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "IssueVoucherForm";
            WindowState = FormWindowState.Maximized;
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
        private Button IssueVoucherAddToWarehouseButton;
        private ComboBox IssueVoucherCustomerComboBox;
        private ComboBox IssueVoucherWarehouseComboBox;
        private DateTimePicker IssueVoucherIssueDate;
        private Label IssueVoucherIssueDateLabel;
        private Label IssueVoucherWarehouseLabel;
        private DataGridView IssueVoucherItemsGridView;
    }
}