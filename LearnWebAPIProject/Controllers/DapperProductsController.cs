using LearnWebAPIProject.Models;
using LearnWebAPIProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearnWebAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DapperProductsController : ControllerBase
    {
        private readonly IDapperProductService _productService;

        public DapperProductsController(IDapperProductService productService)
        {
            _productService = productService;
        }

        // GET: api/dapperproducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            var products = await _productService.GetProducts();
            return Ok(products);
        }

        // GET: api/dapperproducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST: api/dapperproducts
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            var newProduct = await _productService.AddProduct(product);
            return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, newProduct);
        }
    }
}