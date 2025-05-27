using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WarehouseManagementSystem.Domain.Enums;
using WarehouseManagementSystem.Domain.Models;
using WarehouseManagementSystem.Domain.Vouchers;

namespace WarehouseManagementSystem.Data.Context
{
    public class WarehouseDbContext : DbContext
    {

        #region Constructors
        public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options)
    : base(options)
        {
        }

        public WarehouseDbContext()
        {
        }
        #endregion

        #region Entities DBSets
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<ReceiptVoucher> ReceiptVouchers { get; set; }
        public DbSet<ReceiptVoucherDetail> ReceiptVoucherDetails { get; set; }
        public DbSet<IssueVoucher> IssueVouchers { get; set; }
        public DbSet<IssueVoucherDetail> IssueVoucherDetails { get; set; }
        public DbSet<TransferVoucher> TransferVouchers { get; set; }
        public DbSet<TransferVoucherDetail> TransferVoucherDetails { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure TPH Table per hierarchy  inheritance for Person hierarchy
            modelBuilder.Entity<Person>()
                .HasDiscriminator<string>("PersonType")
                .HasValue<Customer>("Customer")
                .HasValue<Supplier>("Supplier");

            

                // Additional configurations that can't be expressed via Data Annotations
                modelBuilder.Entity<InventoryItem>()
                    .HasKey(ii => new { ii.ItemCode, ii.WarehouseId });

                // Configure decimal precision where needed
                modelBuilder.Entity<ReceiptVoucherDetail>()
                    .Property(rvd => rvd.Quantity)
                    .HasColumnType("decimal(18,2)");

                modelBuilder.Entity<IssueVoucherDetail>()
                    .Property(ivd => ivd.Quantity)
                    .HasColumnType("decimal(18,2)");

                modelBuilder.Entity<TransferVoucherDetail>()
                    .Property(tvd => tvd.Quantity)
                    .HasColumnType("decimal(18,2)");

                // Configure the measurement units conversion
                modelBuilder.Entity<Item>()
                .Property(i => i.MeasurementUnits)
                .HasConversion(
                    v => string.Join(",", v.Select(e => e.ToString())),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                          .Select(e => Enum.Parse<MeasurementUnit>(e))
                          .ToList(),
                    new ValueComparer<List<MeasurementUnit>>(
                        (c1, c2) => c1.SequenceEqual(c2),
                        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                        c => c.ToList()));
            }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // This is just for development - in production use DI
            optionsBuilder.UseSqlServer("Data Source=.;initial catalog=WarehouseManagmentSystem;Integrated Security=True;TrustServerCertificate=True;");
        }
    }
}