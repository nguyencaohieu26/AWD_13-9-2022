using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WAD_NguyenCaoHieu.Database;
using WAD_NguyenCaoHieu.Models;

namespace WAD_NguyenCaoHieu.Controllers
{
    public class ProductController : Controller
    {
        private DatabaseContext _dbContext = new DatabaseContext();
        // GET
        public ActionResult Index()
        {
            var products = _dbContext.Products.Include(p => p.categories).ToList();
            return View(products);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Price,Quantity,CategoryId")] Product @product)
        {
           
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("ProductForm");
                }

                if (@product.ProductId != 0)
                {
                    var productGet = _dbContext.Products.Find(@product.ProductId);
                    if (productGet != null)
                    {
                        productGet.Name = @product.Name;
                        productGet.Price = @product.Price;
                        productGet.Quantity = @product.Quantity;
                        productGet.CategoryId = @product.CategoryId;     
                    }
                }
                else
                {
                    Random rnd = new Random();
                    @product.ProductId = rnd.Next();
                    @product.ReleaseDate = DateTime.Now;
                    _dbContext.Products.Add(@product);
                }
                _dbContext.SaveChanges();
                return Redirect("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? productId)
        {
            if (productId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = _dbContext.Products.Find(productId);
            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ProductForm(int? productId)
        {
            Product productGet = new Product();

            ViewBag.Categories = _dbContext.Categories.ToList();

            if (productId == null)
            {
                ViewBag.productGet = productGet;
                return View("Create");
            }

            ViewBag.productGet  = _dbContext.Products.Find(productId);

            return View("Create");
        }

        [HttpGet]
        public ActionResult GetDetail(int? productId)
        {
            if (productId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = _dbContext.Products.Find(productId);
            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            ViewBag.product = product;
            return View("Detail");
        }
        
        
    }
}