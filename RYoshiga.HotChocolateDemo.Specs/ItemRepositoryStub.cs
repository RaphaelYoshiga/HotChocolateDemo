using System.Collections.Generic;
using System.Linq;
using RYoshiga.HotChocolateDemo.GraphModels;
using RYoshiga.HotChocolateDemo.Services;

namespace RYoshiga.HotChocolateDemo.Specs
{
    public class ItemRepositoryStub : IItemRepository
    {
        readonly IDictionary<int, List<Item>> _itemsByOrderId = new Dictionary<int, List<Item>>();

        public IEnumerable<Item> ItemsBy(IEnumerable<int> orderIds)
        {
            return orderIds.SelectMany(orderId => 
                _itemsByOrderId.ContainsKey(orderId) ? 
                    _itemsByOrderId[orderId] : 
                    Enumerable.Empty<Item>());
        }

        public void Add(in int orderId, IEnumerable<Item> items)
        {
            _itemsByOrderId[orderId] = items.ToList();
        }
    }
}