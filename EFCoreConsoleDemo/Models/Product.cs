using System;
using System.Collections.Generic;

namespace EFCoreConsoleDemo.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int? Size { get; set; }
        public string Variety { get; set; }
        public decimal? Price { get; set; }
        public string Status { get; set; }

        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
