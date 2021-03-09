using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using RYoshiga.HotChocolateDemo.GraphModels;
using RYoshiga.HotChocolateDemo.Services;

namespace RYoshiga.HotChocolateDemo.Specs
{
    public class ProductRepositoryStub : IProductRepository
    {
        private int _readCount = 0;
        private readonly Dictionary<int, Product> _productsById = new Dictionary<int, Product>();
        public Dictionary<int, Product> ProductsBy(IReadOnlyList<int> keys)
        {
            _readCount++;
            return keys.ToDictionary(key => key, key => _productsById[key]);
        }

        public void Add(IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                _productsById.Add(product.Id, product);
            }
        }

        public void VerifyCalledOnlyXTimes(int times)
        {
            _readCount.Should().Be(times);
        }
    }
}