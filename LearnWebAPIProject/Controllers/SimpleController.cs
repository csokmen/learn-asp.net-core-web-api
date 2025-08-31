using LearnWebAPIProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearnWebAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimpleController : ControllerBase
    {
        private static readonly List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Product A" },
            new Product { Id = 2, Name = "Product B" }
        };

        // This is an action method that handles HTTP GET requests.
        // It can be accessed at the URL: /api/simple
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _products;
        }

        // This action handles GET requests to /api/simple/{id}
        // For example: /api/simple/1
        [HttpGet("{id}")]
        public Product? GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }
    }
}
