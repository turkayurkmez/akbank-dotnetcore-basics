using eshop.Models;

namespace eshop.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        List<Product> GetProductsByCategoryId(int id);

        Product FindProduct(int productId);
        void AddProduct(Product product);
        void Update(Product product);
    }
}