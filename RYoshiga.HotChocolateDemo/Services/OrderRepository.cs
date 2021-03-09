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
        Task<IEnumerable<Order>> GetOrderBy(int customerId,
            CancellationToken cancellationToken);
    }

    public class OrderRepository : IOrderRepository
    {
        public async Task<IEnumerable<Order>> GetOrderBy(int customerId,
            CancellationToken cancellationToken)
        {
            return await Task.FromResult(new List<Order>()
            {
                new Order
                {
                    Id = 1,
                    Date = DateTime.Now.AddDays(-93),
                    Total = 50,
                }
            }.AsEnumerable());
        }
    }
}