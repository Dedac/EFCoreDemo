using System.Collections.Generic;

namespace EF7NavigationSample.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public List<Pet> Stock { get; set; }
        public List<StoreCustomer> Customers { get; set; }
    }
}
