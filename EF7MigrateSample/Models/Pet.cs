namespace EF7NavigationSample.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public PetType PetType { get; set; }
        public Order Order { get; set; }
        public Customer Customer { get; set; }
    }

    public enum PetType
    {
        Dog = 1,
        Cat = 2,
        Snake = 3,
        Mongoose = 4,
        Fish = 5
    }

}
