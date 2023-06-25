namespace Domain.Entities
{
    public class Product : DbEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}