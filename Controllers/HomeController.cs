using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Project_NexoGamer_Store.Models;

namespace Project_NexoGamer_Store.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private static List<Product> _products = new List<Product>()
    {
        new Product
        {
            Id = 1,
            Name = "Nexo Entry - GTX 1660 Super",
            Description = "The perfect entry point into PC gaming. Capable of playing most modern titles at 1080p with smooth framerates.",
            Price = 549.99m,
            ImageUrl = "https://images.unsplash.com/photo-1587202372775-e229f172b9d7?w=800",
            Specs = new List<string> { "GTX 1660 Super 6GB", "Intel i5-10400F", "16GB DDR4 RAM", "512GB NVMe SSD" }
        },
        new Product
        {
            Id = 2,
            Name = "Nexo Mid - RTX 4060",
            Description = "Balanced performance for high-refresh 1080p and capable 1440p gaming. Modern RTX features included.",
            Price = 899.99m,
            ImageUrl = "https://images.unsplash.com/photo-1591488320449-011701bb6704?w=800",
            Specs = new List<string> { "RTX 4060 8GB", "Intel i7-12700F", "32GB DDR4 RAM", "1TB NVMe SSD" }
        },
        new Product
        {
            Id = 3,
            Name = "Nexo Ultra - RTX 4080 Super",
            Description = "Uncompromising performance. 4K gaming at high settings with full ray tracing capabilities.",
            Price = 2499.99m,
            ImageUrl = "https://images.unsplash.com/photo-1624705002806-5d72df19c3ad?w=800",
            Specs = new List<string> { "RTX 4080 Super 16GB", "Intel i9-14900K", "64GB DDR5 RAM", "2TB Gen5 NVMe SSD" }
        }
    };

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View(_products);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Details(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound();
        return View(product);
    }
}
