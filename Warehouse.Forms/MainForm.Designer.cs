namespace WarehouseManagmentSystem.WinForms
{
    partial class MainForm
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
            panelMain = new Panel();
            label1 = new Label();
            groupBox2 = new GroupBox();
            AddWarehouseButton = new Button();
            EditWarehouseButton = new Button();
            groupBox4 = new GroupBox();
            CreateReceiptVoucherButton = new Button();
            CreateTransferVoucherButton = new Button();
            CreateIssueVoucherButton = new Button();
            groupBox5 = new GroupBox();
            ItemPerWarehouseReport = new Button();
            WarehouseReportButton = new Button();
            ItemTransferReportButton = new Button();
            ItemRemainigDaysTillExpirationButton = new Button();
            ItemAtWarehouseSinceDays = new Button();
            groupBox3 = new GroupBox();
            AddItemButton = new Button();
            EditItemButton = new Button();
            groupBox1 = new GroupBox();
            AddCustomerButton = new Button();
            EditSupplierButton = new Button();
            EditCustomerButton = new Button();
            AddSupplierButton = new Button();
            panelMain.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.Controls.Add(label1);
            panelMain.Controls.Add(groupBox2);
            panelMain.Controls.Add(groupBox4);
            panelMain.Controls.Add(groupBox5);
            panelMain.Controls.Add(groupBox3);
            panelMain.Controls.Add(groupBox1);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(2328, 1130);
            panelMain.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("RM Pro", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(804, 105);
            label1.Name = "label1";
            label1.Size = new Size(347, 72);
            label1.TabIndex = 7;
            label1.Text = "Warehouse Managment\r\nSystem";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Honeydew;
            groupBox2.Controls.Add(AddWarehouseButton);
            groupBox2.Controls.Add(EditWarehouseButton);
            groupBox2.Location = new Point(489, 488);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(527, 202);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Warehouse";
            // 
            // AddWarehouseButton
            // 
            AddWarehouseButton.Location = new Point(12, 58);
            AddWarehouseButton.Name = "AddWarehouseButton";
            AddWarehouseButton.Size = new Size(222, 109);
            AddWarehouseButton.TabIndex = 0;
            AddWarehouseButton.Text = "Add";
            AddWarehouseButton.UseVisualStyleBackColor = true;
            AddWarehouseButton.Click += AddWarehouseButton_Click;
            // 
            // EditWarehouseButton
            // 
            EditWarehouseButton.Location = new Point(289, 58);
            EditWarehouseButton.Name = "EditWarehouseButton";
            EditWarehouseButton.Size = new Size(222, 109);
            EditWarehouseButton.TabIndex = 6;
            EditWarehouseButton.Text = "Edit";
            EditWarehouseButton.UseVisualStyleBackColor = true;
            EditWarehouseButton.Click += EditWarehouseButton_Click;
            // 
            // groupBox4
            // 
            groupBox4.BackColor = SystemColors.ScrollBar;
            groupBox4.Controls.Add(CreateReceiptVoucherButton);
            groupBox4.Controls.Add(CreateTransferVoucherButton);
            groupBox4.Controls.Add(CreateIssueVoucherButton);
            groupBox4.Location = new Point(489, 263);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(832, 198);
            groupBox4.TabIndex = 0;
            groupBox4.TabStop = false;
            groupBox4.Text = "Vouchers";
            // 
            // CreateReceiptVoucherButton
            // 
            CreateReceiptVoucherButton.Location = new Point(12, 36);
            CreateReceiptVoucherButton.Name = "CreateReceiptVoucherButton";
            CreateReceiptVoucherButton.Size = new Size(222, 109);
            CreateReceiptVoucherButton.TabIndex = 9;
            CreateReceiptVoucherButton.Text = "Create Receipt Voucher";
            CreateReceiptVoucherButton.UseVisualStyleBackColor = true;
            CreateReceiptVoucherButton.Click += CreateReceiptVoucherButton_Click;
            // 
            // CreateTransferVoucherButton
            // 
            CreateTransferVoucherButton.Location = new Point(559, 36);
            CreateTransferVoucherButton.Name = "CreateTransferVoucherButton";
            CreateTransferVoucherButton.Size = new Size(222, 109);
            CreateTransferVoucherButton.TabIndex = 10;
            CreateTransferVoucherButton.Text = "Create Transfer Voucher";
            CreateTransferVoucherButton.UseVisualStyleBackColor = true;
            CreateTransferVoucherButton.Click += CreateTransferVoucherButton_Click;
            // 
            // CreateIssueVoucherButton
            // 
            CreateIssueVoucherButton.Location = new Point(289, 36);
            CreateIssueVoucherButton.Name = "CreateIssueVoucherButton";
            CreateIssueVoucherButton.Size = new Size(222, 109);
            CreateIssueVoucherButton.TabIndex = 11;
            CreateIssueVoucherButton.Text = "Create Issue Voucher";
            CreateIssueVoucherButton.UseVisualStyleBackColor = true;
            CreateIssueVoucherButton.Click += CreateIssueVoucherButton_Click;
            // 
            // groupBox5
            // 
            groupBox5.BackColor = Color.LightYellow;
            groupBox5.Controls.Add(ItemPerWarehouseReport);
            groupBox5.Controls.Add(WarehouseReportButton);
            groupBox5.Controls.Add(ItemTransferReportButton);
            groupBox5.Controls.Add(ItemRemainigDaysTillExpirationButton);
            groupBox5.Controls.Add(ItemAtWarehouseSinceDays);
            groupBox5.Location = new Point(1080, 488);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(789, 441);
            groupBox5.TabIndex = 0;
            groupBox5.TabStop = false;
            groupBox5.Text = "Reports";
            // 
            // ItemPerWarehouseReport
            // 
            ItemPerWarehouseReport.Location = new Point(19, 93);
            ItemPerWarehouseReport.Name = "ItemPerWarehouseReport";
            ItemPerWarehouseReport.Size = new Size(222, 109);
            ItemPerWarehouseReport.TabIndex = 12;
            ItemPerWarehouseReport.Text = "Item / Warehouse(s)";
            ItemPerWarehouseReport.UseVisualStyleBackColor = true;
            ItemPerWarehouseReport.Click += ItemPerWarehouseReport_Click;
            // 
            // WarehouseReportButton
            // 
            WarehouseReportButton.Location = new Point(413, 275);
            WarehouseReportButton.Name = "WarehouseReportButton";
            WarehouseReportButton.Size = new Size(222, 109);
            WarehouseReportButton.TabIndex = 16;
            WarehouseReportButton.Text = "Warehouse";
            WarehouseReportButton.UseVisualStyleBackColor = true;
            WarehouseReportButton.Click += WarehouseReportButton_Click;
            // 
            // ItemTransferReportButton
            // 
            ItemTransferReportButton.Location = new Point(270, 93);
            ItemTransferReportButton.Name = "ItemTransferReportButton";
            ItemTransferReportButton.Size = new Size(222, 109);
            ItemTransferReportButton.TabIndex = 13;
            ItemTransferReportButton.Text = "Item Transfer";
            ItemTransferReportButton.UseVisualStyleBackColor = true;
            ItemTransferReportButton.Click += ItemTransferReportButton_Click;
            // 
            // ItemRemainigDaysTillExpirationButton
            // 
            ItemRemainigDaysTillExpirationButton.Location = new Point(91, 275);
            ItemRemainigDaysTillExpirationButton.Name = "ItemRemainigDaysTillExpirationButton";
            ItemRemainigDaysTillExpirationButton.Size = new Size(222, 109);
            ItemRemainigDaysTillExpirationButton.TabIndex = 15;
            ItemRemainigDaysTillExpirationButton.Text = "Item Remainig Days Till Exp";
            ItemRemainigDaysTillExpirationButton.UseVisualStyleBackColor = true;
            ItemRemainigDaysTillExpirationButton.Click += ItemRemainigDaysTillExpirationButton_Click;
            // 
            // ItemAtWarehouseSinceDays
            // 
            ItemAtWarehouseSinceDays.Location = new Point(524, 93);
            ItemAtWarehouseSinceDays.Name = "ItemAtWarehouseSinceDays";
            ItemAtWarehouseSinceDays.Size = new Size(222, 109);
            ItemAtWarehouseSinceDays.TabIndex = 14;
            ItemAtWarehouseSinceDays.Text = "Item At Warehouse Since";
            ItemAtWarehouseSinceDays.UseVisualStyleBackColor = true;
            ItemAtWarehouseSinceDays.Click += ItemAtWarehouseSinceDays_Click;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.SeaShell;
            groupBox3.Controls.Add(AddItemButton);
            groupBox3.Controls.Add(EditItemButton);
            groupBox3.Location = new Point(495, 727);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(527, 202);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Item";
            // 
            // AddItemButton
            // 
            AddItemButton.Location = new Point(6, 58);
            AddItemButton.Name = "AddItemButton";
            AddItemButton.Size = new Size(222, 109);
            AddItemButton.TabIndex = 7;
            AddItemButton.Text = "Add";
            AddItemButton.UseVisualStyleBackColor = true;
            AddItemButton.Click += AddItemButton_Click;
            // 
            // EditItemButton
            // 
            EditItemButton.Location = new Point(289, 58);
            EditItemButton.Name = "EditItemButton";
            EditItemButton.Size = new Size(222, 109);
            EditItemButton.TabIndex = 8;
            EditItemButton.Text = "Edit";
            EditItemButton.UseVisualStyleBackColor = true;
            EditItemButton.Click += EditItemButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.GradientInactiveCaption;
            groupBox1.Controls.Add(AddCustomerButton);
            groupBox1.Controls.Add(EditSupplierButton);
            groupBox1.Controls.Add(EditCustomerButton);
            groupBox1.Controls.Add(AddSupplierButton);
            groupBox1.Location = new Point(62, 263);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(382, 666);
            groupBox1.TabIndex = 17;
            groupBox1.TabStop = false;
            groupBox1.Text = "People";
            // 
            // AddCustomerButton
            // 
            AddCustomerButton.Location = new Point(72, 51);
            AddCustomerButton.Name = "AddCustomerButton";
            AddCustomerButton.Size = new Size(222, 109);
            AddCustomerButton.TabIndex = 2;
            AddCustomerButton.Text = "Add Customer";
            AddCustomerButton.UseVisualStyleBackColor = true;
            AddCustomerButton.Click += AddCustomerButton_Click;
            // 
            // EditSupplierButton
            // 
            EditSupplierButton.Location = new Point(72, 500);
            EditSupplierButton.Name = "EditSupplierButton";
            EditSupplierButton.Size = new Size(222, 109);
            EditSupplierButton.TabIndex = 5;
            EditSupplierButton.Text = "Edit Supplier";
            EditSupplierButton.UseVisualStyleBackColor = true;
            EditSupplierButton.Click += EditSupplierButton_Click;
            // 
            // EditCustomerButton
            // 
            EditCustomerButton.Location = new Point(72, 197);
            EditCustomerButton.Name = "EditCustomerButton";
            EditCustomerButton.Size = new Size(222, 109);
            EditCustomerButton.TabIndex = 3;
            EditCustomerButton.Text = "Edit Customer";
            EditCustomerButton.UseVisualStyleBackColor = true;
            EditCustomerButton.Click += EditCustomerButton_Click;
            // 
            // AddSupplierButton
            // 
            AddSupplierButton.Location = new Point(72, 351);
            AddSupplierButton.Name = "AddSupplierButton";
            AddSupplierButton.Size = new Size(222, 109);
            AddSupplierButton.TabIndex = 4;
            AddSupplierButton.Text = "Add Supplier";
            AddSupplierButton.UseVisualStyleBackColor = true;
            AddSupplierButton.Click += AddSupplierButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2328, 1130);
            Controls.Add(panelMain);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Warehouse Managment system";
            WindowState = FormWindowState.Maximized;
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panelMain;
        private Button EditSupplierButton;
        private Button AddWarehouseButton;
        private Button AddCustomerButton;
        private Button EditCustomerButton;
        private Button AddSupplierButton;
        private Button EditWarehouseButton;
        private Button EditItemButton;
        private Button AddItemButton;
        private Button CreateIssueVoucherButton;
        private Button CreateTransferVoucherButton;
        private Button CreateReceiptVoucherButton;
        private Button WarehouseReportButton;
        private Button ItemPerWarehouseReport;
        private Button ItemTransferReportButton;
        private Button ItemAtWarehouseSinceDays;
        private Button ItemRemainigDaysTillExpirationButton;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private Label label1;
    }
}