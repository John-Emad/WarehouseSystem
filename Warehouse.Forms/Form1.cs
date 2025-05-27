using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem.Data.Context;

namespace Warehouse.Forms
{
    public partial class MainForm : Form
    {
        private readonly WarehouseDbContext _context = new WarehouseDbContext();
        public MainForm()
        {
            Console.WriteLine(_context.Database.EnsureCreated()
                ? "Database created"
                : "Database already exists");
            InitializeComponent();
        }
    }
}
