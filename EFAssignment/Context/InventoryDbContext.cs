using EFAssignment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAssignment.Context
{
    internal class InventoryDbContext:DbContext
    {
        public InventoryDbContext()
        {
            
        }

        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }
        public DbSet<Inventory> Inventories { get; set; }
        
        //Collection
        public DbSet<Supplier> Suppliers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"data source=SHIVAM\SQLEXPRESS;initial catalog=EmpDb;integrated security=true;TrustServerCertificate=True");
        }
    }
}
