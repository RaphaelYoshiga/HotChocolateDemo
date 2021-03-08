using System;
using System.Collections.Generic;
using System.Text;

namespace RYoshiga.HotChocolateDemo.Specs
{
    public class RootResponse
    {
        public Data data { get; set; }
    }

    public class Profile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<OrderResponse> Orders { get; set; }
        public int Id { get; set; }
    }

    public class OrderResponse
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }

        public List<ItemResponse> Items { get; set; }
    }

    public class ItemResponse
    {
        public decimal UnitCost { get; set; }
        public int Quantity { get; set; }

        public ProductResponse Product { get; set; }
    }

    public class ProductResponse
    {
        public string Name { get; set; }
    }

    public class Data
    {
        public Profile profile { get; set; }
    }
}
