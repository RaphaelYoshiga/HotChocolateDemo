using System;
using System.Collections.Generic;
using System.Linq;
using RYoshiga.HotChocolateDemo.DataLoaders;
using RYoshiga.HotChocolateDemo.GraphModels;
using RYoshiga.HotChocolateDemo.QueryTypes;

namespace RYoshiga.HotChocolateDemo.Services
{
    public class ProductRepository : IProductRepository
    {
        public Dictionary<Guid, Product> GetProducts(IReadOnlyList<Guid> keys)
        {
            var products = new Dictionary<Guid, Product>
            {
                {Demo.ProductId, new Product {Name = "PS5"}},
                {Demo.ProductId2, new Product {Name = "Headset"}},
                {Demo.ProductId3, new Product {Name = "Controller"}},
                {Demo.ProductId4, new Product {Name = "Assorted Game"}}
            };

            var result = keys.ToDictionary(key => key, key => products[key]);
            return result;
        }
    }
}