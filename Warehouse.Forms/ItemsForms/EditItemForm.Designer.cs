namespace WarehouseManagmentSystem.WinForms.ItemsForms
{
    partial class EditItemForm
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
            ItemMeasuringUnitsCheckList = new CheckedListBox();
            EditItemButton = new Button();
            ItemsDataGridView = new DataGridView();
            ItemMeasuringUnitsLabel = new Label();
            ItemNameLabel = new Label();
            ItemCodeLabel = new Label();
            ItemNameTextBox = new TextBox();
            ItemCodeTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)ItemsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // ItemMeasuringUnitsCheckList
            // 
            ItemMeasuringUnitsCheckList.AccessibleName = "ItemMeasuringUnitsCheckList";
            ItemMeasuringUnitsCheckList.FormattingEnabled = true;
            ItemMeasuringUnitsCheckList.Location = new Point(231, 396);
            ItemMeasuringUnitsCheckList.Name = "ItemMeasuringUnitsCheckList";
            ItemMeasuringUnitsCheckList.Size = new Size(150, 114);
            ItemMeasuringUnitsCheckList.TabIndex = 16;
            ItemMeasuringUnitsCheckList.ItemCheck += ItemMeasuringUnitsCheckList_ItemCheck;
            // 
            // EditItemButton
            // 
            EditItemButton.AccessibleName = "AddItemButton";
            EditItemButton.Location = new Point(967, 554);
            EditItemButton.Name = "EditItemButton";
            EditItemButton.Size = new Size(174, 29);
            EditItemButton.TabIndex = 15;
            EditItemButton.Text = "Edit Item";
            EditItemButton.UseVisualStyleBackColor = true;
            EditItemButton.Click += EditItemButton_Click;
            // 
            // ItemsDataGridView
            // 
            ItemsDataGridView.AccessibleName = "ItemsDataGridView";
            ItemsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ItemsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ItemsDataGridView.Location = new Point(501, 23);
            ItemsDataGridView.Name = "ItemsDataGridView";
            ItemsDataGridView.RowHeadersWidth = 51;
            ItemsDataGridView.Size = new Size(1174, 487);
            ItemsDataGridView.TabIndex = 14;
            ItemsDataGridView.CellDoubleClick += ItemsDataGridView_CellDoubleClick;
            // 
            // ItemMeasuringUnitsLabel
            // 
            ItemMeasuringUnitsLabel.AccessibleName = "ItemMeasuringUnitsLabel";
            ItemMeasuringUnitsLabel.AutoSize = true;
            ItemMeasuringUnitsLabel.Location = new Point(77, 390);
            ItemMeasuringUnitsLabel.Name = "ItemMeasuringUnitsLabel";
            ItemMeasuringUnitsLabel.Size = new Size(115, 20);
            ItemMeasuringUnitsLabel.TabIndex = 13;
            ItemMeasuringUnitsLabel.Text = "Measuring Units";
            // 
            // ItemNameLabel
            // 
            ItemNameLabel.AccessibleName = "ItemNameLabel";
            ItemNameLabel.AutoSize = true;
            ItemNameLabel.Location = new Point(77, 275);
            ItemNameLabel.Name = "ItemNameLabel";
            ItemNameLabel.Size = new Size(49, 20);
            ItemNameLabel.TabIndex = 12;
            ItemNameLabel.Text = "Name";
            // 
            // ItemCodeLabel
            // 
            ItemCodeLabel.AccessibleName = "ItemCodeLabel";
            ItemCodeLabel.AutoSize = true;
            ItemCodeLabel.Location = new Point(77, 182);
            ItemCodeLabel.Name = "ItemCodeLabel";
            ItemCodeLabel.Size = new Size(44, 20);
            ItemCodeLabel.TabIndex = 11;
            ItemCodeLabel.Text = "Code";
            // 
            // ItemNameTextBox
            // 
            ItemNameTextBox.AccessibleName = "ItemNameTextBox";
            ItemNameTextBox.Location = new Point(231, 268);
            ItemNameTextBox.Name = "ItemNameTextBox";
            ItemNameTextBox.Size = new Size(150, 27);
            ItemNameTextBox.TabIndex = 10;
            // 
            // ItemCodeTextBox
            // 
            ItemCodeTextBox.AccessibleName = "ItemCodeTextBox";
            ItemCodeTextBox.Location = new Point(231, 175);
            ItemCodeTextBox.Name = "ItemCodeTextBox";
            ItemCodeTextBox.Size = new Size(150, 27);
            ItemCodeTextBox.TabIndex = 9;
            // 
            // EditItemForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2329, 1139);
            Controls.Add(ItemMeasuringUnitsCheckList);
            Controls.Add(EditItemButton);
            Controls.Add(ItemsDataGridView);
            Controls.Add(ItemMeasuringUnitsLabel);
            Controls.Add(ItemNameLabel);
            Controls.Add(ItemCodeLabel);
            Controls.Add(ItemNameTextBox);
            Controls.Add(ItemCodeTextBox);
            Name = "EditItemForm";
            Text = "EditItemForm";
            ((System.ComponentModel.ISupportInitialize)ItemsDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox ItemMeasuringUnitsCheckList;
        private Button EditItemButton;
        private DataGridView ItemsDataGridView;
        private Label ItemMeasuringUnitsLabel;
        private Label ItemNameLabel;
        private Label ItemCodeLabel;
        private TextBox ItemNameTextBox;
        private TextBox ItemCodeTextBox;
    }
}