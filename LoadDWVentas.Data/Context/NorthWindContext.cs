using LoadDWVentas.Data.Entities.Northwind;
using LoadDWVentas.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LoadDWVentas.Data.Context
{
    public partial class NorthWindContext : DbContext
    {
        public NorthWindContext(DbContextOptions<NorthWindContext> options) : base(options) 
        {

        } 
        
        #region"Db Sets"
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<VwVenta> VwVentas { get; set; }
        public DbSet<VwClientesAtendido> VwClientesAtendidos { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VwClientesAtendido>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("VWClientesAtendidos", "DWH");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(31);
            });

            modelBuilder.Entity<VwVenta>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("VWVentas", "DWH");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(40);
                entity.Property(e => e.CustomerId)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsFixedLength()
                    .HasColumnName("CustomerID");
                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(40);
                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(31);
                entity.Property(e => e.ShipperId).HasColumnName("ShipperID");
                entity.Property(e => e.Total).HasColumnType("money");
            });
        }
    } 
}