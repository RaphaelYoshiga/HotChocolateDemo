using HotChocolate;
using RYoshiga.HotChocolateDemo.GraphModels;
using RYoshiga.HotChocolateDemo.Services;

namespace RYoshiga.HotChocolateDemo.QueryTypes
{
    public class Query
    {
        public Customer GetProfile([Service]IProfileService service) => service.GetProfile();

    }
}