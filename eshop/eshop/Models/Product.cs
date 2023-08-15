namespace eshop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        public string ImageUrl { get; set; } = "https://cdn.dsmcdn.com/ty544/product/media/images/20220929/18/181394174/583093456/1/1_org.jpg";

    }
}
