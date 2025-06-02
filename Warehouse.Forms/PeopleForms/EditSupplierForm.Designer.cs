namespace WarehouseManagmentSystem.WinForms.PeopleForms
{
    partial class EditSupplierForm
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
            SupplierDataGridView = new DataGridView();
            tableLayoutPanel1 = new TableLayoutPanel();
            UserNameLabel = new Label();
            UserNameTextBox = new TextBox();
            UserWebsiteLabel = new Label();
            UserWebsiteTextBox = new TextBox();
            UserLandlineLabel = new Label();
            UserEmailTextBox = new TextBox();
            UserEmailLabel = new Label();
            UserLandlineTextBox = new TextBox();
            UserMobileTextBox = new TextBox();
            UserFaxTextBox = new TextBox();
            UserMobileLabel = new Label();
            UserFaxLabel = new Label();
            AddUserButton = new Button();
            ((System.ComponentModel.ISupportInitialize)SupplierDataGridView).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // SupplierDataGridView
            // 
            SupplierDataGridView.AccessibleName = "personDataGridView";
            SupplierDataGridView.AllowUserToAddRows = false;
            SupplierDataGridView.AllowUserToDeleteRows = false;
            SupplierDataGridView.AllowUserToOrderColumns = true;
            SupplierDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SupplierDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SupplierDataGridView.Dock = DockStyle.Top;
            SupplierDataGridView.Location = new Point(0, 0);
            SupplierDataGridView.Name = "SupplierDataGridView";
            SupplierDataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            SupplierDataGridView.Size = new Size(2319, 323);
            SupplierDataGridView.TabIndex = 42;
            SupplierDataGridView.CellDoubleClick += SupplierDataGridView_CellDoubleClick;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.6018F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 2.1431632F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.83069F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.044149F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 61.5087852F));
            tableLayoutPanel1.Controls.Add(UserNameLabel, 0, 1);
            tableLayoutPanel1.Controls.Add(UserNameTextBox, 2, 1);
            tableLayoutPanel1.Controls.Add(UserWebsiteLabel, 0, 11);
            tableLayoutPanel1.Controls.Add(UserWebsiteTextBox, 2, 11);
            tableLayoutPanel1.Controls.Add(UserLandlineLabel, 0, 3);
            tableLayoutPanel1.Controls.Add(UserEmailTextBox, 2, 9);
            tableLayoutPanel1.Controls.Add(UserEmailLabel, 0, 9);
            tableLayoutPanel1.Controls.Add(UserLandlineTextBox, 2, 3);
            tableLayoutPanel1.Controls.Add(UserMobileTextBox, 2, 7);
            tableLayoutPanel1.Controls.Add(UserFaxTextBox, 2, 5);
            tableLayoutPanel1.Controls.Add(UserMobileLabel, 0, 7);
            tableLayoutPanel1.Controls.Add(UserFaxLabel, 0, 5);
            tableLayoutPanel1.Controls.Add(AddUserButton, 3, 5);
            tableLayoutPanel1.Font = new Font("Segoe UI", 10F);
            tableLayoutPanel1.Location = new Point(0, 450);
            tableLayoutPanel1.Margin = new Padding(10, 3, 3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 13;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69230747F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69230747F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69230747F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69230747F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69230747F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69230747F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69230747F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69230747F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69230747F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69230747F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69230747F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69230747F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69230747F));
            tableLayoutPanel1.Size = new Size(2333, 468);
            tableLayoutPanel1.TabIndex = 43;
            // 
            // UserNameLabel
            // 
            UserNameLabel.AccessibleName = "UserNameLabel";
            UserNameLabel.AutoSize = true;
            UserNameLabel.Location = new Point(3, 36);
            UserNameLabel.Name = "UserNameLabel";
            UserNameLabel.Size = new Size(56, 23);
            UserNameLabel.TabIndex = 16;
            UserNameLabel.Text = "Name";
            // 
            // UserNameTextBox
            // 
            UserNameTextBox.AccessibleName = "UserNameTextBox";
            UserNameTextBox.Location = new Point(345, 39);
            UserNameTextBox.Name = "UserNameTextBox";
            UserNameTextBox.Size = new Size(245, 30);
            UserNameTextBox.TabIndex = 22;
            // 
            // UserWebsiteLabel
            // 
            UserWebsiteLabel.AccessibleName = "UserWebsiteLabel";
            UserWebsiteLabel.AutoSize = true;
            UserWebsiteLabel.Location = new Point(3, 396);
            UserWebsiteLabel.Name = "UserWebsiteLabel";
            UserWebsiteLabel.Size = new Size(70, 23);
            UserWebsiteLabel.TabIndex = 21;
            UserWebsiteLabel.Text = "Website";
            // 
            // UserWebsiteTextBox
            // 
            UserWebsiteTextBox.AccessibleName = "UserWebsiteLabel";
            UserWebsiteTextBox.Location = new Point(345, 399);
            UserWebsiteTextBox.Name = "UserWebsiteTextBox";
            UserWebsiteTextBox.Size = new Size(245, 30);
            UserWebsiteTextBox.TabIndex = 27;
            // 
            // UserLandlineLabel
            // 
            UserLandlineLabel.AccessibleName = "UserLandlineLabel";
            UserLandlineLabel.AutoSize = true;
            UserLandlineLabel.Location = new Point(3, 108);
            UserLandlineLabel.Name = "UserLandlineLabel";
            UserLandlineLabel.Size = new Size(139, 23);
            UserLandlineLabel.TabIndex = 17;
            UserLandlineLabel.Text = "Landline number";
            // 
            // UserEmailTextBox
            // 
            UserEmailTextBox.AccessibleName = "UserEmailTextBox";
            UserEmailTextBox.Location = new Point(345, 327);
            UserEmailTextBox.Name = "UserEmailTextBox";
            UserEmailTextBox.Size = new Size(245, 30);
            UserEmailTextBox.TabIndex = 26;
            // 
            // UserEmailLabel
            // 
            UserEmailLabel.AccessibleName = "UserEmailLabel";
            UserEmailLabel.AutoSize = true;
            UserEmailLabel.Location = new Point(3, 324);
            UserEmailLabel.Name = "UserEmailLabel";
            UserEmailLabel.Size = new Size(51, 23);
            UserEmailLabel.TabIndex = 20;
            UserEmailLabel.Text = "Email";
            // 
            // UserLandlineTextBox
            // 
            UserLandlineTextBox.AccessibleName = "UserLandlineTextBox";
            UserLandlineTextBox.Location = new Point(345, 111);
            UserLandlineTextBox.Name = "UserLandlineTextBox";
            UserLandlineTextBox.Size = new Size(245, 30);
            UserLandlineTextBox.TabIndex = 23;
            // 
            // UserMobileTextBox
            // 
            UserMobileTextBox.AccessibleName = "UserMobileTextBox";
            UserMobileTextBox.Location = new Point(345, 255);
            UserMobileTextBox.Name = "UserMobileTextBox";
            UserMobileTextBox.Size = new Size(245, 30);
            UserMobileTextBox.TabIndex = 25;
            // 
            // UserFaxTextBox
            // 
            UserFaxTextBox.AccessibleName = "UserFaxTextBox";
            UserFaxTextBox.Location = new Point(345, 183);
            UserFaxTextBox.Name = "UserFaxTextBox";
            UserFaxTextBox.Size = new Size(245, 30);
            UserFaxTextBox.TabIndex = 24;
            // 
            // UserMobileLabel
            // 
            UserMobileLabel.AccessibleName = "UserMobileLabel";
            UserMobileLabel.AutoSize = true;
            UserMobileLabel.Location = new Point(3, 252);
            UserMobileLabel.Name = "UserMobileLabel";
            UserMobileLabel.Size = new Size(127, 23);
            UserMobileLabel.TabIndex = 19;
            UserMobileLabel.Text = "Mobile number";
            // 
            // UserFaxLabel
            // 
            UserFaxLabel.AccessibleName = "UserFaxLabel";
            UserFaxLabel.AutoSize = true;
            UserFaxLabel.Location = new Point(3, 180);
            UserFaxLabel.Name = "UserFaxLabel";
            UserFaxLabel.Size = new Size(99, 23);
            UserFaxLabel.TabIndex = 18;
            UserFaxLabel.Text = "Fax number";
            // 
            // AddUserButton
            // 
            AddUserButton.AccessibleName = "EditUserButton";
            AddUserButton.Location = new Point(690, 183);
            AddUserButton.Name = "AddUserButton";
            AddUserButton.Size = new Size(183, 29);
            AddUserButton.TabIndex = 29;
            AddUserButton.Text = "Edit Supplier";
            AddUserButton.UseVisualStyleBackColor = true;
            AddUserButton.Click += UpdateSupplierButton_Click;
            // 
            // EditSupplierForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2319, 1148);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(SupplierDataGridView);
            Name = "EditSupplierForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Edit Supplier";
            WindowState = FormWindowState.Maximized;
            Load += EditSupplierForm_Load;
            ((System.ComponentModel.ISupportInitialize)SupplierDataGridView).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView SupplierDataGridView;
        private TableLayoutPanel tableLayoutPanel1;
        private Label UserNameLabel;
        private TextBox UserNameTextBox;
        private Label UserWebsiteLabel;
        private TextBox UserWebsiteTextBox;
        private Label UserLandlineLabel;
        private TextBox UserEmailTextBox;
        private Label UserEmailLabel;
        private TextBox UserLandlineTextBox;
        private TextBox UserMobileTextBox;
        private TextBox UserFaxTextBox;
        private Label UserMobileLabel;
        private Label UserFaxLabel;
        private Button AddUserButton;
    }
}