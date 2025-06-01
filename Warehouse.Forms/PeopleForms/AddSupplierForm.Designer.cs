namespace WarehouseManagmentSystem.WinForms.PeopleForms
{
    partial class AddSupplierForm
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
            AddUserButton = new Button();
            CustomerDataGridView = new DataGridView();
            UserWebsiteTextBox = new TextBox();
            UserEmailTextBox = new TextBox();
            UserMobileTextBox = new TextBox();
            UserFaxTextBox = new TextBox();
            UserLandlineTextBox = new TextBox();
            UserNameTextBox = new TextBox();
            UserWebsiteLabel = new Label();
            UserEmailLabel = new Label();
            UserMobileLabel = new Label();
            UserFaxLabel = new Label();
            UserLandlineLabel = new Label();
            UserNameLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)CustomerDataGridView).BeginInit();
            SuspendLayout();
            // 
            // AddUserButton
            // 
            AddUserButton.AccessibleName = "AddUserButton";
            AddUserButton.Location = new Point(1189, 601);
            AddUserButton.Name = "AddUserButton";
            AddUserButton.Size = new Size(183, 29);
            AddUserButton.TabIndex = 29;
            AddUserButton.Text = "Add Supplier";
            AddUserButton.UseVisualStyleBackColor = true;
            AddUserButton.Click += AddUserButton_ClickAsync;
            // 
            // CustomerDataGridView
            // 
            CustomerDataGridView.AccessibleName = "personDataGridView";
            CustomerDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CustomerDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CustomerDataGridView.Location = new Point(569, 61);
            CustomerDataGridView.Name = "CustomerDataGridView";
            CustomerDataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            CustomerDataGridView.Size = new Size(1448, 518);
            CustomerDataGridView.TabIndex = 28;
            // 
            // UserWebsiteTextBox
            // 
            UserWebsiteTextBox.AccessibleName = "UserWebsiteLabel";
            UserWebsiteTextBox.Location = new Point(227, 420);
            UserWebsiteTextBox.Name = "UserWebsiteTextBox";
            UserWebsiteTextBox.Size = new Size(245, 27);
            UserWebsiteTextBox.TabIndex = 27;
            // 
            // UserEmailTextBox
            // 
            UserEmailTextBox.AccessibleName = "UserEmailTextBox";
            UserEmailTextBox.Location = new Point(227, 350);
            UserEmailTextBox.Name = "UserEmailTextBox";
            UserEmailTextBox.Size = new Size(245, 27);
            UserEmailTextBox.TabIndex = 26;
            // 
            // UserMobileTextBox
            // 
            UserMobileTextBox.AccessibleName = "UserMobileTextBox";
            UserMobileTextBox.Location = new Point(227, 288);
            UserMobileTextBox.Name = "UserMobileTextBox";
            UserMobileTextBox.Size = new Size(245, 27);
            UserMobileTextBox.TabIndex = 25;
            // 
            // UserFaxTextBox
            // 
            UserFaxTextBox.AccessibleName = "UserFaxTextBox";
            UserFaxTextBox.Location = new Point(227, 228);
            UserFaxTextBox.Name = "UserFaxTextBox";
            UserFaxTextBox.Size = new Size(245, 27);
            UserFaxTextBox.TabIndex = 24;
            // 
            // UserLandlineTextBox
            // 
            UserLandlineTextBox.AccessibleName = "UserLandlineTextBox";
            UserLandlineTextBox.Location = new Point(227, 156);
            UserLandlineTextBox.Name = "UserLandlineTextBox";
            UserLandlineTextBox.Size = new Size(245, 27);
            UserLandlineTextBox.TabIndex = 23;
            // 
            // UserNameTextBox
            // 
            UserNameTextBox.AccessibleName = "UserNameTextBox";
            UserNameTextBox.Location = new Point(227, 92);
            UserNameTextBox.Name = "UserNameTextBox";
            UserNameTextBox.Size = new Size(245, 27);
            UserNameTextBox.TabIndex = 22;
            // 
            // UserWebsiteLabel
            // 
            UserWebsiteLabel.AccessibleName = "UserWebsiteLabel";
            UserWebsiteLabel.AutoSize = true;
            UserWebsiteLabel.Location = new Point(53, 427);
            UserWebsiteLabel.Name = "UserWebsiteLabel";
            UserWebsiteLabel.Size = new Size(62, 20);
            UserWebsiteLabel.TabIndex = 21;
            UserWebsiteLabel.Text = "Website";
            // 
            // UserEmailLabel
            // 
            UserEmailLabel.AccessibleName = "UserEmailLabel";
            UserEmailLabel.AutoSize = true;
            UserEmailLabel.Location = new Point(53, 357);
            UserEmailLabel.Name = "UserEmailLabel";
            UserEmailLabel.Size = new Size(46, 20);
            UserEmailLabel.TabIndex = 20;
            UserEmailLabel.Text = "Email";
            // 
            // UserMobileLabel
            // 
            UserMobileLabel.AccessibleName = "UserMobileLabel";
            UserMobileLabel.AutoSize = true;
            UserMobileLabel.Location = new Point(53, 295);
            UserMobileLabel.Name = "UserMobileLabel";
            UserMobileLabel.Size = new Size(111, 20);
            UserMobileLabel.TabIndex = 19;
            UserMobileLabel.Text = "Mobile number";
            // 
            // UserFaxLabel
            // 
            UserFaxLabel.AccessibleName = "UserFaxLabel";
            UserFaxLabel.AutoSize = true;
            UserFaxLabel.Location = new Point(53, 235);
            UserFaxLabel.Name = "UserFaxLabel";
            UserFaxLabel.Size = new Size(85, 20);
            UserFaxLabel.TabIndex = 18;
            UserFaxLabel.Text = "Fax number";
            // 
            // UserLandlineLabel
            // 
            UserLandlineLabel.AccessibleName = "UserLandlineLabel";
            UserLandlineLabel.AutoSize = true;
            UserLandlineLabel.Location = new Point(53, 163);
            UserLandlineLabel.Name = "UserLandlineLabel";
            UserLandlineLabel.Size = new Size(120, 20);
            UserLandlineLabel.TabIndex = 17;
            UserLandlineLabel.Text = "Landline number";
            // 
            // UserNameLabel
            // 
            UserNameLabel.AccessibleName = "UserNameLabel";
            UserNameLabel.AutoSize = true;
            UserNameLabel.Location = new Point(53, 99);
            UserNameLabel.Name = "UserNameLabel";
            UserNameLabel.Size = new Size(49, 20);
            UserNameLabel.TabIndex = 16;
            UserNameLabel.Text = "Name";
            // 
            // AddSupplierForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2329, 1145);
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
            Name = "AddSupplierForm";
            Text = "Add Supplier";
            ((System.ComponentModel.ISupportInitialize)CustomerDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddUserButton;
        private DataGridView CustomerDataGridView;
        private TextBox UserWebsiteTextBox;
        private TextBox UserEmailTextBox;
        private TextBox UserMobileTextBox;
        private TextBox UserFaxTextBox;
        private TextBox UserLandlineTextBox;
        private TextBox UserNameTextBox;
        private Label UserWebsiteLabel;
        private Label UserEmailLabel;
        private Label UserMobileLabel;
        private Label UserFaxLabel;
        private Label UserLandlineLabel;
        private Label UserNameLabel;
    }
}