namespace RYoshiga.HotChocolateDemo
{
    public interface IProfileRepository
    {
        Customer GetProfile();
    }

    public class ProfileRepository : IProfileRepository
    {
        public Customer GetProfile()
        {
            return new Customer
            {
                Title = "Mr",
                LastName = "Wick",
                FirstName = "John"
            };
        }
    }
}