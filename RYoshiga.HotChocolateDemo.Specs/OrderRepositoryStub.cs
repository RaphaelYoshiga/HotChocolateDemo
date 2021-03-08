using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RYoshiga.HotChocolateDemo.GraphModels;
using RYoshiga.HotChocolateDemo.Services;

namespace RYoshiga.HotChocolateDemo.Specs
{
    public class OrderRepositoryStub : IOrderRepository
    {
        readonly IDictionary<int, List<Order>> _ordersByCustomerId = new Dictionary<int, List<Order>>();

        public void Add(in int customerId, Order order)
        {
            if (_ordersByCustomerId.ContainsKey(customerId))
                _ordersByCustomerId[customerId].Add(order);
            else
                _ordersByCustomerId[customerId] = new List<Order> { order };
        }

        public Task<IEnumerable<Order>> GetOrderBy(int customerId, CancellationToken cancellationToken)
        {
            return Task.FromResult(_ordersByCustomerId[customerId].AsEnumerable());
        }
    }
}