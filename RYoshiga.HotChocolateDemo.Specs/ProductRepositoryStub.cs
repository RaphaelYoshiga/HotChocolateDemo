using System.Collections.Generic;
using System.Linq;
using RYoshiga.HotChocolateDemo.GraphModels;
using RYoshiga.HotChocolateDemo.Services;

namespace RYoshiga.HotChocolateDemo.Specs
{
    public class ProductRepositoryStub : IProductRepository
    {
        private readonly Dictionary<int, Product> _productsById = new Dictionary<int, Product>();
        public Dictionary<int, Product> GetProducts(IReadOnlyList<int> keys)
        {
            return keys.ToDictionary(key => key, key => _productsById[key]);
        }

        public void Add(IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                _productsById.Add(product.Id, product);
            }
        }
    }
}