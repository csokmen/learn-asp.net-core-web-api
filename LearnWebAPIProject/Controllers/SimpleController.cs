using LearnWebAPIProject.Models;
using LearnWebAPIProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearnWebAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimpleController : ControllerBase
    {
        private readonly IProductService _productService;

        public SimpleController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/simple
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return Ok(_productService.GetProducts());
        }

        // GET: api/simple/5
        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound(); // Returns a 404 Not Found response
            }
            return Ok(product); // Returns a 200 OK response with the product
        }

        // POST: api/simple
        [HttpPost]
        public ActionResult<Product> PostProduct(Product product)
        {
            var newProduct = _productService.AddProduct(product);

            return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, newProduct);
        }
    }
}
