using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate.Types;
using RYoshiga.HotChocolateDemo.Models;

namespace RYoshiga.HotChocolateDemo.QueryTypes
{
    public class CustomerType : ObjectType<Customer>
    {
        protected override void Configure(IObjectTypeDescriptor<Customer> descriptor)
        {
            descriptor
                .Field(t => t.Orders)
                .ResolveWith<OrderResolver>(t => t.GetSessionsAsync(default!, default));
        }

        private class OrderResolver
        {
            public async Task<IEnumerable<Order>> GetSessionsAsync(
                Customer customer,
                CancellationToken cancellationToken)
            {
                return await Task.FromResult(new List<Order>()
                {
                    new Order
                    {
                        Total = 1,
                        Items = new List<Item>()
                        {
                            new Item()
                            {
                                PaidPrice = 50,
                                ProductId = Guid.NewGuid(),
                                Quantity = 1
                            }
                        }
                    }
                }.AsEnumerable());
            }
        }
    }
}