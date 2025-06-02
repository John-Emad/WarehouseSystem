namespace WarehouseManagmentSystem.WinForms
{
    partial class ItemForm
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
            ItemCodeTextBox = new TextBox();
            ItemNameTextBox = new TextBox();
            ItemCodeLabel = new Label();
            ItemNameLabel = new Label();
            ItemMeasuringUnitsLabel = new Label();
            ItemsDataGridView = new DataGridView();
            AddItemButton = new Button();
            ItemMeasuringUnitsCheckList = new CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)ItemsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // ItemCodeTextBox
            // 
            ItemCodeTextBox.AccessibleName = "ItemCodeTextBox";
            ItemCodeTextBox.Location = new Point(225, 175);
            ItemCodeTextBox.Name = "ItemCodeTextBox";
            ItemCodeTextBox.Size = new Size(150, 27);
            ItemCodeTextBox.TabIndex = 0;
            // 
            // ItemNameTextBox
            // 
            ItemNameTextBox.AccessibleName = "ItemNameTextBox";
            ItemNameTextBox.Location = new Point(225, 268);
            ItemNameTextBox.Name = "ItemNameTextBox";
            ItemNameTextBox.Size = new Size(150, 27);
            ItemNameTextBox.TabIndex = 1;
            // 
            // ItemCodeLabel
            // 
            ItemCodeLabel.AccessibleName = "ItemCodeLabel";
            ItemCodeLabel.AutoSize = true;
            ItemCodeLabel.Location = new Point(71, 182);
            ItemCodeLabel.Name = "ItemCodeLabel";
            ItemCodeLabel.Size = new Size(44, 20);
            ItemCodeLabel.TabIndex = 3;
            ItemCodeLabel.Text = "Code";
            // 
            // ItemNameLabel
            // 
            ItemNameLabel.AccessibleName = "ItemNameLabel";
            ItemNameLabel.AutoSize = true;
            ItemNameLabel.Location = new Point(71, 275);
            ItemNameLabel.Name = "ItemNameLabel";
            ItemNameLabel.Size = new Size(49, 20);
            ItemNameLabel.TabIndex = 4;
            ItemNameLabel.Text = "Name";
            // 
            // ItemMeasuringUnitsLabel
            // 
            ItemMeasuringUnitsLabel.AccessibleName = "ItemMeasuringUnitsLabel";
            ItemMeasuringUnitsLabel.AutoSize = true;
            ItemMeasuringUnitsLabel.Location = new Point(71, 390);
            ItemMeasuringUnitsLabel.Name = "ItemMeasuringUnitsLabel";
            ItemMeasuringUnitsLabel.Size = new Size(115, 20);
            ItemMeasuringUnitsLabel.TabIndex = 5;
            ItemMeasuringUnitsLabel.Text = "Measuring Units";
            // 
            // ItemsDataGridView
            // 
            ItemsDataGridView.AccessibleName = "ItemsDataGridView";
            ItemsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ItemsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ItemsDataGridView.Location = new Point(495, 23);
            ItemsDataGridView.Name = "ItemsDataGridView";
            ItemsDataGridView.RowHeadersWidth = 51;
            ItemsDataGridView.Size = new Size(1174, 487);
            ItemsDataGridView.TabIndex = 6;
            // 
            // AddItemButton
            // 
            AddItemButton.AccessibleName = "AddItemButton";
            AddItemButton.Location = new Point(961, 554);
            AddItemButton.Name = "AddItemButton";
            AddItemButton.Size = new Size(174, 29);
            AddItemButton.TabIndex = 7;
            AddItemButton.Text = "Add Item";
            AddItemButton.UseVisualStyleBackColor = true;
            AddItemButton.Click += AddItemButton_Click;
            // 
            // ItemMeasuringUnitsCheckList
            // 
            ItemMeasuringUnitsCheckList.AccessibleName = "ItemMeasuringUnitsCheckList";
            ItemMeasuringUnitsCheckList.FormattingEnabled = true;
            ItemMeasuringUnitsCheckList.Location = new Point(225, 396);
            ItemMeasuringUnitsCheckList.Name = "ItemMeasuringUnitsCheckList";
            ItemMeasuringUnitsCheckList.Size = new Size(150, 114);
            ItemMeasuringUnitsCheckList.TabIndex = 8;
            ItemMeasuringUnitsCheckList.ItemCheck += ItemMeasuringUnitsCheckList_ItemCheck;
            // 
            // ItemForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(2334, 1152);
            Controls.Add(ItemMeasuringUnitsCheckList);
            Controls.Add(AddItemButton);
            Controls.Add(ItemsDataGridView);
            Controls.Add(ItemMeasuringUnitsLabel);
            Controls.Add(ItemNameLabel);
            Controls.Add(ItemCodeLabel);
            Controls.Add(ItemNameTextBox);
            Controls.Add(ItemCodeTextBox);
            Name = "ItemForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ItemForm";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)ItemsDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox ItemCodeTextBox;
        private TextBox ItemNameTextBox;
        private Label ItemCodeLabel;
        private Label ItemNameLabel;
        private Label ItemMeasuringUnitsLabel;
        private DataGridView ItemsDataGridView;
        private Button AddItemButton;
        private CheckedListBox ItemMeasuringUnitsCheckList;
    }
}