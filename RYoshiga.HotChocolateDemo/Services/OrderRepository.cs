using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RYoshiga.HotChocolateDemo.GraphModels;
using RYoshiga.HotChocolateDemo.QueryTypes;

namespace RYoshiga.HotChocolateDemo.Services
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrderBy(
            Customer customer,
            CancellationToken cancellationToken);
    }

    public class OrderRepository : IOrderRepository
    {
        public async Task<IEnumerable<Order>> GetOrderBy(
            Customer customer,
            CancellationToken cancellationToken)
        {
            return await Task.FromResult(new List<Order>()
            {
                new Order
                {
                    Date = DateTime.Now.AddDays(-93),
                    Total = 864.99m,
                    Items = new List<Item>
                    {
                        new Item
                        {
                            UnitCost = 500.99m,
                            ProductId = Demo.ProductId,
                            Quantity = 1
                        },
                        new Item{
                            UnitCost = 99,
                            ProductId = Demo.ProductId2,
                            Quantity = 1
                        },
                        new Item{
                            UnitCost = 55,
                            ProductId = Demo.ProductId3,
                            Quantity = 3
                        },
                        new Item{
                            UnitCost = 25,
                            ProductId = Demo.ProductId4,
                            Quantity = 4
                        }
                    }
                }
            }.AsEnumerable());
        }
    }
}