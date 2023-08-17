using eshop.Infrastructure.Entities;

namespace eshop.Models
{
    public class ProductItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; } = 1;
    }
    public class ShoppingCollection
    {
        //private yapmadık; çünkü JSON'a serialize edilecek.
        public List<ProductItem> ProductItems { get; set; } = new List<ProductItem>();

        public void Add(ProductItem productItem)
        {
            var existingProduct = ProductItems.SingleOrDefault(p => p.Product.Id == productItem.Product.Id);
            if (existingProduct == null)
            {
                ProductItems.Add(productItem);
            }
            else
            {
                existingProduct.Quantity += productItem.Quantity;
            }

        }

        public decimal? TotalPrice() => ProductItems.Sum(p => p.Product.Price * (1 - p.Product.Discount) * p.Quantity);
        public void Clear() => ProductItems.Clear();
        public void Remove(int id) => ProductItems.RemoveAll(p => p.Product.Id == id);


    }
}
