namespace Domain.Entities
{
    public class Purchaser : DbEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
