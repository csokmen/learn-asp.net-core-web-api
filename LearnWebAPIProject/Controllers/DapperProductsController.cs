using LearnWebAPIProject.Dtos;
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
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
        {
            var products = await _productService.GetProducts();

            // Manual mapping from entity to DTO
            var productDtos = products.Select(p => new ProductDto { Id = p.Id, Name = p.Name });

            return Ok(productDtos);
        }

        // GET: api/dapperproducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            // Manual mapping from entity to DTO
            var productDto = new ProductDto { Id = product.Id, Name = product.Name };

            return Ok(productDto);
        }

        // POST: api/dapperproducts
        [HttpPost]
        public async Task<ActionResult<ProductDto>> PostProduct(CreateProductDto createProductDto)
        {
            var newProduct = await _productService.AddProduct(createProductDto);

            // Manual mapping from entity to DTO
            var productDto = new ProductDto { Id = newProduct.Id, Name = newProduct.Name };

            return CreatedAtAction(nameof(GetById), new { id = productDto.Id }, productDto);
        }

        // PUT: api/dapperproducts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, UpdateProductDto updateProductDto)
        {
            var existingProduct = await _productService.GetProductById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            await _productService.UpdateProduct(id, updateProductDto);

            return NoContent();
        }

        // DELETE: api/dapperproducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var existingProduct = await _productService.GetProductById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            await _productService.DeleteProduct(id);

            return NoContent();
        }
    }
}