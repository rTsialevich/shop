namespace Domain.Entities
{
    public enum OrderStatus : byte
    {
        New = 1,
        InProgress = 2,
        Completed = 3,
    }

    public class Order : DbEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModificatedDate { get; set; }
        public OrderStatus Status { get; set; }
        public int PurchaserId { get; set; }
        public Purchaser Purchaser { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
