using BookStore.EntityLayer.Concrete;
using BookStore.EnttityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.Context
{
    public class BookStoreContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-FUO4J03; initial catalog=ApiBookDb; integrated security=true; TrustServerCertificate=True;");
        }

        public DbSet<Category> Categories  { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Word> Words { get; set; }
    }
}
