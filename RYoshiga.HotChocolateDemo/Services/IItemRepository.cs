using System.Collections.Generic;
using RYoshiga.HotChocolateDemo.GraphModels;

namespace RYoshiga.HotChocolateDemo.Services
{
    public interface IItemRepository
    {
        IEnumerable<Item> ItemsBy(IEnumerable<int> orderIds);
    }
}