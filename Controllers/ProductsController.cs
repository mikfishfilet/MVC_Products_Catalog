using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Models;

namespace ProductCatalog.Controllers
{
    public class ProductsController : Controller
    {
        private readonly string _filePath;

        public ProductsController(IWebHostEnvironment environment)
        {
            string dataDirectory = Path.Combine(
                environment.ContentRootPath, "data");

            Directory.CreateDirectory(dataDirectory);

            _filePath = Path.Combine(dataDirectory, "products.json");

            if (!System.IO.File.Exists(_filePath))
            {
                System.IO.File.WriteAllText(_filePath, "[]");
            }
        }

        private List<Product> LoadProducts()
        {
            string json = System.IO.File.ReadAllText(_filePath);

            return JsonSerializer.Deserialize<List<Product>>(json)
                   ?? new List<Product>();
        }

        private void SaveProducts(List<Product> products)
        {
            string json = JsonSerializer.Serialize(
                products,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            System.IO.File.WriteAllText(_filePath, json);
        }

        public IActionResult Index()
        {
            List<Product> products = LoadProducts();

            return View(products);
        }

        public IActionResult Details(int id)
        {
            Product? product = LoadProducts()
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            List<Product> products = LoadProducts();

            product.Id = products.Count == 0
                ? 1
                : products.Max(p => p.Id) + 1;

            products.Add(product);

            SaveProducts(products);

            return RedirectToAction(nameof(Index));
        }
    }
}