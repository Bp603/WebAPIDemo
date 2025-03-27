using MyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace WebAPIDemo.Areas.HelpPage.Controllers
{
    public class ProductController : Controller
    {

        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop" },
             new Product { Id = 2, Name = "Phone" }
        };

        // GET: api/Product
        // [HttpGet]
        //public ActionResult<List<Product>> GetProducts()
        //{
        //    return products;
        //}
        // POST: api/Product
        //[HttpPost]
        //public IActionResult AddProduct([FromBody] Product product)
        //{
        //    if (product == null)
        //    {
        //        return BadRequest("Invalid product data.");
        //    }

        //    product.Id = products.Count > 0 ? products.Max(p => p.Id) + 1 : 1;
        //    products.Add(product);
        //    return Ok(new { Message = "Product Added", Product = product });
        //}
        //// DELETE: api/Product/{id}
        //[HttpDelete("{id}")]
        //public IActionResult DeleteProduct(int id)
        //{
        //    var product = products.FirstOrDefault(p => p.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound("Product not found.");
        //    }

        //    products.Remove(product);
        //    return Ok(new { Message = "Product Deleted", Product = product });
        //}
        // GET: HelpPage/Product
        public ActionResult Index()
        {
            return View();
        }
    }
}