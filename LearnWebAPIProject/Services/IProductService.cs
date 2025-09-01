using LearnWebAPIProject.Models;

namespace LearnWebAPIProject.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product?> GetProductById(int id);
        Task<Product> AddProduct(Product product);
    }
}
