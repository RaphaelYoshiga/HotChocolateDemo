using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using HotChocolate;
using HotChocolate.Execution;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RYoshiga.HotChocolateDemo.QueryTypes;
using Xunit;

namespace RYoshiga.HotChocolateDemo.Specs
{
    public class SimpleGraphQLTest
    {
        [Fact]
        public async Task RunPingQuery()
        {
            var executor = await new ServiceCollection()
                    .AddGraphQL()
                    .AddQueryType<PingQuery>()
                    .BuildRequestExecutorAsync();

            var result = await executor.ExecuteAsync("{ ping }");

            var json = result.ToJson();
            var pingRootResponse = JsonConvert.DeserializeObject<PingRootResponse>(json);
            pingRootResponse.Data.Ping.Should().BeTrue();
        }
    }

    public class PingQuery
    {
        public bool Ping => true;
    }

    public class PingRootResponse
    {
        public PingResponse Data { get; set; }
    }

    public class PingResponse
    {
        public bool Ping { get; set; }
    }


}
