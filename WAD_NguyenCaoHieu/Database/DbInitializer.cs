using System;
using System.Data.Entity;
using WAD_NguyenCaoHieu.Models;

namespace WAD_NguyenCaoHieu.Database
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            context.Categories.Add(new Category()
            {
               CategoryId = 1,
               CategoryName = "Fruit"
            });
            context.Categories.Add(new Category()
            {
               CategoryId = 2,
               CategoryName = "Meat"
            });context.Categories.Add(new Category()
            {
               CategoryId = 3,
               CategoryName = "Vegetable"
            });
            
            
            context.Products.Add(new Product()
            {
                ProductId = 1,
                Name = "Lemon",
                Price = 100,
                Quantity = 10,
                ReleaseDate = DateTime.Now,
                CategoryId = 1,
            });context.Products.Add(new Product()
            {
                ProductId = 2,
                Name = "Beef",
                Price = 150,
                Quantity = 15,
                ReleaseDate = DateTime.Now,
                CategoryId = 2,
            });context.Products.Add(new Product()
            {
                ProductId = 3,
                Name = "Chicken",
                Price = 50,
                Quantity = 20,
                ReleaseDate = DateTime.Now,
                CategoryId = 2,
            });context.Products.Add(new Product()
            {
                ProductId = 4,
                Name = "Duck",
                Price = 34,
                Quantity = 35,
                ReleaseDate = DateTime.Now,
                CategoryId = 2,
            });context.Products.Add(new Product()
            {
                ProductId = 5,
                Name = "Banana",
                Price = 23,
                Quantity = 14,
                ReleaseDate = DateTime.Now,
                CategoryId = 1,
            });context.Products.Add(new Product()
            {
                ProductId = 6,
                Name = "Kiwi",
                Price = 18,
                Quantity = 19,
                ReleaseDate = DateTime.Now,
                CategoryId = 1,
            });context.Products.Add(new Product()
            {
                ProductId = 7,
                Name = "Orange",
                Price = 20,
                Quantity = 20,
                ReleaseDate = DateTime.Now,
                CategoryId = 1,
            });context.Products.Add(new Product()
            {
                ProductId = 8,
                Name = "Spinach",
                Price = 10,
                Quantity = 20,
                ReleaseDate = DateTime.Now,
                CategoryId = 3,
            });context.Products.Add(new Product()
            {
                ProductId = 9,
                Name = "Cauliflower",
                Price = 14,
                Quantity = 20,
                ReleaseDate = DateTime.Now,
                CategoryId = 3,
            });context.Products.Add(new Product()
            {
                ProductId = 10,
                Name = "Sweet Potato",
                Price = 18,
                Quantity = 20,
                ReleaseDate = DateTime.Now,
                CategoryId = 3,
            });
            base.Seed(context);
        }
    }
}