using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
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
            ViewBag.Categories = _dbContext.Categories.ToList();
            return View(products);
        }

        [HttpPost]
        public ActionResult SearchProduct(string name,DateTime? date,string categoryid,string isClear)
        {
            Console.WriteLine("Run: "+name);
            Console.WriteLine("Run: "+date);
            Console.WriteLine("Run: "+categoryid);
            var productsReturn = new List<Product>();
            if (isClear.Length > 0)
            {
                return PartialView("_ProductPartialView", _dbContext.Products.Include(p => p.categories).ToList());
            }
            foreach (var product in _dbContext.Products.Include(p => p.categories).ToList())
            {
                if (name.Length > 0 && date.ToString().Length > 0 && categoryid.Length > 0)
                {
                    if (name == product.Name && product.CategoryId == Int16.Parse(categoryid) &&
                        product.ReleaseDate.ToString("dd/MM/yyyy HH:mm:ss") == date.ToString())
                        productsReturn.Add(product);
                    
                }
            
                if ((name.Length > 0 && date.ToString().Length == 0 && categoryid.Length == 0) && product.Name.Contains(name))
                {
                        productsReturn.Add(product);
                }
            
                if ((date.ToString().Length > 0 && name.Length == 0 && categoryid.Length == 0) && (product.ReleaseDate.ToString("d", new CultureInfo("en-US")).Contains(date.ToString().Substring(0,9))))
                {
                        productsReturn.Add(product);
                }
            
                if ((categoryid.Length > 0 && name.Length == 0 && date.ToString().Length == 0) && (Int16.Parse(categoryid) == product.CategoryId))
                {
                        productsReturn.Add(product);
                }
            }

            return PartialView("_ProductPartialView", productsReturn);
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