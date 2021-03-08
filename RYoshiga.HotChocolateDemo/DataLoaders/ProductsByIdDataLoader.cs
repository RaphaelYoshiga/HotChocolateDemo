using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GreenDonut;
using HotChocolate.DataLoader;
using RYoshiga.HotChocolateDemo.GraphModels;
using RYoshiga.HotChocolateDemo.Services;

namespace RYoshiga.HotChocolateDemo.DataLoaders
{
    public class ProductsByIdDataLoader : BatchDataLoader<int, Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductsByIdDataLoader(IProductRepository productRepository, IBatchScheduler schedule) : base(schedule)
        {
            _productRepository = productRepository;
        }

        protected override async Task<IReadOnlyDictionary<int, Product>> LoadBatchAsync(
            IReadOnlyList<int> keys,
            CancellationToken cancellationToken)
        {
            var productsDictionary = _productRepository.GetProducts(keys);
            return await Task.FromResult(productsDictionary);
        }
    }
}