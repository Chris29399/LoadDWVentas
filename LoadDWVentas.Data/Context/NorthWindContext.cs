using LoadDWVentas.Data.Entities.Northwind;
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
        #endregion
    }
}