using System;

namespace SimpleMeal.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int PreparationTime { get; set; }
        public string PathImage { get; set; }
        public Boolean IsAvaliable { get; set; }
    }
}