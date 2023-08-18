using eshop.Infrastructure.Data;
using eshop.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace eshop.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly AkbankDbContext akbankDbContext;

        public ProductService(AkbankDbContext akbankDbContext)
        {
            this.akbankDbContext = akbankDbContext;
        }

        public void AddProduct(Product product)
        {
            akbankDbContext.Products.Add(product);
            akbankDbContext.SaveChanges();
        }

        public Product FindProduct(int productId)
        {
            return akbankDbContext.Products.Find(productId);
        }

        public List<Product> GetProducts()
        {
            return akbankDbContext.Products.ToList();
        }

        public List<Product> GetProductsByCategoryId(int id)
        {
            return akbankDbContext.Products.Where(p => p.CategoryId == id).ToList();
        }

        public async Task<List<Product>> SearchByName(string name)
        {

            return await akbankDbContext.Products.Where(p => p.Name.Contains(name)).ToListAsync();
        }

        public void Update(Product product)
        {
            akbankDbContext.Products.Update(product);
            akbankDbContext.SaveChanges();
        }
    }
}
