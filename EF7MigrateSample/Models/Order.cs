using System;
using System.Collections.Generic;

namespace EF7NavigationSample.Models
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public DateTime OrderDate { get; set; }
        public Customer Customer { get; set; }
        public List<Pet> Pets { get; set; }
        public Store Store { get; set; }
    }
}
