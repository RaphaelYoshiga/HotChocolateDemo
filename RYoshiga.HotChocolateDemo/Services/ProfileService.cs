using RYoshiga.HotChocolateDemo.GraphModels;

namespace RYoshiga.HotChocolateDemo.Services
{
    public interface IProfileService
    {
        Customer GetProfile();
    }

    public class ProfileService : IProfileService
    {
        public Customer GetProfile()
        {
            // Generally you will be getting this from the DB by some sort of authentication mechanism
            // Like a signed cookie or a JWT token.

            return new Customer
            {
                Title = "Mr",
                LastName = "Wick",
                FirstName = "John"
            };
        }
    }
}