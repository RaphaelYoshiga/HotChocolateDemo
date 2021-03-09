using System.Collections.Generic;
using System.Linq;
using RYoshiga.HotChocolateDemo.GraphModels;

namespace RYoshiga.HotChocolateDemo.Services
{
    public interface IItemRepository
    {
        IEnumerable<Item> ItemsBy(IEnumerable<int> orderIds);
    }

    public class ItemRepository : IItemRepository
    {
        public IEnumerable<Item> ItemsBy(IEnumerable<int> orderIds)
        {
            return orderIds.Select(x => new Item()
            {
                OrderId = x,
                ProductId = 1,
                Quantity = 1,
                UnitCost = 50
            });
        }
    }
}