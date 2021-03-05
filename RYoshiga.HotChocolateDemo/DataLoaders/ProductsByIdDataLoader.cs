using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GreenDonut;
using HotChocolate.DataLoader;
using RYoshiga.HotChocolateDemo.Models;

namespace RYoshiga.HotChocolateDemo.DataLoaders
{
    public interface IProductRepository
    {
        Dictionary<Guid, Product> GetProducts(IReadOnlyList<Guid> keys);
    }

    public class ProductsByIdDataLoader : BatchDataLoader<Guid, Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductsByIdDataLoader(IProductRepository productRepository, IBatchScheduler schedule) : base(schedule)
        {
            _productRepository = productRepository;
        }

        protected override async Task<IReadOnlyDictionary<Guid, Product>> LoadBatchAsync(
            IReadOnlyList<Guid> keys,
            CancellationToken cancellationToken)
        {
            var productsDictionary = _productRepository.GetProducts(keys);
            return await Task.FromResult(productsDictionary);
        }
    }
}