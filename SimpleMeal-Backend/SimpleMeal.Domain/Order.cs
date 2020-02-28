using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleMeal.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; }
        public string ClientName { get; set; }
        public string ClientCpf { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public decimal Price { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
    }
}