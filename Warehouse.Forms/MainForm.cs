using WarehouseManagementSystem.Domain.DTOs;
using WarehouseManagmentSystem.WinForms.Forms;
using WarehouseManagmentSystem.WinForms.ItemsForms;
using WarehouseManagmentSystem.WinForms.PeopleForms;
using WarehouseManagmentSystem.WinForms.ReportForms;
using WarehouseManagmentSystem.WinForms.WarehouseFroms;

namespace WarehouseManagmentSystem.WinForms
{
    public partial class MainForm : Form
    {
        private Form currentActiveForm = null;

        public MainForm()
        {
            InitializeComponent();
            SetupMenuStrip();
        }

        private void SetupMenuStrip()
        {
            MenuStrip mainMenu = new MenuStrip();
            this.MainMenuStrip = mainMenu;
            this.Controls.Add(mainMenu);

            // Person Menu with nested Customer/Supplier submenus
            ToolStripMenuItem personMenu = new ToolStripMenuItem("Person");

            // Customer Submenu
            ToolStripMenuItem customerMenu = new ToolStripMenuItem("Customer");
            customerMenu.DropDownItems.Add("Add Customer", null, (s, e) => OpenForm(new AddCustomerForm()));
            customerMenu.DropDownItems.Add("Edit Customer", null, (s, e) => OpenForm(new EditCustomerForm()));

            // Supplier Submenu
            ToolStripMenuItem supplierMenu = new ToolStripMenuItem("Supplier");
            supplierMenu.DropDownItems.Add("Add Supplier", null, (s, e) => OpenForm(new AddSupplierForm()));
            supplierMenu.DropDownItems.Add("Edit Supplier", null, (s, e) => OpenForm(new EditSupplierForm()));

            personMenu.DropDownItems.AddRange(new ToolStripItem[] { customerMenu, supplierMenu });

            // Item Menu (unchanged)
            ToolStripMenuItem itemMenu = new ToolStripMenuItem("Item");
            itemMenu.DropDownItems.Add("Add Items", null, (s, e) => OpenForm(new ItemForm()));
            itemMenu.DropDownItems.Add("Edit Items", null, (s, e) => OpenForm(new EditItemForm()));

            // Warehouse Menu (unchanged)
            ToolStripMenuItem warehouseMenu = new ToolStripMenuItem("Warehouse");
            warehouseMenu.DropDownItems.Add("Add Warehouses", null, (s, e) => OpenForm(new WarehouseForm()));
            warehouseMenu.DropDownItems.Add("Edit Warehouses", null, (s, e) => OpenForm(new EditWarehouseForm()));

            // Voucher Menu (unchanged)
            ToolStripMenuItem voucherMenu = new ToolStripMenuItem("Voucher");
            voucherMenu.DropDownItems.Add("Receipt Vouchers", null, (s, e) => OpenForm(new ReceiptVoucherForm()));
            voucherMenu.DropDownItems.Add("Transfer Vouchers", null, (s, e) => OpenForm(new TransferVoucherForm()));
            voucherMenu.DropDownItems.Add("Issue Vouchers", null, (s, e) => OpenForm(new IssueVoucherForm()));

            // Reports Menu reorganized into Item/Warehouse categories
            ToolStripMenuItem reportsMenu = new ToolStripMenuItem("Reports");

            // Item Reports Submenu
            ToolStripMenuItem itemReportsMenu = new ToolStripMenuItem("Item Reports");
            itemReportsMenu.DropDownItems.Add("Item/Warehouse(s) Report", null, (s, e) => OpenForm(new ItemPerWarehouseReportForm()));
            itemReportsMenu.DropDownItems.Add("Transfer Report", null, (s, e) => OpenForm(new ItemTransferReportForm()));
            itemReportsMenu.DropDownItems.Add("Since Period Report", null, (s, e) => OpenForm(new ItemAtWarehouseSincePeriodReportForm()));
            itemReportsMenu.DropDownItems.Add("Expiration Report", null, (s, e) => OpenForm(new ItemAtWarehouseDaysTillExpirationReportForm()));

            // Warehouse Reports Submenu
            ToolStripMenuItem warehouseReportsMenu = new ToolStripMenuItem("Warehouse Reports");
            warehouseReportsMenu.DropDownItems.Add("Warehouse Report", null, (s, e) => OpenForm(new WarehousReportForm()));

            reportsMenu.DropDownItems.AddRange(new ToolStripItem[] { itemReportsMenu, warehouseReportsMenu });

            // Add all main menu items
            mainMenu.Items.AddRange(new ToolStripItem[] {
                personMenu,
                itemMenu,
                warehouseMenu,
                voucherMenu,
                reportsMenu
            });
        }

        private void OpenForm(Form childForm)
        {
            currentActiveForm?.Close();

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();

            currentActiveForm = childForm;
            this.Text = $"Warehouse Management System - {childForm.Text}";
        }

        #region People event handler
        private void AddCustomerButton_Click(object sender, EventArgs e)
        {
            OpenForm(new AddCustomerForm());
        }

        private void EditCustomerButton_Click(object sender, EventArgs e)
        {
            OpenForm(new EditCustomerForm());
        }

        private void AddSupplierButton_Click(object sender, EventArgs e)
        {
            OpenForm(new AddSupplierForm());
        }

        private void EditSupplierButton_Click(object sender, EventArgs e)
        {
            OpenForm(new EditSupplierForm());
        }
        #endregion

        #region Warehouse Event Handler
        private void AddWarehouseButton_Click(object sender, EventArgs e)
        {
            OpenForm(new WarehouseForm());
        }

        private void EditWarehouseButton_Click(object sender, EventArgs e)
        {
            OpenForm(new EditWarehouseForm());
        }
        #endregion

        #region Item Event handler
        private void AddItemButton_Click(object sender, EventArgs e)
        {
            OpenForm(new ItemForm());
        }

        private void EditItemButton_Click(object sender, EventArgs e)
        {
            OpenForm(new EditItemForm());
        }
        #endregion

        #region Vouchers Event handler
        private void CreateReceiptVoucherButton_Click(object sender, EventArgs e)
        {
            OpenForm(new ReceiptVoucherForm());
        }

        private void CreateTransferVoucherButton_Click(object sender, EventArgs e)
        {
            OpenForm(new TransferVoucherForm());
        }

        private void CreateIssueVoucherButton_Click(object sender, EventArgs e)
        {
            OpenForm(new IssueVoucherForm());
        }
        #endregion

        #region Reports Event handler
        private void ItemPerWarehouseReport_Click(object sender, EventArgs e)
        {
            OpenForm(new ItemPerWarehouseReportForm());
        }

        private void ItemTransferReportButton_Click(object sender, EventArgs e)
        {
            OpenForm(new ItemTransferReportForm());
        }

        private void ItemAtWarehouseSinceDays_Click(object sender, EventArgs e)
        {
            OpenForm(new ItemAtWarehouseSincePeriodReportForm());
        }

        private void ItemRemainigDaysTillExpirationButton_Click(object sender, EventArgs e)
        {
            OpenForm(new ItemAtWarehouseDaysTillExpirationReportForm());
        }

        private void WarehouseReportButton_Click(object sender, EventArgs e)
        {
            OpenForm(new WarehousReportForm());
        } 
        #endregion
    }
}