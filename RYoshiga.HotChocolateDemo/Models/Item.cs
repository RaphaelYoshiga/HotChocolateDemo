using System;

namespace RYoshiga.HotChocolateDemo
{
    public class Item
    {
        public int Quantity { get; set; }
        public decimal PaidPrice { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}