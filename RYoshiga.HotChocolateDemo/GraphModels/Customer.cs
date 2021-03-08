using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using RYoshiga.HotChocolateDemo.Services;

namespace RYoshiga.HotChocolateDemo.GraphModels
{
    public class Customer
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Task<IEnumerable<Order>> Orders([Service]IOrderRepository orderRepository, [Parent] Customer customer, CancellationToken cancellationToken)
        {
            return orderRepository.GetOrderBy(customer.UserId, cancellationToken);
        }
    }
}