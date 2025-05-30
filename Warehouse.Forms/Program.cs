using WarehouseManagementSystem.Data.Context;
using WarehouseManagementSystem.Domain.Models;
using WarehouseManagmentSystem.WinForms.ReportForms;

namespace WarehouseManagmentSystem.WinForms.Forms
{
    internal static class Program
    {
        private static  WarehouseDbContext Context { get; } = new WarehouseDbContext();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            bool created = Context.Database.EnsureCreated();
            Console.WriteLine(created ? "Database created successfully" : "Database already exists");
            Application.Run(new MainForm());
        }
    }
}