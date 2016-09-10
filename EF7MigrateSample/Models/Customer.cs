using System.Collections.Generic;

namespace EF7NavigationSample.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Order> Orders { get; set; }
        public List<Pet> Pets { get; set; }
        public List<StoreCustomer> Stores { get; set; }
    }
}
