using FluentAssertions;

namespace RYoshiga.HotChocolateDemo.Specs
{
    public class ItemExpectedResponse
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitCost { get; set; }

        public void ShouldMatch(ItemResponse actual)
        {
            actual.Product.Name.Should().Be(ProductName);
            actual.Quantity.Should().Be(Quantity);
            actual.UnitCost.Should().Be(UnitCost);
        }
    }
}