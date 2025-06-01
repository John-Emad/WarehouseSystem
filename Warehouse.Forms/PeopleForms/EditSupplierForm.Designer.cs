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
            EditUserButton = new Button();
            SupplierDataGridView = new DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)SupplierDataGridView).BeginInit();
            SuspendLayout();
            // 
            // EditUserButton
            // 
            EditUserButton.AccessibleName = "AddUserButton";
            EditUserButton.Location = new Point(1186, 583);
            EditUserButton.Name = "EditUserButton";
            EditUserButton.Size = new Size(183, 29);
            EditUserButton.TabIndex = 43;
            EditUserButton.Text = "Edit Supplier";
            EditUserButton.UseVisualStyleBackColor = true;
            EditUserButton.Click += UpdateSupplierButton_Click;
            // 
            // SupplierDataGridView
            // 
            SupplierDataGridView.AccessibleName = "personDataGridView";
            SupplierDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SupplierDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SupplierDataGridView.Location = new Point(566, 43);
            SupplierDataGridView.Name = "SupplierDataGridView";
            SupplierDataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            SupplierDataGridView.Size = new Size(1448, 518);
            SupplierDataGridView.TabIndex = 42;
            SupplierDataGridView.CellDoubleClick += SupplierDataGridView_CellDoubleClick;
            // 
            // UserWebsiteTextBox
            // 
            UserWebsiteTextBox.AccessibleName = "UserWebsiteLabel";
            UserWebsiteTextBox.Location = new Point(224, 402);
            UserWebsiteTextBox.Name = "UserWebsiteTextBox";
            UserWebsiteTextBox.Size = new Size(245, 27);
            UserWebsiteTextBox.TabIndex = 41;
            // 
            // UserEmailTextBox
            // 
            UserEmailTextBox.AccessibleName = "UserEmailTextBox";
            UserEmailTextBox.Location = new Point(224, 332);
            UserEmailTextBox.Name = "UserEmailTextBox";
            UserEmailTextBox.Size = new Size(245, 27);
            UserEmailTextBox.TabIndex = 40;
            // 
            // UserMobileTextBox
            // 
            UserMobileTextBox.AccessibleName = "UserMobileTextBox";
            UserMobileTextBox.Location = new Point(224, 270);
            UserMobileTextBox.Name = "UserMobileTextBox";
            UserMobileTextBox.Size = new Size(245, 27);
            UserMobileTextBox.TabIndex = 39;
            // 
            // UserFaxTextBox
            // 
            UserFaxTextBox.AccessibleName = "UserFaxTextBox";
            UserFaxTextBox.Location = new Point(224, 210);
            UserFaxTextBox.Name = "UserFaxTextBox";
            UserFaxTextBox.Size = new Size(245, 27);
            UserFaxTextBox.TabIndex = 38;
            // 
            // UserLandlineTextBox
            // 
            UserLandlineTextBox.AccessibleName = "UserLandlineTextBox";
            UserLandlineTextBox.Location = new Point(224, 138);
            UserLandlineTextBox.Name = "UserLandlineTextBox";
            UserLandlineTextBox.Size = new Size(245, 27);
            UserLandlineTextBox.TabIndex = 37;
            // 
            // UserNameTextBox
            // 
            UserNameTextBox.AccessibleName = "UserNameTextBox";
            UserNameTextBox.Location = new Point(224, 74);
            UserNameTextBox.Name = "UserNameTextBox";
            UserNameTextBox.Size = new Size(245, 27);
            UserNameTextBox.TabIndex = 36;
            // 
            // UserWebsiteLabel
            // 
            UserWebsiteLabel.AccessibleName = "UserWebsiteLabel";
            UserWebsiteLabel.AutoSize = true;
            UserWebsiteLabel.Location = new Point(50, 409);
            UserWebsiteLabel.Name = "UserWebsiteLabel";
            UserWebsiteLabel.Size = new Size(62, 20);
            UserWebsiteLabel.TabIndex = 35;
            UserWebsiteLabel.Text = "Website";
            // 
            // UserEmailLabel
            // 
            UserEmailLabel.AccessibleName = "UserEmailLabel";
            UserEmailLabel.AutoSize = true;
            UserEmailLabel.Location = new Point(50, 339);
            UserEmailLabel.Name = "UserEmailLabel";
            UserEmailLabel.Size = new Size(46, 20);
            UserEmailLabel.TabIndex = 34;
            UserEmailLabel.Text = "Email";
            // 
            // UserMobileLabel
            // 
            UserMobileLabel.AccessibleName = "UserMobileLabel";
            UserMobileLabel.AutoSize = true;
            UserMobileLabel.Location = new Point(50, 277);
            UserMobileLabel.Name = "UserMobileLabel";
            UserMobileLabel.Size = new Size(111, 20);
            UserMobileLabel.TabIndex = 33;
            UserMobileLabel.Text = "Mobile number";
            // 
            // UserFaxLabel
            // 
            UserFaxLabel.AccessibleName = "UserFaxLabel";
            UserFaxLabel.AutoSize = true;
            UserFaxLabel.Location = new Point(50, 217);
            UserFaxLabel.Name = "UserFaxLabel";
            UserFaxLabel.Size = new Size(85, 20);
            UserFaxLabel.TabIndex = 32;
            UserFaxLabel.Text = "Fax number";
            // 
            // UserLandlineLabel
            // 
            UserLandlineLabel.AccessibleName = "UserLandlineLabel";
            UserLandlineLabel.AutoSize = true;
            UserLandlineLabel.Location = new Point(50, 145);
            UserLandlineLabel.Name = "UserLandlineLabel";
            UserLandlineLabel.Size = new Size(120, 20);
            UserLandlineLabel.TabIndex = 31;
            UserLandlineLabel.Text = "Landline number";
            // 
            // UserNameLabel
            // 
            UserNameLabel.AccessibleName = "UserNameLabel";
            UserNameLabel.AutoSize = true;
            UserNameLabel.Location = new Point(50, 81);
            UserNameLabel.Name = "UserNameLabel";
            UserNameLabel.Size = new Size(49, 20);
            UserNameLabel.TabIndex = 30;
            UserNameLabel.Text = "Name";
            // 
            // EditSupplierForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2319, 1148);
            Controls.Add(EditUserButton);
            Controls.Add(SupplierDataGridView);
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
            Name = "EditSupplierForm";
            Text = "EditSupplierForm";
            ((System.ComponentModel.ISupportInitialize)SupplierDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button EditUserButton;
        private DataGridView SupplierDataGridView;
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