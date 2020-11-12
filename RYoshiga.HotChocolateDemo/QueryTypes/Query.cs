using HotChocolate;
using RYoshiga.HotChocolateDemo.Models;
using RYoshiga.HotChocolateDemo.Services;

namespace RYoshiga.HotChocolateDemo.QueryTypes
{
    public class Query
    {
        public string Hello() => "world";

        public Customer GetProfile([Service]IProfileRepository repository) => repository.GetProfile();

    }
}