namespace MediatorWithCQRS.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
    }
}
