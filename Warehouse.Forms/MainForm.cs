using WarehouseManagmentSystem.WinForms.Forms;
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

            // Person Menu
            ToolStripMenuItem personMenu = new ToolStripMenuItem("Person");
            personMenu.DropDownItems.Add("Manage people", null, (s, e) => OpenForm(new PersonForm()));

            // Item Menu
            ToolStripMenuItem itemMenu = new ToolStripMenuItem("Item");
            itemMenu.DropDownItems.Add("Manage Items", null, (s, e) => OpenForm(new ItemForm()));

            // Warehouse Menu
            ToolStripMenuItem warehouseMenu = new ToolStripMenuItem("Warehouse");
            warehouseMenu.DropDownItems.Add("Add Warehouses", null, (s, e) => OpenForm(new WarehouseForm()));
            warehouseMenu.DropDownItems.Add("Edit Warehouses", null, (s, e) => OpenForm(new EditWarehouseForm()));


            // Voucher Menu
            ToolStripMenuItem voucherMenu = new ToolStripMenuItem("Voucher");
            voucherMenu.DropDownItems.Add("Receipt Vouchers", null, (s, e) => OpenForm(new ReceiptVoucherForm()));
            voucherMenu.DropDownItems.Add("Transfer Vouchers", null, (s, e) => OpenForm(new TransferVoucherForm()));
            voucherMenu.DropDownItems.Add("Issue Vouchers", null, (s, e) => OpenForm(new IssueVoucherForm()));

            // Reports Menu
            ToolStripMenuItem reportsMenu = new ToolStripMenuItem("Reports");
            reportsMenu.DropDownItems.Add("Warehouse Report", null, (s, e) => OpenForm(new WarehousReportForm()));
            reportsMenu.DropDownItems.Add("Item Report", null, (s, e) => OpenForm(new ItemReportForm()));
            reportsMenu.DropDownItems.Add("Item Transfer Report", null, (s, e) => OpenForm(new ItemTransferReportForm()));
            reportsMenu.DropDownItems.Add("Item Since Period Report", null, (s, e) => OpenForm(new ItemAtWarehouseSincePeriodReportForm()));
            reportsMenu.DropDownItems.Add("Item Remaining days for Expiration", null, (s, e) => OpenForm(new ItemAtWarehouseDaysTillExpirationReportForm()));

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
            // Close current active form if exists
            currentActiveForm?.Close();

            // Set up new form
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // Add to main form's panel
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();

            currentActiveForm = childForm;

            // Optional: Update main form title
            this.Text = $"Warehouse Management System - {childForm.Text}";
        }

    }

}
