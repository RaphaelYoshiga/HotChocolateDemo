using System;

namespace RYoshiga.HotChocolateDemo.Models
{
    public class Item
    {
        public int Quantity { get; set; }
        public decimal PaidPrice { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}