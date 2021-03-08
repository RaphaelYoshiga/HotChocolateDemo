using System;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using RYoshiga.HotChocolateDemo.DataLoaders;

namespace RYoshiga.HotChocolateDemo.GraphModels
{
    public class Item
    {
        public int Quantity { get; set; }
        public decimal UnitCost { get; set; }
        public Guid ProductId { get; set; }

        public async Task<Product> GetProductAsync(
            [DataLoader]ProductsByIdDataLoader productById,
            CancellationToken cancellationToken)
        {
            return await productById.LoadAsync(ProductId, cancellationToken);
        }
    }
}