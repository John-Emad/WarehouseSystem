namespace WarehouseManagmentSystem.WinForms
{
    partial class PersonForm
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
            UserTypeLabel = new Label();
            personDataGridView = new DataGridView();
            AddUserButton = new Button();
            PersonUserTypeComboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)personDataGridView).BeginInit();
            SuspendLayout();
            // 
            // UserNameLabel
            // 
            UserNameLabel.AccessibleName = "UserNameLabel";
            UserNameLabel.AutoSize = true;
            UserNameLabel.Location = new Point(24, 23);
            UserNameLabel.Name = "UserNameLabel";
            UserNameLabel.Size = new Size(49, 20);
            UserNameLabel.TabIndex = 0;
            UserNameLabel.Text = "Name";
            // 
            // UserLandlineLabel
            // 
            UserLandlineLabel.AccessibleName = "UserLandlineLabel";
            UserLandlineLabel.AutoSize = true;
            UserLandlineLabel.Location = new Point(24, 87);
            UserLandlineLabel.Name = "UserLandlineLabel";
            UserLandlineLabel.Size = new Size(120, 20);
            UserLandlineLabel.TabIndex = 1;
            UserLandlineLabel.Text = "Landline number";
            // 
            // UserFaxLabel
            // 
            UserFaxLabel.AccessibleName = "UserFaxLabel";
            UserFaxLabel.AutoSize = true;
            UserFaxLabel.Location = new Point(24, 159);
            UserFaxLabel.Name = "UserFaxLabel";
            UserFaxLabel.Size = new Size(85, 20);
            UserFaxLabel.TabIndex = 2;
            UserFaxLabel.Text = "Fax number";
            // 
            // UserMobileLabel
            // 
            UserMobileLabel.AccessibleName = "UserMobileLabel";
            UserMobileLabel.AutoSize = true;
            UserMobileLabel.Location = new Point(24, 219);
            UserMobileLabel.Name = "UserMobileLabel";
            UserMobileLabel.Size = new Size(111, 20);
            UserMobileLabel.TabIndex = 3;
            UserMobileLabel.Text = "Mobile number";
            // 
            // UserEmailLabel
            // 
            UserEmailLabel.AccessibleName = "UserEmailLabel";
            UserEmailLabel.AutoSize = true;
            UserEmailLabel.Location = new Point(24, 281);
            UserEmailLabel.Name = "UserEmailLabel";
            UserEmailLabel.Size = new Size(46, 20);
            UserEmailLabel.TabIndex = 4;
            UserEmailLabel.Text = "Email";
            // 
            // UserWebsiteLabel
            // 
            UserWebsiteLabel.AccessibleName = "UserWebsiteLabel";
            UserWebsiteLabel.AutoSize = true;
            UserWebsiteLabel.Location = new Point(24, 351);
            UserWebsiteLabel.Name = "UserWebsiteLabel";
            UserWebsiteLabel.Size = new Size(62, 20);
            UserWebsiteLabel.TabIndex = 5;
            UserWebsiteLabel.Text = "Website";
            // 
            // UserNameTextBox
            // 
            UserNameTextBox.AccessibleName = "UserNameTextBox";
            UserNameTextBox.Location = new Point(198, 16);
            UserNameTextBox.Name = "UserNameTextBox";
            UserNameTextBox.Size = new Size(181, 27);
            UserNameTextBox.TabIndex = 6;
            // 
            // UserLandlineTextBox
            // 
            UserLandlineTextBox.AccessibleName = "UserLandlineTextBox";
            UserLandlineTextBox.Location = new Point(198, 80);
            UserLandlineTextBox.Name = "UserLandlineTextBox";
            UserLandlineTextBox.Size = new Size(181, 27);
            UserLandlineTextBox.TabIndex = 7;
            // 
            // UserFaxTextBox
            // 
            UserFaxTextBox.AccessibleName = "UserFaxTextBox";
            UserFaxTextBox.Location = new Point(198, 152);
            UserFaxTextBox.Name = "UserFaxTextBox";
            UserFaxTextBox.Size = new Size(181, 27);
            UserFaxTextBox.TabIndex = 8;
            // 
            // UserMobileTextBox
            // 
            UserMobileTextBox.AccessibleName = "UserMobileTextBox";
            UserMobileTextBox.Location = new Point(198, 212);
            UserMobileTextBox.Name = "UserMobileTextBox";
            UserMobileTextBox.Size = new Size(181, 27);
            UserMobileTextBox.TabIndex = 9;
            // 
            // UserEmailTextBox
            // 
            UserEmailTextBox.AccessibleName = "UserEmailTextBox";
            UserEmailTextBox.Location = new Point(198, 274);
            UserEmailTextBox.Name = "UserEmailTextBox";
            UserEmailTextBox.Size = new Size(181, 27);
            UserEmailTextBox.TabIndex = 10;
            // 
            // UserWebsiteTextBox
            // 
            UserWebsiteTextBox.AccessibleName = "UserWebsiteLabel";
            UserWebsiteTextBox.Location = new Point(198, 344);
            UserWebsiteTextBox.Name = "UserWebsiteTextBox";
            UserWebsiteTextBox.Size = new Size(181, 27);
            UserWebsiteTextBox.TabIndex = 11;
            // 
            // UserTypeLabel
            // 
            UserTypeLabel.AccessibleName = "UserTypeLabel";
            UserTypeLabel.AutoSize = true;
            UserTypeLabel.Location = new Point(24, 421);
            UserTypeLabel.Name = "UserTypeLabel";
            UserTypeLabel.Size = new Size(38, 20);
            UserTypeLabel.TabIndex = 12;
            UserTypeLabel.Text = "User";
            // 
            // personDataGridView
            // 
            personDataGridView.AccessibleName = "personDataGridView";
            personDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            personDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            personDataGridView.Location = new Point(543, 12);
            personDataGridView.Name = "personDataGridView";
            personDataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            personDataGridView.Size = new Size(975, 518);
            personDataGridView.TabIndex = 14;
            // 
            // AddUserButton
            // 
            AddUserButton.AccessibleName = "AddUserButton";
            AddUserButton.Location = new Point(543, 553);
            AddUserButton.Name = "AddUserButton";
            AddUserButton.Size = new Size(183, 29);
            AddUserButton.TabIndex = 15;
            AddUserButton.Text = "AddAsync";
            AddUserButton.UseVisualStyleBackColor = true;
            AddUserButton.Click += AddUserButton_ClickAsync;
            // 
            // PersonUserTypeComboBox
            // 
            PersonUserTypeComboBox.AccessibleName = "PersonUserTypeComboBox";
            PersonUserTypeComboBox.FormattingEnabled = true;
            PersonUserTypeComboBox.Location = new Point(198, 413);
            PersonUserTypeComboBox.Name = "PersonUserTypeComboBox";
            PersonUserTypeComboBox.Size = new Size(181, 28);
            PersonUserTypeComboBox.TabIndex = 17;
            PersonUserTypeComboBox.SelectedIndexChanged += PersonUserTypeComboBox_SelectedIndexChanged;
            // 
            // PersonForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1584, 711);
            Controls.Add(PersonUserTypeComboBox);
            Controls.Add(AddUserButton);
            Controls.Add(personDataGridView);
            Controls.Add(UserTypeLabel);
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
            Name = "PersonForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PersonForm";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)personDataGridView).EndInit();
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
        private Label UserTypeLabel;
        private DataGridView personDataGridView;
        private Button AddUserButton;
        private ComboBox PersonUserTypeComboBox;
    }
}