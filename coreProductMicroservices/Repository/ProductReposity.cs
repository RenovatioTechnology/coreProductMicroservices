using coreProductMicroservices.Models;
using Microsoft.EntityFrameworkCore;

namespace coreMicroserviceProject.Repository
{
    public class ProductReposity : IProductRepository
    {
        // Communicate with  DbContext
        private readonly ProductDbContext _dbContext;
        // Injected into constructor
        public ProductReposity(ProductDbContext context)
        {
            _dbContext = context; 
        }
        public void DeleteProduct(int productId)
        {
            var product = _dbContext.Products.Find(productId);
            _dbContext.Products.Remove(product);
            Save();
        }

        public Product GetProductById(int productId)
        {
            return _dbContext.Products.Find(productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dbContext.Products.ToList();
        }

        public void InsertProduct(Product product)
        {
            _dbContext.Add(product);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            Save();
        }
        // Add controller "Read and Write"
    }
}
