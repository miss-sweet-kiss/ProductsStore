using System;
using System.Data.Entity;

namespace ProductsStore.Models
{
    public class ProductDbInitializer : DropCreateDatabaseAlways<ProductContext>
    {
        protected override void Seed(ProductContext db)
        {
            Random rand = new Random();
            for (int i = 1; i < 20; i++)
            {
                db.Products.Add(new Product { Id = i, Name = $"Product {i}", Description = $"Description {i}", Price = rand.Next(1, 2000), CreationDate = DateTime.Now });
            }

            base.Seed(db);
        }
    }
}