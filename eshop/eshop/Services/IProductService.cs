using eshop.Models;

namespace eshop.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}