using Dapper;
using LearnWebAPIProject.Data;
using LearnWebAPIProject.Models;

namespace LearnWebAPIProject.Services
{
    public class DapperProductService : IDapperProductService
    {
        private readonly DapperContext _context;

        public DapperProductService(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var query = "SELECT * FROM Products";
            using (var connection = _context.CreateConnection())
            {
                var products = await connection.QueryAsync<Product>(query);
                return products.ToList();
            }
        }

        public async Task<Product?> GetProductById(int id)
        {
            var query = "SELECT * FROM Products WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                var product = await connection.QuerySingleOrDefaultAsync<Product>(query, new { id });
                return product;
            }
        }

        public async Task<Product> AddProduct(Product product)
        {
            var query = "INSERT INTO Products (Name) VALUES (@Name); SELECT CAST(SCOPE_IDENTITY() as int)";
            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, new { product.Name });
                var createdProduct = new Product { Id = id, Name = product.Name };
                return createdProduct;
            }
        }
    }
}