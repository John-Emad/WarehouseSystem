using WarehouseManagmentSystem.WinForms.Forms;
using WarehouseManagmentSystem.WinForms.ReportForms;

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
            warehouseMenu.DropDownItems.Add("Manage Warehouses", null, (s, e) => OpenForm(new WarehouseForm()));


            // Voucher Menu
            ToolStripMenuItem voucherMenu = new ToolStripMenuItem("Voucher");
            voucherMenu.DropDownItems.Add("Receipt Vouchers", null, (s, e) => OpenForm(new ReceiptVoucherForm()));
            voucherMenu.DropDownItems.Add("Transfer Vouchers", null, (s, e) => OpenForm(new TransferVoucherForm()));
            voucherMenu.DropDownItems.Add("Issue Vouchers", null, (s, e) => OpenForm(new IssueVoucherForm()));

            // Reports Menu
            ToolStripMenuItem reportsMenu = new ToolStripMenuItem("Reports");
            reportsMenu.DropDownItems.Add("Warehouse Report", null, (s, e) => OpenForm(new WarehousReportForm()));
            reportsMenu.DropDownItems.Add("Item Report", null, (s, e) => OpenForm(new ItemReportForm()));

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
