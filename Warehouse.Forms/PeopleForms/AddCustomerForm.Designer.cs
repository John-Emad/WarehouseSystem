namespace WarehouseManagmentSystem.WinForms
{
    partial class AddCustomerForm
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
            UserNameLabel = new Label();
            UserLandlineLabel = new Label();
            UserFaxLabel = new Label();
            UserMobileLabel = new Label();
            UserEmailLabel = new Label();
            UserWebsiteLabel = new Label();
            UserNameTextBox = new TextBox();
            UserLandlineTextBox = new TextBox();
            UserFaxTextBox = new TextBox();
            UserMobileTextBox = new TextBox();
            UserEmailTextBox = new TextBox();
            UserWebsiteTextBox = new TextBox();
            CustomerDataGridView = new DataGridView();
            AddUserButton = new Button();
            ((System.ComponentModel.ISupportInitialize)CustomerDataGridView).BeginInit();
            SuspendLayout();
            // 
            // UserNameLabel
            // 
            UserNameLabel.AccessibleName = "UserNameLabel";
            UserNameLabel.AutoSize = true;
            UserNameLabel.Location = new Point(27, 50);
            UserNameLabel.Name = "UserNameLabel";
            UserNameLabel.Size = new Size(49, 20);
            UserNameLabel.TabIndex = 0;
            UserNameLabel.Text = "Name";
            // 
            // UserLandlineLabel
            // 
            UserLandlineLabel.AccessibleName = "UserLandlineLabel";
            UserLandlineLabel.AutoSize = true;
            UserLandlineLabel.Location = new Point(27, 114);
            UserLandlineLabel.Name = "UserLandlineLabel";
            UserLandlineLabel.Size = new Size(120, 20);
            UserLandlineLabel.TabIndex = 1;
            UserLandlineLabel.Text = "Landline number";
            // 
            // UserFaxLabel
            // 
            UserFaxLabel.AccessibleName = "UserFaxLabel";
            UserFaxLabel.AutoSize = true;
            UserFaxLabel.Location = new Point(27, 186);
            UserFaxLabel.Name = "UserFaxLabel";
            UserFaxLabel.Size = new Size(85, 20);
            UserFaxLabel.TabIndex = 2;
            UserFaxLabel.Text = "Fax number";
            // 
            // UserMobileLabel
            // 
            UserMobileLabel.AccessibleName = "UserMobileLabel";
            UserMobileLabel.AutoSize = true;
            UserMobileLabel.Location = new Point(27, 246);
            UserMobileLabel.Name = "UserMobileLabel";
            UserMobileLabel.Size = new Size(111, 20);
            UserMobileLabel.TabIndex = 3;
            UserMobileLabel.Text = "Mobile number";
            // 
            // UserEmailLabel
            // 
            UserEmailLabel.AccessibleName = "UserEmailLabel";
            UserEmailLabel.AutoSize = true;
            UserEmailLabel.Location = new Point(27, 308);
            UserEmailLabel.Name = "UserEmailLabel";
            UserEmailLabel.Size = new Size(46, 20);
            UserEmailLabel.TabIndex = 4;
            UserEmailLabel.Text = "Email";
            // 
            // UserWebsiteLabel
            // 
            UserWebsiteLabel.AccessibleName = "UserWebsiteLabel";
            UserWebsiteLabel.AutoSize = true;
            UserWebsiteLabel.Location = new Point(27, 378);
            UserWebsiteLabel.Name = "UserWebsiteLabel";
            UserWebsiteLabel.Size = new Size(62, 20);
            UserWebsiteLabel.TabIndex = 5;
            UserWebsiteLabel.Text = "Website";
            // 
            // UserNameTextBox
            // 
            UserNameTextBox.AccessibleName = "UserNameTextBox";
            UserNameTextBox.Location = new Point(201, 43);
            UserNameTextBox.Name = "UserNameTextBox";
            UserNameTextBox.Size = new Size(245, 27);
            UserNameTextBox.TabIndex = 6;
            // 
            // UserLandlineTextBox
            // 
            UserLandlineTextBox.AccessibleName = "UserLandlineTextBox";
            UserLandlineTextBox.Location = new Point(201, 107);
            UserLandlineTextBox.Name = "UserLandlineTextBox";
            UserLandlineTextBox.Size = new Size(245, 27);
            UserLandlineTextBox.TabIndex = 7;
            // 
            // UserFaxTextBox
            // 
            UserFaxTextBox.AccessibleName = "UserFaxTextBox";
            UserFaxTextBox.Location = new Point(201, 179);
            UserFaxTextBox.Name = "UserFaxTextBox";
            UserFaxTextBox.Size = new Size(245, 27);
            UserFaxTextBox.TabIndex = 8;
            // 
            // UserMobileTextBox
            // 
            UserMobileTextBox.AccessibleName = "UserMobileTextBox";
            UserMobileTextBox.Location = new Point(201, 239);
            UserMobileTextBox.Name = "UserMobileTextBox";
            UserMobileTextBox.Size = new Size(245, 27);
            UserMobileTextBox.TabIndex = 9;
            // 
            // UserEmailTextBox
            // 
            UserEmailTextBox.AccessibleName = "UserEmailTextBox";
            UserEmailTextBox.Location = new Point(201, 301);
            UserEmailTextBox.Name = "UserEmailTextBox";
            UserEmailTextBox.Size = new Size(245, 27);
            UserEmailTextBox.TabIndex = 10;
            // 
            // UserWebsiteTextBox
            // 
            UserWebsiteTextBox.AccessibleName = "UserWebsiteLabel";
            UserWebsiteTextBox.Location = new Point(201, 371);
            UserWebsiteTextBox.Name = "UserWebsiteTextBox";
            UserWebsiteTextBox.Size = new Size(245, 27);
            UserWebsiteTextBox.TabIndex = 11;
            // 
            // CustomerDataGridView
            // 
            CustomerDataGridView.AccessibleName = "personDataGridView";
            CustomerDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CustomerDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CustomerDataGridView.Location = new Point(543, 12);
            CustomerDataGridView.Name = "CustomerDataGridView";
            CustomerDataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            CustomerDataGridView.Size = new Size(1448, 518);
            CustomerDataGridView.TabIndex = 14;
            // 
            // AddUserButton
            // 
            AddUserButton.AccessibleName = "AddUserButton";
            AddUserButton.Location = new Point(1163, 552);
            AddUserButton.Name = "AddUserButton";
            AddUserButton.Size = new Size(183, 29);
            AddUserButton.TabIndex = 15;
            AddUserButton.Text = "Add Customer";
            AddUserButton.UseVisualStyleBackColor = true;
            AddUserButton.Click += AddUserButton_ClickAsync;
            // 
            // AddCustomerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2329, 1154);
            Controls.Add(AddUserButton);
            Controls.Add(CustomerDataGridView);
            Controls.Add(UserWebsiteTextBox);
            Controls.Add(UserEmailTextBox);
            Controls.Add(UserMobileTextBox);
            Controls.Add(UserFaxTextBox);
            Controls.Add(UserLandlineTextBox);
            Controls.Add(UserNameTextBox);
            Controls.Add(UserWebsiteLabel);
            Controls.Add(UserEmailLabel);
            Controls.Add(UserMobileLabel);
            Controls.Add(UserFaxLabel);
            Controls.Add(UserLandlineLabel);
            Controls.Add(UserNameLabel);
            Name = "AddCustomerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Customer";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)CustomerDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label UserNameLabel;
        private Label UserLandlineLabel;
        private Label UserFaxLabel;
        private Label UserMobileLabel;
        private Label UserEmailLabel;
        private Label UserWebsiteLabel;
        private TextBox UserNameTextBox;
        private TextBox UserLandlineTextBox;
        private TextBox UserFaxTextBox;
        private TextBox UserMobileTextBox;
        private TextBox UserEmailTextBox;
        private TextBox UserWebsiteTextBox;
        private DataGridView CustomerDataGridView;
        private Button AddUserButton;
    }
}