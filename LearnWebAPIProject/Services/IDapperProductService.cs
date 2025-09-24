using LearnWebAPIProject.Dtos;
using LearnWebAPIProject.Models;

namespace LearnWebAPIProject.Services
{
    public interface IDapperProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product?> GetProductById(int id);
        Task<Product> AddProduct(CreateProductDto createProductDto);
        Task UpdateProduct(int id, UpdateProductDto productDto);
        Task DeleteProduct(int id);
    }
}