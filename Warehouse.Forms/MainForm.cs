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
            itemReportsMenu.DropDownItems.Add("Item Report", null, (s, e) => OpenForm(new ItemReportForm()));
            itemReportsMenu.DropDownItems.Add("Item Transfer Report", null, (s, e) => OpenForm(new ItemTransferReportForm()));
            itemReportsMenu.DropDownItems.Add("Item Since Period Report", null, (s, e) => OpenForm(new ItemAtWarehouseSincePeriodReportForm()));
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
    }
}