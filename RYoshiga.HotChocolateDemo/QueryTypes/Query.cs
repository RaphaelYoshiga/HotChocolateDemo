using HotChocolate;

namespace RYoshiga.HotChocolateDemo
{
    public class Query
    {
        public string Hello() => "world";

        public Customer GetProfile([Service]IProfileRepository repository) => repository.GetProfile();

    }
}