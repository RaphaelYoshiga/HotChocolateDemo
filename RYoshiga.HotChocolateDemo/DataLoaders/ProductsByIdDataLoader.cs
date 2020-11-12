using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate.DataLoader;

namespace RYoshiga.HotChocolateDemo
{
    public class ProductsByIdDataLoader : BatchDataLoader<Guid, Product>
    {
        protected override async Task<IReadOnlyDictionary<Guid, Product>> LoadBatchAsync(
            IReadOnlyList<Guid> keys,
            CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                Name = "Dog Bed"
            };
            return await Task.FromResult(keys.ToDictionary(p => p, x => product));
        }
    }
}