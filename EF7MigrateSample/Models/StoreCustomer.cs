using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF7NavigationSample.Models
{
    public class StoreCustomer
    {
        public int StoreId { get; set; }
        public int CustomerID { get; set; }
        public Store Store { get; set; }
        public Customer Customer { get; set; }
    }
}
