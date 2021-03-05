using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RYoshiga.HotChocolateDemo.Services;
using Xunit;
using Moq;
using Newtonsoft.Json;
using Shouldly;

namespace RYoshiga.HotChocolateDemo.Specs
{
    public class ProfileTest
    {
        [Fact]
        public async Task TestProfile()
        {
            var executorBuilder = GetRequestExecutorFromIoc();
            var profileRepositoryMock = new Mock<IProfileRepository>();
            var customer = new Models.Customer()
            {
                FirstName = "Mega",
                LastName = "Test"
            };
            profileRepositoryMock.Setup(p => p.GetProfile())
                .Returns(customer);

            executorBuilder.Services.AddSingleton<IProfileRepository>(profileRepositoryMock.Object);
            var executor = await executorBuilder.BuildRequestExecutorAsync();

            var result = await executor.ExecuteAsync(@"{ profile { firstName lastName} }");

            var json = result.ToJson();

            var response = JsonConvert.DeserializeObject<Root>(json);
            response.data.profile.firstName.ShouldBe("Mega");
            response.data.profile.lastName.ShouldBe("Test");
        }

        private static IRequestExecutorBuilder GetRequestExecutorFromIoc()
        {
            var executorBuilder = new ServiceCollection()
                .AddGraphQL();
            Ioc.RegisterGraphDependencies(executorBuilder);
            Ioc.RegisterServices(executorBuilder.Services);

            return executorBuilder;
        }
    }

    public class Profile
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
    }

    public class Data
    {
        public Profile profile { get; set; }
    }

    public class Root
    {
        public Data data { get; set; }
    }
}
