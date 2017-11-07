using System.Linq;
using System.Web.Mvc;
using ShoppingList.Models;
using System.Net;

namespace ShoppingList.Controllers
{
    [ValidateInput(false)]
    public class ProductController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            using (var db = new ShoppingListDbContext())
            {
                var products = db
                    .Products
                    .ToList();
                return View(products);
            }
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ShoppingListDbContext())
                {
                    if (product.Priority != 0 && product.Quantity != 0 && (product.Status == "bought" || product.Status == "not bought"))
                    {
                        db.Products.Add(product);
                        db.SaveChanges();

                        return RedirectToAction("Index");
                    }
                    else

                        return RedirectToAction("Create");
                }
            }
            return View(product);
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var db = new ShoppingListDbContext())
            {
                var product = db
                   .Products
                   .Where(a => a.Id == id)
                   .FirstOrDefault();
                if (product == null)
                {
                    return HttpNotFound();
                }
                return View(product);
            }
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int? id, Product productModel)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            using (var db = new ShoppingListDbContext())
            {
                var product = db
                   .Products
                   .Where(a => a.Id == id)
                   .FirstOrDefault();
                if (product == null)
                {
                    return HttpNotFound();
                }
                if (productModel.Priority != 0 && productModel.Quantity != 0 && (productModel.Status == "bought" || productModel.Status == "not bought"))
                {
                    product.Priority = productModel.Priority;
                    product.Name = productModel.Name;
                    product.Quantity = productModel.Quantity;
                    product.Status = productModel.Status;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
    }
}