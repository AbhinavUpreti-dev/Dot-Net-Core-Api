using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ContextClasses
{
    public class ItemContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectModels;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public DbSet<Item> Item { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
              .HasData(
               new Item { Id = 1, Name = "Pencil",Quantity=10 },
               new Item { Id = 2, Name = "Pen",Quantity=11 },
               new Item { Id = 3, Name = "Notebook", Quantity = 11 });
        }

        public IEnumerable<Item> GetOrders()
        {
            return this.Item.AsEnumerable();
        }

        public void AddItems(Item item)
        {
             this.Item.Add(item);
        }
    }
}
