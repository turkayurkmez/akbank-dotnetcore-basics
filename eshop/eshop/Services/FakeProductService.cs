﻿using eshop.Models;

namespace eshop.Services
{
    public class FakeProductService : IProductService
    {
        private List<Product> products;

        public FakeProductService()
        {
            products = new List<Product>()
            {
              new (){ Id =1, Name="Product A", Description="Desc of Product A", Price=100, Discount=0.15M },
              new (){ Id =2, Name="Product B", Description="Desc of Product B", Price=100, Discount=0.15M },
              new (){ Id =3, Name="Product C", Description="Desc of Product C", Price=100, Discount=0.15M },
              new (){ Id =4, Name="Product D", Description="Desc of Product D", Price=100, Discount=0.15M },
              new (){ Id =5, Name="Product e", Description="Desc of Product E", Price=100, Discount=0.15M },
              new (){ Id =6, Name="Product F", Description="Desc of Product F", Price=100, Discount=0.15M },
              new (){ Id =7, Name="Product G", Description="Desc of Product G", Price=100, Discount=0.15M },
              new (){ Id =8, Name="Product H", Description="Desc of Product H", Price=100, Discount=0.15M }
            };
        }

        public List<Product> GetProducts()
        {
            return products;
        }
    }
}