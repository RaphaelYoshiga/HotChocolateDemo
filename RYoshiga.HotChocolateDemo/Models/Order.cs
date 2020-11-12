using System;
using System.Collections.Generic;

namespace RYoshiga.HotChocolateDemo
{
    public class Order
    {
        public decimal Total { get; set; }
        public DateTime Date { get; set; }

        public List<Item> Items { get; set; }
    }
}