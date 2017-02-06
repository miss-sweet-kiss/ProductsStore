using System.Linq;
using System.Web.Mvc;
using ProductsStore.Models;

namespace ProductsStore.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public int pageSize = 10;
        ProductContext db = new ProductContext();

        public ActionResult Index(int page = 1)
        {
            var model = new ProductsListViewModel
            {
                Products = db.Products
                    .OrderBy(prod => prod.Id)
                    .Skip((page - 1)*pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = db.Products.Count()
                }
            };
            return View(model);
        }

        public ViewResult Edit(int id)
        {
            Product product = db.Products.FirstOrDefault(p => p.Id == id);
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.SaveProduct(product);
                TempData["message"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Product());
        }

        public ActionResult Delete(int id)
        {
            Product deletedProduct = db.DeleteProduct(id);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedProduct.Name);
            }
            return RedirectToAction("Index", "Admin");
        }
    }
}