using Microsoft.AspNetCore.Mvc;
using Project_NexoGamer_Store.Models;

namespace Project_NexoGamer_Store.Controllers
{
    public class CartController : Controller
    {
        private static List<Product> _cartItems = new List<Product>();

        public IActionResult Index()
        {
            return View(_cartItems);
        }

        [HttpPost]
        public IActionResult Add(int id, string name, decimal price, string image)
        {
            _cartItems.Add(new Product { Id = id, Name = name, Price = price, ImageUrl = image });
            return RedirectToAction("Index");
        }

        public IActionResult Checkout()
        {
            _cartItems.Clear();
            return View();
        }
    }
}
