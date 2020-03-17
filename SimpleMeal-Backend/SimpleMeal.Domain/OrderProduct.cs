using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMeal.Domain
{
    public class OrderProduct
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
        public decimal Cost { get; set; }
        public string Status { get; set; }
    }
}