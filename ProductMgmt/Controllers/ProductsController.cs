using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMgmt.Models;

namespace ProductMgmt.Controllers
{
    public class ProductsController : Controller
    {
        // GET: ProductsController
        public ActionResult Index()
        {
            List<Product> list = Product.AllProduct();
            return View(list);
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            Product obj = Product.GetProduct(id);
            return View(obj);
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            Product product = new Product();    
            return View(product);
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Product obj = new Product();
                obj.ProductID = Convert.ToInt32(collection["ProductID"]);
                obj.ProductName = Convert.ToString(collection["ProductName"]);
                obj.Price = Convert.ToDecimal(collection["Price"]);


                Product.AddProduct(obj);
                ViewBag.Message = "Product Added Succesfully";
                return View();
            }
            catch(Exception e)
            {
                ViewBag.Message = e.Message;
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            Product product =Product.GetProduct(id);
            return View(product);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product obj)
        {
            try
            {

                Product.EditProduct(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            Product product = Product.GetProduct(id);
            return View(product);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Product.DeleteProduct(id);
                ViewBag.Meassage = "Product Deleted";

                // return View();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return View();
            }
        }
    }
}
