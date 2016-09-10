namespace EF7NavigationSample.Models
{
    public class StoreCustomer
    {
        public int StoreId { get; set; }
        public int CustomerId { get; set; }
        public Store Store { get; set; }
        public Customer Customer { get; set; }
    }
}
