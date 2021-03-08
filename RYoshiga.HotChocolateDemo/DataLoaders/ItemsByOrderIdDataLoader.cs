using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GreenDonut;
using HotChocolate.DataLoader;
using RYoshiga.HotChocolateDemo.GraphModels;
using RYoshiga.HotChocolateDemo.Services;

namespace RYoshiga.HotChocolateDemo.DataLoaders
{
    public class ItemsByOrderIdDataLoader : GroupedDataLoader<int, Item>
    {
        private readonly IItemRepository _itemRepository;
        public ItemsByOrderIdDataLoader(IItemRepository itemRepository, IBatchScheduler schedule) : base(schedule)
        {
            _itemRepository = itemRepository;
        }

        protected override Task<ILookup<int, Item>> LoadGroupedBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            var items = _itemRepository.ItemsBy(keys).ToLookup(x => x.OrderId);
            var lookup = keys.SelectMany(key => items[key].Select(p => new { Key = key, Item = p }))
                .ToLookup(x => x.Key, x => x.Item);
            return Task.FromResult(lookup);
        }
    }
}