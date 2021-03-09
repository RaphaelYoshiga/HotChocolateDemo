using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Newtonsoft.Json;
using RYoshiga.HotChocolateDemo.GraphModels;
using RYoshiga.HotChocolateDemo.Services;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RYoshiga.HotChocolateDemo.Specs
{
    [Binding]
    public class CustomerOrdersGraphSteps
    {
        private readonly Mock<IProfileService> _profileServiceMock;
        private readonly OrderRepositoryStub _orderRepositoryStub;
        private readonly ItemRepositoryStub _itemsRepositoryStub;
        private readonly ProductRepositoryStub _productsRepositoryStub;
        private RootResponse _rootResponse;
        private IReadOnlyList<IError>? _queryErrors;

        public CustomerOrdersGraphSteps()
        {
            _profileServiceMock = new Mock<IProfileService>();

            _orderRepositoryStub = new OrderRepositoryStub();
            _itemsRepositoryStub = new ItemRepositoryStub();

            _productsRepositoryStub = new ProductRepositoryStub();
        }

        [Given(@"I am logged in as:")]
        public void GivenIAmLoggedInAs(Table table)
        {
            var customer = table.CreateInstance<Customer>();

            _profileServiceMock.Setup(p => p.GetProfile())
                .Returns(customer);
        }

        [Given(@"the customer with id (.*) has placed this order")]
        public void GivenTheCustomerWithIdHasPlacedThisOrder(int customerId, Table table)
        {
            var order = table.CreateInstance<Order>();
            _orderRepositoryStub.Add(customerId, order);
        }

        [Given(@"the order with id (.*) has the following items")]
        public void GivenTheOrderWithIdHasTheFollowingItems(int orderId, Table table)
        {
            var items = table.CreateSet<Item>();

            _itemsRepositoryStub.Add(orderId, items);
        }

        [Given(@"the products repository contains those products")]
        public void GivenTheProductsRepositoryContainsThoseProducts(Table table)
        {
            var products = table.CreateSet<Product>();

            _productsRepositoryStub.Add(products);
        }

        [When(@"I request the graph query with the orders for the current user")]
        public async Task WhenIRequestTheGraphQueryWithTheOrdersForTheCurrentUser()
        {
            var executorBuilder = GetRequestExecutorFromIoc();

            executorBuilder.Services.AddSingleton<IProfileService>(_profileServiceMock.Object);
            executorBuilder.Services.AddSingleton<IOrderRepository>(_orderRepositoryStub);
            executorBuilder.Services.AddSingleton<IItemRepository>(_itemsRepositoryStub);
            executorBuilder.Services.AddSingleton<IProductRepository>(_productsRepositoryStub);

            var executor = await executorBuilder.BuildRequestExecutorAsync();

            var result = await executor.ExecuteAsync(
            @"{
              profile{
                id
                firstName
                lastName
                orders{
                  id  
                  date
                  total
                  items{
                    product{
                      name
                    }
                    quantity
                    unitCost
                  }
                }
              }
            }");

            _queryErrors = result.Errors;

            var json = result.ToJson();
            _rootResponse = JsonConvert.DeserializeObject<RootResponse>(json);
        }

        private static IRequestExecutorBuilder GetRequestExecutorFromIoc()
        {
            var executorBuilder = new ServiceCollection()
                .AddGraphQL();
            Ioc.RegisterGraphDependencies(executorBuilder);
            Ioc.RegisterServices(executorBuilder.Services);

            return executorBuilder;
        }


        [Then(@"I should have no errors")]
        public void ThenIShouldHaveNoErrors()
        {
            _queryErrors.Should().BeNullOrEmpty();
        }


        [Then(@"I should receive this customer")]
        public void ThenIShouldReceiveThisCustomer(Table table)
        {
            var expectedCustomer = table.CreateInstance<Customer>();

            var actualCustomer = _rootResponse.data.profile;
            actualCustomer.Id.Should().Be(expectedCustomer.Id);
            actualCustomer.FirstName.Should().Be(expectedCustomer.FirstName);
            actualCustomer.LastName.Should().Be(expectedCustomer.LastName);
        }

        [Then(@"I should receive those orders")]
        public void ThenIShouldReceiveThoseOrders(Table table)
        {
            var expectedOrders = table.CreateSet<Order>().ToList();

            var actualOrders = _rootResponse.data.profile.Orders;

            actualOrders.Count.Should().Be(expectedOrders.Count);
            for (int i = 0; i < expectedOrders.Count; i++)
            {
                var actual = actualOrders[i];
                var expected = expectedOrders[i];

                actual.Id.Should().Be(expected.Id);
                actual.Date.Should().Be(expected.Date);
                actual.Total.Should().Be(expected.Total);
            }
        }

        [Then(@"the order with Id (.*) should contain those Items")]
        public void ThenTheOrderWithIdShouldContainThoseItems(int orderId, Table table)
        {
            var expectedItems = table.CreateSet<ItemExpectedResponse>().ToList();
            var order = _rootResponse.data.profile.Orders.Single(x => x.Id == orderId);
            var actualItems = order.Items;

            actualItems.Count.Should().Be(expectedItems.Count);

            for (int i = 0; i < actualItems.Count; i++)
            {
                var actual = actualItems[i];
                expectedItems[i].ShouldMatch(actual);
            }
        }

        [Then(@"we should have called the products query only once")]
        public void ThenWeShouldHaveCalledTheProductsQueryOnlyOnce()
        {
            _productsRepositoryStub.VerifyCalledOnlyXTimes(1);
        }

    }
}
