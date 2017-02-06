using System;
using System.Data.Entity;
using System.Linq;

namespace ProductsStore.Models
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public void SaveProduct(Product product)
        {
            if (product.Id == 0)
            {
                product.Id = Products.Count() + 1;
                product.CreationDate = DateTime.Now;
                Products.Add(product);
            }
            else
            {
                Product dbEntry = Products.Find(product.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                }
            }
            SaveChanges();
        }

        public Product DeleteProduct(int productId)
        {
            Product dbEntry = Products.Find(productId);
            if (dbEntry != null)
            {
                Products.Remove(dbEntry);
                SaveChanges();
            }
            return dbEntry;
        }
    }
}