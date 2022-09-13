using System.Data.Entity;
using WAD_NguyenCaoHieu.Models;

namespace WAD_NguyenCaoHieu.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        
        public DbSet<Category> Categories { get; set; }

        public DatabaseContext(DbSet<Product> products, DbSet<Category> categories)
        {
            Products = products;
            Categories = categories;
        }

        public DatabaseContext() :base()
        { }
    }
}