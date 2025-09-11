using LearnWebAPIProject.Models;

namespace LearnWebAPIProject.Services
{
    public interface IDapperProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product?> GetProductById(int id);
        Task<Product> AddProduct(Product product);
    }
}