using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleMeal.Domain
{
    public class Table
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public Boolean IsAvaliable { get; set; }
    }
}
