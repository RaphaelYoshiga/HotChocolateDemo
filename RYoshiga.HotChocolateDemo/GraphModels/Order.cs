using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using RYoshiga.HotChocolateDemo.DataLoaders;

namespace RYoshiga.HotChocolateDemo.GraphModels
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }


        public async Task<IEnumerable<Item>> Items([DataLoader]ItemsByOrderIdDataLoader itemsByOrderIdDataLoader, CancellationToken cancellationToken)
        {
            return await itemsByOrderIdDataLoader.LoadAsync(Id, cancellationToken);
        }
    }
}