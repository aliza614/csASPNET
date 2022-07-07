using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Testing.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository repo;

        public ProductController(IProductRepository repo)
        {
            this.repo = repo;
        }
        //this is what is loaded when you look for Product/Index on your website
        //the Product comes from the name of the file ProductController
        ///you can open it with localhost:44387/Product
        public IActionResult Index()
        {
            var products = repo.GetAllProducts();   
            return View(products);
        }

    }
}
