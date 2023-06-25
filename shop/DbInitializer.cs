using Domain.Entities;
using Infrastructure.Repositories;

namespace shop
{
    internal static class DbInitializer
    {
        internal static void Initialize(BaseDbContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
            dbContext.Database.EnsureCreated();
            if (dbContext.Products.Any()) return;

            var now = DateTime.UtcNow;

            var products = new Product[]
            {
                new Product{ Name = "car", Price = 9999.99M }
                //add other products
            };

            dbContext.Products.AddRange(products);
            dbContext.SaveChanges();

            var purchasers = new Purchaser[]
            {
                new Purchaser{ Name = "James" }
                //add other purchasers
            };

            dbContext.Purchasers.AddRange(purchasers);
            dbContext.SaveChanges();

            var orders = new Order[]
            {
                new Order{ CreatedDate = now, ModificatedDate = now, Products = products, Status = OrderStatus.InProgress, PurchaserId = purchasers[0].Id }
                //add other orders
            };

            dbContext.Orders.AddRange(orders);
            dbContext.SaveChanges();
        }
    }
}
