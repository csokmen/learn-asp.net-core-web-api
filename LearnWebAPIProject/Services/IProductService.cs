using LearnWebAPIProject.Models;

namespace LearnWebAPIProject.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product? GetProductById(int id);
        Product AddProduct(Product product);
    }
}
