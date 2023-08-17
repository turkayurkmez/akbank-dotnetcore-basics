using System.ComponentModel.DataAnnotations;

namespace eshop.Infrastructure.Entities
{
    //[Table("Urunler")]
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Lütfen ürün adını giriniz ")]
        [MinLength(2, ErrorMessage = "En az iki harfli olmalı")]
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public string? ImageUrl { get; set; } = "https://cdn.dsmcdn.com/ty544/product/media/images/20220929/18/181394174/583093456/1/1_org.jpg";
        public int? CategoryId { get; set; }

        //Navigation Property: 
        public Category? Category { get; set; }

    }
}
